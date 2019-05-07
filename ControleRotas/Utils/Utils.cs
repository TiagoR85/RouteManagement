using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class Utils
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }

    public static void Copy<T>(T source, T destination)
    {
        foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (propertyInfo.GetSetMethod() == null)
                continue;

            var methodName = propertyInfo.Name;
            var sourceValue = typeof(T).GetProperty(methodName).GetValue(source);
            typeof(T).GetProperty(methodName).SetValue(destination, sourceValue);
        }
    }

    public static double Truncate(double value, int places)
    {
        var f = Math.Pow(10, places);
        return Math.Truncate(value * f) / f;
    }

    public static string GetEnumDescription<TEnum>(TEnum value)
    {
        if (value == null)
            return "";

        var field = value.GetType().GetField(value.ToString());
        if (field == null)
            return "";

        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

    public static string ClearFormating(string pTexto)
    {
        pTexto = pTexto.Replace(".", "");
        pTexto = pTexto.Replace(",", "");
        pTexto = pTexto.Replace("/", "");
        pTexto = pTexto.Replace("-", "");
        return pTexto;
    }

    public static bool CpfValidate(string pCpf)
    {
        string valor = ClearFormating(pCpf);
        if (valor.Length != 11)
            return false;

        var todosIguais = true;
        for (var i = 1; i < 14; i++)
        {
            if (valor[i] == valor[0]) continue;

            todosIguais = false;
            break;
        }

        if (todosIguais || valor == "12345678909")
            return false;

        int[] numeros = new int[11];
        for (int i = 0; i < 11; i++)
            numeros[i] = int.Parse(valor[i].ToString());

        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

        int resultado = soma % 11;
        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
                return false;
        }
        else if (numeros[9] != 11 - resultado)
            return false;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];
        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
                return false;
        }
        else if (numeros[10] != 11 - resultado)
            return false;

        return true;
    }

    public static bool CnpjValidate(string pCnpj)
    {
        string cnpj = ClearFormating(pCnpj);
        const string ftmt = "6543298765432";
        var digitos = new int[14];
        var soma = new int[2];
        soma[0] = 0;
        soma[1] = 0;
        var resultado = new int[2];
        resultado[0] = 0;
        resultado[1] = 0;
        var cnpjOk = new bool[2];
        cnpjOk[0] = false;
        cnpjOk[1] = false;

        var todosIguais = true;
        for (var i = 1; i < 14; i++)
        {
            if (cnpj[i] == cnpj[0]) continue;

            todosIguais = false;
            break;
        }

        if (todosIguais)
            return false;

        try
        {
            int nrDig;
            for (nrDig = 0; nrDig < 14; nrDig++)
            {
                digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));
                if (nrDig <= 11)
                    soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                if (nrDig <= 12)
                    soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
            }

            for (nrDig = 0; nrDig < 2; nrDig++)
            {
                resultado[nrDig] = (soma[nrDig] % 11);
                if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);
                else
                    cnpjOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
            }
            return (cnpjOk[0] && cnpjOk[1]);
        }
        catch
        {
            return false;
        }
    }

    public static string MaskCpf(string cpf)
    {
        var cpfOnlyNumbers = Regex.Replace(cpf, @"[^\d]", "");

        var num1 = cpfOnlyNumbers.Substring(0, 3);
        var num2 = cpfOnlyNumbers.Substring(2, 3);
        var num3 = cpfOnlyNumbers.Substring(5, 3);
        var num4 = cpfOnlyNumbers.Substring(8, 2);

        return num1 + "." + num2 + "." + num3 + "-" + num4;
    }

    public static string MaskCnpj(string cnpj)
    {
        var cnpjOnlyNumbers = Regex.Replace(cnpj, @"[^\d]", "");

        var num1 = cnpjOnlyNumbers.Substring(0, 2);
        var num2 = cnpjOnlyNumbers.Substring(2, 3);
        var num3 = cnpjOnlyNumbers.Substring(5, 3);
        var num4 = cnpjOnlyNumbers.Substring(8, 4);
        var num5 = cnpjOnlyNumbers.Substring(12, 2);

        return num1 + "." + num2 + "." + num3 + "/" + num4 + "-" + num5;
    }

    public static string MaskDate(string dateNotMask)
    {
        var dt = dateNotMask.Substring(0, 2);
        dt += "/" + dateNotMask.Substring(2, 2);
        dt += "/" + dateNotMask.Substring(4, 4);

        return dt;
    }

    public static string MaskDouble(string numberNotMask, int qtdDecimals = 2)
    {
        var ret = numberNotMask.Substring(0, numberNotMask.Length - qtdDecimals);
        ret += "," + numberNotMask.Substring(numberNotMask.Length - qtdDecimals, qtdDecimals);

        return ret;
    }

    public static void SendMail(MailAddress pOrigem, MailAddress pDestino, string pAssunto, string pTexto,
        bool pIsHTML, List<MailAddress> pCCO, List<MailAddress> pCC, List<string> pAnexos = null)
    {
        if (pAnexos == null)
            SendMail("naoresponda.edm", "123edm*", pOrigem, pDestino, pAssunto, pTexto, pIsHTML, pCCO, pCC);
        else
            SendMail("naoresponda.edm", "123edm*", pOrigem, pDestino, pAssunto, pTexto, pIsHTML, pCCO, pCC, pAnexos);
    }

    public static void SendMail(string pUsuario, string pSenha, MailAddress pOrigem, MailAddress pDestino,
        string pAssunto, string pTexto, bool pIsHTML, List<MailAddress> pCCO, List<MailAddress> pCC)
    {
        List<string> pAnexos = null;
        SendMail(pUsuario, pSenha, pOrigem, pDestino, pAssunto, pTexto, pIsHTML, pCCO, pCC, pAnexos);
    }

    public static void SendMail(string pUsuario, string pSenha, MailAddress pOrigem, MailAddress pDestino,
        string pAssunto, string pTexto, bool pIsHTML, List<MailAddress> pCCO, List<MailAddress> pCC,
        List<string> pAnexos)
    {
        using (SmtpClient mSmtp = new SmtpClient("mail.edm.com.br", 25))
        {
            using (MailMessage Message = new MailMessage(pOrigem, pDestino))
            {
                try
                {
                    Message.Subject = pAssunto;
                    Message.Body = pTexto;
                    Message.IsBodyHtml = pIsHTML;

                    if (pCCO != null)
                        foreach (MailAddress mBcc in pCCO)
                            Message.Bcc.Add(mBcc);

                    if (pCC != null)
                        foreach (MailAddress mCC in pCC)
                            Message.CC.Add(mCC);

                    if (pAnexos != null)
                    {
                        foreach (string mArquivo in pAnexos)
                        {
                            Attachment mAnexo = new Attachment(mArquivo);
                            Message.Attachments.Add(mAnexo);
                        }
                    }
                    mSmtp.EnableSsl = false;
                    mSmtp.Credentials = new NetworkCredential(pUsuario, pSenha);
                    mSmtp.Send(Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Falha ao tentar enviar email", ex);
                }
            }
        }
    }

    public static string GetPathCertificateFolder(int idContractor, int idEnterprise)
    {
        var directoryCertificateFiles = GetDirectoryEnterprise(idContractor, idEnterprise) + "\\CertificateFiles";
        if (!Directory.Exists(directoryCertificateFiles))
            Directory.CreateDirectory(directoryCertificateFiles);

        return directoryCertificateFiles;
    }

    public static string GetPathShippingFolder(int idContractor, int idEnterprise)
    {
        var directoryShippingBankingFiles = GetDirectoryEnterprise(idContractor, idEnterprise) + "\\ShippingBankingFiles";
        if (!Directory.Exists(directoryShippingBankingFiles))
            Directory.CreateDirectory(directoryShippingBankingFiles);

        return directoryShippingBankingFiles;
    }

    public static string GetPathReturnBankigFolder(int idContractor, int idEnterprise)
    {
        var directoryReturnBankingFiles = GetDirectoryEnterprise(idContractor, idEnterprise) + "\\ReturnBankingFiles";
        if (!Directory.Exists(directoryReturnBankingFiles))
            Directory.CreateDirectory(directoryReturnBankingFiles);

        return directoryReturnBankingFiles;
    }

    public static string GetPathTempFolder(int idContractor, int idEnterprise)
    {
        var tempFolder = GetDirectoryEnterprise(idContractor, idEnterprise) + "\\TempFolder";
        if (!Directory.Exists(tempFolder))
            Directory.CreateDirectory(tempFolder);

        return tempFolder;
    }

    public static string GetPathReturnGeneralFolder(int idContractor, int idEnterprise)
    {
        var directoryReturnBankingFiles = GetDirectoryEnterprise(idContractor, idEnterprise) + "\\GeneralFiles";
        if (!Directory.Exists(directoryReturnBankingFiles))
            Directory.CreateDirectory(directoryReturnBankingFiles);

        return directoryReturnBankingFiles;
    }

    private static string GetDirectoryEnterprise(int idContractor, int idEnterprise)
    {
        const string directoryApplication = "C:\\FolderHANDpaper";
        if (!Directory.Exists(directoryApplication))
            Directory.CreateDirectory(directoryApplication);

        var directoryContractor = directoryApplication + "\\FolderContractorId_" + idContractor;
        if (!Directory.Exists(directoryContractor))
            Directory.CreateDirectory(directoryContractor);

        var directoryEnterprise = directoryContractor + "\\FolderEnterprise" + idEnterprise;
        if (!Directory.Exists(directoryEnterprise))
            Directory.CreateDirectory(directoryEnterprise);

        return directoryEnterprise;
    }

    /// <summary>
    /// Gera hash MD5
    /// </summary>
    /// <param name="input">String a ser aplicado o hash</param>
    /// <returns>String já aplicado o hash MD5</returns>
    public static string HashMd5(string input)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }

    /// <summary>
    /// Transforma um object em query string.
    /// </summary>
    /// <param name="pObject">Objeto a ser tranformado em query string</param>
    /// <returns>String no formato query string</returns>
    public static string ObjectToQueryString(object pObject)
    {
        var properties = from p in pObject.GetType().GetProperties()
                         where p.GetValue(pObject, null) != null
                         select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(pObject, null).ToString());

        return String.Join("&", properties.ToArray());
    }

    public static X509Certificate2 GetCertificate(int idKeyContractor, int idKeyEnterprise,
        string certificateFileName, string certificatePassword)
    {
        string pathCertificate = "";
        try
        {
            pathCertificate = GetPathCertificateFolder(idKeyContractor, idKeyEnterprise);
            pathCertificate = pathCertificate + "\\" + certificateFileName;

            var x509Cert = new X509Certificate2(pathCertificate, certificatePassword, X509KeyStorageFlags.MachineKeySet);
            return x509Cert;
        }
        catch (Exception ex)
        {
            var pathFormated = pathCertificate;
            var splitPath = pathCertificate.Split('\\');
            var quebra = 2;
            if (splitPath.Count() <= 3)
                throw new Exception("Erro de acesso ao certificado \n" + pathFormated + "\n Retorno: " + ex.Message);

            pathFormated = "";
            for (int i = 0; i < splitPath.Count(); i++)
            {
                if (i == 0)
                {
                    pathFormated += splitPath[i];
                    continue;
                }

                pathFormated += "\\" + splitPath[i];
                if (i != quebra)
                    continue;

                pathFormated += "\n";
                quebra = quebra + quebra;
            }
            throw new Exception("Erro de acesso ao certificado \n" + pathFormated + "\n Retorno: " + ex.Message);
        }
    }

    public static string SignXmlSha1(string xmlString, string tagAssinatura, X509Certificate2 x509Cert)
    {
        // Create a new XML document.
        var xmlDocument = new XmlDocument
        {
            // Format the document to ignore white spaces.
            PreserveWhitespace = false
        };

        // Load the passed XML file using it’s name.
        xmlDocument.LoadXml(xmlString);

        if (xmlDocument.GetElementsByTagName(tagAssinatura).Count == 0)
            throw new Exception("A tag de assinatura " + tagAssinatura.Trim() + " não existe no XML.");

        XmlNodeList lists = xmlDocument.GetElementsByTagName(tagAssinatura);
        foreach (XmlNode nodes in lists)
        {
            // Create a reference to be signed
            Reference reference = new Reference();
            reference.Uri = "";

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmlDocument);

            // Add the key to the SignedXml document
            signedXml.SigningKey = x509Cert.PrivateKey;

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform envelopedSignature = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(envelopedSignature);

            XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
            reference.AddTransform(c14);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Create a new KeyInfo object
            KeyInfo keyInfo = new KeyInfo();

            // Load the certificate into a KeyInfoX509Data object and add it to the KeyInfo object.
            keyInfo.AddClause(new KeyInfoX509Data(x509Cert));

            // Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo;
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            nodes.AppendChild(xmlDocument.ImportNode(xmlDigitalSignature, true));
        }
        var xmlDoc = xmlDocument;
        string conteudoXmlAssinado = xmlDoc.OuterXml;

        return conteudoXmlAssinado;
    }

    public static string XmlSerialize<T>(T dataToSerialize, bool omitXmlDeclaration = true)
    {
        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = omitXmlDeclaration
        };

        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var stringwriter = new StringWriter();
        var serializer = new XmlSerializer(typeof(T));
        using (var writer = XmlWriter.Create(stringwriter, settings))
        {
            serializer.Serialize(writer, dataToSerialize, emptyNamepsaces);
            return stringwriter.ToString();
        }
    }

    public static T XmlDeserialize<T>(string xmlText)
    {
        var stringReader = new StringReader(xmlText);
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(stringReader);
    }

    public static void CreateFile(string pathFileName, string archiveContent)
    {
        StreamWriter streamWriter = new StreamWriter(pathFileName);
        streamWriter.WriteLine(archiveContent);
        streamWriter.Close();
    }

    public static void DeleteFile(string pathFileName)
    {
        try
        {
            using (StreamWriter sw = File.CreateText(pathFileName)) { }

            // Ensure that the target does not exist.
            File.Delete(pathFileName);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static string Encript(string value)
    {
        Byte[] criptValue = Encoding.ASCII.GetBytes(value);
        var keyCript = Convert.ToBase64String(criptValue);
        return keyCript;
    }

    public static string Decript(string value)
    {
        Byte[] criptValue = Convert.FromBase64String(value);
        var keyCript = Encoding.ASCII.GetString(criptValue);
        return keyCript;
    }
}