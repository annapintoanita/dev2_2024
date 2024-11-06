

// creo una lista partecipanti

List<string> partecipanti = new List<string> { "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8", "P9", "P10" };

// creo oggetto random 
Random random = new Random();

//chiedo all'utente il numero di squadre
Console.WriteLine("Scegli il numero di squadre che desideri formare: ");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un arrey di liste di stringhe per le squadre
List<string>[] listaSquadre = new List<string>[numeroSquadre];

// per ogni squadra creo una lista vuota
for (int i = 0; i < numeroSquadre; i++) 
{
    listaSquadre[i] = new List<string>();
}
// calcolo quanti partecipanti per ogni squadra
int pPSquadra = partecipanti.Count / numeroSquadre;

//se il numero di partecipanti non è divisibile per il numero di squadre aggiungo un partecipante in più ad una squadra
//CALCOLO quanti partecipanti ci sono in più
int partecipantiRimasti = partecipanti.Count % numeroSquadre;

//per ogni squadra
for (int i = 0; i < numeroSquadre; i++) 
{
    //per ogni partecipante della squadra

    for (int j = 0; j < pPSquadra; j++)
    {
        int index = random.Next(partecipanti.Count);

        //aggiungo il partecipante alla squadra
        listaSquadre[i].Add(partecipanti[index]);
        //genero un numero casuale tra 0 e il numero di partecipanti
        partecipanti.RemoveAt(index);
    }

    //se ci sono partecipanti in più aggiungo un partecipante in più alla squadra corrente
    if (partecipantiRimasti > 0)
    {
        //genero un numero casuale tra 0 e il numero di partecipanti rimasti alla squadra corrente
        int index = random.Next(partecipanti.Count);

        //aggiungo il partecipante alla squadra
        listaSquadre[i].Add(partecipanti[index]);

        //rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        //decremento il numero di partecipanti in più
        partecipantiRimasti--;
    }
    //ora posso stampare i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in listaSquadre[i])
    {
        Console.WriteLine(partecipante); //stampa la variabile
    }
    Console.WriteLine();
}


