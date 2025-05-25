// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ejemplo de arreglos");

string [] nombres = ["Juan", "Pedro", "Luisa", "Adriana", "Sofia"]; 
int [] notas = [88, 75, 96, 77, 59];
int promedio = 0;
string nombre = nombres[0];
for (int i = 0; i < nombres.Length; i++)
{
    Console.WriteLine($"Nombre: {nombres[i]} - Nota: {notas[i]}");
     promedio += notas[i];
    
    
}
    promedio /= notas.Length;
    Console.WriteLine($"El pormedio de la suma de todas las notas es: {promedio}");
