using Newtonsoft.Json;

//comando per installare il pacchetto using
//dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        //creare una lista di prodotti
        List<Prodotto> prodotti = new List<Prodotto>
        {   //10.5m la m sta per decimal (tipo di dato) e indica che il valore è un decimale (numero con la virgola)
            new Prodotto { Id = 1, NomeProdotto = "Prodotto A" , PrezzoProdotto = 10.50m, GiacenzaProdotto = 100},
            new Prodotto { Id = 2, NomeProdotto= "Prodotto B" , PrezzoProdotto = 20.75m, GiacenzaProdotto = 50}
        };

        //serializzare i dati in file Json
        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($" Dati serializzati e salvati in {filePath}:\n{jsonData}\n");

        //Deserializzare i dati del file json
        string readJson = File.ReadAllText(filePath);
        List<Prodotto> prodottiDeserializzati = JsonConvert.DeserializeObject<List<Prodotto>>(readJson);

        Console.WriteLine($"Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo:{prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }
    }


}

// il modificatore public significa che la classe è accessibil da qualsiasi codice all'innterno dell'applicazione
// gli altri tipi di accesso sono privati, protected
// la classe Prodotto contiene quattro proprietà:Id. NompeProdotto, PrezzoProdotto e GiacenzaProdotto
// le proprietà sono definite con il modificatore di accesso public, quindi sono accessibili da qualsiasi codice all'interno dell'appllicazione
// le proprieta sono defintite con il modificatore set, quindi posso essere lette da qualsiasi codice all'interno ell'applicazione
// le proprietà sono definite con il modificatore get, quindi possono essere lette da qualsiasi codice all'interno dell'applicazione
public class Prodotto
{
    public int Id { get; set; }
    public string NomeProdotto { get; set; }
    public decimal PrezzoProdotto { get; set; }
    public int GiacenzaProdotto { get; set; }
}

//esempio di classe con proprietà private rese pubbliche tramite metodi get e set dopo aver applicato delle egole di validazione
public class ProdottoAdvanced
{
    // definisco una variabile privata id
    // la definisco privata in modo che non possa essere modificata direttamente dall'esterno della classe
    // così solo la classe ProdottoAdvanced può accedre e modificare la variabile id
    private int id; // campo privato

    // definisci una proprità pubblica Id in modo che possa essere letta e scritta dall'esterno della classe
    // il vantaggio di utilizzare una proprietà è che posso controllare l'accesso alla variabile privata id e applicare delle regole di validazione
    //ad esempio posso controllare che il valoro passato come argomento sia maggiore di zero

    public int Id
    {
        get { return id; } //restituisce il valore della variabile privata Id
        //set { Id = value; } //imposta il valore della variabile privata Id con il valore passato come argomento
        //implemento la logica di validzione per il valore passato come argomento
        //se  il valore passato come argomento è mnore o uguale a zero, sollevo un'eccezione
        //l'eccezione inerrompe l'esecuzione del programma e mostra un messaggio di errore
        //l'eccezione può essere catturata e gestita da un blocco try catch
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value; // imposta il valore della variabile privata id con il valore passato come argomento
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
        get { return prezzoProdotto;}
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prodotto deve essere maggiore di zero.");
            }
            prezzoProdotto = value;
        }
    }

    private int giacenzaProdotto;
    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set { giacenzaProdotto = value ;}
    }
}