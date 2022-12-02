using ControleDeGastos.ApplicationCore.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.ApplicationCore.Models
{
    public class CategoryViewModel
    {
        [Required]
        public string? Description { get; set; }

        public TypeTransactionEnum Type { get; set; }
    }
}
