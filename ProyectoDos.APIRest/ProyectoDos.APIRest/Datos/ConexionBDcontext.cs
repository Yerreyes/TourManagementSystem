using Microsoft.EntityFrameworkCore;
using ProyectoDos.APIRest.Modelos;
using ProyectoDos.APIRest.Models;

namespace ProyectoDos.APIRest.Datos
{
    public class ConexionBDcontext: DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<FacturaIntermedia> FacturaIntermedia { get; set; }
        public DbSet<FacturaTour> FacturaTour { get; set; }

        //forma estandarizada
        public ConexionBDcontext(DbContextOptions<ConexionBDcontext> options) : base(options)
        {


        }

    


    }
}
