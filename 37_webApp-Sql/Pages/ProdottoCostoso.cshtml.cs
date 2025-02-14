using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;

public class ProdottoCostosoModel : PageModel
{
    public string SearchTerm { get; set; }
    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();

    public void OnGet(string q)
    {
        SearchTerm = q;

        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //scrivo nella query il limite per trovare solo 3 prodotti quindi LIMIT
        var sql = @"
        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        WHERE p.Nome LIKE @searchTerm
        ORDER BY p.Prezzo DESC
        LIMIT 3"; // solo i 3 più costosi

        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@searchTerm", $"%{q}%");

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Prodotti.Add(new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            });
        }
    }
}
