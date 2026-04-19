using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionSolicitudes
{
    // --- PARTE 1: EL ENUMERADOR ---
    public enum EstadoSolicitud
    {
        Pendiente,
        EnProceso,
        Completada,
        Cancelada
    }

    // --- PARTE 2: LA CLASE ---
    public class Solicitud
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public EstadoSolicitud Estado { get; set; }

        public void MostrarInfo()
        {
            Console.WriteLine($"\n[ID: {Id}] - {Cliente}");
            Console.WriteLine($"Estado: {Estado} | Descripción: {Descripcion}");
            Console.WriteLine("---------------------------------------------");
        }
    }

    // --- PARTE 3: EL PROGRAMA PRINCIPAL ---
    internal class Program
    {
        static List<Solicitud> lista = new List<Solicitud>();
        static int proximoId = 1;

        static void Main(string[] args)
        {
            string opcion = "";
            while (opcion != "5")
            {
                Console.WriteLine("\n--- MENÚ DE SOLICITUDES ---");
                Console.WriteLine("1. Nueva Solicitud");
                Console.WriteLine("2. Ver Todas");
                Console.WriteLine("3. Cambiar Estado");
                Console.WriteLine("4. Buscar por ID");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": Registrar(); break;
                    case "2": Mostrar(); break;
                    case "3": Actualizar(); break;
                    case "4": Buscar(); break;
                }
            }
        }

        static void Registrar()
        {
            Console.Write("Cliente: ");
            string c = Console.ReadLine();
            Console.Write("Descripción: ");
            string d = Console.ReadLine();

            lista.Add(new Solicitud { Id = proximoId++, Cliente = c, Descripcion = d, Estado = EstadoSolicitud.Pendiente });
            Console.WriteLine("✅ Guardado.");
        }

        static void Mostrar()
        {
            if (lista.Count == 0) Console.WriteLine("No hay datos.");
            foreach (var s in lista) s.MostrarInfo();
        }

        static void Actualizar()
        {
            Console.Write("ID a cambiar: ");
            int id = int.Parse(Console.ReadLine());
            var sol = lista.FirstOrDefault(x => x.Id == id);

            if (sol != null)
            {
                Console.WriteLine("Nuevo estado (0:Pendiente, 1:EnProceso, 2:Completada, 3:Cancelada):");
                int nuevo = int.Parse(Console.ReadLine());
                sol.Estado = (EstadoSolicitud)nuevo; // Aquí ocurre la magia del Enum
                Console.WriteLine("✅ Actualizado.");
            }
            else Console.WriteLine("❌ No existe.");
        }

        static void Buscar()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            var sol = lista.FirstOrDefault(x => x.Id == id);
            if (sol != null) sol.MostrarInfo();
            else Console.WriteLine("❌ No encontrado.");
        }
    }
}