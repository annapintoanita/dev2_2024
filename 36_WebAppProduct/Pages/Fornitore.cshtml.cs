public class Fornitore
{
    public string Fornitori {get; set;}

}



/*using Microsoft.AspNetCore.Mvc; // Importa il namespace per la gestione delle azioni e dei risultati nelle pagine Razor.
using Microsoft.AspNetCore.Mvc.RazorPages; // Importa il namespace per la gestione delle Razor Pages.
using Newtonsoft.Json; // Importa il namespace per il supporto alla serializzazione e deserializzazione JSON.

public class FornitoreModel : PageModel*/
/*
{
    // Inizializzazione della variabile _logger per il logging delle informazioni (non viene usata nel codice fornito).

    private readonly ILogger<FornitoreModel> _logger;

    public FornitoreModel(ILogger<FornitoreModel> logger)
    {
        _logger = logger;
    }
    
    //public List<string> Categorie { get; set; } 
    public List<string> Fornitore {get; set;}

    [TempData]
    public string Messaggio {get;  set;}
    
    public void OnGet()// onget è vuoto perchè non serve che al caricamento della pagina vengano visualizzati i dati del prodotto.
    {
        
        var json3 = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        Fornitore = JsonConvert.DeserializeObject<List<string>>(json3);

        //var json3 = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        //Fornitore = JsonConvert.DeserializeObject<List<string>>(json);
    }
    
*/

    //Metodo che viene eseguito quando si invia un modulo (POST) con nome, prezzo e dettaglio del prodotto.
    //IActionResult è il tipo di dato che indica che metodo restituisce un risultato che può essere una View o un redirect.
    /*public IActionResult OnPost(string fornitore )//onpost modifica le impostazioni

    {

        // Legge il contenuto del file JSON che contiene i dati dei prodotti.
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");

        // Deserializza il contenuto JSON in una lista di oggetti di tipo Prodotto.
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Calcola Id incrementando di 1 da quello precedente
        /*var id = 1;
        if (fornitori.Count > 0)
        {
            id = prodotti[prodotti.Count - 1].Id + 1;
        }*/

        // Aggiunge un nuovo prodotto alla lista con i valori passati tramite il form (nome, prezzo, dettaglio).
        
        /*prodotti.Add(new Prodotto
        {
            //Id = id,
            //Nome = nome,
            //Prezzo = prezzo,
            //Dettaglio = dettaglio,
            //Categoria = categoria,
            //DataInserimento = dataInserimento
            //DataInserimento = DateTime.Now,
            Fornitore = fornitore
            
        });

        // Scrive la lista aggiornata di prodotti nel file JSON, serializzandola di nuovo l'informazione in formato JSON.
        // crea il file partendo dalla lista, lo serializza e lo formatta.
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        // Reindirizza l'utente alla pagina "Prodotti" dopo aver aggiunto il nuovo prodotto.

        Messaggio = "Fornitore aggiunto con successo";
        TempData.Keep(Messaggio);
        return RedirectToPage("Prodotti");
    }
}
*/