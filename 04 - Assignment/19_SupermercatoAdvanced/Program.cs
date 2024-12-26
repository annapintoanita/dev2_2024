
using System.Runtime.InteropServices;
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();
        DipendenteRepository repositoryDip = new DipendenteRepository();
        ClienteRepository repositoryCliente = new ClienteRepository();
        CarrelloRepository repositoryCarrello= new CarrelloRepository();
        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (repository)
        List<Prodotto> prodotti = repository.CaricaProdotti();
        List<Dipendente> listaDipendenti = repositoryDip.CaricaDipendenti();
        List<Cliente> listaClienti = repositoryCliente.CaricaClienti();
        List<Prodotto> prodottoCarrello= repositoryCarrello.CaricaCarrello();
        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoManager manager = new ProdottoManager(prodotti);
        DipendenteManager managerDip = new DipendenteManager(listaDipendenti);
        ClienteManager managerCliente = new ClienteManager(listaClienti);
        CarrelloManager managerCarrello = new CarrelloManager(prodottoCarrello);

        // Menu interattivo per eseguire operazioni CRUD sui prodotti

        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;
        bool continuaMagazziniere = true;
        bool continuaCliente = true;
        bool continuaAmministratore = true;
        // il ciclo while continua finché la variabile continua è true
        while (continua)
        {
            Console.WriteLine("\n--- Benvenuto al Supermercato Json ---");

            Console.WriteLine("\nIdentificati:");
            Console.WriteLine("1. Magazziniere");
            Console.WriteLine("2. Cliente");
            Console.WriteLine("3. Cassiere");
            Console.WriteLine("4. Amministratore");


            string identificazione = InputManager.LeggiIntero("Scelta: ", 1, 4).ToString();
            //pulisco la console
            Console.Clear();



            if (identificazione == "1")
            {
                while (continuaMagazziniere)
                {
                    Console.WriteLine("\n --- Menu magazziniere ---");
                    Console.WriteLine("1. Visualizza Prodotti");
                    Console.WriteLine("2. Aggiungi Prodotto");
                    Console.WriteLine("3. Trova Prodotto per ID");
                    Console.WriteLine("4. Aggiorna Prodotto");
                    Console.WriteLine("5. Elimina Prodotto");
                    Console.WriteLine("0. Esci");
                    string sceltaDipendente = InputManager.LeggiIntero("Scelta: ", 0, 6).ToString();
                    Console.Clear();
                    switch (sceltaDipendente)
                    {
                        case "1":
                            Console.WriteLine("\nProdotti: ");
                            //string scelta = Console.ReadLine();
                            //string scelta = acquisita mediante il metodo LeggiInteri della classe InputManager
                            //string scelta = InputManager.LeggiIntero();
                            // Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
                            manager.StampaProdottiIncolonnati();
                            break;

                        case "2":
                            //acquisisco il nome mediante il metodo LeggiStringa della classe InputManager
                            string nome = InputManager.LeggiStringa("\nNome: ");
                            //acquisisco il prezzo mediante il metodo LeggiDecimale della classe InputManager
                            decimal prezzo = InputManager.LeggiDecimale("\nPrezzo: ");
                            //acuqisisco giacenza mediante il metodo LeggiIntero della classe InputManager
                            int giacenza = InputManager.LeggiIntero("\nGiacenza: ");
                            manager.AggiungiProdotto(new Prodotto { Nome = nome, Prezzo = prezzo, Giacenza = giacenza });
                            break;

                        case "3":
                            Console.Write("ID: ");
                            int idProdotto = InputManager.LeggiIntero("\n");
                            Prodotto prodottoTrovato = manager.TrovaProdotto(idProdotto);
                            if (prodottoTrovato != null)
                            {
                                Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
                            }
                            else
                            {
                                Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                            }
                            break;

                        case "4":

                            int idProdottoDaAggiornare = InputManager.LeggiIntero("\nID: ");

                            string nomeNuovo = InputManager.LeggiStringa("\nNome: ");

                            decimal prezzoNuovo = InputManager.LeggiDecimale("\nPrezzo: ");
                            Console.Write("Giacenza: ");
                            int giacenzaNuova = int.Parse(Console.ReadLine());
                            manager.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeNuovo, Prezzo = prezzoNuovo, Giacenza = giacenzaNuova });
                            break;

                        case "5":
                            int idProdottoDaEliminare = InputManager.LeggiIntero("\nID: ");
                            manager.EliminaProdotto(idProdottoDaEliminare);
                            break;

                        case "6":
                            repository.SalvaProdotti(manager.OttieniProdotti());
                            Console.WriteLine("Vuoi uscire dal programma? s/n");
                            string rispostaMagazzieniere = Console.ReadLine().ToLower();
                            if (rispostaMagazzieniere == "n")
                            {
                                continuaMagazziniere = false;
                            }
                            else
                            {
                                continua = false;
                                continuaMagazziniere = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprovare.");
                            break;
                    }
                }
            }
            // devo creare cliente dall' amministratore.
            if (identificazione == "2")
            {
                while (continuaCliente)
                {
                    
                    Console.WriteLine("\n --- Menu cliente ---");
                    Console.WriteLine("Scegli un'operazione: ");
                    Console.WriteLine("1. Visualizza il catalogo");
                    Console.WriteLine("2. Aggiungi prodotto al carrello");
                    Console.WriteLine("3. Elimina un prodotto dal carrello");
                    Console.WriteLine("4. Visualizza il carrello"); //provo sola
                    Console.WriteLine("0. ESCI"); //sola
                    string sceltaCliente = InputManager.LeggiIntero("Scelta: ", 0, 5).ToString();
                    switch (sceltaCliente)
                    {
                        case "1":
                            Console.WriteLine("\nCatalogo: ");
                            manager.StampaProdottiIncolonnati();
                            break;

                        case "2":
                            string nome= InputManager.LeggiStringa("\nNome: ");
                            int quantita= InputManager.LeggiIntero("\nQuantita: ");
                            string categoria= InputManager.LeggiStringa("\nCategoria: ");
                            
                          
                            break;

                        case "3":
                        
                            break;

                        case "4":
                         

                            break;

                        case "5":
                            
                            Console.WriteLine("Vuoi uscire dal programma? s/n");
                            string rispostaCliente = Console.ReadLine().ToLower();
                            if (rispostaCliente == "n")
                            {
                                continuaCliente = false;
                            }
                            else
                            {
                                continua = false;
                                continuaCliente = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprovare.");
                            break;
                    }
                }
            }
            if (identificazione == "3")
            {
                Console.WriteLine("\n--- Menu cassiere ---");
                Console.WriteLine("1. Visualizza prodotti");
                Console.WriteLine("2. Aggiungi prodotti");
                Console.WriteLine("3. Elimina prodotti");
                Console.WriteLine("0. ESCI");
                string sceltaCassiere = InputManager.LeggiIntero("Scelta: ", 0, 4).ToString();
                switch (sceltaCassiere)
                {
                    case "1":

                        break;

                    case "2":

                        break;
                    case "3":

                        break;

                    case "4":

                        break;

                }
            }

            if (identificazione == "4")
            {
                while (continuaAmministratore)
                {
                    Console.WriteLine("\n--- Menu Amministratore ---");
                    Console.WriteLine("1. Visualizza dipendenti");
                    Console.WriteLine("2. Imposta ruolo dei dipendenti tramite ID");
                    Console.WriteLine("3. Aggiungi dipendente");
                    Console.WriteLine("4. Elimina dipendente");
                    Console.WriteLine("5. Aggiungi cliente");
                    Console.WriteLine("6. Visualizza cliente");
                    Console.WriteLine("7. Elimina cliente");
                    Console.WriteLine("0. Salva ed esci");
                    string sceltaAmministratore = InputManager.LeggiIntero("Scelta :", 0, 11).ToString();
                    switch (sceltaAmministratore)
                    {
                        case "1":// visualizza dipendenti
                            managerDip.StampaDipendentiIncolonnati();
                            break;

                        case "2": //impostare il ruolo del dipendente tramite ID
                            int idDipendenteRuolo = InputManager.LeggiIntero("ID: ", 0);
                            managerDip.ImpostaRuolo(idDipendenteRuolo);
                            break;

                        case "3": //aggiungi dipendente
                            string userNameDip = InputManager.LeggiStringa("\nAggiungi il nome del dipendente:");
                            string ruoloDip = InputManager.LeggiStringa("\nImposta il suo ruolo:");
                            managerDip.AggiungiDipendente(new Dipendente { UserName = userNameDip, Ruolo = ruoloDip });
                            break;

                        case "4"://elimina dipendente
                            int idDipendenteDaEliminare = InputManager.LeggiIntero("ID:");
                            managerDip.EliminaDipendente(idDipendenteDaEliminare);
                            break;

                        case "5":// aggiungi cliente
                            string UserNameCliente = InputManager.LeggiStringa("\nAggiungi username del cliente:");
                            managerCliente.AggiungiCliente(new Cliente
                            {
                                UserName = UserNameCliente,
                                Carrello = new List<Prodotto>(),
                                StoricoAcquisti = new List<Prodotto>(),
                                PercentualeSconto = 0,
                                Credito = 100
                            });
                            break;

                        case "6":// visualizza clienti
                            managerCliente.StampaClientiIncolonnati();
                            break;

                        case "7"://elimina cliente
                            int idClienteDaEliminare = InputManager.LeggiIntero("ID:");
                            managerCliente.EliminaCliente(idClienteDaEliminare);
                            break;

                        case "0": //salva ed esci
                            repositoryDip.SalvaDipendente(listaDipendenti);
                            repositoryCliente.SalvaClienti(listaClienti);
                            Console.WriteLine("Vuoi uscire dal programma? s/n");
                            string rispostaAmministratore = Console.ReadLine().ToLower();
                            if (rispostaAmministratore == "n")
                            {
                                continuaAmministratore = false;
                            }
                            else
                            {
                                continua = false;
                                continuaAmministratore = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprovare.");
                            break;
                    }
                }
            }
            //Resetto il bool del while a true altrimenti non è più accessibile al menu del dipendente che mi interessa
            continuaMagazziniere = true;
            continuaCliente = true;
            //
            continuaAmministratore = true;
        }
    }
}

