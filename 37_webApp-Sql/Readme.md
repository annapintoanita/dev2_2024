# Web App SQLite 
### 11/02

Abbiamo creato una nuova cartella in Esercitazioni col comando `dotnet new webapp -n`
- Aggiunto il package di sql `dotnet add package System.Data.SQLite`.

 In Data :
- Creato DatabaseInitializer.cs

Abbiamo creato la cartella Model in cui abbiamo:
- Creato Categoria.cs
- Creato Prodotto.cs
- Creato ProdottoViewModel.cs

Abbiamo creato in Pages:
- Prodotti.cshtml
- Prodotti.cshtml.cs
- Create.cshtml
- Create.cshtml.cs

Nel Program.cs abbiamo aggiunto `DatabaseInitializer.InitializerDatabase();`

In DatabaseInitializer.cs abbiamo:
- Creato il database `prodottiapp.db` e la stringa di connessione `Data Source=prodottiapp.db.`
- Creato le tabelle:
    - `Categorie`  con Id (PRIMARY KEY) e Nome
    - `Prodotti`   con Id (PRIMARY KEY), Nome, Prezzo, CategoriaId (FOREIGN KEY).
- Seeding dei dati iniziali:

Se le tabelle Categorie e Prodotti sono vuote, vengono inserite alcune categorie e prodotti predefiniti.

- creato il Metodo `GetConnection()` che restituisce una connessione SQLite da usare in altre parti del codice.

Nella pagina Create:

Quando la pagina viene caricata (OnGet()), viene chiamato il metodo `CaricaCategorie()` per popolare il menu a tendina con le categorie.

Quando il form viene inviato (OnPost()):

<details>

<summary>ONGET/ONPOST</summary>

`OnGet()`: Recupera e prepara i dati per la visualizzazione quando la pagina viene aperta.

`OnPost()`: Gestisce i dati inviati dall'utente, li valida e li salva nel database.


</details>


- Verifica se il modello è valido con `ModelState.IsValid`

- Apre la connessione al database:
```csharp
using var connection = new SQLiteConnection(_connectionString);
//Il comando connection.Open(); apre la connessione
```
- Inserisce il prodotto nel database tramite parametri SQL per evitare SQL injection:
```csharp
INSERT INTO Prodotti(Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoriaId)
command.Parameters.AddWithValue("@nome", Prodotto.Nome);
command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
command.Parameters.AddWithValue("@categoriaId", Prodotto.CategoriaId);
```
- Reindirizza l'utente alla pagina di elenco dei prodotti (Index).

## DatabaseInitializer.cs

- Il codice crea un database prodottiapp.db se non esiste.

- Crea due tabelle: Categorie e Prodotti.

- Se le tabelle sono vuote, inserisce dati iniziali.

- Offre un metodo GetConnection() per ottenere una connessione al database.


```csharp
//Importo la libreria System.Data.SQLite, necessaria per gestire il database SQLite.
using System.Data.SQLite;
```
<details>

<summary>CLASSE STATICA</summary>

`Possiamo immaginarla come una raccolta di funzioni (che prima scrivevo nel main).
Posso usarla per non andare ad intaccare le funzionalità del main. 
Nella classe statica non ci sono proprietà ma tutte le cose vanno passate in argomento. (non ha bisogno del costruttore)
Può essere usata senza creare un oggetto (o istanza).
Permette di organizzare e riutilizzare il codice in modo più semplice. Non devo creare oggetti ogni volta per poter utilizzare i metodi.
Un membro static è condiviso tra tutte le istanze della classe, è associato alla classe stessa`

</details>

