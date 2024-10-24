Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>();

Console.WriteLine("Scegli il livello di difficolta':");
Console.WriteLine("1. Facile (1-50, 10 tentativi)");
Console.WriteLine("2. Medio (1-100, 7 tentativi)");
Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

// int scelta = int.Parse(Console.ReadLine());
int scelta = 0; // Inizializzo la variabile scelta a 0
bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta); // TryParse restituisce true se la conversione è riuscita, altrimenti false

// se la conversione non è riuscita oppure la scelta non è compresa tra 1 e 3
if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
{
    Console.WriteLine("Scelta non valida."); // Stampo un messaggio di errore
}
else
{
    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        bool successo = int.TryParse(Console.ReadLine(), out numeroUtente); // TryParse restituisce true se la conversione è riuscita, altrimenti false

        if (!successo)
        {
            Console.WriteLine("Inserisci un numero valido."); // Se l'utente non ha inserito un numero valido, si salta il tentativo
            continue; // Salta il resto del ciclo e va al prossimo tentativo
        }

        tentativiUtente.Add(numeroUtente);
        tentativi--;

        if (numeroUtente < numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' maggiore.");
        }
        else if (numeroUtente > numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' minore.");
        }
        else
        {
            Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
            haIndovinato = true;
        }

        if (!haIndovinato && tentativi == 0)
        {
            Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
        }
    }

    Console.WriteLine("Tentativi effettuati: ");

    foreach (int tentativo in tentativiUtente)
    {
        Console.Write($"{tentativo} ");
    }
}

// se vogliamo che chieda di nuovo il livello di difficoltà quando la scelta non è valida
// dobbiamo mettere tutto il codice precedente in un ciclo do-while
// e fare in modo che il ciclo si ripeta finché la scelta non è valida

