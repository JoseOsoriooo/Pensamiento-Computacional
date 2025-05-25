//int numero;
//do
//{
    //Console.WriteLine("Ingrese un numero positivo:");
    //numero=Convert.ToInt32(Console.ReadLine());
    //if (numero<=0)
    //{
       // Console.WriteLine("Número incorrecto, ingrese de nuevo.");
    //}
    //else
    //{
       // Console.WriteLine("Número correcto.");
    //}
//} while (numero<=0);

int edad;
do
{
    Console.WriteLine("Ingrese su edad:");
    edad=Convert.ToInt32(Console.ReadLine());
    if (edad<=0)
    {
        Console.WriteLine("Edad incorrecta, ingrese de nuevo.");
    }
    else if (edad>100)
    {
        Console.WriteLine("Edad incorrecta, ingrese de nuevo.");
    }
    else
    {
        Console.WriteLine("Edad correcta.");
    }
} while (edad<=0 || edad>100);
