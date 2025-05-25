// See https://aka.ms/new-console-template for more information
Console.WriteLine("ejerciciolab9");
Console.WriteLine("ingrese una hora del dia");
int hora = int.Parse(Console.ReadLine());
if (hora >= 0 && hora <= 11)
{
    Console.WriteLine("Buenos dias");
}
else if (hora >= 12 && hora <= 18)
{
    Console.WriteLine("Buenas tardes");
}
else if (hora >= 19 && hora <= 23)
{
    Console.WriteLine("Buenas noches");
}
else
{
    Console.WriteLine("hora no valida");
}

