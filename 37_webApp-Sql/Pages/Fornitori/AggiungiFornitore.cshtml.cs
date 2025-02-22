using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Fornitori;

public class AggiungiFornitoreModel : PageModel
{
     [BindProperty] //attributo bind proprety per collegare il modello al form
    public Fornitore Fornitore { get; set; }
      
     public void OnGet()
    {
     
    }

    public IActionResult OnPost()
    {
       
        try
        {
            DbUtils.ExecuteNonQuery(
                "INSERT INTO Fornitori(Nome) VALUES (@nome)",
                cmd=>
                {
                    cmd.Parameters.AddWithValue("@nome",Fornitore.Nome);
                    
                }
            );
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
          
            return Page();
        }


        return RedirectToPage("Fornitore");
    }
}