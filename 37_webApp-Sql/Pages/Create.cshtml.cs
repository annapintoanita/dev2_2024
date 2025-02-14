//Librerie che servono per utilizzare metodi, modelli, proprietà
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
//namespace ProdottiApp.Pages.Prodotti;



public class CreateModel : PageModel //creo un modello di pagina Razor che deriva da PageModel che è il modello base delle pagine Razor.
{
    //attributo bind property per collegare il modello al form. è un attributo che si collega al form col metodo post che creerò nella pagina vista
    // nel form della pagina web nel tag input inserendo asp-for è possibile richiamare il campo della proprieta dichiarata
    //ad esempio :  <input type="text" asp-for="Prodotto.Nome" class="form-control "> assocerà il valore passato con quell'input direttamente nel campo Nome della proprieta Prodotto
    [BindProperty] 
    //proprieta pubblica di tipo Prodotto per contenere i dati del prodotto
    public Prodotto Prodotto { get; set; }

    //creo una lista di select list per contenere le categorie
    //select list item è un oggetto che rappresenta un elemento di una select list
    //Questa lista contiene le opzioni per il menu a tendina delle categorie.
   
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();


    //metodo per caricare le categorie
    public void OnGet() //gestisce tutto cio che succede nella pagina quando essa viene caricata
    {
        CaricaCategorie();//abbiamo inserito il metodo CaricaCategorie nell'onget perchè quando carico la pagina dell'aggiungi prodotto la pagina visualizza il form di inserimento dei dati del prodotto,
        //ma a me serve che all'interno del form mi venga visualizzata una lista delle categorie caricata dal database, questa parte del form una get. . Carica la lista delle categorie nell'onget, se non lo faccio
        //quando richiamo dall'altra parte con l'onget , non visualizzo niente, la parte del form che mi visualizza questo è:
        /*
        <label asp-for="Prodotto.CategoriaId"></label>
        <select asp-for="Prodotto.CategoriaId" class="form-control" asp-items="Model.CategorieSelectList">
            <option value="">--- Selezione Categoria --- </option>
        </select>
        Che si trova nella pagina cshtml
        */
    }

    public IActionResult OnPost() //è un metodo che viene eseguito quando invio un modulo sulla pagina web.
    /*Verifica dei dati: Prima di tutto, il sistema controlla se i dati che l'utente ha inserito sono corretti e completi.
    Salvataggio nel database: Se i dati sono validi, vengono salvati nel database (ad esempio, aggiungendo un nuovo prodotto).
    Reindirizzamento con IActionResult: Dopo aver salvato i dati, l'utente viene indirizzato a un'altra pagina, come la lista dei prodotti.
    In breve, OnPost è il metodo che gestisce l'azione quando l'utente invia un modulo.*/

    {
        //controllo se il modello è valido cioe se i dati inseriti dall'utente rispettano le regole di validazione
        //se il modello non e valido ritorno la pagina con gli errori
        if (!ModelState.IsValid)
        {
            CaricaCategorie(); //carico le categorie se no quando si carica si carica senza categorie
            //page e un metodo di page model che restituisce un oggetto page result che rappresenta la pagina nella quale siamo
            return Page(); //se il modello non è valido ritorno la pagina 
        }
        //invoco il metodo GetConnection per ottenere la connessione al db
        using var connection = DatabaseInitializer.GetConnection();
        //apro la connessione
        connection.Open();

        //creo la query sql per inserire un nuovo prodotto usando i parametri
        //i parametri servono in modo da evitare sql injection
        //la sql injection è un attacco informatico che sfrutta le query sql per inserire codice
        //in pratica dobbiamo separare i dati dalla query sql e passarli come parametri dopo che sono stati validati
        //si mette davanti al valore di parametro la chiocciola @
        var sql = "INSERT INTO Prodotti(Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoriaId )";

        //creo un comando sql per eseguire la query sulla connesione che ho creato
        using var command = new SQLiteCommand(sql, connection);

        //aggiungo i parametri al comando con il metodo add with value che prende il nome del parametro e il valore che al posto del valore inseriscono il codice malevolo che quindi viene letto
        command.Parameters.AddWithValue("@nome", Prodotto.Nome);
        command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
        command.Parameters.AddWithValue("@categoriaId", Prodotto.CategoriaId);
       

        //eseguo il comando
        command.ExecuteNonQuery();

        //reindirizzo il utente alla pagina di elenco dei prodotti
        return RedirectToPage("Index");
    }
    //metodo per caricare le categorie
    private void CaricaCategorie()
    {
        //Ottiene e apre una connessione al database.
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //creo la query sql per ottenere i dati delle categorie
        var sql = "SELECT Id, Nome FROM Categorie";


        //creo un comando per eseguire la query
        using var command = new SQLiteCommand(sql, connection);
        //leggo il risultato 
        using var reader = command.ExecuteReader();

        //finche il reader ha dati
        while (reader.Read())
        {
            CategorieSelectList.Add(new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),// converto in string in modo da poter essere usato
                Text = reader.GetString(1)
            });
           


        }
    }
}