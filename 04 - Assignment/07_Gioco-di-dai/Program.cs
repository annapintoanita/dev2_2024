string rispostaUtente;
do
{
    //genero numeri random 
    Random random = new Random();
// presento il gioco all'utente
Console.WriteLine("Benvenuto nel gioco dei dadi. Chi fa il punteggio più alto vince il gioco");

Console.WriteLine("Scrivi 'lancio' per lanciare il dado");
Console.ReadLine();
//l'utente tira
int tiroUtente= random.Next(1,7);
Console.WriteLine($"è uscito il numero {tiroUtente}");
// il computer tira
Console.WriteLine("Tocca a me..Sto lanciando il dado ");
int tiroComputer = random.Next(1,7);
Console.WriteLine($"mi è uscito il numero {tiroComputer}");
if (tiroUtente > tiroComputer)
{
    Console.WriteLine("HAI VINTO TU");
}
else if (tiroUtente< tiroComputer)
{
    Console.WriteLine("HO VINTO IO");
}
else
{//chiedo all'utente se vuole giocare ancora
    Console.WriteLine("Abbiamo pareggiato");
   
}
 Console.WriteLine("vuoi riprovare? s/n");
 rispostaUtente= Console.ReadLine();
}  
while ( rispostaUtente == "s");





