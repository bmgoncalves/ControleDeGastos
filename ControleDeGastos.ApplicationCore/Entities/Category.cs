using System.ComponentModel.DataAnnotations;

namespace ControleDeGastos.ApplicationCore.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }
        public int Type { get; set; }

    }
}