```csharp

//Dichiarazione della Classe DatabaseInitializer:
//è una classe static, il che significa che i suoi metodi e variabili possono essere usati 
//senza creare un'istanza(o oggetto) della classe, ma ricorda che tutte le cose devono essere passate in argomento. 
public static class DatabaseInitializer
{
        
    //connessione al database:
    //Definisco una stringa _connectionString che specifica il file SQLite da usare (prodottiapp.db).
    //Questa stringa sarà usata per connettersi al database.
    private static string _connectionString = "Data Source=prodottiapp.db";
    //Metodo principale che inizializza il database,
    // crea le tabelle e inserisce dati di base (se non già presenti).
    public static void InitializerDatabase()
    {

        //creazione della connessione al database:
        //Creo un oggetto connection per connettersi al database.
        using var connection = new SQLiteConnection(_connectionString);
        //Il comando connection.Open(); apre effettivamente la connessione.
        connection.Open();
        //creo la tabella di Categorie
        var createCategorieTable = @"
        CREATE TABLE IF NOT EXISTS Categorie
        (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome TEXT NOT NULL
        );"
        ;
        /*
        Definisco una query SQL per creare la tabella Categorie,se non esiste già.-->IF NOT EXISTS
        La tabella ha:
        Id come chiave primaria che si incrementa automaticamente.
        Nome, un campo di tipo TEXT che non può essere nullo.
        */

        //Creo un oggetto command con la query e lo eseguo (ExecuteNonQuery()),
        //non restituisce dati ma esegue il comando.
        using (var command = new SQLiteCommand(createCategorieTable, connection))
        {
            command.ExecuteNonQuery();
        }
        //apriamo la connessione
        //gestisco l' eccezione se il db esiste gia in sql
        //creo la tabella Prodotti
        var createProdottiTable = @"
        CREATE TABLE IF NOT EXISTS Prodotti
        (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome TEXT NOT NULL,
        Prezzo REAL NOT NULL,
        CategoriaId INTEGER,
        FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id)
        );"
        ;
            /*
            Definisco la query per la tabella Prodotti, che contiene:
            Id (chiave primaria, autoincrementante).
            Nome (TEXT NOT NULL).
            Prezzo (REAL NOT NULL, cioè un numero con decimali).
            CategoriaId (un riferimento alla tabella Categorie).
            FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id): indica che CategoriaId
            deve essere un valore valido dalla tabella Categorie.
            */

        //Creo il comando e lo eseguo per creare la tabella se non esiste:
        using (var command = new SQLiteCommand(createProdottiTable, connection))
        {
        //eseguo la query ma il comando sql non ritorna niente
        command.ExecuteNonQuery();
        }

        //seed dei dati per Categorie solo la prima volta.
        //inserimento dei dati nella tabella Categoria(se vuota):
        var countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Categorie", connection);
        var count = (long)countCommand.ExecuteScalar();
        //dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        //execute scalar ritorna un oggetto,restituisce un valore singolo, quindi faccio il casting a long per ottenere il valore numerico.
        //Con SELECT COUNT(*) contiamo quanti record ci sono nella tabella Categorie.

        //Se la tabella è vuota (count == 0),allora non ci sono categorie nel db e posso fare il seed dei dati(inserisco le categorie predefinite: "Elettronica", "Abbigliamento", "Casa") :
        if (count == 0)
        {
            var insertCategorie = @"
            INSERT INTO Categorie (Nome)
            VALUES ('Elettronica'),
            ('Abbigliamento'), 
            ('Casa');
            ";
            //lancio il comando sulla connessione che ho creato 
            using (var command = new SQLiteCommand(insertCategorie, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    
        //seed dei dati per Prodotti (solo se non esistono gia)
        countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Prodotti", connection);
        //contiamo quanti prodotti ci sono nella tabella
        //dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        //execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere  il valore numerico
        count = (long)countCommand.ExecuteScalar();
        //Se la tabella Prodotti è vuota, inseriamo prodotti predefiniti con il loro prezzo e categoria.
        //Per ottenere CategoriaId, usiamo SELECT Id FROM Categorie WHERE Nome= 'Elettronica'.
        if (count == 0)
        {
            // Seed dei dati per la tabella Prodotti
            var insertProdotti = @"
                INSERT INTO Prodotti (Nome,Prezzo,CategoriaId) VALUES ('Gameboy',18.99, (SELECT Id FROM Categorie WHERE Nome= 'Elettronica')),
                ('T-shirt', 19.99, (SELECT Id FROM Categorie WHERE Nome= 'Abbigliamento')), 
                ('Lampada', 49.99, (SELECT Id FROM Categorie WHERE Nome='Casa' ));
                ";
            //lancio il comando sulla connessione che ho creato
            using (var command = new SQLiteCommand(insertProdotti, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
     //metodo per ottenere la connessione al database in modo da poter essere utilizzato in altre parti del codice
     //oltretutto database initializer è una classe statica quindi posso chiamare questo metodo senza creare un istanza della classe.
     //Quindi:
     //Questo metodo restituisce un oggetto SQLiteConnection, che può essere usato in altre parti del programma per connettersi al database.
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(_connectionString); // in questo modo la connessione è creata ma non aperta però non puo essere utilizzata in altri metodi.
    }
}
```
## Prodotti.cshtml.cs (quello che per altri è Index)

