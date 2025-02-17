using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;


public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm {get; set;}
    public List<ProdottoViewModel> Prodotti {get; set;} = new List<ProdottoViewModel>();
    public void OnGet(string q)
    {
        //assegno la stringa di ricerca alla proprieta pubblica
        SearchTerm = q;
        //se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            try
            {
                Prodotti = DbUtils.ExecuteReader(
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Nome LIKE @searchTerm",
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
                }
                );
            }
            catch (Exception ex)
            {
                  SimpleLogger.Log(ex);

            }
            /*using var connection = DatabaseInitializer.GetConnection();
            connection.Open();

            //query per selezionare i prodotti che contengono la stringa di ricerca
            //il like è case insensitive di default in sqlite
            //il like è un clausola che permette di fare una ricerca parziale
            var sql= @"
            SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
            FROM Prodotti p
            LEFT JOIN Categorie c ON p.CategoriaId = c.Id
            WHERE p.Nome LIKE @searchTerm";

            //lancio il comando sql sulla connessione
            using var command = new SQLiteCommand(sql, connection);
            //uso il parametro per evitare sql injection con % + q + % in modo da cercare la stringa in qualsiasi parte el nome
            command.Parameters.AddWithValue("@searchTerm", $"%{q}%");
            //ottengo il reader
            using var reader = command.ExecuteReader();
            //finche il reader ha qualcosa da leggere vado a fare l' aggiunta del prodotto alla lista
            while (reader.Read())
            {
                //aggiungo un nuovo pprodotto alla lista Prodotti
                Prodotti.Add(new ProdottoViewModel
                {
                    //faccio il get dei campi del record restituito dalla query
                    Id= reader.GetInt32(0),
                    Nome= reader.GetString(1),
                    Prezzo= reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                });

            }*/
        }
    }
}