# INDOVINA NUMERO

## Obiettivo

L'obiettivo di questa applicazione e di indovinare un **numero casuale** generato dal computer.

> Passaggi:

1. Il computer genera un numero casuale tra 1 e 100.
2. L'utente inserisce un numero.
3. Il computer confronta il numero inserito con quello generato.
4. Se il numero inserito è uguale a quello generato, l'utente ha indovinato.
5. Altrimenti, il computer fornisce un suggerimento (maggiore o minore) e l'utente può inserire un nuovo numero.
6. Il gioco termina quando l'utente indovina il numero o quando raggiunge il numero massimo di tentativi.

> **Esempio di codice:**

## Versione 1

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;

numeroInserito = Convert.ToInt32(Console.ReadLine()); // converto il valore inserito dall'utente in un intero perche 

if (numeroInserito == numeroDaIndovinare)
{
   Console.WriteLine("Complimenti! Hai indovinato il numero.");
}
else
{
   Console.WriteLine("Mi dispiace! Non hai indovinato il numero.");
    Console.WriteLine($"Il numero da indovinare era: {numeroDaIndovinare}");
}
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 1"
git push -u origin main
```
## Versione 2

**Obiettivo:**  
Modifica il programma precedente per fornire all'utente suggerimenti dopo ogni tentativo, indicando se il numero da indovinare è maggiore o minore di quello inserito.

**Istruzioni:**

* Usa un ciclo while per permettere all'utente di continuare a tentare finché non indovina.  
* Dopo ogni tentativo errato, indica se il numero da indovinare è maggiore o minore di quello inserito.  
* Quando l'utente indovina, esci dal ciclo e stampa un messaggio di congratulazioni.

> **Esempio di codice:**

## Versione 2

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;

numeroInserito = 0; // Inizializzo a 0 per entrare nel ciclo while

while (numeroInserito != numeroDaIndovinare)
{
    numeroInserito = Convert.ToInt32(Console.ReadLine());
    
    if (numeroInserito < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore");
    }
    else
    {
        Console.WriteLine("Il numero da indovinare e' minore");
    }

    Console.WriteLine("Riprova: ");
    
}

Console.WriteLine("Hai indovinato! Il numero da indovinare era: " + numeroDaIndovinare);
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 2"
git push -u origin main
```

## Versione 3

**Obiettivo:**  
Imposta un numero massimo di tentativi (ad esempio, 5). Se l'utente non indovina entro questi tentativi, il gioco termina.

**Istruzioni:**

* Imposta una variabile booleana per tenere traccia se l'utente ha indovinato.
* Mantieni un contatore di tentativi all'interno del ciclo while.  
* Dopo ogni tentativo, decrementa il numero di tentativi rimasti e informane l'utente.  
* Se i tentativi esauriscono senza che l'utente abbia indovinato, stampa un messaggio di sconfitta e rivela il numero.

**Esempio di codice:**

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
int numeroInserito;
int tentativiMassimi = 5;  
int tentativiEffettuati = 0;  
bool haIndovinato = false;
int numeroUtente = 0;

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi.");

while (tentativiEffettuati < tentativiMassimi && !haIndovinato)  
{  
    Console.Write("Tentativo {0}: ", tentativiEffettuati + 1);  
    
    // numeroUtente = int.Parse(Console.ReadLine());  
    numeroUtente = int.Parse(Console.ReadLine());
    
    tentativiEffettuati++;

    if (numeroUtente < numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è maggiore.");  
    }  
    else if (numeroUtente > numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è minore.");  
    }  
    else  
    {  
        Console.WriteLine("Complimenti! Hai indovinato il numero.");  
        haIndovinato = true;  
    }

    if (!haIndovinato && tentativiEffettuati == tentativiMassimi)  
    {  
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");  
    }  
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 3"
git push -u origin main
```

## Versione 4

**Obiettivo:**  
Assegna un punteggio all'utente in base al numero di tentativi utilizzati. Più tentativi impiega, minore sarà il punteggio.

**Istruzioni:**

* Inizia con un punteggio massimo (ad esempio, 100 punti).  
* Ad ogni tentativo fallito, sottrai un certo numero di punti (ad esempio, 2 punti).  
* Alla fine del gioco, mostra il punteggio all'utente.

**Esempio di codice:**

```csharp
Random random = new Random();
int numeroDaIndovinare = random.Next(1, 101);  
int punteggio = 100;  
bool haIndovinato = false;

Console.WriteLine("Indovina il numero (tra 1 e 100). Punteggio massimo: 100 punti.");

while (!haIndovinato && punteggio > 0)  
{  
    Console.Write("Tentativo: ");  
    int numeroUtente = int.Parse(Console.ReadLine());  
    punteggio -= 2;

    if (numeroUtente < numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è maggiore.");  
    }  
    else if (numeroUtente > numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è minore.");  
    }  
    else  
    {  
        Console.WriteLine("Hai indovinato! Punteggio: " + punteggio);  
        haIndovinato = true;  
    }

    if (!haIndovinato && punteggio == 0)  
    {  
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");  
    }  
}
```