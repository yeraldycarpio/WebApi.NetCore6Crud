using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYCM.DTOs.ProductHYCMDTOs
{
    public class EditProductHYCMDTO
    {
        public EditProductHYCMDTO(GetIdResultProductHYCMDTO get)
        {
            Id = get.Id;
            NombreHYCM = get.NombreHYCM;
            DescripcionHYCM = get.DescripcionHYCM;
            PrecioHYCM = get.PrecioHYCM;
        }

        public EditProductHYCMDTO()
        {
            NombreHYCM = string.Empty;
        }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de 50 caracteres")]
        public string NombreHYCM { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de 50 caracteres")]
        public string? DescripcionHYCM { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal PrecioHYCM { get; set; }
    }
}
