using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Veterinaria.Modelo
{
    public class ModeloMascota
    {
        //Campos

        private int id;
        private string nombre;
        private string tipo;
        private string color;

        //Properties - Validaciones

        [DisplayName("Id_Mascotas")]
        public int Id 
        { 
            get => id; 
            set => id = value; 
        }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre de la mascota.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string Nombre 
        { 
            get => nombre; 
            set => nombre = value; 
        }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Se requiere el tipo de la mascota.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El tipo de la mascota debe tener entre 3 y 50 caracteres.")]
        public string Tipo 
        { 
            get => tipo; 
            set => tipo = value; 
        }

        [DisplayName("Color")]
        [Required(ErrorMessage = "Se requiere el color de la mascota.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El color de la mascota debe tener entre 3 y 50 caracteres.")]
        public string Color 
        { 
            get => color; 
            set => color = value; 
        }

    }
}
