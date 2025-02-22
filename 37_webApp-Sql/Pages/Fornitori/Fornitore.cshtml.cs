using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Utilities;
using _37_WebApp_SQLite.Models;
namespace _37_WebApp_SQLite.Pages.Fornitori;
public class FornitoreModel : PageModel
{
    
    public List<Fornitore> Fornitori { get; set; } = new List<Fornitore>();
    public void OnGet()
    {
        try
        {
            Fornitori = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Fornitori",
                reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}