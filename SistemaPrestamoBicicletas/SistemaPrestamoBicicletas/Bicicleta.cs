using System;

namespace SistemaPrestamoBicicletas
{
    public class Bicicleta
    {
        public int IdBicicleta { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public EstadoBicicleta Estado { get; set; }
        public double TarifaPorHora { get; set; }

        public Bicicleta(int id, string tipo, string marca, string color, double tarifa)
        {
            IdBicicleta = id;
            Tipo = tipo;
            Marca = marca;
            Color = color;
            Estado = EstadoBicicleta.Disponible;
            TarifaPorHora = tarifa;
        }

        public void ActualizarEstado(EstadoBicicleta nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {IdBicicleta} | Tipo: {Tipo} | Marca: {Marca} | Color: {Color} | Estado: {Estado} | Tarifa: ${TarifaPorHora}/h");
        }
    }
}