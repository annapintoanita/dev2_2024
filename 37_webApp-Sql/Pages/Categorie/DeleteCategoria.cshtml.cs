using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Utilities;
using _37_WebApp_SQLite.Models;

namespace _37_WebApp_SQLite.Pages.Categorie;
public class DeleteCategoriaModel : PageModel
{

    public Categoria Categoria { get; set; }
    public IActionResult OnGet(int id)
    {
        try
        {
            var Categorie = DbUtils.ExecuteReader("SELECT Id, Nome FROM Categorie WHERE Id = @id",
            reader => new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            },
            //command cmd separato perchè  per passare paramatero nell'on get e ci serve così perchè dobbiamo identicìficato il prodotto separato dal reader che va a leggere la query, la chiocciola per passarlo al reader e vedere l'id che abbiamo inizializzato
            cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
            }
            );
            Categoria = Categorie.First(); //.First(); 
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
          DbUtils.ExecuteNonQuery("DELETE FROM Categorie WHERE Id = @id",
            cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
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