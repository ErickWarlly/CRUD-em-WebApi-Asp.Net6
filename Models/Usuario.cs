using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

    }
}