
string rispostaUtente;
int punteggioUtente = 100;
int punteggioComputer = 100;

Random random = new Random();
do
{
    //genero numeri random 

    // presento il gioco all'utente
    Console.WriteLine("Benvenuto nel gioco dei dadi. Chi fa il punteggio più alto vince il gioco");
    Console.WriteLine("Partiremo entrambi con 100 punti ");

    Console.WriteLine("Scrivi 'lancio' per lanciare il dado");

    Console.ReadLine();
    //l'utente tira
    int tiroUtente = LancioDado(random);
    Console.WriteLine($"Per adesso hai totalizzato {tiroUtente} punti");


    // il computer tira
    Console.WriteLine("Tocca a me. Sto lanciando il dado.. ");
    int tiroComputer = LancioDado(random);
    Console.WriteLine($" Per ora ho totalizzato {tiroComputer} punti");

    StampaVincitore(tiroUtente, tiroComputer, punteggioUtente, punteggioComputer);

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
void StampaVincitore(int tiroUtente, int tiroComputer, int  punteggioUtente, int punteggioComputer)

{


    if (tiroUtente > tiroComputer)
    {
        Console.WriteLine("HAI VINTO TU");

        punteggioUtente += 10 + (tiroUtente - tiroComputer);
        punteggioComputer -= 10 + (tiroComputer - tiroUtente);
        Console.WriteLine($"Il tuo punteggio è {punteggioUtente}");
    }
    else if (tiroUtente < tiroComputer)
    {
        Console.WriteLine("HO VINTO IO");

        punteggioComputer += 10 + (tiroComputer - tiroUtente);
        punteggioUtente -= 10 + (tiroUtente - tiroComputer);
        Console.WriteLine($"Il mio punteggio è {punteggioComputer}");
    }
    else
    {//chiedo all'utente se vuole giocare ancora
        Console.WriteLine("Abbiamo pareggiato");
    }

}

#endregion





