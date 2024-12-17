namespace MyApp.Models;
public class DipendenteManager 
{
    private int Id;
    private string Cognome;
    private string Ruolo;
    private List <Dipendente> dipendenti;
    private DipendenteRepository repository ;


   public DipendenteManager(List<Dipendente> Dipendenti)
    {
         
       dipendenti = Dipendenti ;
       repository = new DipendenteRepository();
       Id = 1;

    foreach (var dipendente in dipendenti)
        {
            if (dipendente.Id >= Id)
            {
                Id = dipendente.Id + 1;
            }
        }

    }

    public void AggiungiDipendente(Dipendente dipendente)
    { //assegna automaticamente un ID univoco
        dipendente.Id = Id;
        //incrementa il prossimo ID per il prossimo cliente
        Id++;
        dipendenti.Add(dipendente);
        Console.WriteLine($"Cliente aggiunto con ID: {dipendente.Id}");
    }
     public List<Dipendente> OttieniDipendente()
    {
        return dipendenti;
    }

    public void StampaDipendentiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"UserName",-20} {"Ruolo", -10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var dipendente in dipendenti)
        {
            Console.WriteLine(
                $"{dipendente.Id,-5} {dipendente.UserName,-20} {dipendente.Ruolo,-10}"
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
            dipendente.UserName = nuovoDipendente.UserName;
            dipendente.Ruolo = nuovoDipendente.Ruolo;
           
        }
    }
    public void EliminaDipendente(int id)
    {
        var dipendente = TrovaDipendente(id);
        if (dipendente != null)
        {
            dipendenti.Remove(dipendente);
            //elimina il file json corrispondente al  prodotto
            string filePath = Path.Combine("Dipendenti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Dipendente eliminato: {filePath}");
        }
    }

}