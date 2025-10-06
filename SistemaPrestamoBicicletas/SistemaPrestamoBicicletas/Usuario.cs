using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPrestamoBicicletas
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }

        public List<Prestamo> HistorialPrestamos { get; set; } = new List<Prestamo>();

        public virtual void ConsultarDisponibilidad(List<Bicicleta> bicicletas)
        {
            Console.WriteLine("\nBicicletas disponibles:");
            foreach (var b in bicicletas.Where(b => b.Estado == EstadoBicicleta.Disponible))
                b.MostrarInformacion();
        }

        public void RealizarPrestamo(Bicicleta bicicleta)
        {
            if (bicicleta.Estado == EstadoBicicleta.Disponible)
            {
                Prestamo p = new Prestamo { IdPrestamo = HistorialPrestamos.Count + 1, Bicicleta = bicicleta, Usuario = this };
                p.IniciarPrestamo();
                HistorialPrestamos.Add(p);
            }
            else
            {
                Console.WriteLine("La bicicleta no está disponible.");
            }
        }

        public void DevolverBicicleta()
        {
            var prestamo = HistorialPrestamos.LastOrDefault(p => p.FechaFin == default);
            if (prestamo != null)
                prestamo.FinalizarPrestamo();
            else
                Console.WriteLine("No tienes préstamos activos.");
        }
    }
}