

// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8", "P9", "P10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// chiedo all'utente il numero di squadre
Console.WriteLine("Inserisci il numero di squadre:");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un dizionario per le squadre
Dictionary<int, List<string>> squadre = new Dictionary<int, List<string>>();

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // aggiungo la squadra al dizionario
    squadre.Add(i + 1, new List<string>());
}

// calcolo quanti partecipanti ci sono in ogni squadra
int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

// se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra
int partecipantiInPiu = partecipanti.Count % numeroSquadre;

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // aggiungo i partecipanti
    for (int j = 0; j < partecipantiPerSquadra; j++)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i + 1].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
    }

    // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
    if (partecipantiInPiu > 0)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i + 1].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        // decremento il numero di partecipanti in piu
        partecipantiInPiu--;
    }

    // stampo i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in squadre[i + 1])
    {
        Console.WriteLine(partecipante);
    }
    Console.WriteLine();
}
