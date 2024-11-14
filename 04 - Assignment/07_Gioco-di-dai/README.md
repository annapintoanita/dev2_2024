# GIOCO DEI DADI

## Versione 1

## Obiettivo:
- implementare un gioco di dadi umano vs computer
- il giocatore ed il computer lanciano un dado a 6 facce
- il punteggio più alto vince
- il gioco deve chiedere all'utente se vuole continuare a giocare
- il gioco in questa versione viene realizzato senza funzioni

```csharp



```
## Comandi di versionamento

```bash
git add --all
git commit -m "versione 1"
git push -u origin main
```

# Versione2

## Obiettivo

- Implementa qualche funzione

```csharp
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


```

# Versione 3

## Obiettivo:

- implementare un sistema di punteggio
- il giocatore ed il computer partono da un punteggio di 100 punti
- al vincitore vengono assegnati 10 punti, più la differenza tra il lancio del dado del giocatore e del computer
- al perdente vengono sottratti 10 punti, più la differenza tra il lancio del dado del giocatore e del computer
- ad esempio, se il giocatore fa 6 ed il computer fa 3, il giocatore vince e guadagna 10+3 andando a 113 punti, mentre il computer perde 10+3 andando a 87 punti

```csharp
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


```

## Comandi di versionamento 

```bash
git add --all
git commit -m"versione3"
git push -u origin main
```