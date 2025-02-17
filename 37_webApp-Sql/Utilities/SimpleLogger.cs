using System.IO;
namespace _37_webApp_Sql.Utilities;
public static class SimpleLogger
{
    // percorso del file di log (puoi modificare il perorso se necessario)
    private static readonly string logFilePath = "log.txt";
    ///<summary>
    /// registro un messaggio nel file di Log con data e ora.
    ///</summary>
    ///<param name= "message">Il messaggio da Loggare.</param>
    public static void Log(string message)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(logFilePath, append: true);
            writer.WriteLine($"{DateTime.Now:yyy-MM-dd MM:mm:ss} - {message}");
        }
        catch(Exception)
        {
            //se il Loggin fallisce, l'errore viene ignorato.
        }
    }
        /// <summary>
        ///  Registra un' eccezione nel file di log
        ///  </summary>
        ///  <param name="ex">L'eccezione da loggare</param>
        public static void Log(Exception ex)
        {
            Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }

}
