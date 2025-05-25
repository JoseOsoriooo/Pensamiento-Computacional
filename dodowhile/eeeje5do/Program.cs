Console.WriteLine("Ingrese un texto");
string texto = Console.ReadLine();
int cantidadDePablabras = texto.Length;
string textoFormateado = "";
string[] palabras = texto.Split(' ');

for (int i = 0; i < texto.Length; i++)
{
   string palabra = palabras [i];
    if (palabra == " ")
    {
         textoFormateado += " ";
         textoFomentado += palabras[i].ToUpper() + " ";
    }
    
    
   }

{
    Console.WriteLine($"El texto formateado es: {textoFormateado}");
    Console.WriteLine($"El texto tiene {cantidadDePablabras} palabras");
    
    
    
    

}