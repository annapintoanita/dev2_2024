using System.Collections.Generic;
using System.Text.Json;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using Newtonsoft.Json;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public int numeroPagine { get; set; }
    public IEnumerable<Prodotto> Prodotti { get; set; }
    string filePath;
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        filePath = "wwwroot/prodotti.json";
        string json = System.IO.File.ReadAllText(filePath);
        Prodotti = JsonConvert.DeserializeObject<IEnumerable<Prodotto>>(json);

        var allProdotti = Prodotti;

        /*{
            Prodotti = new List<Prodotto>
        {
                new Prodotto {Nome = "Prodotto1", Prezzo = 10, Dettaglio = "Dettaglio1", Immagine="https://img.joomcdn.net/5ba0c59ac5bdb4750ec4c92a752306d5ddbccaf6_original.jpeg"},
                new Prodotto {Nome = "Prodotto2", Prezzo = 20, Dettaglio = "Dettaglio2", Immagine="https://img.joomcdn.net/f5cc4408e4c7cc959130bda4907c7bb5e64688fd_original.jpeg"},
                new Prodotto {Nome = "Prodotto3", Prezzo = 30, Dettaglio = "Dettaglio3", Immagine="https://img.joomcdn.net/4f6f87c5eba655b11014fcc610baef5656cab2b5_original.jpeg"},
        };*/
            _logger.LogInformation("Prodotti caricati");

             //inizializimo la lista filtrata
        var prodottiFiltrati = new List<Prodotto>();

        foreach (var prodotto in allProdotti)
        {
            bool aggiungi = true;

            if (minPrezzo.HasValue)
            {
                if (prodotto.Prezzo < minPrezzo.Value)
                {
                    aggiungi = false;
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

        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);
        // calcola il numero di pagine Math.eiling arrotonda il numero di pagine all'interno del pià vicino 
        // Prodotti,Count restituisc il numero di elementi nella lista Prodotti
        // 6.0 è il numero di prodotti per pagina
    
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
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
