using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;
using _37_webApp_Sql.Utilities;
public class CategoriaModel : PageModel
{
    
    public List<Categoria> Categorie { get; set; } = new List<Categoria>();
    public void OnGet()
    {
        try
        {
            Categorie = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie",
                reader => new Categoria
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