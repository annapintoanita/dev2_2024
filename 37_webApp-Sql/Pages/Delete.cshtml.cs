
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;

public class DeleteModel : PageModel
{

    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)
    {
        try
        {
            var Prodotti = DbUtils.ExecuteReader( "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Id = @id",
            reader => new ProdottoViewModel
            {
                 Id = reader.GetInt32(0),
                 Nome = reader.GetString(1),
                 Prezzo = reader.GetDouble(2),
                 CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            },
            cmd => 
            {
                cmd.Parameters.AddWithValue("@id",id);
            }
            );
            Prodotto = Prodotti.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }
        //uso l id del prodotto nell onpost per prendere l'id del prodotto nel parametro
        public IActionResult OnPost(int id)
        {
            try
            {
                var Prodotti = DbUtils.ExecuteReader( "DELETE FROM Prodotti WHERE Id= @id",
                reader => new ProdottoViewModel
                {
                 Id = reader.GetInt32(0),
                 Nome = reader.GetString(1),
                 Prezzo = reader.GetDouble(2),
                 CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                },
                 cmd => 
                {
                    cmd.Parameters.AddWithValue("@id",id);
                }
                );
                Prodotto = Prodotti.First();
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
           
            return RedirectToPage("Prodotti");
        }
        
}    