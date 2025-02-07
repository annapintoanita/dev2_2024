using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;//visualizza i messaggi di log, mi mostra in console i messaggi di bug
                        //li stampa ma quando eseguo l'azione sulla pagina interessata.
    }

    public int numeroPagine { get; set; }//proprietà del modello che possono essere
                                         // lette e scritte.
    public IEnumerable<Prodotto>? Prodotti { get; set; } //IEnumerable è una condizione generica,ad esempio in questo caso
                                                        //possiamo fare una lista senza sapere prima come è fatta.
    string? filePath; //variabile locale del modello, memorizza qualcosa.
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)//onget è un metodo che viene richiamato quando viene caricata una pagina.
    {
        filePath = "wwwroot/json/prodotti.json"; // stiamo assegnando la rotta wwwroot/prodotti.json alla variabile filePath.
        string json = System.IO.File.ReadAllText(filePath);// leggo cio che c'è nel filePath wwwroot/prodotti.json.
        Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);// deserializziamo il file json in una lista prodotto.

        //var allProdotti = Prodotti; 

        /*{
            Prodotti = new List<Prodotto>
        {
                new Prodotto {Nome = "Prodotto1", Prezzo = 10, Dettaglio = "Dettaglio1", Immagine="https://img.joomcdn.net/5ba0c59ac5bdb4750ec4c92a752306d5ddbccaf6_original.jpeg"},
                new Prodotto {Nome = "Prodotto2", Prezzo = 20, Dettaglio = "Dettaglio2", Immagine="https://img.joomcdn.net/f5cc4408e4c7cc959130bda4907c7bb5e64688fd_original.jpeg"},
                new Prodotto {Nome = "Prodotto3", Prezzo = 30, Dettaglio = "Dettaglio3", Immagine="https://img.joomcdn.net/4f6f87c5eba655b11014fcc610baef5656cab2b5_original.jpeg"},
        };*/
            _logger.LogInformation("Prodotti caricati");

             //inizializimo la lista filtrata
        var prodottiFiltrati = new List<Prodotto>(); //nuova lista in cui ci sono solo i prodotti che soddisfano i criteri

        foreach (var prodotto in Prodotti)
        {
            bool aggiungi = true; // variabile che dice se aggiungere o meno il prodotto alla lista filtrata.

            if (minPrezzo.HasValue) //hasvalue per controllare se il valore è stato assegnato.
            {
                if (prodotto.Prezzo < minPrezzo.Value)//value è il corrispottivo di hasvalue e restituisce il valore del nullable
                {
                    aggiungi = false;// non aggiunge il prodotto alla lista filtrata.
                }
            }

            if (maxPrezzo.HasValue)
            {
                if (prodotto.Prezzo > maxPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            if (aggiungi)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }
        Prodotti = prodottiFiltrati;

        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);//(int)per fare un casting esplicito ad un numero intero.
        // Math.ceiling arrotonda il numero di pagine all'interno del più vicino 
        // Prodotti.Count restituisce il numero di elementi nella lista Prodotti
        // 6.0 è il numero di prodotti per pagina
    
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
        // '??' operatore di coalescenza se pageindex è nullo ci restituisce 1
        // esegue la paginazione
        // skip salta i primi ((pageIndex ?? 1) - 1) * 6 elementi
        // take prende i successivi 6 prodotti
        // i ?? restituisce 1 se pageIndex è null o indefinito
        // facciamo -1 in modo che pageIndex inizi da 1 unvece ghe da 0.
        // questo ci permette di avere pPageIndex = 1 come prima pagina
        // perché non facciamo pageIndex + 1 ?? perch se poageIndex è null o indefinito
        // quindi bisogna fare pageIndex -1
    }
}
