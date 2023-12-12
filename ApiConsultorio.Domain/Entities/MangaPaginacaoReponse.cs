using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Domain.Entities
{
	public class MangaPaginacaoReponse
	{
		public List<Manga>? Mangas { get; set; }
		public int TotalPaginas { get; set; }
	}
}
