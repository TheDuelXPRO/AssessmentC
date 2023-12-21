using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Jogador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nao pode ficar em branco")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nao pode ficar em branco")]
        public string Posicao { get; set; }
        [Required(ErrorMessage = "Nao pode ficar em branco")]
        public string Time { get; set; }

        public int numero { get; set; }

    }
}
