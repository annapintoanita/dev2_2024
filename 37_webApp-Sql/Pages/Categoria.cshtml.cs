using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
public class CategoriaModel : PageModel
{
    
    public List<Categoria> Categorie { get; set; } = new List<Categoria>();
    public void OnGet()
    {
        // Connessione al database
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

       
        var sql = "SELECT Id, Nome FROM Categorie";

        using var command = new SQLiteCommand(sql, connection);

        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            
            Categorie.Add(new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            });
        }
    }
}