/*public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
    public int Giacenza { get; set; }
    public string Categoria { get; set; }
}*/
/*public class ProdottoAdvanced

{
    private int id;
    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value;
        }
    }

    private string nomeProdotto;
    public string NomeProdotto
    {
        get { return nomeProdotto; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
            }
            nomeProdotto = value;
        }
    }

    private decimal prezzoProdotto;
    public decimal PrezzoProdotto
    {
        get { return prezzoProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero.");
            }
            prezzoProdotto = value;
        }
    }

    private int giacenzaProdotto;
    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set { giacenzaProdotto = value; }
    }
}*/

/*public class ProdottoManager // HO SPOSTATO LA CLASS PRODOTTOMANAGER IN UN NUOVO FILE MANAGER.CS NELLA CARTELLA MANAGER

{
    private int prossimoId;
    //lista di prodotti di tipo ProddottoAdvanced per 
    private List<Prodotto> prodotti;
    private ProdottoRepository repository; // prodotti e private perche non voglio che venga modificato dall'esterno

    public ProdottoManager(List<Prodotto> Prodotti)
    {
        prodotti = Prodotti;
        repository = new ProdottoRepository(); // inizializzo la lista di prodotti nel costruttore pubblco in modo che sia accessibile all'esterno
        prossimoId = 1;
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }

    // metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(Prodotto prodotto)
    { //assegna automaticamente un ID univoco
        prodotto.Id = prossimoId;
        //incrementa il prossimo ID per il prossim prodotto
        prossimoId++;
        prodotti.Add(prodotto);
        Console.WriteLine($"Prodotto aggiunto con ID: {prodotto.Id}");
    }

    // metodo per visualizzare la lista di prodotti
    public List<Prodotto> OttieniProdotti()
    {
        return prodotti;
    }
    //ongi campo utilizza il formato {campo,-largezza} dove:
    //campo è il valore da stampare
    //-larghezza specifica la larghezza del campo; il il segno - allinea il testo a sinistra.
    //{"Nome". -20}significa che il nome del prodotto avrà una largezza fissa di 20 caratteri, allineato a sinisitra
    //Formato dei numeri:
    // Per i prezzi, viene usato il formato 0.00 per mostrare sempre due cifre decimali
    // Linea Console.WriteLine(new string ('-', 50)); stampa una linea divisoria lung 50 caratteri per migliorare la leggibilità
    
   public void StampaProdottiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Nome",-20} {"Prezzo",-10} {"Giacenza",-10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var prodotto in prodotti)
        {
            Console.WriteLine(
                $"{prodotto.Id,-5} {prodotto.Nome,-20} {prodotto.Prezzo,-10:0.00} {prodotto.Giacenza,-10}"
            );
        }
    }

    // metodo per cercare un prodotto
    public Prodotto TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto; 
            }
        }
        return null;
    }

    // metodo per mpdificare un prodotto esistente
    public void AggiornaProdotto(int id, Prodotto nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.Nome = nuovoProdotto.Nome;
            prodotto.Prezzo = nuovoProdotto.Prezzo;
            prodotto.Giacenza = nuovoProdotto.Giacenza;
        }
    }

    // metodo per eliminare un prodotto
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            //elimina il file json corrispondente al  prodotto
            string filePath = Path.Combine("Prodotti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }

}*/

