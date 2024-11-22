/*try
{//("Verifico se un numero è intero")
    int numero = 0;
    Console.WriteLine("Inserisci un numero intero");
    numero = int.Parse(Console.Readline());
}
catch (FormatException e)
{
    Console.WriteLine($"Devi inserire un numero intero {e.Message}");
}

try
{   //("Verifico se il numero è decimale")
    double numeroDecimale= 0;
    Console.WriteLine("Inserisci un numero decimale");
    decimale = double.Parse(Console.Readline());
}
catch(FormatException e)
{
    Console.WriteLine($"Devi inserire un numero decimale");
}*/



/*int numero;

try
{

    Console.WriteLine("Inserisci un numero intero:");
    numero = int.Parse(Console.ReadLine());


    Console.WriteLine("Hai inserito: " + numero);
}
catch (FormatException e)
{

    Console.WriteLine($"Errore: {e.Message}");  
}

double numero2;

try
{
Console.WriteLine("Inserisci un numero decimale:");
numero2= double.Parse(Console.ReadLine());
Console.WriteLine("Hai inserito: " + numero2);
}
catch (FormatException)
{
Console.WriteLine($"Errore: ");
}

string testo = ""*/
////////////
/*Console.WriteLine("inserisci un numero intero");
int numero = VerificaIntero (numero);
Console.WriteLine ($"hai inseriro {numero}");

int VerificaIntero(int numero)
{
  int numero = VerificaIntero;
  numero= int.Parse (Console.ReadLine());
  return numero;
}*/

static int VerificaIntero(string messaggio)
{
    int numero;
    bool successo;// dichiaro la variabile successo
                  //do while che cicla finchè non si inserisce un numero

    do

    { Console.WriteLine("Inserisci un numero"); }

         Console.WriteLine(messaggio);
    // stampo il messaggio cioè "inserisci un numero intero" che gli passo
    successo = int.TryParse(Console.ReadLine(), out numero);// TryParse tenta di convertire la stringa in numero intero
                                                            //se non ci riesce restituisce false e continua a ciclare
} while (!successo) ;
return numero;
      
      
      /*static double VerificaDecimale()
      {
        double numero1;
        bool successo;
        do 
        {
            Console.WriteLine()
        }
      }*/