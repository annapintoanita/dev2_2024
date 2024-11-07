
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// chiedo all'utente il numero di squadre
Console.WriteLine("Inserisci il numero di squadre:");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un array di liste di stringhe per le squadre
List<string>[] squadre = new List<string>[numeroSquadre];

// per ogni squadra creo una lista vuota
for (int i = 0; i < numeroSquadre; i++)
{
    squadre[i] = new List<string>();
}

// calcolo quanti partecipanti ci sono in ogni squadra
int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

// se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra

// calcolo quanti partecipanti ci sono in piu
int partecipantiInPiu = partecipanti.Count % numeroSquadre;

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // per ogni partecipante della squadra

    for (int j = 0; j < partecipantiPerSquadra; j++)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
    }

    // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
    if (partecipantiInPiu > 0)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        // decremento il numero di partecipanti in piu
        partecipantiInPiu--;
    }

    // stampo i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in squadre[i])
    {
        Console.WriteLine(partecipante);
    }
    Console.WriteLine();
}