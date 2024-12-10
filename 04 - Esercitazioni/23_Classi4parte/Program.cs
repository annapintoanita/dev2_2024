using System.Buffers;
using Newtonsoft.Json;

class Program
{
    
    static void Main(string[] args)
    {
        //Crea un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoRepository repository = new ProdottoRepository();

        List<ProdottoAdavnced> prodotti = repository.CaricaProdotti();

        ProdottoAdvancedManager manager= new ProdottoAdvancedManager();

        // Carica i dati da file con il metodo CaricaProdotti della classe ProdottoRepository ()
        //Aggiungere prodotti alla lista con il metodo AggiungiProdotto alla classe ProdottoAdvanced (manager)
        manager.AggiungiProdotto(new ProdottoAdvanced { Id = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 });
        manager.AggiungiProdotto(new ProdottoAdvanced { Id = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50 });

        //Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("Prodotti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID:{prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        //Trovare un prodotto per ID con il metodo TrovaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdotto = 1;
        ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
        if (prodottoTrovato != null)
        {
            Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: \n{prodottoTrovato.NomeProdotto}");
        }
        else
        {
            Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
        }

        //Aggiornare un prodotto con il metodo AggiornaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdottoDaAggiornare = 2;
        ProdottoAdvanced nuovoProdotto = new ProdottoAdvanced { Id = 2, NomeProdotto = "Prodotto C", PrezzoProdotto = 30.25m, GiacenzaProdotto = 75 };
        manager.AggiornaProdotto(idProdottoDaAggiornare, nuovoProdotto);

        //Visualizzare i prodotti aggiornati (vadiìo a richiamare ottieniprodotti)
        Console.WriteLine("\nProdotti aggiornati:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto},Giacenza: {prodotto.GiacenzaProdotto}");
        }

        //Eliminare un prodotto con il metodo EliminaProdotto della classe ProdottoAdvancedManagere (manager)
        int idProdottoDaEliminare = 1;
        manager.EliminaProdotto(idProdottoDaEliminare);

        //Visualizza i prodotti rimanenti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("\nProdotti rimanenti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        // salvare i prodotti su file con il metodo SalvaProdotti della classe ProdottoRepository (repository)
        repository.SalvaProdotti(manager.OttieniProdotti());
    }
}
public class ProdottoAdvanced
{

    private int id;
    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valoe dell'Id deve essere maggiore di zero");
            }
            id = value;
        }
    }

    private string nomeProdotto;
    public string NomeProdotto
    {
        get { return nomeProdotto; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
            }
            nomeProdotto = value;

        }
    }

    private decimal prezzoProdotto;
    public decimal PrezzoProdotto
    {
        get { return prezzoProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero.");
            }
            prezzoProdotto = value;
        }
    }

    private int giacenzaProdotto;
    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set { giacenzaProdotto = value; }
    }
}

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; // prodotti e private perchè non voglio che venga modificato dall'esterno
    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>();
    }

    //creo metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto);
    }

    //aggiungo metodo per visualizzare la lista di prodotti
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    //metodo per cercare un prodotto
    public ProdottoAdvanced TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }

    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto !=null)
        {
            prodotti.Remove(prodotto);
        }
    }
}
public class ProdottoRepository
{
    
    // la classe ProdottoRepository è una classe che si occupa di gestire la persistenza dei dati in modo centralizzato
    // i vantaggi di questa classe sono:
    // - centralizzazione della logica di accesso ai dati
    // - facilità di manutenzione
    // - facilità di test
    // - possibilità di cambiare il tipo di persistenza senza dover specificare il codice che utilizza la classe
    // - possibilità di aggiungere logica di caching (memorizzazione temporanea dei dati) senza dover modificare il codice che utilizza la classe
}

    private readonly string filePath = "prodotti.json";
    
    //metodo per caricare i dati da file
    //restituisce una lista di prodotti se il file esiste e contiene dati

    public void SalvaProdotti (List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti,Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine ($"Dati salvati in {filePath}: \n{jsonData}\n");
    }

// metodo per caricare i dati da file
// restituisce una lista di prodotti se il file esiste e contiene dati
    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if (File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConverter.DeserializeObject<ListProdottoAdvanced>>(readJsonData); //deserializzo i dati letti dal file
            Console.WriteLine("Dati caricati da file");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                return prodotti; // restituisco la lista prodotti letti dal filein modo che possa essere utilizzata all'esterno della classe
            }
            else
            {
                Console.WriteLine("Nessun dato trovato.Inizializzare una nuova lista di prodotti.");
                return new List<ProdottoAdvanced>(); //restituisce una nuova lista di prodotti vuota se il file non esiste o è vuota
                // in modo che possa essere utilizzata all'esterno della classe
            }

            //restituisco la lista di prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
        }

    }
}    