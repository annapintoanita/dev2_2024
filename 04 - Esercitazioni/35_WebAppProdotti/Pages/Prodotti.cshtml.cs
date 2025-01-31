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
    public IEnumerable<Prodotto> Prodotti { get; set; }
    public void OnGet()
     {
        Prodotti = new List<Prodotto>
            {
                new Prodotto {Nome = "Prodotto1", Prezzo = 100},
                new Prodotto {Nome = "Prodotto2", Prezzo = 200},
                new Prodotto {Nome = "Prodotto3", Prezzo = 300}
            };
    }

}