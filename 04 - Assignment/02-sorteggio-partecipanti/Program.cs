
//creo la lista di nomi dei partecipaanti
List<string>listaPartecipanti= new List<string>
{
    "Andrea", "Anita", "Diego", "Felipe", "Giorgio", "Ivan", "Sofia", "Tamer"
    };
    foreach (var nome in listaPartecipanti) // utilizzo il foreach per stamparli tutti
    {
        Console.WriteLine(nome);
    }
 Random random = new Random();//metodo random per sorteggiare i nomi casualmente 

 int nomeCasuale= random.Next(listaPartecipanti.Count); // mi sono creata un indice

  Console.WriteLine("E' stato sorteggiato " + listaPartecipanti[nomeCasuale] ); // ho inserito l'indice nel Console.WriteLine
  