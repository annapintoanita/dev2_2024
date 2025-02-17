using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;

public class DashboardModel : PageModel
//creo una proprieta  pubblica di tipo lista di prodotti view model
//devo ceare la lista sulla quale lavoro creando una proprieta pubblica che prendo da prodottoviewmodel

{
    [BindProperty(SupportsGet = true)]
    public List<ProdottoViewModel> ProdottoCostoso { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottoEconomico { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottoRecente { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> SceltaCategoria { get; set; } = new List<ProdottoViewModel>();

    public void OnGet()
    {
        try
        {

            ProdottoCostoso = DbUtils.ExecuteReader(
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id ORDER BY p.Prezzo DESC LIMIT 3",
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        try
        {
            ProdottoEconomico = DbUtils.ExecuteReader("SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id ORDER BY p.Prezzo ASC LIMIT 3",
             reader => new ProdottoViewModel
             {
                 Id = reader.GetInt32(0),
                 Nome = reader.GetString(1),
                 Prezzo = reader.GetDouble(2),
                 CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3) //operatore ternario
             }
             );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            ProdottoRecente = DbUtils.ExecuteReader("SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id ORDER BY p.Id DESC LIMIT 3",
            reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            }
           );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        try
        {
            SceltaCategoria = DbUtils.ExecuteReader("SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.CategoriaId = 1 LIMIT 3",
               reader => new ProdottoViewModel
               {
                   Id = reader.GetInt32(0),
                   Nome = reader.GetString(1),
                   Prezzo = reader.GetDouble(2),
                   CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
               }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        /*
         //invoco il metodo GetConnection per ottenere la connessione al db
         using var connection = DatabaseInitializer.GetConnection();
         //apro la connessione
         connection.Open();

         //creo la query sql per ottenere i dati dei prodotti
         //voglio accedere al nome della categoria quindi devo fare un join tra la tabella prodotti e la tabella categorie
         //uso JOIN per ottenere solo i prodotti con categoria
         //uso LEFT JOIN per ottenere anche i prodotti senza categoria (ma poi devo gestire l'eccezione)
         //posso usare p e c come alias per le tabelle prodotti e categorie se voglio usare i nomi completi delle tabelle devo usare Prodotti e Categorie(il nome completo)
         //pero usando Prodotti e Categorie il codice diventa piu lungo perche devo assegnare i nomi completi delle tabelle ai campi
         //il vantaggio di usare gli alias è che dopo posso usare p e c per accedere ai campi tabelle


         //creo il comando sql per eseguire la query
         using (var command = new SQLiteCommand(sql, connection))

         //uso il reader come un cursore per scorrere i record restituiti dalla query
         using (var reader = command.ExecuteReader())
         {
             while (reader.Read())
             {
                 //aggiungo i dati del prodotto alla lista di prodotti
                 //uso prodotto view model perche voglio visualizzare il nome della categoria
                 ProdottoCostoso.Add(new ProdottoViewModel
                 {
                     //faccio il get dei campi del record restituito dalla query
                     Id = reader.GetInt32(0),
                     Nome = reader.GetString(1),
                     Prezzo = reader.GetDouble(2),
                     // versione senza il controllo se la categoria è nulla
                     //CategoriaNome = reader.GetString(3)
                     //IsDBNull restituisce un booleano,controlla se il campo è null e restituisce true se è null
                     //se è null restituisco l'elemento alla sinistra dei due punti
                     //se non è null restituisco l'elemento alla destra dei due punti
                     CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3) //operatore ternario
                                                                                          //SoloInOfferta = reader.IsDBNull
                 });
             }
         }
         var sqlEconomico = @"
             SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
             FROM Prodotti p
             LEFT JOIN Categorie c ON p.CategoriaId = c.Id
             ORDER BY p.Prezzo ASC
             LIMIT 3"; // solo i 3 più economici


         //creo il comando sql per eseguire la query
         using (var command = new SQLiteCommand(sqlEconomico, connection))

         //uso il reader come un cursore per scorrere i record restituiti dalla query
         using (var reader = command.ExecuteReader())
         {
             while (reader.Read())
             {
                 //aggiungo i dati del prodotto alla lista di prodotti
                 //uso prodotto view model perche voglio visualizzare il nome della categoria
                 ProdottoEconomico.Add(new ProdottoViewModel
                 {
                     //faccio il get dei campi del record restituito dalla query
                     Id = reader.GetInt32(0),
                     Nome = reader.GetString(1),
                     Prezzo = reader.GetDouble(2),
                     // versione senza il controllo se la categoria è nulla
                     //CategoriaNome = reader.GetString(3)
                     //IsDBNull restituisce un booleano,controlla se il campo è null e restituisce true se è null
                     //se è null restituisco l'elemento alla sinistra dei due punti
                     //se non è null restituisco l'elemento alla destra dei due punti
                     CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3) //operatore ternario
                                                                                          //SoloInOfferta = reader.IsDBNull
                 });
             }
         }
         //finche ci sono dati nel reader continua a ciclare

         //leggo i record restituiti dalla query finche ce ne sono


         //using var connection2 = DatabaseInitializer.GetConnection();

         sql = @"
             SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
             FROM Prodotti p
             LEFT JOIN Categorie c ON p.CategoriaId = c.Id
             ORDER BY p.Id DESC
             LIMIT 3"; // solo i 3 più costosi


         //creo il comando sql per eseguire la query
         using (var command = new SQLiteCommand(sql, connection))

         //uso il reader come un cursore per scorrere i record restituiti dalla query
         using (var reader = command.ExecuteReader())
         {
             while (reader.Read())
             {
                 //aggiungo i dati del prodotto alla lista di prodotti
                 //uso prodotto view model perche voglio visualizzare il nome della categoria
                 ProdottoRecente.Add(new ProdottoViewModel
                 {
                     //faccio il get dei campi del record restituito dalla query
                     Id = reader.GetInt32(0),
                     Nome = reader.GetString(1),
                     Prezzo = reader.GetDouble(2),
                     // versione senza il controllo se la categoria è nulla
                     //CategoriaNome = reader.GetString(3)
                     //IsDBNull restituisce un booleano,controlla se il campo è null e restituisce true se è null
                     //se è null restituisco l'elemento alla sinistra dei due punti
                     //se non è null restituisco l'elemento alla destra dei due punti
                     CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3) //operatore ternario
                                                                                          //SoloInOfferta = reader.IsDBNull
                 });
             }
         }
         //finche ci sono dati nel reader continua a ciclare

         //leggo i record restituiti dalla query finche ce ne sono

         //connection2.Close();
         //using var connection = DatabaseInitializer.GetConnection();

         sql = @"
             SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
             FROM Prodotti p
             LEFT JOIN Categorie c ON p.CategoriaId = c.Id
             WHERE p.CategoriaId = 1
             LIMIT 3"; // solo 3


         //creo il comando sql per eseguire la query
         using (var command = new SQLiteCommand(sql, connection))

         //uso il reader come un cursore per scorrere i record restituiti dalla query
         using (var reader = command.ExecuteReader())
         {
             while (reader.Read())
             {
                 //aggiungo i dati del prodotto alla lista di prodotti
                 //uso prodotto view model perche voglio visualizzare il nome della categoria
                 SceltaCategoria.Add(new ProdottoViewModel
                 {
                     //faccio il get dei campi del record restituito dalla query
                     Id = reader.GetInt32(0),
                     Nome = reader.GetString(1),
                     Prezzo = reader.GetDouble(2),
                     // versione senza il controllo se la categoria è nulla
                     //CategoriaNome = reader.GetString(3)
                     //IsDBNull restituisce un booleano,controlla se il campo è null e restituisce true se è null
                     //se è null restituisco l'elemento alla sinistra dei due punti
                     //se non è null restituisco l'elemento alla destra dei due punti
                     CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3) //operatore ternario
                                                                                          //SoloInOfferta = reader.IsDBNull
                 });
             }
         }

         //finche ci sono dati nel reader continua a ciclare

         //leggo i record restituiti dalla query finche ce ne sono
 */
    }
}