```csharp
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;

//namespace ProdottiApp.Pages.Prodotti; (per chi ha deciso di utilizzare i namespace)
public class ProdottiModel : PageModel
//creo una proprieta  pubblica di tipo lista di prodotti view model
//devo ceare la lista sulla quale lavoro creando una proprieta pubblica che prendo da prodottoviewmodel

{
    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();
    public void OnGet()
    {
        //invoco il metodo GetConnection per ottenre la connessione al db
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
        var sql = @"
        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id";

        //creo il comando sql per eseguire la query
        using var command = new SQLiteCommand(sql, connection);

        //uso il reader come un cursore per scorrere i record restituiti dalla query
        using var reader = command.ExecuteReader();
        //finche ci sono dati nel reader continua a ciclare

        //leggo i record restituiti dalla query finche ce ne sono
        while (reader.Read())
        {
            //aggiungo i dati del prodotto alla lista di prodotti
            //uso prodotto view model perche voglio visualizzare il nome della categoria
            Prodotti.Add(new ProdottoViewModel{
                //faccio il get dei campi del record restituito dalla query
                Id= reader.GetInt32(0),
                Nome= reader.GetString(1),
                Prezzo= reader.GetDouble(2),
                // versione senza il controllo se la categoria è nulla
                //CategoriaNome = reader.GetString(3)
                //IsDBNull restituisce un booleano,controlla se il campo è null e restituisce true se è null
                //se è null restituisco l'elemento alla sinistra dei due punti
                //se non è null restituisco l'elemento alla destra dei due punti
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            });
        }
    }
}
```

## Create.cshtml.cs

