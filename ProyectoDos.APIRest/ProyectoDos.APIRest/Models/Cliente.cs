using System.ComponentModel.DataAnnotations;

namespace ProyectoDos.APIRest.Modelos
{
    public class Cliente
    {
        [Key]
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public int FechaNacimiento { get; set; }
        public String Telefono { get; set; }
        public String Profesion { get; set; }
        public String Correo { get; set; }
        public String Entero { get; set; }
        public String Contrasenna { get; set; }

        public Cliente(string cedula, string nombre, int fechaNacimiento, string telefono, string profesion, string correo, string entero, string contrasenna)
        {
            Cedula = cedula;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Profesion = profesion;
            Correo = correo;
            Entero = entero;
            Contrasenna = contrasenna;
        }

        public Cliente()
        {
        }
    }
}
