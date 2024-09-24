using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYCM.DTOs.ProductHYCMDTOs
{
    public class SearchResultProductHYCMDTO
    {
        public int CountRow { get; set; }
        public List<ProductHYCM>? Data { get; set; }
        public class ProductHYCM
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string? NombreHYCM { get; set; }

            [Display(Name = "Descripcion")]
            public string? DescripcionHYCM { get; set; }

            [Display(Name = "Precio")]
            public decimal PrecioHYCM { get; set; }
        }
    }
}
