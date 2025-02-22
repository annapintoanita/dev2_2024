using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Fornitori;
public class EditFornitoreModel : PageModel
{
    [BindProperty]
    public Fornitore Fornitore { get; set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            var Fornitori = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Fornitori WHERE Id = @id",
                reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
            );
            Fornitore = Fornitori.First();
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

    var sql = "SELECT Id, Nome FROM Fornitori WHERE Id = @id";
    using var command = new SQLiteCommand(sql, connection);
    command.Parameters.AddWithValue("@id", id);

    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
        Fornitore = new Fornitore
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
                "UPDATE Fornitori SET Nome = @nome WHERE Id = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Fornitore.Nome);
                    cmd.Parameters.AddWithValue("@id", Fornitore.Id);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Fornitore");
    }
}
/*using var connection = DatabaseInitializer.GetConnection();
connection.Open();

var sql = "UPDATE Fornitori SET Nome = @nome WHERE Id = @id";
using var command = new SQLiteCommand(sql, connection);
command.Parameters.AddWithValue("@nome", Fornitore.Nome);
command.Parameters.AddWithValue("@id", Fornitore.Id);

command.ExecuteNonQuery();

return RedirectToPage("Fornitore");*/