using System;

namespace SistemaPrestamoBicicletas
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public Bicicleta Bicicleta { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DuracionMinutos { get; set; }
        public double CostoTotal { get; set; }

        public void IniciarPrestamo()
        {
            FechaInicio = DateTime.Now;
            Bicicleta.ActualizarEstado(EstadoBicicleta.EnPrestamo);
            Console.WriteLine($"Préstamo iniciado a las {FechaInicio}");
        }

        public void FinalizarPrestamo()
        {
            FechaFin = DateTime.Now;
            DuracionMinutos = CalcularDuracion();
            CostoTotal = CalcularCosto(Bicicleta.TarifaPorHora);
            Bicicleta.ActualizarEstado(EstadoBicicleta.Disponible);
            Console.WriteLine($"Préstamo finalizado. Duración: {DuracionMinutos} min. Costo total: ${CostoTotal:F2}");
        }

        public int CalcularDuracion()
        {
            return (int)(FechaFin - FechaInicio).TotalMinutes;
        }

        public double CalcularCosto(double tarifaPorHora)
        {
            return (DuracionMinutos / 60.0) * tarifaPorHora;
        }
    }
}