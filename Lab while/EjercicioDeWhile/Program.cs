Console.WriteLine("Adivina el numero");

    {
        Console.WriteLine("Se generara un numero random del 0 al 50, adivina cual es.");
        Random generador = new Random();
        int aleatorio = generador.Next(0, 51);
        int intento = -1;

        Console.WriteLine("Adivina el numero entre 0 y 50");
        
        while (intento != aleatorio)
        {
            Console.WriteLine("Ingresa tu numero:");
            if (int.TryParse(Console.ReadLine(), out intento))
            {
                if (intento < aleatorio)
                {
                    Console.WriteLine("El numero es mayor.");
                }
                else if (intento > aleatorio)
                {
                    Console.WriteLine("El numero es menor.");
                }
                else
                {
                    Console.WriteLine("Felicidades Adivinaste el numero.");
                }
            }
            else
            {
                Console.WriteLine("Ese no es, ingresa un número válido.");
            }
        }
    }

