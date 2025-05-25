class Program
{
    static void Main(string[] args)
    {
        Estacionamiento sistema = new Estacionamiento();
        sistema.Iniciar();
    }
}

class Estacionamiento
{
    Dictionary<string, (string marca, string color, string tipo, string placa, int horaEntrada)> informacionVehiculo
        = new Dictionary<string, (string, string, string, string, int)>();
    int estacionamientosPorPiso;
    int pisosHabilitados;

    public void Iniciar()
    {
        // Se demostrara el sistema de estacionamientos
        Console.WriteLine("Sistema de estacionamientos:");

        estacionamientosPorPiso = PedirNumero("Ingrese la cantidad de estacionamientos por piso: ");
        pisosHabilitados = PedirNumero("Ingrese la cantidad de pisos habilitados al público: ");
        int estacionamientosMoto = PedirNumero("Ingrese la cantidad de estacionamientos tipo 'Moto': ");
        int estacionamientosSUV = PedirNumero("Ingrese la cantidad de estacionamientos tipo 'SUV': ");

        int totalEstacionamientos = estacionamientosPorPiso * pisosHabilitados;

        // Verificar que la suma de los estacionamientos de con el total disponible y que no se pase del total
        if (estacionamientosMoto + estacionamientosSUV > totalEstacionamientos)
        {
            Console.WriteLine("Ocurrio un error ya La suma de estacionamientos tipo Moto y SUV excede el total disponible.");
            return;
        }

        int estacionamientosSedan = totalEstacionamientos - (estacionamientosMoto + estacionamientosSUV);

        Console.WriteLine("\nConfiguración completada:");
        Console.WriteLine($"Total de estacionamientos: {totalEstacionamientos}");
        Console.WriteLine($"Estacionamientos tipo Moto: {estacionamientosMoto}");
        Console.WriteLine($"Estacionamientos tipo SUV: {estacionamientosSUV}");
        Console.WriteLine($"Estacionamientos tipo Sedán: {estacionamientosSedan}");

        // Menú principal
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Ingresar un vehículo manualmente");
            Console.WriteLine("2. Ingresar lote de vehículos");
            Console.WriteLine("3. Encontrar un vehículo");
            Console.WriteLine("4. Retirar un vehículo");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    IngresarVehiculo();
                    break;
                case "2":
                    Console.WriteLine("¿Cuántos vehículos desea ingresar? ");
                    int cantidad = PedirNumero("");
                    IngresarLoteVehiculos(cantidad);
                    break;
                case "3":
                    EncontrarVehiculo();
                    break;
                case "4":
                    RetirarVehiculo();
                    break;
                case "5":
                    Console.WriteLine("Saliendo del sistema de parqueo...");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

     public void IngresarVehiculo()
    {
        Console.WriteLine("\n Ingresar un vehículo");
        string[] marcasValidas = { "Honda", "Mazda", "Hyundai", "Toyota", "Suzuki" };
        Console.WriteLine("Marca del vehículo (Honda, Mazda, Hyundai, Toyota, Suzuki): ");
        string marca = Console.ReadLine();
        while (Array.IndexOf(marcasValidas, marca) == -1)
        {
            Console.WriteLine("Marca inválida. Ingrese una de las siguientes (Honda, Mazda, Hyundai, Toyota, Suzuki): ");
            marca = Console.ReadLine();
        }
        string[] coloresValidos = { "Rojo", "Azul", "Negro", "Gris", "Blanco" };
        Console.WriteLine("Color del vehículo: (Rojo, Azul, Negro, Gris, Blanco) ");
        string color = Console.ReadLine();

        Console.WriteLine("Placa del vehículo (3 números seguidos de 3 letras en mayúsculas, sin vocales ni Ñ): ");
        string placa = Console.ReadLine();
        while (!EsPlacaValida(placa))
        {
            Console.WriteLine("Placa inválida. Ingrese una placa con 3 números seguidos de 3 letras en mayúsculas (sin vocales ni Ñ): ");
            placa = Console.ReadLine();
        }

        Console.WriteLine("Tipo de vehículo (moto, sedán, SUV): ");
        string tipo = Console.ReadLine().ToLower();
        while (tipo != "moto" && tipo != "sedán" && tipo != "suv")
        {
            Console.WriteLine("Tipo inválido. Ingrese 'moto', 'sedán' o 'SUV': ");
            tipo = Console.ReadLine().ToLower();
        }

        int horaEntrada = PedirNumero("Hora de entrada (entre 6 y 20): ", 6, 20);

        MostrarMapaEstacionamientos(tipo);
        //Ingresar el código del estacionamiento para el vehículo
        // Verificar que el código sea válido y que no esté ocupado
        Console.WriteLine("Ingrese el código del estacionamiento: ");
        string codigoEstacionamiento = Console.ReadLine();
        while (!EsCodigoValido(codigoEstacionamiento) || informacionVehiculo.ContainsKey(codigoEstacionamiento))
        {
            Console.WriteLine("El estacionamiento no es válido o ya está ocupado. Ingrese otro código: ");
            codigoEstacionamiento = Console.ReadLine();
        }

        informacionVehiculo[codigoEstacionamiento] = (marca, color, tipo, placa, horaEntrada);
        Console.WriteLine($"Vehículo con placa {placa} registrado en el estacionamiento {codigoEstacionamiento}.");
    }
    // Ingresar un lote de vehículos donde se generaran aleatoriamente
    // Se generaran aleatoriamente los datos de los vehículos
    public void IngresarLoteVehiculos(int cantidad)
    {
        string[] marcas = { "Honda", "Mazda", "Hyundai", "Toyota", "Suzuki" };
        string[] colores = { "Rojo", "Azul", "Negro", "Gris", "Blanco" };
        string[] tipos = { "moto", "sedán", "suv" };
        Random aleatorio = new Random();

        List<(string placa, string codigo)> registrados = new List<(string, string)>();

        for (int i = 0; i < cantidad; i++)
        {
            string marca = marcas[aleatorio.Next(marcas.Length)];
            string color = colores[aleatorio.Next(colores.Length)];
            string tipo = tipos[aleatorio.Next(tipos.Length)];
            int horaEntrada = aleatorio.Next(6, 21);

            string placa;
            bool placaCliente;
            do
            {
                placa = GenerarPlacaAleatoria(aleatorio);
                placaCliente = true;
                foreach (var vehiculo in informacionVehiculo.Values)
                {
                    if (vehiculo.placa == placa)
                    {
                        placaCliente = false;
                        break;
                    }
                }
            } while (!placaCliente);

            string codigoEstacionamiento = null;
            for (int piso = 1; piso <= pisosHabilitados && codigoEstacionamiento == null; piso++)
            {
                for (int espacio = 1; espacio <= estacionamientosPorPiso; espacio++)
                {
                    string codigo = $"P{piso}E{espacio}";
                    if (!informacionVehiculo.ContainsKey(codigo))
                    {
                        codigoEstacionamiento = codigo;
                        break;
                    }
                }
            }

            if (codigoEstacionamiento != null)
            {
                informacionVehiculo[codigoEstacionamiento] = (marca, color, tipo, placa, horaEntrada);
                registrados.Add((placa, codigoEstacionamiento));
            }
        }
        // Mostrar los vehículos registrados
        Console.WriteLine("\nVehículos registrados en el lote:");
        if (registrados.Count == 0)
        {
            Console.WriteLine("No se pudo registrar ningún vehículo. El parqueo está lleno.");
        }
        else
        {
            foreach (var vehiculoRegistrado in registrados)
            {
                Console.WriteLine($"Placa: {vehiculoRegistrado.placa} - Estacionamiento: {vehiculoRegistrado.codigo}");
            }
        }

        MostrarMapaEstacionamientos("todos");
    }
    // Buscar un vehículo por su placa y mostrar la información del vehículo
    // Se mostrara la información del vehículo y el estacionamiento donde se encuentra
     public void EncontrarVehiculo()
    {
        Console.WriteLine("Ingrese la placa del vehículo a buscar: ");
        string placaBuscada = Console.ReadLine();

        bool encontrado = false;
        foreach (var registro in informacionVehiculo)
        {
            var info = registro.Value;
            if (info.placa == placaBuscada)
            {
                Console.WriteLine("Vehículo encontrado:");
                Console.WriteLine($"Estacionamiento: {registro.Key}");
                Console.WriteLine($"Marca: {info.marca}");
                Console.WriteLine($"Color: {info.color}");
                Console.WriteLine($"Tipo: {info.tipo}");
                Console.WriteLine($"Placa: {info.placa}");
                Console.WriteLine($"Hora de entrada: {info.horaEntrada}");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Vehículo no encontrado en el sistema.");
        }
    }
    // Retirar un vehículo del estacionamiento
    // Se mostrara el monto a pagar dependiendo del tiempo de estadía
    // Se mostrara el método de pago y se realizara el pago ya sea con tarjeta, efectivo o sticker y se retirara el vehículo ya una vez pagando todo
     public void RetirarVehiculo()
    {
        Console.WriteLine("Ingrese el código del estacionamiento donde está su vehículo: ");
        string codigo = Console.ReadLine();

        if (!informacionVehiculo.ContainsKey(codigo))
        {
            Console.WriteLine("No se encontró ningún vehículo en ese código de estacionamiento.");
            return;
        }

        int horaEntrada = informacionVehiculo[codigo].horaEntrada;

        Random aleatorio = new Random();
        int horaSalida = aleatorio.Next(horaEntrada + 1, 25);
        int horasTotales = horaSalida - horaEntrada;
        if (horasTotales < 1) horasTotales = 1;

        int monto = 0;
        if (horasTotales <= 1)
            monto = 0;
        else if (horasTotales <= 4)
            monto = 15;
        else if (horasTotales <= 7)
            monto = 45;
        else if (horasTotales <= 12)
            monto = 60;
        else
            monto = 150;
        // Mostrar información del vehículo
        Console.WriteLine("Información del vehículo:");
        Console.WriteLine($"Tiempo de estadía: {horasTotales} horas");
        if (monto == 0)
            Console.WriteLine("Monto a pagar: Cortesía (Q0)");
        else
            Console.WriteLine($"Monto a pagar: Q{monto}");
        // se preguntara si desea pagar con tarjeta, efectivo o sticker
        Console.WriteLine("¿Cómo desea pagar? (tarjeta/efectivo/sticker): ");
        string metodo = Console.ReadLine().ToLower();

        if (metodo == "tarjeta" || metodo == "sticker")
        {
            Console.WriteLine("Pago realizado con éxito. Puede retirar su vehículo.");
            informacionVehiculo.Remove(codigo);
            MostrarMapaEstacionamientos("todos");
            return;
        }
        else if (metodo == "efectivo")
        {
            if (monto == 0)
            {
                Console.WriteLine("No es necesario realizar pago. Puede retirar su vehículo.");
                informacionVehiculo.Remove(codigo);
                MostrarMapaEstacionamientos("todos");
                return;
            }
            // Se mostrara el monto a pagar y se preguntara por el billete
            int[] billetesValidos = { 100, 50, 20, 10, 5 };
            int pago = 0;
            while (pago < monto)
            {
                Console.WriteLine($"Ingrese un billete (100, 50, 20, 10, 5). Total ingresado: Q{pago}. Falta: Q{monto - pago}");
                string entrada = Console.ReadLine();
                int billete;
                if (int.TryParse(entrada, out billete) && Array.Exists(billetesValidos, b => b == billete))
                {
                    pago += billete;
                }
                else
                {
                    Console.WriteLine("Billete no válido. Solo se aceptan billetes de 100, 50, 20, 10 o 5.");
                }
            }
            // Se mostrara el cambio y el vuelto entregado
            int cambio = pago - monto;
            if (cambio > 0)
            {
                Console.WriteLine($"Su cambio es de: Q{cambio}");
                int[] billetes = { 100, 50, 20, 10, 5 };
                Console.WriteLine("Vuelto entregado: ");
                foreach (int b in billetes)
                {
                    int cantidad = cambio / b;
                    if (cantidad > 0)
                    {
                        Console.WriteLine($"{cantidad} billetes de Q{b}  ");
                        cambio -= cantidad * b;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Pago realizado con éxito. Puede retirar su vehículo.");
            informacionVehiculo.Remove(codigo);
            MostrarMapaEstacionamientos("todos");
        }
        else
        {
            Console.WriteLine("Método de pago no válido.");
        }
    }

    string GenerarPlacaAleatoria(Random random)
    {
        string letrasValidas = "BCDFGHJKLMNPQRSTVWXYZ";
        string placa = "";
        for (int i = 0; i < 3; i++)
            placa += random.Next(0, 10).ToString();
        for (int i = 0; i < 3; i++)
            placa += letrasValidas[random.Next(letrasValidas.Length)];
        return placa;
    }

    bool EsPlacaValida(string placa)
    {
        if (placa.Length != 6) return false;
        for (int i = 0; i < 3; i++)
        {
            if (!char.IsDigit(placa[i])) return false;
        }
        string letrasInvalidas = "AEIOUÑ";
        for (int i = 3; i < 6; i++)
        {
            if (!char.IsUpper(placa[i]) || letrasInvalidas.Contains(placa[i])) return false;
        }
        return true;
    }

    // Matriz del mapa de estacionamientos
    // Mostrar el mapa de estacionamientos
    // Se mostrara el mapa de estacionamientos con los espacios ocupados
    void MostrarMapaEstacionamientos(string tipo)
{
    Console.WriteLine($"\nMapa de estacionamientos ({pisosHabilitados} pisos x {estacionamientosPorPiso} espacios):");
    // Encabezado de columnas
    Console.WriteLine("      ");
    for (int columnas = 1; columnas <= estacionamientosPorPiso; columnas++)
    {
        Console.WriteLine($"E{columnas,3} ");
    }
    Console.WriteLine();

    for (int piso = 1; piso <= pisosHabilitados; piso++)
    {
        Console.WriteLine($"Piso {piso,2}: ");
        for (int espacio = 1; espacio <= estacionamientosPorPiso; espacio++)
        {
            string codigo = $"P{piso}E{espacio}";
            if (informacionVehiculo.ContainsKey(codigo))
            {
                Console.WriteLine("  X  ");
            }
            else
            {
                Console.WriteLine($"{codigo,5}");
            }
        }
        Console.WriteLine();
    }
}

    int PedirNumero(string mensaje, int min = int.MinValue, int max = int.MaxValue)
    {
        int valor;
        Console.WriteLine(mensaje);
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
        {
            Console.WriteLine($"Entrada inválida. {mensaje}");
        }
        return valor;
    }

    bool EsCodigoValido(string codigo)
    {
        if (!codigo.StartsWith("P")) return false;

        string[] partes = codigo.Substring(1).Split('E');
        if (partes.Length != 2) return false;

        if (!int.TryParse(partes[0], out int piso) || piso < 1 || piso > pisosHabilitados) return false;
        if (!int.TryParse(partes[1], out int espacio) || espacio < 1 || espacio > estacionamientosPorPiso) return false;

        return true;
    }
}