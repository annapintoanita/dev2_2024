using Newtonsoft.Json;

class Program // <-- standard/default
{
    static void Main(string[] args) // <--- entry point. //string args è un array di stringhe (firma main) //un canale di comunicazione
    {
        //creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();

        //caricare i dati da file
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti(); //modello
        
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(); // passaggio obbligato da una classe derivare un oggetto utilizzabile

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Visualizza");
            Console.WriteLine("2. Aggiungi");
            Console.WriteLine("3. Trova per ID");
            Console.WriteLine("4. Aggiorna");
            Console.WriteLine("5. Elimina");
            Console.WriteLine("6. Esci");


            Console.Write("> ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");
                    foreach (var prodotto in manager.OttieniProdotti())
                    {
                        Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                    }
                    break;
                case "2":
                    Console.Write("ID > ");
                    int idMain = int.Parse(Console.ReadLine());
                    Console.Write("Nome > ");
                    string nome = Console.ReadLine();
                    Console.Write("Prezzo > ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza > ");
                    int giacenza = int.Parse(Console.ReadLine());
                    manager.AggiungiProdotto(new ProdottoAdvanced { Id = idMain, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
                    break;
                case "3":
                    Console.Write("ID > ");
                    int idProdotto = int.Parse(Console.ReadLine());
                    ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);

                    if (prodottoTrovato != null)
                    {
                        Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                    }
                    break;
                case "4":
                    Console.Write("ID: ");
                    int idProdottoDaAggiornare = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nomeNuovo = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzoNuovo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenzaNuova = int.Parse(Console.ReadLine());
                    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { Id = idProdottoDaAggiornare, NomeProdotto = nomeNuovo, PrezzoProdotto = prezzoNuovo });
                    break;
                case "5":
                    Console.Write("ID: ");
                    int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    manager.EliminaProdotto(idProdottoDaEliminare);
                    break;
                case "6":
                    repository.SalvaProdotti(manager.OttieniProdotti());
                    continua = false; //imposto la variabile continua a false per uscire dal ciclo while
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprovare");
                    break;
            }

        }
    }

}
public class ProdottoAdvanced
{
    private int id; // campo privato

    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value;
        }
    }

    private string nomeProdotto;  // campo privato
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

    private decimal prezzoProdotto;  // campo privato
    public decimal PrezzoProdotto
    {
        get { return prezzoProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero");
            }
            prezzoProdotto = value;
        }
    }
    private int giacenzaProdotto;  // campo privato
    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("La giacenza non può essere negativa");
            }
            giacenzaProdotto = value;
        }
    }
}

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; // prodotti e' private perche non voglio che venga modificato dall'esterno

    public ProdottoAdvancedManager()
    {
         prodotti = new List<ProdottoAdvanced>(); // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile all'esterno
         //new è necessario mi rende disponibile una nuova lista (affinchè dal dominio privato della classe possa comunicare all'esterno i dati aggiornati)
         //un modo per rendere pubblico un dato privato
    }

    // metodo per aggiungere
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto); // quella private
    }

    // metodo per visualizzare 
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    // metodo per cercare un prodotto 
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

    // metodo per modificare il prodotto
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

    // metodo per eliminare un prodotto
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}


//la gestione dei file json è più sicura se il path è privato
//dunque ogni file json avrà la propria Class Repository per salvare e caricare
//ma bisogna evitare di mischiare delle cose con delle altre (mantenere i vari blocchi modulari (riutilizzabili)
public class ProdottoRepository
{
    private readonly string filePath = "prodotti.json"; // percorso in cui memorizzare i dati

    //metodo per salvare i dati su file 
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);               //serializzazione= sto dando l'indicazione di COME vanno scritti sul json
        File.WriteAllText(filePath, jsonData); 
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}");
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if (File.Exists(filePath))
        {                                                       
                                                                            //deserializzazione= sto dando i pezzetti di codice a c# per farglieli comprendere
                                                                            
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.Id}, Nome {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
            }
            // restituisco la lista di prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
            return prodotti;
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            // restituisco una lista di prodotti vuota se il file non esisteo è vuoto
            return new List<ProdottoAdvanced>();
        }
    }
}