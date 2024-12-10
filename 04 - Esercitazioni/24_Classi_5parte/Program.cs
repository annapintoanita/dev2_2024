
using Newtonsoft.Json;

class Programm
{
    static void Main(string[] args)
    {
        ProdottoRepository = repository = new ProdottoRepository();
        
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();


        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager()

        //Menu interattivo per eseguire operazioni CRUD sui prodotti

        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;

        // il ciclo while continua finchè la variabile continua è true
        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1.VisualizzaProdotti");
            Console.WriteLine("3. Trova prodotto per Id");
        }
    }
}


//acquisire l'input adll'utente
Console.Write("\nScelta:");
string scelta = Console.ReadLine();

//switch-case per gestire le scelte dell'utente che usa una scelta come variabile di controllo
switch (scelta)
{
    case "1":
        Console.WriteLine("n\Prodotti")
}