```csharp
//Librerie che servono per utilizzare metodi, modelli, proprietà 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering;  //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite; //per connettersi a un database SQLite
//namespace ProdottiApp.Pages.Prodotti;(per chi ha scelto di utilizzare il namespace)

//creo un modello di pagina Razor che deriva da PageModel
//CreateModel è un modello di pagina Razor.
//Estende PageModel, che è la classe base per le pagine Razor--> ' : PageModel' 
public class CreateModel : PageModel 

    //bind property è un attributo che permette di collegare il modello al form col metodo post che creerò nella pagina vista
    //nel form della pagina web, nel tag input inserendo asp-for è possibile richiamare il campo della proprietà dichiarata
    //ad esempio :  <input type="text" asp-for="Prodotto.Nome" class="form-control "> assocerà il valore passato con quell'input direttamente nel campo Nome della proprieta Prodotto.
    [BindProperty] 

    //proprieta pubblica di tipo Prodotto per contenere i dati del prodotto
    public Prodotto Prodotto { get; set; }

    //creo una lista di select list per contenere le categorie
    //select list item è un oggetto che rappresenta un elemento di una select list
    //Questa lista contiene le opzioni per il menu a tendina delle categorie.
    //Ogni elemento della lista rappresenta una categoria (ID e Nome).
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();

    //metodo per caricare le categorie
    //OnGet() viene eseguito quando la pagina viene caricata.
    //gestisce tutto cio che succede nella pagina quando essa viene caricata
        public void OnGet()
    {
        //Chiama il metodo CaricaCategorie() per riempire il menu a tendina con le categorie disponibili nel database.
        //se non lo faccio, quando richiamo dall'altra parte con l'onget , non visualizzo niente.
        //La parte del form che mi visualizza questo è:
        /*
        <label asp-for="Prodotto.CategoriaId"></label>
        <select asp-for="Prodotto.CategoriaId" class="form-control" asp-items="Model.CategorieSelectList">
            <option value="">--- Selezione Categoria --- </option>
        </select>
        Che si trova nella pagina cshtml
        */

        //metodo che viene eseguito quando invio un modulo sulla pagina web cioè gestisce l'azione quando l’utente preme il pulsante di invio del form.
        public IActionResult OnPost()
        {
            //controllo se il modello è valido cioè se i dati inseriti dall'utente rispettano le regole di validazione.
            if (!ModelState.IsValid)
            {
                CaricaCategorie(); //carico le categorie se no quando si carica si carica senza categorie
                //page e un metodo di page model che restituisce un oggetto page result che rappresenta la pagina nella quale siamo
                return Page(); //se il modello non è valido ritorno la stessa pagina con gli errori 
            }
            //invoco il metodo GetConnection per ottenere la connessione al db
            using var connection = DatabaseInitializer.GetConnection();
            //apro la connessione
            connection.Open();

```
<details>

<summary>SQL INJECTION</summary>

`La sql injection è un attacco informatico che sfrutta le query sql per inserire codice`

</details>
             
```csharp
            //creo la query sql per inserire un nuovo prodotto usando i parametri (@nome, @prezzo, @categoriaId)
            //i parametri servono in modo da evitare sql injection 
            var sql = "INSERT INTO Prodotti(Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoriaId)";

            //creo un comando sql per eseguire la query(l'inserimento) sulla connesione che ho creato
            using var command = new SQLiteCommand(sql, connection);

            //aggiungo i parametri al comando con il metodo AddWithValue che prende il nome del parametro e il valore,così non vengono eseguiti comandi SQL dannosi.
            command.Parameters.AddWithValue("@nome", Prodotto.Nome);
            command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
            command.Parameters.AddWithValue("@categoriaId", Prodotto.CategoriaId);

            //eseguo il comando
            command.ExecuteNonQuery();

            //Dopo aver salvato il prodotto, reindirizzo l'utente alla pagina di elenco dei prodotti,alla pagina Index
            return RedirectToPage("Index");
        }
            //metodo per caricare le categorie
            //Legge le categorie dal database e le aggiunge alla lista CategorieSelectList.
            private void CaricaCategorie()
            {
                using var connection = DatabaseInitializer.GetConnection();
                connection.Open();

                //creo la query sql per ottenere i dati delle categorie
                var sql = "SELECT Id, Nome FROM Categorie";


                //creo un comando per eseguire la query
                using var command = new SQLiteCommand(sql, connection);
                using var reader = command.ExecuteReader();

                //finche il reader ha dati
                while (reader.Read())
                {
                    CategorieSelectList.Add(new SelectListItem
                    {
                        Value = reader.GetInt32(0).ToString(),
                        Text = reader.GetString(1)
                    });
                     /*Legge ogni riga restituita dalla query.
                        Crea un oggetto SelectListItem con:
                        Value = ID della categoria.
                        Text = Nome della categoria.
                        Aggiunge l’elemento alla lista CategorieSelectList.*/
                }
            }
    }


```


