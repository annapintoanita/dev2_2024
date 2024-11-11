# Versione 1

## Obiettivo

- Scrivere un programma che simuli una calcolatrice semplice.
- L utente deve poter inserire due numeri e selezionare un operatore matematico (+, -, *, /)
- Il programma deve eseguire l'operazione selezionata e stampare il risultato.
- Il programma non gestisce nessun tipo di errore o di eccezione.

```csharp
//chiedo all'utente di inserire due numeri

    Console.WriteLine("Inserisci un numero");
    double numero1 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("inserisci il secondo numero");
    double numero2 = Convert.ToDouble(Console.ReadLine());

    //chiedo all'utente di inserire un operatore matematico
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
## Comandi di versionamento

```bash
git add --all
git commit -m "versione1"
```