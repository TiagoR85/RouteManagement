using System.ComponentModel;

namespace ControleRotas.Models
{
    public class Enums
    {
        public enum TipoEndereco
        {
            [Description("Residencial")] Residencial,
            [Description("Comercial")] Comercial,
            [Description("Entrega")] Entrega,
            [Description("Cobrança")] Cobranca
        }

        public enum TipoUrgencia
        {
            Alta,
            [Description("Média")] Media,
            Baixa
        }

        public enum TipoPessoa
        {
            [Description("Pessoa Jurídica")] Pessoa_Juridica,
            [Description("Pessoa Física")] Pessoa_Fisica
        }

        public enum TipoConfirmacao
        {
            [Description("Confirmado")] Confirmado,
            [Description("Ausência")] Ausente
        }

        public enum TipoContrante
        {
            [Description("Fornecedor")] Fornecedor,
            [Description("Cliente")] Cliente,
			[Description("Funcionário")] Usuario
        }

        public enum TipoTelefone
        {
            [Description("Celular")] Celular,
			[Description("Residencial")] Residencial,
            [Description("Comercial")] Comercial
        }

        public enum TipoConta
        {
            [Description("Pagar")] Pagar,
            [Description("Receber")] Receber
        }

        public enum TipoFrequencia
        {
            [Description("Semanal")] Semanal,
            [Description("Quinzenal")] Quinzenal,
            [Description("Mensal")] Mensal,
            [Description("Bimestral")] Bimestral,
            [Description("Semestral")] Semestral,
            [Description("Anual")] Anual
        }

        public enum TipoParcela
        {
            [Description("Valor Dividido")] Valor_Dividido,
            [Description("Valor Repetido")] Valor_Repetido
        }

        public enum TipoOrdenacaoConta
        {
            [Description("Data de Vencimento")] Vencimento,
            [Description("Data de Quitação")] Quitacao
        }

        public enum TipoSituacaoConta
        {
            [Description("Em Aberto")] Aberto,
            [Description("Quitado")] Quitado,
            [Description("Todas")] Todas,
            [Description("Isento")] Isento,
            [Description("Perda")] Perda
        }

        public enum TipoFiltroConta
        {
            [Description("Data de Vencimento")] DataDeVencimento,
            [Description("Data de Emissão")] DataDeEmissao,
            [Description("Data de Quitação")] DataDeQuitacao
        }

        public enum TipoSituacao
        {
            [Description("Ativo")] Ativo,
            [Description("Inativo")] Inativo,
        }

        public enum TipoMarcaBandeira
        {
            [Description("American Express")] AmericanExpress,
            [Description("Elo")] Elo,
            [Description("Hipercard")] Hipercard,
            [Description("Master Card")] MasterCard,
            [Description("Visa")] Visa,
            [Description("Diners Club")] DinersClub,
            [Description("BNDES")] BNDES,
            [Description("Outras Bandeiras")] Outros
        }

        public enum EnumContaMovimentacao
        {
            [Description("Caixa")] Caixa = 0,
            [Description("Banco")] Banco = 1,
            [Description("Cartão de Crédito")] CartaoCredito = 2,
        }

        public enum EnumFuncaoMovimento
        {
            [Description("Inserção de Movimentação")] Insercao = 0,
            [Description("Saldo Inicial")] SaldoInicial = 1,
            [Description("Inserção Manual de Movimentação")] InsercaoManual = 2,
            [Description("Desfazer Inserção de Movimentação")] DesfazerInsercao = 3
        }

        public enum EnumTipoMovimento
        {
            [Description("Débito")] Debito = 0,
            [Description("Crédito")] Credito = 1,
        }

        public enum EnumEspecie
        {
            [Description("Dinheiro")] Dinheiro,
            [Description("Cheque")] Cheque,
            [Description("Cartão")] Cartao
        }

        public enum TipoRelatorio
        {
            [Description("Analítico")] Analitico,       // Completo
            [Description("Sintetizado")] Sintetizado    // Por Data
        }

        public enum EnumTipoFormaPagamento
        {
            [Description("Pagamento")] Pagamento,
            [Description("Recebimento")] Recebimento
        }

        public enum EnumTipoItemComercializavel
        {
            [Description("Produto")] Produto,
            [Description("Serviço")] Servico
        }

        public enum EnumTipoLancamento
        {
            [Description("Entrada")] Entrada,
            [Description("Saída")] Saida
        }

        public enum EnumTipoLancamentoSaida
        {
            [Description("Venda")] Venda,
            [Description("Orçamento")] Orcamento
        }

        public enum EnumBancoBoleto
        {
            [Description("Banco do Brasil")] BancodoBrasil = 1,
            [Description("Banco Banrisul")] Banrisul = 41,
            [Description("Banco BASA")] Basa = 3,
            [Description("Banco Bradesco")] Bradesco = 237,
            [Description("Banco BRB")] BRB = 70,
            [Description("Caixa Econômica Federal")] Caixa = 104,
            [Description("Banco HSBC")] HSBC = 399,
            [Description("Banco Itaú")] Itau = 341,
            [Description("Banco Real")] Real = 356,
            [Description("Banco Safra")] Safra = 422,
            [Description("Banco Santander")] Santander = 33,
            [Description("Banco Sicoob")] Sicoob = 756,
            [Description("Banco Sicred")] Sicred = 748,
            [Description("Banco Sudameris")] Sudameris = 347,
            [Description("Itaú Unibanco")] Unibanco = 409,
            [Description("Itaú Unicred")] Unicred = 136
        }

        public enum EnumTipoComissao
        {
            [Description("")] SemComissao = 0,
            [Description("Percentual")] Percentual = 1,
            [Description("Moeda")] Moeda = 2
        }