/*public class ProdottoRepository  //HO SPOSTATO LA CLASSE PRODOTTOREPOSITORY IN UN NUOVO FILE.CS NELLA CARTELLA REPOSITORIES
{

    private readonly string folderPath = "Prodotti"; //crea per il file json
    public void SalvaProdotti(List<Prodotto> prodotti)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var prodotto in prodotti)
        {
            string filePath = Path.Combine(folderPath, $"{prodotto.Id}.json"); //percorso del file JSON
            string jsonData = JsonConvert.SerializeObject(prodotto, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Prodotto salvato in {filePath}: \n");
        }
    }

    public List<Prodotto> CaricaProdotti()
    {

        List<Prodotto> prodotti = new List<Prodotto>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Prodotto prodotto = JsonConvert.DeserializeObject<Prodotto>(readJsonData);
                prodotti.Add(prodotto);
            }
        }
        return prodotti;

    }
  
}*/

//classe gestion einput che può esssere integrata per semplificare e standardizzare l'acquisizione degli input dell'utente.
//questa classe aiuta a gestire i casi di errore e fornisce metodi per acquisire input di diversi tipi


/*public static class InputManager // HO SPOSTATO LA CLASS INPUTMANAGER IN UN NUOVO FILE .CS NELLA CARTELLA UTILITIES
{
    //minvalue e maxvalue sono i metodi di int che rappresentano il valore minimo ed il valore massimo di un intero
    // il metodo LeggiIntero accetta un messaggio da visualizzare
    public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
        int valore; //Vriabile per memorizzare il valore intero acquisito
        while (true)
        {
            Console.Write($"{messaggio}"); //messaggio e la variabile di input che dovrò passare al metodo
            string input = Console.ReadLine();//acquisire l'input dell'utente come stringa
            // try parse per convertire la stringa  in un intero e controllare se l'input è vaòidp
            if (int.TryParse(input, out valore) && valore >= min && valore <= max) // devo verifiare se il valore e tra min e max e se è un intero
            {
                return valore; // restituire il valore intero se è valido
            }
            else
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}"); // messaggio di errore
        }
    }

    public static decimal LeggiDecimale(string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore; //variabile per memorizzare il valore decimale acquisito
        while (true)
        {
            Console.Write($"{messaggio}");
            string input = Console.ReadLine();

            //sostituisco la virgola con il punto per gestire i decimali
            if (input.Contains(",")) //se l'input contiene la virgola e non contiene il punto
            {
                input = input.Replace(",", ","); //sostituire la virgola con il punto
            }

            // try parse per convertire la stringa in un decimale e controllare se l'input è valido
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
            }
            Console.WriteLine($"errore: inserire un numero decimale comprso tra {min} e {max}");
        }
    }

    public static string LeggiStringa(string messaggio, bool obbligatorio = true)
    {
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio e la variabile di input che devo passare al metodo
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio) // se l'input non è vuoro o non è obbligtaorio
            {
                return input; // restituire il valore della stringa
            }
            Console.WriteLine($"errore: il valore non può essere vuot");
        }
    }

    public static bool LeggiConferma(string messaggio)
    {
        while (true)
        {
            Console.Write($"{messaggio} (s/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            if (input == "n" || input == "no")
            {
                return false;
            }
            Console.WriteLine("errore: rispondere con 's' o 'n' ");
        }
    }
}
*/