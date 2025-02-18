//contiene metodi per eseguire query SQL su un database,
//semplifica l'esecuzione di operazioni di lettura e scrittura nel database. 
//le query SQL possono essere così riutilizzate in diverse parti.

using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc;
//classi utulities per semplifcare dei passaggi, la prima per il database
namespace _37_webApp_Sql.Utilities;
public static class DbUtils
{
    /// <summary>
    
    /// Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il numero di righe interessate</returns>
     
    //EXECUTENONQUERY esegue una query SQL che non restituisce risultati, 
    //come quelle che fanno modifiche al database (ad esempio INSERT, UPDATE, DELETE).
    //SETUP PARAMETERS  per aggiungere parametri al comando SQL 
    //(per esempio, passare un id o un valore come parametro per evitare SQL injection).
    
    /// uso ACTION per passare un metodo come parametro (ad esempio SQLiteCommand-->comando di SQL da eseguire)
    /// delegate
    public static int ExecuteNonQuery(string sql, Action<SQLiteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        setupParameters?.Invoke(command); //il metodo invoke esegue il delegate setupParameters 
                                          // cioè la funzione che gli passiamo
        return command.ExecuteNonQuery();
    }
    /// <summary>
    /// Esegue una query che restituisce un valore scalare.
    /// </summary>
    /// <typeparam name="T"> Il tipoo del valore atteso </typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>il valore restituito convertito al tipo T.</returns>

//EXECUTESCALAR command.ExecuteScalar() restituisce il primo valore della prima riga della query
//
    public static T ExecuteScalar<T>(string sql, Action<SQLiteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        //una funzione di callback (setupParameters) e invoca 
        // (cioè esegue) questa funzione passando l'oggetto command come parametro
        setupParameters?.Invoke(command);
        var result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
        {
            return default(T);
        }
        return (T)Convert.ChangeType(result, typeof(T));
    }
    /// <summary>
    /// Esegue una query che restituisce piu righe e le convrte in una lista di oggetti di tipo T.
    /// </summary>
    /// <typeparam name="T"> Il tipo di oggetto da restituire in ogni riga </typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="converter">Funzione per convertire una riga (SqliteDataReader) in un oggetto T.</param>
    /// <param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Una lista di oggetti di tipo T.</returns>
    public static List<T> ExecuteReader<T>(string sql, Func<SQLiteDataReader, T> converter, Action<SQLiteCommand> setupParameters = null)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        setupParameters?.Invoke(command);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(converter(reader));

        }
        return list;

    }
}


// esempio: ottenere il numero di prodotti nella tabella
///int count = DbUtils.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
///
///OPPURE OTTENERE UNA LISTA DI PRODOTTI:
//var prodotti = DbUtils.ExecuteReader(
///"SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id",reader => new ProdottiViewModel
/// {
/// Id = reader.GetInt32(0),
/// Nome= reader.GetString(1),
/// Prezzo= reader.GetDouble(2),
/// CategoriaNome= reader.IsDBNull(3) ? "Nessuna": reader.GetString(3)
/// } 
/// );
/// 


