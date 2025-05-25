using System;

class Program
{
    static void Main(string[] args)
    {
    
        Console.WriteLine("Por favor, ingrese un texto:");
        string input = Console.ReadLine();

       
        int wordCount = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

        
        string capitalizedText = CapitalizeWords(input);

       
        Console.WriteLine($"\nCantidad de palabras ingresadas: {wordCount}");
        Console.WriteLine($"Texto con la primera letra de cada palabra en mayúscula:\n{capitalizedText}");
    }

    static string CapitalizeWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
        }

        return string.Join(" ", words);
    }
}