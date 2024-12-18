using System.Data.Common;
using MyApp.Models;
using Newtonsoft.Json;

public class CarrelloManager
{
    private int prossimoId;
    private List<Prodotto> prodotti;
    private List<Prodotto> catalogo;
    private ProdottoRepository repositoryCatalogo;
    private CarrelloRepository repositoryCarrello;
    private ClienteRepository repositoryCliente;


    public CarrelloManager (List<Prodotto> listaProdotti)
    {
        prodotti = listaProdotti;
        repositoryCatalogo = new ProdottoRepository();
        repositoryCarrello = new CarrelloRepository();
        repositoryCliente = new ClienteRepository();

        prossimoId = 1;
       
        
        if (listaProdotti != null)
        {
            prodotti = listaProdotti;
        }
        else
        {
            prodotti = new List<Prodotto>();
        }
        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId) // se l'ID del prodotto è maggiore o uguale al prossimoId
            {
                prossimoId = prodotto.Id + 1; // assegna al prossimoId il valore successivo
            }
        }

    }
    public void AggiungiProdotto(string ProdottoDaAggiungere, List<Prodotto> carrello, ref Cliente cliente)
    {
        catalogo = repositoryCatalogo.CaricaProdotti();

        bool trovato = false;
        foreach (var prodotto in catalogo)
        {
            if(prodotto.Nome.ToString() == ProdottoDaAggiungere)
            {
                
            }
        }
    }
}
