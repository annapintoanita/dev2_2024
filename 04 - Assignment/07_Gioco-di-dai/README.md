# Gioco di dadi

## Versione 1

## Obiettivo
- Implementare un gioco di dadi umano contro il computer
- Il giocatore e il computer lanciano un dado a 6 facce
- il punteggio più alto vince.
- il gioco deve chiedere all'utente se vuole continuare a giocare
- il gioco in questa versione viene svolto senza funzioni.

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
    int tiroUtente = random.Next(1, 7);
    Console.WriteLine($"è uscito il numero {tiroUtente}");
    // il computer tira
    Console.WriteLine("Tocca a me..Sto lanciando il dado ");
    int tiroComputer = random.Next(1, 7);
    Console.WriteLine($"mi è uscito il numero {tiroComputer}");
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
    Console.WriteLine("vuoi riprovare? s/n");
    rispostaUtente = Console.ReadLine();
}
while (rispostaUtente == "s");
```
## Comandi di versionamento

```bash
git add --all
git commit -m "tiro dei dadi"
git push -u origin main
```

# Versione 2

## Obiettivo

- Implemento con qualche funzione 

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

## Obiettivo

- Implementare un sistema di punteggio
- il giocatore e il computer partono da un punteggio di 100 punti.
- al vincitore vengono assegnati 10 punti piu la differenza fra il lancio del dado del giocatore e del computer.
- al perdente vengono sottratti 10 punti piu la differenza fra il lancio del dado del giocatore e del computer.
- ad esempio se il giocatore fa 6 ed il computer 3 il giocatore vince e guadagna 10 + 3 andando a 113 punti mentre il computer perde 10 +3 andando a 87 punti.
- Il gioco termina quando il giocatore o il computer raggiungono 0 punti.

```csharp


```

## Comandi di versionamento

```bash

```