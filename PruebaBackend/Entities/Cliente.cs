using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Entities
{
    public class Cliente : EntityBase
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El nombre es demasaido largo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El genero es requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El genero es demasaido largo")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Saber si maneja es requerido")]
        public bool Maneja { get; set; }

        [Required(ErrorMessage = "Saber si usa lentes es requerido")]
        public bool UsaLentes { get; set; }

        [Required(ErrorMessage = "Saber si es diabetico es requerido")]
        public bool EsDiabetico { get; set; }

        [Required(ErrorMessage = "Saber si posee otra enfermedad es requerido")]
        public bool OtraEnfermedad { get; set; }

        [StringLength(maximumLength: 1000, ErrorMessage = "Nombre de enfermedad/es es demasaido largo")]
        public string Enfermedad { get; set; }
    }
}
