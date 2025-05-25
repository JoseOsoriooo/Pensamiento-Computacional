///<Variable "random" que se usara cada vez que se necesite obtener un numero aleatorio para generar una probabilidad.>
Random random = new Random();
Console.WriteLine("Bienvenido al videojuego SUPERVIVIENCIA EN LA ISLA \n Escriba el nombre de su personaje:");
string nombre = Console.ReadLine();
Console.WriteLine($"Te encontrabas en un crucero, pero este se hundio y naufragaste solo en una isla \nTu objetivo {nombre} es sobrevivir 10 dias en la isla desierta, suerte!");
///<Aca se declaran y asignan valores aleatorios todas la variables de las estadisticas del jugador. Se usa la variable random para generar 
/// una estadistica aleatoria cada vez que se inicia el juego;>
int energia = random.Next(60,76);
int comida = random.Next(25,31);
int agua = random.Next(20,31);
int numeroBotellas = 1;
int dia = 1;
int probabilidadEventoNocturno = 10;
///<Tambien se declaran otras variables que ayudaran a generar interacciones y eventos en el juego.>
int eleccionDiaria;
int probabilidades;
int energiaperdida;
bool opciónValida;
Console.WriteLine($"Estadisticas:\nEnergia: {energia} pts \nComida: {comida} pts\nAgua: {agua} pts\nCantidad de botellas: {numeroBotellas}");
///<El ciclo while se repetira mientras que el dia sea menor que 11 y que la energia se mayor a 0>
while (dia < 11 && energia > 0)
{
    ///<El jugador decide entre 4 opciones que desea realizar a lo largo del dia.>
    Console.WriteLine($"Dia {dia} \n La isla tiene muchas posiblidades, ¿Que decides hacer? \n1. Buscar comida \n2. Buscar agua \n3. Descansar \n4. Explorar la isla \n Escribe el numero de tu opcion para seleccionarla.");
    eleccionDiaria = Convert.ToInt16(Console.ReadLine());
    opciónValida = true;
    ///<En este swicth case se engloban las 4 decisiones, cada una afectando las estadisticas del jugador de distintas maneras.>
    switch (eleccionDiaria)
    {
        ///<En el caso de elegir "1", el jugador gastara una cantidad aleatoria de puntos de energia y tendra un 30% de probabilidades de encontrar peces, 
        /// los cuales dan 30 puntos de comida. Luego hay un 50% de encontrar frutas, las cuales dan 25 puntos de comida. Por ultimo con 20% de probabilidad
        /// se pueden encontrar semillas que dan 10 puntos de comida.> 
        case 1:
            energiaperdida = energia;
            energia -= random.Next(5,16);
            Console.WriteLine($"Decidiste buscar comida en la isla \nGastas {energia-energiaperdida} puntos de energia");
            probabilidades = random.Next(1,101);
            if ( probabilidades <= 30 && probabilidades >= 0)
            {
                Console.WriteLine("Encontraste peces, obtienes 30 puntos de comida");
                comida += 30;
            }
            else if (probabilidades <= 80 && probabilidades >= 31)
            {
                Console.WriteLine("Encontraste frutas y obtuviste 25 puntos de comida");
                comida += 25;                
            }
            else if (probabilidades <= 100 && probabilidades >= 81)
            {
                Console.WriteLine("Encontraste semillas y obtuviste 10 puntos de comida");
                comida += 10;
            }
            break;
        case 2:
            ///<Al escribir 2, el jugadro busca agua. Al generar una probabilidad, hay un 80 % de probabilidades de encontrar agua potable, la cual da
            /// 20 puntos de agua. Tambien hay un 20 % de probabilidades de encontrar agua sucia, la cual quita 10 puntos de energia.>
            energiaperdida = energia;    
            energia -= random.Next(10,21);
            Console.WriteLine($"Decidiste buscar agua en la isla \nGastas {energia-energiaperdida} puntos de energia");
            probabilidades = random.Next(1,101);
            if ( probabilidades <= 80 && probabilidades >= 0)
            {
                Console.WriteLine($"Encontraste agua potable, obtienes {numeroBotellas*20} puntos de agua");
                agua += 20;
            }
            else if (probabilidades <= 100 && probabilidades >= 81)
            {
                Console.WriteLine("Encontraste agua contaminada y perdiste 10 puntos de energía");
                energia -= 10;                
            }
            break;
        case 3:
            ///<En caso de seleccionar "3", el jugador descansa, obtiene 20 puntos de energia y se suma 10 a la proabilidade de un evento nocutrno, aumentando
            /// las probabilidades de este en un 10 %.>
            Console.WriteLine("Tomaste una comoda siesta, te levantaste como nuevo pero sentiste un escalofrio \nObtienes 20 puntso de energia \n Aumenta la probabilidad de un evento nocturno.");
            energia += 20;
            probabilidadEventoNocturno += 10;
            break;
        case 4:
            ///<Durante el case "4", el jugador explora la isla y pueden darse 3 eventos aleatoriamente. Puede ser atacado por un animal, perdiendo 10 puntos
            /// de energiat, ambien puede pasar pro terreno peligroso y perder 20 puntos de energia o puede encontrar una botella de agua.>
            probabilidades = random.Next(1,101);
            Console.WriteLine("Decidiste explorar la isla.");
            if ( probabilidades <= 30 && probabilidades >= 0)
            {
                Console.WriteLine("Encontraste un animal salvaje el cual te ataca. El ataque te deja herido.\n Pierdes 10 puntos de energia.");

                energia -= 10;
            }
            else if (probabilidades <= 80 && probabilidades >= 31)
            {
                Console.WriteLine("Buscando entre los restos del naufragio encontraste . . . \n¡Una botella!");
                numeroBotellas += 1;
                Console.WriteLine($"Ahora tienes {numeroBotellas} botellas");                
            }
            else if (probabilidades <= 100 && probabilidades >= 81)
            {
                Console.WriteLine("No se como no ves el gran barranco que tienes enfrente y te caes por el. \nPierdes 20 puntos de energia.");
                energia -= 20;
            }
            break;
        default:
            ///En caso de que se elija algo mas, saldra el default.
            Console.WriteLine("Ingrese una opción válida");
            opciónValida = false;
            break;

    }
    ///Este if es en caso de que se haya escrito una opcion valida, en caso de que no, se saltara esta parte y no se ahbara hecho nada en el dia y este
    /// ultimo se reiniciara.
    if (opciónValida == true)
    {
        ///<Al final del dia y dependiendo de la cantidad de recursos que se tenga en ese momento, se consumiran los recursos o se gastara energia.>
        Console.WriteLine("Tras ello cayo la noche y decidiste buscar un refugio seguro.");
        if (comida >= 20)
        {
            Console.WriteLine("TIenes hambre y decides comer.\nConsumes 20 puntos de comida");
            comida -= 20;
        }
        else if (comida < 20)
        {
            Console.WriteLine($"No tenias suficiente comida y no comiste bien. \nPierdes {20-comida} puntos de energia.");
            energia -= (20-comida);
            comida -= comida;
        }
        if (agua >= 15)
        {
            Console.WriteLine("Debido al cansancio del dia, tomas agua. \nConsumes 15 puntos de agua.");
            agua -= 15;
        }
        else if (agua < 15)
        {
            Console.WriteLine($"No tienes suficiente agua y por eso te deshidratas. \nPierdes {15-agua} puntos de energia.");
            energia -= (15-agua);
            agua -= agua;
        }
        /// Tras ello se genera una probabilidad para ver si habra evento nocturno. Hay 3 distintos y depende de una estadistica que aumenta al descansar.
        /// Estas van desde perder puntos de comida, perder energia o que llueva y ganar puntos de agua.
        probabilidades = random.Next(1,101);
        if (probabilidades <= probabilidadEventoNocturno)
        {
            Console.WriteLine("Hay un evento nocturno . . .");
            probabilidades = random.Next(1,101);
            if (probabilidades <= 33 && probabilidades >= 0)
            {
                Console.WriteLine($"Empezo a llover en la isla! Al ver esto decides llenar tus botellas con el agua de lluvia. \nObtienes {10*numeroBotellas} puntos de agua");
                agua += (numeroBotellas*10);
            }
            else if(probabilidades <= 66 && probabilidades >= 34)
            {
                Console.WriteLine("Un grupo de monos invade tu refugio. Logras ahuyentarlos, pero se roban tu comidad \n Pierdes 10 puntos de comida.");
                comida -= 10;
            }
            else if (probabilidades <= 100 && probabilidades >= 67)
            {
                Console.WriteLine("Por alguna razon, hay mas frio de lo normal por la noche. \nDuermes incomodo y pierdes 10 puntos de energia");
                energia -= 10;
            }
        }
        Console.WriteLine($"Fin del dia {dia} \nEstadisticas:\nEnergia: {energia} pts \nComida: {comida} pts\nAgua: {agua} pts\nCantidad de botellas: {numeroBotellas}");
        dia += 1;
    }
    else if (opciónValida == false)
    {
        Console.WriteLine("El dia se reiniciara");
    }
}
///Este if evalua si al terminar el bucle fue por perder toda la energia o por haber ganado el juego.
if (dia >= 10)
{
    Console.WriteLine("Tras sobrevivir 10 dias en la isla, un helicoptero llego a rescartarte. \n Felicidades, ganaste el juego!");
}
else if (energia <= 0)
{
    Console.WriteLine("Te quedaste sin energia y te desmayaste. Fin del juego.");
}