using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Models.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El nombre es demasaido largo")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "La edad es requerida")]
        public int Edad { get; set; }

        //[Required(ErrorMessage = "El genero es requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El genero es demasaido largo")]
        public string Genero { get; set; }

        public bool Maneja { get; set; }

        public bool UsaLentes { get; set; }

        public bool EsDiabetico { get; set; }

        public bool OtraEnfermedad { get; set; }

        [StringLength(maximumLength: 1000, ErrorMessage = "Nombre de enfermedad/es es demasaido largo")]
        public string Enfermedad { get; set; }
    }
}
