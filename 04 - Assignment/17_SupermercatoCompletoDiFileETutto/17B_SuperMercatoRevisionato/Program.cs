// using è la direttiva per importare una libreria
// newtonsoft.json è la libreria che permette di serializzare e deserializzare i file json
using Newtonsoft.Json;

// filepath è la variabile stringa che identifica la posizione del catalogo
string filePath = "catalogo.json";

// continua permette di uscire dal programma ma potrei migliorarlo in modo da uscire dal menu cliente o lavoratore ritornando alla scelta dell'utente
// MIGLIORAMENTO: IMPLEMENTARE LA LOGICA PER PASSARE DA UN MENU ALL'ALTRO
bool continua = true;

// una lista di dizionari string object che rapprestenta il catalogo dei prodotti
List<Dictionary<string, object>> catalogo = new List<Dictionary<string, object>>();

Console.WriteLine("--- Benvenuto al Supermercato Json ---");
Console.WriteLine("Digita '1' se sei un nostro dipendente, '2' se sei un cliente ");

// selezione è la variabile che viene acquisita dall'utente e serve per selezionare il tipo di utenza
// MIGLIORAMENTO: DARE DEI NOMI SIGNIFICATI ALLE VARIABILI, IN QUESTO CASO 'selezionaUtente'
string selezione = Console.ReadLine();

// rendo disponibile il catalogo a tutta l'applicazione utilizzando la funzione CaricaCatalogoDalFile
// se non lo faccio quando sono sul menu del cliente non ho nessun prodotto nel catalogo
// MIGLIORAMENTO: RICORDARSI DI TOGLIERE DAL MENU OPERATORE LA VOCE Console.WriteLine("6. Carica il catalogo dal file");
catalogo = CaricaCatalogoDalFile(filePath); 

// inizio del ciclo while di scelta delle operazioni di ogni utente
// LOGICA DA IMPLEMENTARE CON LA VARIABILE continua 
// IN PRATICA DOBBIAMO CREARE UNA VARIABILE DI CONTROLLO TIPO 'continua' PER OGNI MENU
// continuaOperatore e continuaCliente saranno i nomi delle due nuove variabili
while (continua)
{
    // menu dipendente
    if (selezione == "1")
    {
        Console.WriteLine("Seleziona un'operazione da effettuare:");
        Console.WriteLine("1. Visualizza il catalogo");
        Console.WriteLine("2. Aggiungi un prodotto al catalogo tramite ID");
        Console.WriteLine("3. Modifica il prezzo di un prodotto");
        Console.WriteLine("4. Rimuovi un prodotto dal catalogo");
        Console.WriteLine("5. Salva il catalogo sul file");
        Console.WriteLine("6. Carica il catalogo dal file");
        Console.WriteLine("0. ESCI");

        // sceltaOperazione identifica la scelta effettuata dall'utente all'interno del menu
        // MIGLIORAMENTO: DARE UN NOME SIGNIFICATIVO COME 'sceltaOperazioneDipendente'
        string sceltaOperazione = Console.ReadLine();

        switch (sceltaOperazione)
        {
            case "1":
                VisualizzaCatalogo(catalogo);
                break;

            case "2":
                AggiungiAlCatalogo(catalogo);
                break;

            case "3":
                ModificaPrezzo(catalogo);
                break;

            case "4":
                RimuoviDalCatalogo();
                break;

            case "5":
                SalvaCatalogoSuFile(catalogo, filePath);

                break;

            // QUESTA E' L'OPZIONE DA ELIMINARE PERCHE' L'ABBIAMO RESA DISPONIBILE A TUTTA L'APPLICAZIONE ALLA RIGA 25
            case "6":
                catalogo = CaricaCatalogoDalFile(filePath); 
                break;

            case "0":
                Console.WriteLine("Grazie per il tuo lavoro!");
                continua = false;
                break;
        }
    }
    else
    {
        // menu cliente 
        Console.WriteLine("Scegli un'operazione:");
        Console.WriteLine("1. Visualizza il catalogo");
        Console.WriteLine("2. Aggiungi prodotto al carrello");
        Console.WriteLine("3. Elimina un prodotto dal carrello");
        Console.WriteLine("4. Visualizza il carrello");
        Console.WriteLine("0 ESCI");

        // sceltaCliente è la variabile che memorizza l'operazione effettuata dal cliente
        // MIGLIORAMENTO: DARE UN NOME SIGNIFICATIVO COME 'sceltaOperazioneCliente'
        string sceltaCliente = Console.ReadLine();

        // inizio dello switch di scelta delle operazioni del cliente
        switch (sceltaCliente)
        {
            case "1":
                VisualizzaCatalogo(catalogo);
                break;

            case "2":
                AggiungiAlCarrello(catalogo, carrello);
                break;

            case "3":
                RimuoviProdottoDaCarrello();
                break;

            case "4":
                VisualizzaCarrello(carrello);
                break;

            case "0":
                Console.WriteLine("Grazie, a presto!");
                continua = false;
                break;

            default:
                Console.WriteLine("Inserisci una scelta valida");
                break;

        }
    }
}

// INIZIO OPERAZIONE CRUD DEL DIPENDENTE ( Create. Read. Update. Delete )

// AggiungiAlCatalogo accetta come parametro la lista dei dizionari catalogo
// non restituisce nulla quindi è una funziona 'void'
static void AggiungiAlCatalogo(List<Dictionary<string, object>> catalogo)
{
    Console.WriteLine("Inserisci il codice ID:");
    int id = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il nome del prodotto:");
    string nomeProdotto = Console.ReadLine();

    Console.WriteLine("Inserisci il prezzo del prodotto:");
    decimal prezzoProdotto = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci la quantita da aggiungere del prodotto:");
    int quantita = int.Parse(Console.ReadLine());

    // sto creando un nuovo dizionario per il prodotto che avrà le seguenti proprietà:
    var prodotto = new Dictionary<string, object>
   {
        //MIGLIORAMENTO: NOME SIGNIFICATIVO PER QUESTA VARIABILE 'idProdotto'
        {"ID" , id},
        {"Nome", nomeProdotto},
        {"Prezzo",prezzoProdotto},
        //Quantita indica la quantità del prodotto che il dipendente può aggiungere
        // MIGLIORAMENTO: NOME SIGNIFICATIVO PER QUESTA VARIABILE 'quantitaProdotto'
        {"Quantita", quantita},
        // MIGLIORAMENTO: NOME SIGNIFICATIVO PER QUESTA VARIABILE COME 'giacenzaProdotto'
        {"QuantitaDisponibile",quantita}
   };
    catalogo.Add(prodotto);
    Console.WriteLine("Il prodotto è stato aggiunto al catalogo.");
}

