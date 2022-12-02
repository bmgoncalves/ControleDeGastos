using ControleDeGastos.ApplicationCore.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.ApplicationCore.Models
{
    public class EntriesViewModel
    {
        public DateTime DateTransaction { get; set; } = DateTime.Now;

        [DisplayName("Value")]
        [Required(ErrorMessage = "Informe o valor")]
        public double Value { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Recurrence")]
        public int Recurrence { get; set; }

    }
}
