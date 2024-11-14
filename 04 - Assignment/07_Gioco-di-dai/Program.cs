
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
    int tiroUtente = LancioDado(random);

    // il computer tira
    Console.WriteLine("Tocca a me..Sto lanciando il dado ");
    int tiroComputer = LancioDado(random);
    StampaVincitore(tiroUtente, tiroComputer);

    Console.WriteLine("vuoi riprovare? s/n");
    rispostaUtente = Console.ReadLine();
}
while (rispostaUtente == "s");

#region Funzioni

// La funzione deve richiamare sia il tiro utente che il tiro computer
int LancioDado(Random random)
{
    int dado = random.Next(1, 7);
    Console.WriteLine($"è uscito il numero {dado}");
    return dado;
}

// La funzione stampa chi ha vinto confrontando i numeri che sono usciti
void StampaVincitore(int tiroUtente, int tiroComputer)
{
    if (tiroUtente > tiroComputer)
    {
        Console.WriteLine("HAI VINTO TU");
    }
    else if (tiroUtente < tiroComputer)
    {
        Console.WriteLine("HO VINTO IO");
    }
    else
    {//chiedo all'utente se vuole giocare ancora
        Console.WriteLine("Abbiamo pareggiato");
    }
}

#endregion





