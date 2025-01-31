using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;
    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;

    }
    public IEnumerable<Prodotto> Prodotti { get; set; }//una sequenza di elementi che non supporta la modifica
    public string Ricerca { get; set; }
    //public string Ricerca;
    public void OnGet()
    {
        Prodotti = new List<Prodotto>
            {
                new Prodotto {Nome = "Coca-cola", Prezzo = 100, Dettaglio = "Dettaglio1"},
                new Prodotto {Nome = "Fanta", Prezzo = 200, Dettaglio = "Dettaglio2"},
                new Prodotto {Nome = "Vino", Prezzo = 300, Dettaglio = "Dettaglio3"}
            };
        
        //creo una lista di prodotti filtrati
        List<Prodotto> prodottiFiltrati = new List<Prodotto>();

        if(!string.IsNullOrEmpty(Ricerca))
        //aggiungo alla lista di prodotti filtrati
        foreach (var prodotto in Prodotti)
        {
            if (prodotto.Nome.Contains(Ricerca))
            {
                prodottiFiltrati.Add(prodotto);
            }
             Prodotti = prodottiFiltrati;
        }
    }
}