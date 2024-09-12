using Microsoft.Extensions.Caching.Memory;
using ProyectoDos.APIRest.Modelos;
using ProyectoDos.APIRest.Models;

namespace ProyectoDos.APIRest.Datos
{
    public class DatosFactura : IDatosFactura
    {
        private readonly ConexionBDcontext contextBD;
        public DatosFactura(ConexionBDcontext contextBD)
        {
            this.contextBD = contextBD;
        }

        int i = 0;
        public async Task<Boolean> Crear(Factura factura)
        {
            foreach (Producto producto in factura.Productos.ToList())
            {
                i++;
                FacturaIntermedia facturaIntermedia = new FacturaIntermedia();
                facturaIntermedia.FacturaId = factura.IdFactura;
                facturaIntermedia.ProductoId = producto.id;
                contextBD.FacturaIntermedia.AddAsync(facturaIntermedia);
            }

            foreach (Tour tour in factura.Tours.ToList())
            {
                i++;
                FacturaTour facturaTour = new FacturaTour();
                facturaTour.FacturaId = factura.IdFactura;
                facturaTour.TourId = tour.Id;
                contextBD.FacturaTour.AddAsync(facturaTour);
            }

            contextBD.Factura.Add(factura);
            contextBD.SaveChanges();
            return false;
        }

        //metodo para obtener la lista de personas
        public async Task<List<Factura>> ObtenerLista()
        {
            IEnumerable<Factura> facturas;
            IEnumerable<FacturaIntermedia> facturaIntermedias = contextBD.FacturaIntermedia.ToList();
            IEnumerable<FacturaTour> facturaTours = contextBD.FacturaTour.ToList();
            facturas = contextBD.Factura.ToList();

            foreach (var factura in facturas)
            {
                foreach (var facturaTour in facturaTours)
                {
                    if (factura.IdFactura == facturaTour.FacturaId)
                    {
                        Tour tour = contextBD.Tour.Where(w => w.Id == facturaTour.TourId).Single();
                        factura.Tours.Add(tour);
                    }
                }
                foreach (var facturaIntermedia in facturaIntermedias)
                {
                    if (factura.IdFactura == facturaIntermedia.FacturaId)
                    {
                        Producto producto = contextBD.Producto.Where(w => w.id == facturaIntermedia.ProductoId).Single();
                        factura.Productos.Add(producto);
                    }
                }
            }
            return (List<Factura>)facturas;
        }

        public async Task<Factura> sacar(String id)
        {
            List<Factura> lista;
            lista = await ObtenerLista();

            foreach (Factura factura in lista)
            {
                if (factura.IdFactura.Equals(id))
                    return factura;
            }
            return null;
        }

    }
}
