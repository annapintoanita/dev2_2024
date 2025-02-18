using System.ComponentModel.Design;
using _37_webApp_Sql.Utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using ProdottiApp.Models;
using ProdottiApp.Utilities;
public class PageIndexModel : PageModel
{
    public PaginatedList<ProdottoViewModel> Products {get; set;}
    public int PageSize {get;set;} =5; //numero di prodotti per pagina
    public void OnGet (int? pageIndex)
    {
        int currentPage = pageIndex ?? 1;
        int TotalCount =DbUtils.ExecuteScalar<int> ("SELECT COUNT(*) FROM Prodotti");
        int offset = (currentPage -1) * PageSize;

        //recupera i prodotti per la pagina corrente
        //in sqlite si usa LIMIT e OFFSET per la paginazione
        //limit = quantti elementi voglio
        //offset= da ove voglio partire
        //offset= (pagina corrente -1) * elementi per pagina
        //LIMIT 5 OFFSET 0-> 5elementi a partire dall'elemento 0
        string sql = $@"
        SELECT p.Id, p.Nome, p.Prezzo, c.Nome a CategoriaNome
        FROM Prodotti p
        LEFT JOIN Categotie c ON p.CategoriaId = c.Id
        ORDER BY p.Id
        LIMIT {PageSize} OFFSET {offset}";
        
        List<ProdottoViewModel> items = DbUtils.ExecuteReader(sql,
        reader => new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome= reader.GetString(1),
            Prezzo= reader.GetDouble(2),
            CategoriaNome= reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
        }
        );

        //crea l oggetto paginato
        Products = new PaginatedList<ProdottoViewModel>(items,TotalCount, currentPage, PageSize);
    }
}