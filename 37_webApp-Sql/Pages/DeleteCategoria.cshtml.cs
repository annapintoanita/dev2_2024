using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;


public class DeleteCategoriaModel : PageModel
{

    public Categoria Categoria { get; set; }
    public IActionResult OnGet(int id)
    {
        try
        {
            var Categorie = DbUtils.ExecuteReader("SELECT Id, Nome FROM Categorie WHERE Id = @id",
            reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            },
            cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
            }
            );
            //Categoria = Categorie.First();
        }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }
            return Page();
    }

    //uso l id del prodotto nell onpost
    public IActionResult OnPost(int id)
    {
        try
        {
            var Categorie = DbUtils.ExecuteReader("DELETE FROM Categorie WHERE Id = @id",
            reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            },
            cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
            }
            );
                    //Categoria = Categoria.First();
                }
                catch (Exception ex)
                {
                    SimpleLogger.Log(ex);
                }
                return RedirectToPage("Categoria");
    }
}