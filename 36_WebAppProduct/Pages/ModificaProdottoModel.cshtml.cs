using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }
    public Prodotto Prodotto { get; set; }

    public void OnGet(int id)
    {
        string path = Path.Combine("wwwroot/json", "prodotti.json");
        var json = System.IO.File.ReadAllText(path);
        dynamic prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }
    }

    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine,int quantita,string categoria)
    {
        string path = Path.Combine("wwwroot/json", "prodotti.json");
        var json = System.IO.File.ReadAllText(path);
        dynamic prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto prodotto = null; //inizializzato a null perchè 
                                  //se non trova niente non ha niente da modificare
                                  //dobbiamo quindi discriminare entrambi i casi.

        foreach (var p in prodotti)
        {
            if (p.Id == id)
            {
                prodotto = p;
                break;
            }
        }
        
            if (prodotto == null)
            {
                return NotFound();
            }

            prodotto.Nome = nome;
            prodotto.Prezzo = prezzo;
            prodotto.Dettaglio = dettaglio;
            prodotto.Immagine = immagine;
            prodotto.Categoria = categoria;
            prodotto.Quantita = quantita;

            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(prodotti, Formatting.Indented));
            return RedirectToPage("Prodotti");
    }
}