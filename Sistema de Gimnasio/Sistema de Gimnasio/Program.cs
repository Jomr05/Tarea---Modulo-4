using System;
using System.Collections.Generic;
using System.Linq;

class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Edad: {Edad}, Teléfono: {Telefono}, Correo: {Correo}";
    }
}

class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static int nextId = 1;

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n*** Registro de clientes del Gimnasio ***");
            Console.WriteLine("1. Dar de alta un cliente");
            Console.WriteLine("2. Mostrar detalles de un cliente");
            Console.WriteLine("3. Listar clientes");
            Console.WriteLine("4. Buscar cliente (Nombre)");
            Console.WriteLine("5. Dar de baja un cliente");
            Console.WriteLine("6. Modificar un cliente");
            Console.WriteLine("7. Salir");
            Console.Write("Selecciona una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1: DarAltaCliente(); break;
                    case 2: MostrarDetallesCliente(); break;
                    case 3: ListarClientes(); break;
                    case 4: BuscarClientePorNombre(); break;
                    case 5: DarBajaCliente(); break;
                    case 6: ModificarCliente(); break;
                    case 7: Console.WriteLine("¡Hasta luego!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
        } while (opcion != 7);
    }

    static void DarAltaCliente()
    {
        Console.Write("Ingresa el nombre del cliente: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingresa la edad del cliente: ");
        int edad = int.Parse(Console.ReadLine());
        Console.Write("Ingresa el teléfono del cliente: ");
        string telefono = Console.ReadLine();
        Console.Write("Ingresa el correo del cliente: ");
        string correo = Console.ReadLine();

        clientes.Add(new Cliente { Id = nextId++, Nombre = nombre, Edad = edad, Telefono = telefono, Correo = correo });
        Console.WriteLine("Cliente dado de alta exitosamente.");
    }

    static void MostrarDetallesCliente()
    {
        Console.Write("Ingresa el ID del cliente: ");
        int id = int.Parse(Console.ReadLine());
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            Console.WriteLine(cliente);
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }

    static void ListarClientes()
    {
        if (clientes.Count > 0)
        {
            Console.WriteLine("\nLista de clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente);
            }
        }
        else
        {
            Console.WriteLine("No hay clientes registrados.");
        }
    }

    static void BuscarClientePorNombre()
    {
        Console.Write("Ingresa el nombre del cliente: ");
        string nombre = Console.ReadLine();
        var resultados = clientes.Where(c => c.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
        if (resultados.Count > 0)
        {
            Console.WriteLine("Clientes encontrados:");
            foreach (var cliente in resultados)
            {
                Console.WriteLine(cliente);
            }
        }
        else
        {
            Console.WriteLine("No se encontraron clientes con ese nombre.");
        }
    }

    static void DarBajaCliente()
    {
        Console.Write("Ingresa el ID del cliente a dar de baja: ");
        int id = int.Parse(Console.ReadLine());
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            clientes.Remove(cliente);
            Console.WriteLine("Cliente eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }

    static void ModificarCliente()
    {
        Console.Write("Ingresa el ID del cliente a modificar: ");
        int id = int.Parse(Console.ReadLine());
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            Console.Write("Nuevo nombre (deja vacío para no cambiar): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) cliente.Nombre = nuevoNombre;

            Console.Write("Nueva edad (deja vacío para no cambiar): ");
            string nuevaEdad = Console.ReadLine();
            if (int.TryParse(nuevaEdad, out int edad)) cliente.Edad = edad;

            Console.Write("Nuevo teléfono (deja vacío para no cambiar): ");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoTelefono)) cliente.Telefono = nuevoTelefono;

            Console.Write("Nuevo correo (deja vacío para no cambiar): ");
            string nuevoCorreo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoCorreo)) cliente.Correo = nuevoCorreo;

            Console.WriteLine("Cliente modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
        Console.ReadKey();
    }
}

