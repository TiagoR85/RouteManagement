using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Exceptions
{
    public class ExceptionDadosObrigatoriosInvalidos : ExceptionApp
    {
        public enum TypeDadosObrigatorios
        {
            Email,
            Telefone,
            Agenda,
            Endereco
        }

        public ExceptionDadosObrigatoriosInvalidos(TypeDadosObrigatorios pTipoDadosObrigatorios)
            : base(string.Format("Dados obrigatórios de {0} são inválidos ou nulos.", pTipoDadosObrigatorios))
        {

        }

        public ExceptionDadosObrigatoriosInvalidos(Type typeData, string descriptionField)
            : base(string.Format("O Dado obrigatório '{0}' de {1} é inválido ou nulo.", descriptionField, typeData.Name))
        {

        }

    }
}
