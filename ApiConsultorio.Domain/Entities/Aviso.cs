using ApiConsultorio.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
    public class Aviso : Entity
    {
        public Paciente? Paciente { get; set; }

        public int? PacienteId { get; set; }

        public string? PacienteNome { get; set; }

        //aniversario do mes
        //falta de pagamento
        public int? Categoria { get; set; }

        //Para fazer exclusão logica
        //1 = Ativo (ele foi lido, mas nao foi excluido pela tela)
        //0 = Inativo (ele foi lido e excluido pela tela)
        public int? Ativo { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Descricao { get; set; }
    }
}