        public enum EnumTipoRepresentanteSaida
        {
            Contrato = 1,
            Venda = 2
        }

        public enum EnumTipoReajusteValores
        {
            [Description("Acréscimo no Valor")] Acrescimo,
            [Description("Desconto no Valor")] Desconto
        }

        public enum EnumSituacaoParcela
        {
            [Description("Normal")] Normal,
            [Description("Isento")] Isento,
            [Description("Perda")] Perda
        }

        public enum EnumTipoNotaFiscal
        {
            NotaVenda = 1,
            NotaServico = 2
        }

        public enum EnumStatusPeoples
        {
            Ativo,
            Inativo,
            Todos
        }

        public enum EnumTipoValorConferenciaCaixa
        {
            [Description("Venda")] Venda,
            [Description("Deposito")] Deposito,
            [Description("Retirada")] Retirada,
            [Description("Recebimento de Convênio")] RecebimentoConvenio,
            [Description("Abertura")] Abertura
        }

        public enum EnumTipoSimNao
        {
            [Description("Não")] Nao = 0,
            [Description("Sim")] Sim = 1,
        }

        public enum EnumSituacaoBoleto
        {
            [Description("Somente em Abertos")] SomenteAberto = 0,
            [Description("Somente em Quitados")] SomenteQuitado = 1
        }

        public enum EnumSituacaoContrato
        {
            [Description("Somente em Ativos")] Ativo = 0,
            [Description("Somente em Inativos")] Inativo = 1,
            [Description("Todos")] Todos = 2
        }

        public enum EnumTipoServico
        {
            [Description("Serviço Normal")] Normal = 0,
            [Description("Pacote de Serviços")] Pacote = 1
        }

        public enum EnumBuscaCep
        {
            [Description("ViaCep")] ViaCep = 0,
            [Description("Correios")] Correios = 1
        }
		
		public enum EnumEstadosBr
		{
			Acre,
			Alagoas,
			[Description("Amapá")] Amapa,
			Amazonas,
			Bahia,
			[Description("Ceará")] Ceara,
			[Description("Distrito Federal")] DistritoFederal,
			[Description("Espírito Santo")] EspiritoSanto,
			[Description("Goiás")] Goias,
			[Description("Maranhão")] Maranhao,
			[Description("Mato Grosso")] MatoGrosso,
			[Description("Mato Grosso do Sul")] MatoGrossoSul,
			[Description("Minas Gerais")] MinasGerais,
			[Description("Pará")] Para,
			[Description("Paraíba")] Paraiba,
			[Description("Paraná")] Parana,
			Pernambuco,
			[Description("Piauí")] Piaui,
			[Description("Rio de Janeiro")] RioJaneiro,
			[Description("Rio Grande do Norte")] RioGrandeNorte,
			[Description("Rio Grande do Sul")] RioGrandeSul,
			[Description("Rondônia")] Rondonia,
			Roraima,
			[Description("Santa Catarina")] SantaCatarina,
			[Description("São Paulo")] SaoPaulo,
			Sergipe,
			Tocantins
		}
		
		public enum EnumMarcaVeiculo
		{
			CHEVROLET,
			VOLKSWAGEN,
			FIAT,
            [Description("MERCEDES-BENZ")] MERCEDESBENZ,
			CITROEN,
			CHANA,
			HONDA,
			SUBARU,
			FERRARI,
			BUGATTI,
			LAMBORGHINI,
			FORD,
			HYUNDAI,
			JAC,
			KIA,
			GURGEL,
			DODGE,
			CHRYSLER,
			BENTLEY,
			SSANGYONG,
			PEUGEOT,
			TOYOTA,
			RENAULT,
			ACURA,
			ADAMO,
			AGRALE,
            [Description("ALFA ROMEO")] ALFAROMEO,
			AMERICAR,
            [Description("ASTON MARTIN")] ASTONMARTIN,
			AUDI,
			BIANCO,
			BMW,
			BORGWARD,
			NISSAN,
            CHAMONIX,
            CHEDA,
            CHERY,
            CORD,
            COYOTE,
            DAEWOO,
            DAIHATSU,
            VOLVO,
            DETOMAZO,
            DELOREAN,
            SUZUKI,
            EAGLE,
            EFFA,
            ENGESA,
            FNM,
            PONTIAC,
            PORSCHE,
            HAFEI,
            HOFSTETTER,
            HUDSON,
            HUMMER,
            INFINITI,
            JAGUAR,
            JEEP,
            JINBEI,
            KAISER,
            KOENIGSEGG,
            LADA,
            LANCIA,
            [Description("LAND ROVER")] LANDROVER,
            LEXUS,
            LIFAN,
            LINCOLN,
            LOBINI,
            LOTUS,
            MAHINDRA,
            MASERATI,
            MATRA,
            MAYBACH,
            MAZDA,
            MENON,
            MERCURY,
            MITSUBISHI,
            MG,
            MINI,
            MIURA,
            MORRIS,
            NISSIN,
            PAGANI,
            PLYMOUTH,
            PUMA,
            RENO,
            [DisplayName("ROLLS-ROYCE")] ROLLSROYCE,
            ROMI,
            SEAT,
            SHINERAY,
            SAAB,
            SMART,
            TAC,
            TRIUMPH,
            TROLLER,
            UNIMOG,
            WIESMANN,
            CADILLAC,
            OUTROS,
            IVECO,
            TRAILER,
            RANDON,
            SCANIA,
            ONIBUS,
            NAVISTAR,
            SINOTRUK,
            SCHIFFER,
            GUERRA,
            MICHIGAN
        }
    }
}
