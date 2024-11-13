## Calcolatrice semplice

## versione 1

# Obiettivo

- Scrivere un programma che simuli una calcolatricee semplice.
- L' utente deve poter inserire due numeri e selezionare un operatore matemati (+,-,*,/)
- Il programma deve eseguire l'operazione selezionata e stampare il risultato.
- Il programma non gestisce nessun tipo di errore o eccezione.

```csharp
//chiedo all'utente di inserire due numeri

Console.WriteLine("Inserisci un numero");
double numero1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("inserisci il secondo numero");
double numero2 = Convert.ToDouble(Console.ReadLine());

//chiedo all' inserire un operatore matematico
Console.WriteLine("Inserisci un operatore:");
Console.WriteLine("+, -, /, * ");
string operatore = Console.ReadLine();
double risultato = 0;

switch (operatore)
{
    case "+":
        risultato = numero1 + numero2;
        break;
    case "-":
        risultato = numero1 - numero2;
        break;
    case "/":
        risultato = numero1 / numero2;
        break;
    case "*":
        risultato = numero1 * numero2;
        break;
}
       
//stampa il risultato
Console.WriteLine($"Il risultato dell'operazione {numero1} {operatore} {numero2} è: {risultato}");

```

# Comandi di versionamento
```bash
git add --all
git commit -m "versione1"
git push -u origin main

```

# Versione 2

## Obiettivo

- Aggiunge la gestione degli errori per evitare crash nel programma.
- Se l'utente inserisce un valore numerico, il programma deve stampare un messaggio di errore dicendo di inserire un numero valido
- Se l'utente seleziona un operatore non valido, il programma deve stampare un messaggio di errore dicendo di selezionare un operatore valido
- Se l'utente tenta di dividere per zero, il programma deve stampare un messaggio di errore dicendo che la divisione per zero non è consentita
- Il programma deve usare i blocchi try-catch per gestire gli errori

```csharp
// Inserisco il codice

```

## Comandi di verisonamento

```bash


```
