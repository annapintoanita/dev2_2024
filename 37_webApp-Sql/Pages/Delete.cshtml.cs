
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_webApp_Sql.Utilities;// il namespace per accedere alla cartella utilities e i file che ci sono dentro.

public class DeleteModel : PageModel
{

    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)//Carica i dati del prodotto con l'id specificato.
    {
        try
        {
            //La query viene eseguita usando il metodo DbUtils.ExecuteReader 
            //che esegue la query SQL e restituisce un lettore (reader) per leggere i dati.
            //LEFT JOIN per prendere i prodotti anche se non hanno una categoria associata.
            var Prodotti = DbUtils.ExecuteReader( "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Id = @id",
            reader => new ProdottoViewModel
            {
                 Id = reader.GetInt32(0),
                 Nome = reader.GetString(1),
                 Prezzo = reader.GetDouble(2),
                 CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            },
            //command cmd separato per passare paramatero nell'on get e ci serve così perchè 
            //dobbiamo identicìficato il prodotto separato dal reader che va a leggere la query, 
            //la chiocciola per poter mettere dinamicamente l'id dove ci serve.
       
            cmd =>  
            {
                cmd.Parameters.AddWithValue("@id",id);
            }
            );
            Prodotto = Prodotti.First();
        }
        catch (Exception ex)
        //Se qualcosa va storto, viene catturata un'eccezione e loggata usando SimpleLogger.Log(ex).
        {
            //per stampare un eccezione e catturare l'errore,posso provare a modificare qualcosa nella query 
            //e lanciare il comando
            //nel log.txt dovrebbe apparirmi l'errore (eccezione) 
            SimpleLogger.Log(ex);
        }
        return Page();
    }
        //uso l id del prodotto nell onpost per prendere l'id del prodotto nel parametro
        //Elimina il prodotto con l'id specificato dal database
        //elimina il prodotto dalla tabella Prodotti dove il Id corrisponde 
        //al valore passato come parametro @id.
        public IActionResult OnPost(int id)
        {
            try
            {
                //si usa DbUtils.ExecuteReader per eseguire la query. 
                // In questo caso non viene restituito alcun valore dal database
                //gestisce l'esecuzione delle query SQL. Il metodo ExecuteReader viene utilizzato per eseguire 
                //le query e ottenere i risultati
                //passando una funzione di lettura reader => , per mappare i risultati a oggetti ProdottoViewModel.
                
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
                //Aggiunge un parametro alla query SQL per prevenire attacchi di SQL injection. In questo caso,
                //il parametro @id viene sostituito dal valore di id passato al metodo.
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
/*il codice gestisce la visualizzazione e la cancellazione, in questo caso del prodotto. 
 carica i dati di un prodotto dal database;(con la richiesta get) 
 elimina il prodotto dal database e poi reindirizza (quando viene inviata la richiesta POST)
 alla pagina che ci interessa.La gestione degli errori serve per garantire che 
 eventuali problemi siano registrati */