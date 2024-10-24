Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>();

int scelta = 0;

do
{
    Console.WriteLine("Scegli il livello di difficolta':");
    Console.WriteLine("1. Facile (1-50, 10 tentativi)");
    Console.WriteLine("2. Medio (1-100, 7 tentativi)");
    Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

    bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);

    if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
    {
        Console.WriteLine("Scelta non valida.");
    }
} while (scelta < 1 || scelta > 3);

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
    bool successo = int.TryParse(Console.ReadLine(), out numeroUtente);

    if (!successo)
    {
        Console.WriteLine("Inserisci un numero valido.");
        continue;
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