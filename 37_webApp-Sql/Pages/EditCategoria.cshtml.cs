using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;

public class EditCategoriaModel : PageModel
{
    [BindProperty]
    public Categoria Categoria { get; set; }

    //passo l id come parametro perchè voglio modificare un prodottoesistente sul quale ho cliccato in precedenza
    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        //uso la clausola WHERE di sql in modo da ottenere solo il prodotto con id passato  come parametro
        var sql = "SELECT Id, Nome FROM Categorie WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        //eseguo il comando e ottengo il reeader che è un oggetto che permette di leggere i dati
        using var reader = command.ExecuteReader();

        //se il reader ha dati
        if (reader.Read())
        {
            Categoria = new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
            };
        }
        else
        {
            //se il prodotto non esiste ritorno NOT FOUND 
            // not found e un metodo di Page Model che restituisce un oggetto not found result che rappresenta la pagina  non trovata
            return NotFound();

        }
        return Page();

    }
    public IActionResult OnPost(int id)
    {
        if (!ModelState.IsValid)
        {         
            return Page();
        }

        //invoco il metodo getconnection per ottenere la connessione al db ed apro la pagina
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //costruisco la query basandomi sull input
        var sql = "UPDATE Categorie SET Nome = @nome WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", Categoria.Nome);
        command.Parameters.AddWithValue("@id", Categoria.Id);

        //eseguo il comando e aggiorno il prodotto poi reinderizzo alla pagina elenco dei prodotti
        command.ExecuteNonQuery();
        return RedirectToPage("Categoria");
    }
    //metodo per caricare le categorie    
}
