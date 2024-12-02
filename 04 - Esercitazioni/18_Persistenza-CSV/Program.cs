//GESTIONE FILE CSV

//ESEMPIO FILE CSV

//prodotto,quantità,prezzo --- nome,cognome,età (mario.csv) e nel file Rossi,35
//Macchina ,11,30 --- Mario,Rossi,30
//Mouse,10,25 --- Luigi.Bianchi,25

//LEGGERE UN CONTENUTO DA UN FILE CSV

/*string path = "@test.csv"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path);

foreach (string line in lines)
{
    Console.WriteLine(line);   //stampa la riga
}
// creare una lista di stringhe partendo dal file CSV
 List<string> list = new List<string>();
 foreach (string line in lines)
 {
    list.Add(line);
 }

 */

// creare una lista di array di stringhe partendo dal file CSV

//creare un file CSV con il nome del file che corrisponde al nome della prima colonna 
//ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili


/*string[][] data =new string[lines.Length][];
for (int i =0; i<lines.Length; i ++)
{
    
}
string fileCsv1 = @"file.csv";
string [0] lines = File.ReadAllLines(fileCsv1);

foreach (string line in lines)
{
    Console.WriteLine(line);
}
*/ //ESERCIZIO DA VEDERE IN TOTO

//CREA UN PROGRAMMA CHE CHIEDE DI INSERIRE UN nome, cognome,età'SCRIVERLO SUL FILE CSV

string datiUtente =@"dati.csv";
File.Create(datiUtente).Close();

Console.WriteLine("Inserisci il tuo nome");
string nome = Console.ReadLine();

Console.WriteLine("Inserisci il tuo cognome");
string cognome = Console.ReadLine();

Console.WriteLine("Inserisci la tua età");
int età= int.Parse(Console.ReadLine());

File.AppendAllText(datiUtente,$"{nome}, {cognome}, {età}\n" );
 string visualizzaTutto=File.ReadAllText(datiUtente);
 Console.WriteLine(visualizzaTutto);
 // eliminare un elemento specifico da un file csv
 //File.Delete(datiUtente);

 Console.WriteLine("Inserisci il dato da eliminare:");
 string datoDaEliminare= Console.ReadLine();
 string [] linea1 = File.ReadAllLines(datiUtente);
 List<string> salvateModifica= new List<string>();
 //File.Create(datiUtenteE).Close();
 datoDaEliminare.RemoveAt[2];
 foreach(string linea in linea1)
 {
    if (!linea.Contains(datoDaEliminare))
    {
        salvateModifica.Add(linea);
    }
    File.WriteAllLines(datiUtente,salvateModifica);
 }
 //File.WriteAllText(datiUtente + line1);
Console.WriteLine(File.ReadAllText(datiUtente));