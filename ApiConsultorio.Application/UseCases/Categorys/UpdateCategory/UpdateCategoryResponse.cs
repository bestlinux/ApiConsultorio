using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Application.UseCases.Categorys.UpdateCategory
{
    public sealed record UpdateCategoryResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? IconCSS { get; set; }
    }
}
