using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastos.ApplicationCore.Entities
{
    public class Entries
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double Value { get; set; } = 0;

        [ForeignKey("Categories")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public int Recurrence { get; set; }
        public DateTime DateTransaction { get; set; } = DateTime.Now;

        public virtual Category? Categories { get; set; }

    }
}
