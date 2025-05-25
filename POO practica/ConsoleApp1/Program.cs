using System.Reflection.Metadata;
Medicamento[] medicamentos = new Medicamento[6];

medicamentos[0] = new Medicamento { codigo = "000", nombre = "Aspirina", Inventario = 50, precio = 2 };
medicamentos[1] = new Medicamento { codigo = "001", nombre = "Diclofenaco", Inventario = 45, precio = 5 };
medicamentos[2] = new Medicamento { codigo = "002", nombre = "Pasiflora", Inventario = 12, precio = 3 };
medicamentos[3] = new Medicamento { codigo = "003", nombre = "Paracetamol", Inventario = 20, precio = 7 };
medicamentos[4] = new Medicamento { codigo = "004", nombre = "Sukrol", Inventario = 10, precio = 4 };
medicamentos[5] = new Medicamento { codigo = "005", nombre = "Gripetin", Inventario = 8, precio = 12 };
imprimir();
void imprimir()
{
    for(int i = 0; i < medicamentos.Length; i++)
    {
        Console.WriteLine($"CÓDIGO: {medicamentos[i].codigo} NOMBRE: {medicamentos[i].nombre} INVENTARIO: {medicamentos[i].Inventario} PRECIO: {medicamentos[i].precio}");
    }
}

struct  Medicamento
{
     public string codigo;
    public string nombre;
    public int Inventario;
    public int precio;
}
