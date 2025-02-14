//file DatabaseInitializer.cs
//questo filegestisce la connessione al database ed inizializza i dati tramite seeding

using System.Data.SQLite;


public static class DatabaseInitializer
{

    //il database verrà creato nella cartella dell'app
    private static string _connectionString = "Data Source=prodottiapp.db";//utilizzeremo _connectionString in modo da ottenere la connessione al db
    public static void InitializerDatabase()
    {
        using var connection = new SQLiteConnection(_connectionString);//creiamo una connessione al db tramite using
        connection.Open(); //apriamo la connessione
                           //gestisco l' eccezione se il db esiste gia in sql

        //creazione tabella Categorie
        var createCategorieTable = @"

        CREATE TABLE IF NOT EXISTS Categorie
        (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome TEXT NOT NULL
        );
        ";

        //lancio il comando sulla connessione che ho creato
        using (var command = new SQLiteCommand(createCategorieTable, connection))
        {
            command.ExecuteNonQuery();//eseguiamo la query ma il comando sql non ritorna niente
        }

        //apriamo la connessione
        //gestisco l' eccezione se il db esiste gia in sql

        //creazione tabella Prodotti
        var createProdottiTable = @"

        CREATE TABLE IF NOT EXISTS Prodotti
        (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome TEXT NOT NULL,
        Prezzo REAL NOT NULL,
        CategoriaId INTEGER,
        FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id)
        );
        ";
        // DEFAULT 0 sta ad indicare che il prodotto non è in offerta e 1 invece che è in offerta

        //lancio il comando sulla connessione che ho creato
        using (var command = new SQLiteCommand(createProdottiTable, connection))
        {
            command.ExecuteNonQuery();//eseguiamo la query ma il comando sql non ritorna niente
        }

        // seed dei dati per Categorie solo la prima volta
        var countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Categorie", connection);

        //dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        //execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere  il valore numerico
        var count = (long)countCommand.ExecuteScalar();

        //se il count è uguale a zero, allora non ci sono categorie nel db e posso fare il seed dei dati
        if (count == 0)
        {
            // Seed dei dati per la tabella Categorie
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
    //oltretutto database initializer è una classe statica quindi posso chiamare questo metodo senza creare un istanza della classe
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(_connectionString); // in questo modo la connessione è creata ma non aperta pero non puo essere utilizzata in altri metodi
    }
}


