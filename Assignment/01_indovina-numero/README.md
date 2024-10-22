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