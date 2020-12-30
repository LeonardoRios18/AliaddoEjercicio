using Aliaddo_Ejercicio_Practica.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aliaddo_Ejercicio_Practica.Models
{
    public class Padre
    {

        public int PadreID { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get { return LName + " " + Name; }
        }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Nombres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Apellidos")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "N° de Documento")]
        public string NDocument { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Direccion de Residencia")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Correo Electronico no valido")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "N° de Telefono")]
        public string PhoneN { get; set; }

        [Required(ErrorMessage = "Campo obligatorio ")]
        [Display(Name = "Genero")]
        public Genero Gender { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "¿Tiene Hijos?")]
        public THijos Children { get; set; }

        public ICollection<Hijo> Hijos { get; set; }
    }
}
