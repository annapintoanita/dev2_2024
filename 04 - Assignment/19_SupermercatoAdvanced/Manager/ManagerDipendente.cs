public class DipendenteManager 
{
    private int Id;
    private string Cognome;
    private string Ruolo;
    private List <Dipendente> dipendenti;
    private DipendenteRepository repository ;


   public DipendenteManager(List <Dipendente> dipendenti)
    {
         
       dipendente = Dipendente ;
       repository = new DipendenteRepository();
       dipendentiId = 1;

    foreach (var dipendente in dipendenti)
        {
            if (dipendenti.Id >= Id)
            {
                Id = dipendente.Id + 1;
            }
        }

    }

    public void AggiungiDipendente(Dipendente dipendenti)
    { //assegna automaticamente un ID univoco
        dipendenti.Id = Id;
        //incrementa il prossimo ID per il prossimo cliente
        Id++;
        dipendenti.Add(dipendenti);
        Console.WriteLine($"Cliente aggiunto con ID: {dipendenti.Id}");
    }
     public List<Cliente> OttieniDipendente()
    {
        return clienti;
    }

    public void StampaDipendentiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Cognome",-20} {"Ruolo", -10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var dipendente in dipendenti)
        {
            Console.WriteLine(
                $"{dipendente.Id,-5} {dipendente.Cognome,-20} {dipendente.Ruolo,-10}"
            );
        }
    }

    public Dipendente TrovaDipendente(int id)
    {
        foreach (var dipendente in dipendenti)
        {
            if (dipendente.Id == id)
            {
                return dipendente; 
            }
        }
        return null;
    }
    public void AggiornaDipendente(int id, Dipendente nuovoDipendente)
    {
        var dipendente = TrovaDipendente(id);
        if (dipendente != null)
        {
            dipendente.Id = nuovoDipendente.Id;
            dipendente.Cognome = nuovoDipendente.Cognome;
            dipendente.Ruolo = nuovoDipendente.Ruolo;
           
        }
    }
    public void EliminaDipendente(int id)
    {
        var dipendente = TrovaDipendente(id);
        if (dipendente != null)
        {
            dipendente.Remove(dipendente);
            //elimina il file json corrispondente al  prodotto
            string filePath = Path.Combine("Dipendenti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Dipendente eliminato: {filePath}");
        }
    }

}