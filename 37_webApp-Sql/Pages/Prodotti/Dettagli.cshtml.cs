
using _37_WebApp_SQLite.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_WebApp_SQLite.Models;
namespace _37_WebApp_SQLite.Pages.Prodotti;
using _37_WebApp_SQLite.Models;
public class DettagliModel : PageModel
{
    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)
    {
        try
        {
           var Prodotti= DbUtils.ExecuteReader("SELECT p.Id, p.Nome, p.Prezzo, c.Nome, f.Nome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id LEFT JOIN Fornitori f ON p.FornitoreId = f.Id WHERE p.Id = @id",
            reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
                 FornitoreNome = reader.IsDBNull(4) ? "Nessuno" : reader.GetString(4)
            },
            cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
            }
            );
           

            Prodotto = Prodotti.First();
        }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }

       /* using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        using var reader = command.ExecuteReader();


        if (reader.Read())
        {
            Prodotto = new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
            };
        }
        else
        {
            return NotFound(); // Se non trova il prodotto, ritorna NotFound
        }*/

        return Page();
    }

}
