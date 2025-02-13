//Librerie che servono per utilizzare metodi, modelli, proprietà
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;

public class CreateCategoriaModel : PageModel
{
    [BindProperty]
    public string NuovaCategoria { get; set; } 

    public void OnGet()
    {
     
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrEmpty(NuovaCategoria))
        {
        
            return Page(); 
        }

        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        var sql = "INSERT INTO Categorie(Nome) VALUES (@nome)";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", NuovaCategoria);

        command.ExecuteNonQuery();

        
        return RedirectToPage("Index");
    }
}
