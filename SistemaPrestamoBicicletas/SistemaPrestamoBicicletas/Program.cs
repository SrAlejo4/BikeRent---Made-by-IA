using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPrestamoBicicletas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Bicicleta> bicicletas = new List<Bicicleta>();
            Administrador admin = new Administrador { Nombre = "Admin" };
            Usuario usuario = new Usuario { Nombre = "Alejandro" };

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n===== SISTEMA DE PRÉSTAMO DE BICICLETAS =====");
                Console.WriteLine("1. Registrar bicicleta (Admin)");
                Console.WriteLine("2. Ver bicicletas disponibles");
                Console.WriteLine("3. Realizar préstamo");
                Console.WriteLine("4. Devolver bicicleta");
                Console.WriteLine("5. Actualizar información de bicicleta (Admin)");
                Console.WriteLine("6. Eliminar bicicleta (Admin)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
                        Console.Write("Tipo: "); string tipo = Console.ReadLine();
                        Console.Write("Marca: "); string marca = Console.ReadLine();
                        Console.Write("Color: "); string color = Console.ReadLine();
                        Console.Write("Tarifa por hora: "); double tarifa = double.Parse(Console.ReadLine());
                        Bicicleta nueva = new Bicicleta(id, tipo, marca, color, tarifa);
                        admin.RegistrarBicicleta(bicicletas, nueva);
                        break;

                    case "2":
                        usuario.ConsultarDisponibilidad(bicicletas);
                        break;

                    case "3":
                        Console.Write("Ingrese el ID de la bicicleta: ");
                        int idPrestamo = int.Parse(Console.ReadLine());
                        var biciPrestamo = bicicletas.FirstOrDefault(b => b.IdBicicleta == idPrestamo);
                        if (biciPrestamo != null)
                            usuario.RealizarPrestamo(biciPrestamo);
                        else
                            Console.WriteLine("Bicicleta no encontrada.");
                        break;

                    case "4":
                        usuario.DevolverBicicleta();
                        break;

                    case "5":
                        Console.Write("ID de bicicleta a actualizar: ");
                        int idAct = int.Parse(Console.ReadLine());
                        var biciAct = bicicletas.FirstOrDefault(b => b.IdBicicleta == idAct);
                        if (biciAct != null)
                        {
                            Console.Write("Nuevo tipo: "); string ntipo = Console.ReadLine();
                            Console.Write("Nueva marca: "); string nmarca = Console.ReadLine();
                            Console.Write("Nuevo color: "); string ncolor = Console.ReadLine();
                            Console.Write("Nueva tarifa por hora: "); double ntarifa = double.Parse(Console.ReadLine());
                            admin.ActualizarBicicleta(biciAct, ntipo, nmarca, ncolor, ntarifa);
                        }
                        else
                            Console.WriteLine("Bicicleta no encontrada.");
                        break;

                    case "6":
                        Console.Write("ID de bicicleta a eliminar: ");
                        int idDel = int.Parse(Console.ReadLine());
                        admin.EliminarBicicleta(bicicletas, idDel);
                        break;

                    case "0":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }

            Console.WriteLine("\nFin del programa. ¡Gracias por usar el sistema!");
        }
    }
}