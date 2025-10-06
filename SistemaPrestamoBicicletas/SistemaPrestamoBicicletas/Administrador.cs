using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPrestamoBicicletas
{
    public class Administrador : Usuario
    {
        public void RegistrarBicicleta(List<Bicicleta> lista, Bicicleta bicicleta)
        {
            lista.Add(bicicleta);
            Console.WriteLine($"Bicicleta {bicicleta.IdBicicleta} registrada correctamente.");
        }

        public void ActualizarBicicleta(Bicicleta bicicleta, string tipo, string marca, string color, double tarifa)
        {
            bicicleta.Tipo = tipo;
            bicicleta.Marca = marca;
            bicicleta.Color = color;
            bicicleta.TarifaPorHora = tarifa;
            Console.WriteLine("Información de la bicicleta actualizada.");
        }

        public void EliminarBicicleta(List<Bicicleta> lista, int idBicicleta)
        {
            var bici = lista.FirstOrDefault(b => b.IdBicicleta == idBicicleta);
            if (bici != null)
            {
                lista.Remove(bici);
                Console.WriteLine($"Bicicleta {idBicicleta} eliminada del sistema.");
            }
            else
                Console.WriteLine("Bicicleta no encontrada.");
        }
    }
}