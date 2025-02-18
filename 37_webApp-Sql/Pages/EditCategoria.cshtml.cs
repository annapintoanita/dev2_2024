using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;
public class EditCategoriaModel : PageModel
{
    [BindProperty]
    public Categoria Categoria { get; set; }

    //passo l id come parametro perchè voglio modificare un prodottoesistente sul quale ho cliccato in precedenza
    public IActionResult OnGet(int id)
    {
        try
        {
            var Categorie = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie WHERE Id = @id",
                reader => new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
            );
            Categoria = Categorie.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            return NotFound();
        }
        return Page();
    }
    /*using var connection = DatabaseInitializer.GetConnection();
    connection.Open();

    var sql = "SELECT Id, Nome FROM Categorie WHERE Id = @id";
    using var command = new SQLiteCommand(sql, connection);
    command.Parameters.AddWithValue("@id", id);

    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
        Categoria = new Categoria
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1)
        };
    }
    else
    {
        return NotFound();
    }

    return Page();*/


    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            DbUtils.ExecuteNonQuery(
                "UPDATE Categorie SET Nome = @nome WHERE Id = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Categoria.Nome);
                    cmd.Parameters.AddWithValue("@id", Categoria.Id);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Categoria");
    }
}
/*using var connection = DatabaseInitializer.GetConnection();
connection.Open();

var sql = "UPDATE Categorie SET Nome = @nome WHERE Id = @id";
using var command = new SQLiteCommand(sql, connection);
command.Parameters.AddWithValue("@nome", Categoria.Nome);
command.Parameters.AddWithValue("@id", Categoria.Id);

command.ExecuteNonQuery();

return RedirectToPage("Categoria");*/