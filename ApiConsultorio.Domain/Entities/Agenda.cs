using ApiConsultorio.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Agenda : Entity
    {
        public string Paciente { get; set; }


        //PRIMEIRO ATENDIMENTO
        //CONSULTA

        public string TipoServico { get; set; }

        public string TipoSessao { get; set; }

        public DateTime InicioSessao { get; set; }

        public DateTime FimSessao { get; set; }


        //MENSAL
        //AVULSO
        public int TipoPagamento { get; set; }


        public Decimal ValorSessao { get; set; }

        //REGRAS
        //1 - QUANDO FOR PRIMEIRA CONSULTA, OS CAMPOS TIPO PAGAMENTO E VALOR SESSÃO VÃO ESTA DESABILITADOS
        //2 - QUANDO FOR CONSULTA, O CAMPO TIPOPAGAMENTO E VALORSESSAO VAO SER CARREGADOS ATRAVES DO CADASTRO DO PACIENTE
        //3 - ESTES CAMPOS, VÃO SER APENAS VISUALIZAÇÃO

        public bool SessaoRecorrente { get; set; }

        //1 - 1 SEMANA
        //2 - 2 SEMANA
        //3 - 3 SEMANA
        //4 - 4 SEMANA
        public int TipoRecorrencia { get; set; }


        //DIAS DA SEMANA
        public int DiaRecorrencia { get; set; }

        public int Quantidade { get; set; }
    }
}
