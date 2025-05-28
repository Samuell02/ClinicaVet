
namespace ClinicaVetAPI.Models
{
using System.ComponentModel.DataAnnotations.Schema;

    public class Pet
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raça { get; set; } 
         [ForeignKey("Tutor")]
        public int Tutorid { get; set; }

        public Tutor? Tutor { get; set; }
    }
}