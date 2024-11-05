Random random = new Random();//metodo random per sorteggiare i nomi casualmente
//creo la lista di nomi dei partecipanti
List<string> listaPartecipanti = new List<string> { "Andrea", "Anita", "Diego", "Felipe", "Giorgio", "Ivan", "Sofia", "Tamer" };
int nomeCasuale; // mi sono creata un indice
string nomeEstratto; //aggiungo una variabile stringa
int conteggioP = listaPartecipanti.Count;
string risposta;


do
{
    nomeCasuale = random.Next(conteggioP);

    foreach (var nome in listaPartecipanti) // utilizzo il foreach per stamparli tutti
    {
        Console.WriteLine(nome);
    }

    nomeEstratto = listaPartecipanti[nomeCasuale];

    Console.WriteLine($"E' stato sorteggiato {nomeEstratto}"); // ho inserito l'indice nel Console.WriteLine

    listaPartecipanti.RemoveAt(nomeCasuale);

    conteggioP--;

    if (conteggioP == 0)
    {
        Console.WriteLine("Non ci sono più nomi da estrarre");
        break;
    }


    Console.WriteLine("Vuoi estrarre un altro nome? s/n");
    risposta= Console.ReadLine().ToLower();

      while (risposta != "s" && risposta != "n")
    {
        Console.WriteLine("Risposta non valida. Vuoi estrarre di nuovo? (s/n)");
        risposta = Console.ReadLine().ToLower();
        Console.Clear();
    }
}
while (risposta =="s");

