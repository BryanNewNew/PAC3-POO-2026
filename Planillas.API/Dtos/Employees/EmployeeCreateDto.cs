using System.ComponentModel.DataAnnotations;

namespace Planillas.API.Dtos.Employees
{
    public class EmployeeCreateDto
    {
        [Display(Name = "Nombres")]//Cambia el nombre del campo
        [Required(ErrorMessage = "Los {0} son requeridos" )]
        [MaxLength(30, ErrorMessage = "Los {0} no pueden tener mas de {1} Caracteres")]
        public string? FirstName { get; set; }
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Los {0} son requeridos")]
        [MaxLength(30, ErrorMessage = "Los {0} deben tener mas de {1} caracteres")]
        public string? LastName { get; set; }
        [Display(Name = "DNI (Documento nacional de identidad)")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "EL {0} no puede tener mas de {1} caracteres")]
        public string? DNI { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(1, ErrorMessage = "El {0} no puede tener mas de {1} caracteres")]
        public string? Gender { get; set; }
    }
}