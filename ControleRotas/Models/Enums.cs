using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleRotas.Models
{
    public class Enums
    {
        public enum TipoEndereco
        {
            [Display(Name ="Residencial")] Residencial,
            [Display(Name ="Comercial")] Comercial,
            [Display(Name ="Entrega")] Entrega,
            [Display(Name ="Cobrança")] Cobranca
        }

        public enum TipoUrgencia
        {
            Alta,
            [Display(Name ="Média")] Media,
            Baixa
        }

        public enum TipoPessoa
        {
            [Display(Name ="Pessoa Jurídica")] Pessoa_Juridica,
            [Display(Name ="Pessoa Física")] Pessoa_Fisica
        }

        public enum TipoConfirmacao
        {
            [Display(Name ="Confirmado")] Confirmado,
            [Display(Name ="Ausência")] Ausente
        }

        public enum TipoContrante
        {
            [Display(Name ="Fornecedor")] Fornecedor,
            [Display(Name ="Cliente")] Cliente,
			[Display(Name ="Funcionário")] Usuario
        }

        public enum TipoTelefone
        {
            [Display(Name ="Celular")] Celular,
			[Display(Name ="Residencial")] Residencial,
            [Display(Name ="Comercial")] Comercial
        }

        public enum TipoConta
        {
            [Display(Name ="Pagar")] Pagar,
            [Display(Name ="Receber")] Receber
        }

        public enum TipoFrequencia
        {
            [Display(Name ="Semanal")] Semanal,
            [Display(Name ="Quinzenal")] Quinzenal,
            [Display(Name ="Mensal")] Mensal,
            [Display(Name ="Bimestral")] Bimestral,
            [Display(Name ="Semestral")] Semestral,
            [Display(Name ="Anual")] Anual
        }

        public enum TipoParcela
        {
            [Display(Name ="Valor Dividido")] Valor_Dividido,
            [Display(Name ="Valor Repetido")] Valor_Repetido
        }

        public enum TipoOrdenacaoConta
        {
            [Display(Name ="Data de Vencimento")] Vencimento,
            [Display(Name ="Data de Quitação")] Quitacao
        }

        public enum TipoSituacaoConta
        {
            [Display(Name ="Em Aberto")] Aberto,
            [Display(Name ="Quitado")] Quitado,
            [Display(Name ="Todas")] Todas,
            [Display(Name ="Isento")] Isento,
            [Display(Name ="Perda")] Perda
        }

        public enum TipoFiltroConta
        {
            [Display(Name ="Data de Vencimento")] DataDeVencimento,
            [Display(Name ="Data de Emissão")] DataDeEmissao,
            [Display(Name ="Data de Quitação")] DataDeQuitacao
        }

        public enum TipoSituacao
        {
            [Display(Name ="Ativo")] Ativo,
            [Display(Name ="Inativo")] Inativo,
        }

        public enum TipoMarcaBandeira
        {
            [Display(Name ="American Express")] AmericanExpress,
            [Display(Name ="Elo")] Elo,
            [Display(Name ="Hipercard")] Hipercard,
            [Display(Name ="Master Card")] MasterCard,
            [Display(Name ="Visa")] Visa,
            [Display(Name ="Diners Club")] DinersClub,
            [Display(Name ="BNDES")] BNDES,
            [Display(Name ="Outras Bandeiras")] Outros
        }

        public enum EnumContaMovimentacao
        {
            [Display(Name ="Caixa")] Caixa = 0,
            [Display(Name ="Banco")] Banco = 1,
            [Display(Name ="Cartão de Crédito")] CartaoCredito = 2,
        }

        public enum EnumFuncaoMovimento
        {
            [Display(Name ="Inserção de Movimentação")] Insercao = 0,
            [Display(Name ="Saldo Inicial")] SaldoInicial = 1,
            [Display(Name ="Inserção Manual de Movimentação")] InsercaoManual = 2,
            [Display(Name ="Desfazer Inserção de Movimentação")] DesfazerInsercao = 3
        }

        public enum EnumTipoMovimento
        {
            [Display(Name ="Débito")] Debito = 0,
            [Display(Name ="Crédito")] Credito = 1,
        }

        public enum EnumEspecie
        {
            [Display(Name ="Dinheiro")] Dinheiro,
            [Display(Name ="Cheque")] Cheque,
            [Display(Name ="Cartão")] Cartao
        }

        public enum TipoRelatorio
        {
            [Display(Name ="Analítico")] Analitico,       // Completo
            [Display(Name ="Sintetizado")] Sintetizado    // Por Data
        }

        public enum EnumTipoFormaPagamento
        {
            [Display(Name ="Pagamento")] Pagamento,
            [Display(Name ="Recebimento")] Recebimento
        }

        public enum EnumTipoItemComercializavel
        {
            [Display(Name ="Produto")] Produto,
            [Display(Name ="Serviço")] Servico
        }

        public enum EnumTipoLancamento
        {
            [Display(Name ="Entrada")] Entrada,
            [Display(Name ="Saída")] Saida
        }

        public enum EnumTipoLancamentoSaida
        {
            [Display(Name ="Venda")] Venda,
            [Display(Name ="Orçamento")] Orcamento
        }

        public enum EnumBancoBoleto
        {
            [Display(Name ="Banco do Brasil")] BancodoBrasil = 1,
            [Display(Name ="Banco Banrisul")] Banrisul = 41,
            [Display(Name ="Banco BASA")] Basa = 3,
            [Display(Name ="Banco Bradesco")] Bradesco = 237,
            [Display(Name ="Banco BRB")] BRB = 70,
            [Display(Name ="Caixa Econômica Federal")] Caixa = 104,
            [Display(Name ="Banco HSBC")] HSBC = 399,
            [Display(Name ="Banco Itaú")] Itau = 341,
            [Display(Name ="Banco Real")] Real = 356,
            [Display(Name ="Banco Safra")] Safra = 422,
            [Display(Name ="Banco Santander")] Santander = 33,
            [Display(Name ="Banco Sicoob")] Sicoob = 756,
            [Display(Name ="Banco Sicred")] Sicred = 748,
            [Display(Name ="Banco Sudameris")] Sudameris = 347,
            [Display(Name ="Itaú Unibanco")] Unibanco = 409,
            [Display(Name ="Itaú Unicred")] Unicred = 136
        }

        public enum EnumTipoComissao
        {
            [Display(Name ="")] SemComissao = 0,
            [Display(Name ="Percentual")] Percentual = 1,
            [Display(Name ="Moeda")] Moeda = 2
        }

        public enum EnumTipoRepresentanteSaida
        {
            Contrato = 1,
            Venda = 2
        }

        public enum EnumTipoReajusteValores
        {
            [Display(Name ="Acréscimo no Valor")] Acrescimo,
            [Display(Name ="Desconto no Valor")] Desconto
        }

        public enum EnumSituacaoParcela
        {
            [Display(Name ="Normal")] Normal,
            [Display(Name ="Isento")] Isento,
            [Display(Name ="Perda")] Perda
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
            [Display(Name ="Venda")] Venda,
            [Display(Name ="Deposito")] Deposito,
            [Display(Name ="Retirada")] Retirada,
            [Display(Name ="Recebimento de Convênio")] RecebimentoConvenio,
            [Display(Name ="Abertura")] Abertura
        }

        public enum EnumTipoSimNao
        {
            [Display(Name ="Não")] Nao = 0,
            [Display(Name ="Sim")] Sim = 1,
        }

        public enum EnumSituacaoBoleto
        {
            [Display(Name ="Somente em Abertos")] SomenteAberto = 0,
            [Display(Name ="Somente em Quitados")] SomenteQuitado = 1
        }

        public enum EnumSituacaoContrato
        {
            [Display(Name ="Somente em Ativos")] Ativo = 0,
            [Display(Name ="Somente em Inativos")] Inativo = 1,
            [Display(Name ="Todos")] Todos = 2
        }

        public enum EnumTipoServico
        {
            [Display(Name ="Serviço Normal")] Normal = 0,
            [Display(Name ="Pacote de Serviços")] Pacote = 1
        }

        public enum EnumBuscaCep
        {
            [Display(Name ="ViaCep")] ViaCep = 0,
            [Display(Name ="Correios")] Correios = 1
        }
		
		public enum EnumEstadosBr
		{
			Acre,
			Alagoas,
			[Display(Name ="Amapá")] Amapa,
			Amazonas,
			Bahia,
			[Display(Name ="Ceará")] Ceara,
			[Display(Name ="Distrito Federal")] DistritoFederal,
			[Display(Name ="Espírito Santo")] EspiritoSanto,
			[Display(Name ="Goiás")] Goias,
			[Display(Name ="Maranhão")] Maranhao,
			[Display(Name ="Mato Grosso")] MatoGrosso,
			[Display(Name ="Mato Grosso do Sul")] MatoGrossoSul,
			[Display(Name ="Minas Gerais")] MinasGerais,
			[Display(Name ="Pará")] Para,
			[Display(Name ="Paraíba")] Paraiba,
			[Display(Name ="Paraná")] Parana,
			Pernambuco,
			[Display(Name ="Piauí")] Piaui,
			[Display(Name ="Rio de Janeiro")] RioJaneiro,
			[Display(Name ="Rio Grande do Norte")] RioGrandeNorte,
			[Display(Name ="Rio Grande do Sul")] RioGrandeSul,
			[Display(Name ="Rondônia")] Rondonia,
			Roraima,
			[Display(Name ="Santa Catarina")] SantaCatarina,
			[Display(Name ="São Paulo")] SaoPaulo,
			Sergipe,
			Tocantins
		}
		
		public enum EnumMarcaVeiculo
		{
			CHEVROLET,
			VOLKSWAGEN,
			FIAT,
            [Display(Name ="MERCEDES-BENZ")] MERCEDESBENZ,
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
            [Display(Name ="ALFA ROMEO")] ALFAROMEO,
			AMERICAR,
            [Display(Name ="ASTON MARTIN")] ASTONMARTIN,
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
            [Display(Name ="LAND ROVER")] LANDROVER,
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
