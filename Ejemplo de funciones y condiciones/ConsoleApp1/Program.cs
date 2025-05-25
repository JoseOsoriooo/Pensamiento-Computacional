//Console.WriteLine("Hola, por favor ingrese su nombre::");
//string nombre = Console.ReadLine();
//Saludar();

//Console.WriteLine("Ahora ingrese un número para calcular su factorial:");
//int numero = Convert.ToInt32(Console.ReadLine());
//int factorial = CalcularFactorial(numero);
//Console.WriteLine($"El factorial de {numero} es {factorial}");
//void Saludar()
//{
  //  Console.WriteLine($"Buenos días, {nombre}");
//}

//int CalcularFactorial(int numero)
//{
  //  int resultado = 1;
   // for (int i = numero; i > 0; i--)
    //{
      //  resultado = resultado * i;
    //}
    //return resultado;
//}

using System;


    {
        int opcion;

        do
{
    MostrarMenu();
    opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 3:
            MostrarInformacionProgramador("Tu Nombre");
            break;
        case 1:
            Console.Write("Ingrese la temperatura en Celsius: ");
            double celsius = Convert.ToDouble(Console.ReadLine());
            double fahrenheit = CelsiusAFahrenheit(celsius);
            Console.WriteLine($"La temperatura en Fahrenheit es: {fahrenheit}°F");
            break;
        case 2:
            Console.Write("Ingrese la temperatura en Fahrenheit: ");
            double fahrenheitInput = Convert.ToDouble(Console.ReadLine());
            double celsiusOutput = FahrenheitACelsius(fahrenheitInput);
            Console.WriteLine($"La temperatura en Celsius es: {celsiusOutput}°C");
            break;
        case 4:
            Console.WriteLine("Saliendo del programa");
            break;
        default:
            Console.WriteLine("Intentar de nuevo, la opcion que eligio no es valida.");
            break;
    }

    Console.WriteLine(); // Espacio entre iteraciones del menú
} while (opcion != 4);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Menú de opciones:");
        Console.WriteLine("1. Pasar de Celsius a Fahrenheit");
        Console.WriteLine("2. Pasar de Fahrenheit a Celsius");
        Console.WriteLine("3. Información del programador");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static double CelsiusAFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double FahrenheitACelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static void MostrarInformacionProgramador(string nombre)
{
    Console.WriteLine("Información del programador:");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine("Descripción: Programa de conversión de temperaturas entre Celsius y Fahrenheit.");
} 