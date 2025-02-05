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
        //_logger.LoginInformation("Prodotti Caricati");
    }
    public IEnumerable<Prodotto> Prodotti {get; set;}

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo)
 
    
    {
        Prodotti = new List <Prodotto>
        {
                new Prodotto {Nome = "Prodotto1", Prezzo = 10, Dettaglio = "Dettaglio1", Immagine="https://img.joomcdn.net/5ba0c59ac5bdb4750ec4c92a752306d5ddbccaf6_original.jpeg"},
                new Prodotto {Nome = "Prodotto2", Prezzo = 20, Dettaglio = "Dettaglio2", Immagine="https://img.joomcdn.net/f5cc4408e4c7cc959130bda4907c7bb5e64688fd_original.jpeg"},
                new Prodotto {Nome = "Prodotto3", Prezzo = 30, Dettaglio = "Dettaglio3", Immagine="https://img.joomcdn.net/4f6f87c5eba655b11014fcc610baef5656cab2b5_original.jpeg"},
        };
        var prodottiFiltrati = new List<Prodotto>();
        //_logger.LogInformation("Prodotti Caricati");
         //var prodottiFiltrati = new List<Prodotto>();
        foreach (var prodotto in allProdotti)
        {
            bool aggiungi = true;
            if(minPrezzo.HasValue)
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
        //assegnamo ai prodotti filtrati alla proprietà Prodotii
        Prodotti = prodottiFiltrati;
        

    }
}
