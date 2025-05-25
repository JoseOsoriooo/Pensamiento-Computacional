//Carro carro1 = new Carro("Chevrolet", 2023, "Sonic");
//carro1.Mostrar();
//class Carro
//{
  //  private string marca;
    //private int modelo;
   // private string linea;

    // Constructor
    //public Carro(string Marca, int Modelo, string Linea)
    //{
      //  marca = Marca;
        //modelo = Modelo;
        //linea = Linea;
    //}
    //Métodos (procedimiento o funciones)
    //public void Mostrar()
    //{
      //  Console.WriteLine($"Marca:  {marca}");
        //Console.WriteLine($"Modelo:  {modelo}");
        //Console.WriteLine($"Linea:  {linea}");
    //}
//}
Console.WriteLine("Buenas, ingrese el radio y la altura del cilindro");
double radio = double.Parse(Console.ReadLine());
double altura = double.Parse(Console.ReadLine());
Cilindro cilindro1 = new Cilindro(radio, altura);
cilindro1.Mostrar();
Console.WriteLine($"El volumen del cilindro es: {cilindro1.CalcularVolumen()}");
class Cilindro
{
    private double radio;
    private double altura;

    // Constructor
    public Cilindro(double Radio, double Altura)
    {
        radio = Radio;
        altura = Altura;
    }

    // Métodos (procedimiento o funciones)
    public void Mostrar()
    {
        Console.WriteLine($"Radio:  {radio}");
        Console.WriteLine($"Altura:  {altura}");
    }
    public double CalcularVolumen()
    {
        double volumen = Math.PI * Math.Pow(radio, 2) * altura;
        return volumen;
    }
}  
