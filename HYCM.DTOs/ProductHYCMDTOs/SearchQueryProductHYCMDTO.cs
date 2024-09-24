using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYCM.DTOs.ProductHYCMDTOs
{
    public class SearchQueryProductHYCMDTO
    {
        [Display(Name = "Nombre")]
        public string? NombreHYCM_Like { get; set; }
        [Display(Name = "Pagina")]
        public int Skip { get; set; }
        [Display(Name = "CantReg x Pagina")]
        public int Take { get; set; }
        public byte SendRowCount { get; set; }
    }
}

