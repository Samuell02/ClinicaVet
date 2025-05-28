namespace ClinicaVetAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tutor
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Nome não pode conter numeros ou caracteres especiais.")]
        public string Nome { get; set; } 
        [MaxLength(11, ErrorMessage = "Telefones não podem ter mais que 11 caracteres")]

        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}