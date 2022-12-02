using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastos.ApplicationCore.Entities
{
    public class Entries
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTransaction { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="Informe o valor")]
        public double Value { get; set; }

        [ForeignKey("Categories")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public int Recurrence { get; set; }

        public virtual Category? Categories { get; set; }

    }
}
