# Supermercato - simulazione
## Obiettivo
#### Realizzare un programma che simuli il funzionamento di un supermercato

## Versione 1

```csharp
// Prodotti disponibili

// creo una lista di stringhe contenente i prodotti disponibili
List<string> prodotti = new List<string>
{
    "Latte intero", "Pane integrale", "Mela", "Banana", "Acqua naturale",
    "Biscotti al cioccolato", "Riso basmati", "Formaggio grattugiato"
};

// Carrello

// creo un dizionario per tenere traccia dei prodotti nel carrello
Dictionary<string, int> carrello = new Dictionary<string, int>();

// creo una variabile booleana per controllare se il programma deve continuare
bool continua = true;

// Menu
// il while loop permette di continuare a visualizzare il menu finché l'utente non decide di uscire
while (continua)
{
    Console.WriteLine("\nScegli un'opzione:");
    Console.WriteLine("1. Visualizza i prodotti");
    Console.WriteLine("2. Cerca un prodotto");
    Console.WriteLine("3. Aggiungi un prodotto al carrello");
    Console.WriteLine("4. Rimuovi un prodotto dal carrello");
    Console.WriteLine("5. Visualizza il carrello");
    Console.WriteLine("6. Procedi al pagamento");
    Console.WriteLine("0. Esci");

    // chiedo all'utente di inserire la sua scelta
    Console.Write("\nInserisci la tua scelta: ");
    string scelta = Console.ReadLine();

    // utilizzo uno switch statement per eseguire l'azione corrispondente alla scelta dell'utente
    switch (scelta)
    {
        case "1":
            VisualizzaProdotti(prodotti);
            break;
        case "2":
            CercaProdotto(prodotti);
            break;
        case "3":
            AggiungiAlCarrello(prodotti, carrello);
            break;
        case "4":
            RimuoviDalCarrello(carrello);
            break;
        case "5":
            VisualizzaCarrello(carrello);
            break;
        case "6":
            ProcediAlPagamento(carrello);
            continua = false; // Termina il programma dopo il pagamento
            break;
        case "0":
            continua = false;
            break;
        default:
            Console.WriteLine("Scelta non valida. Riprova.");
            break;
    }
}

// Metodo per visualizzare i prodotti si usa static perchè si vuole usarlo nel main
// senza static sarebbe necessario creare un'istanza della classe cosi: Supermercato.VisualizzaProdotti(prodotti); dove supermercato e il nome della classe (in questo caso non c'è)
// invece usando static si può chiamare direttamente VisualizzaProdotti(prodotti);

static void VisualizzaProdotti(List<string> prodotti)
{
    Console.WriteLine("\nProdotti disponibili:");
    foreach (string prodotto in prodotti)
    {
        Console.WriteLine($"- {prodotto}");
    }
}

// Metodo per cercare un prodotto
static void CercaProdotto(List<string> prodotti)
{
    Console.Write("\nInserisci una parola chiave per cercare un prodotto: ");
    string parolaChiave = Console.ReadLine();

    Console.WriteLine("\nRisultati della ricerca:");
    foreach (string prodotto in prodotti)
    {
        if (prodotto.Contains(parolaChiave))
        {
            Console.WriteLine($"- {prodotto}");
        }
    }
}

// Metodo per aggiungere un prodotto al carrello
static void AggiungiAlCarrello(List<string> prodotti, Dictionary<string, int> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da aggiungere al carrello: ");
    string prodotto = Console.ReadLine();

    // Controlla se il prodotto esiste
    if (prodotti.Contains(prodotto))
    {
        Console.Write("Inserisci la quantità: ");
        int quantita = int.Parse(Console.ReadLine());

        if (carrello.ContainsKey(prodotto))
        {
            carrello[prodotto] += quantita;
        }
        else
        {
            carrello[prodotto] = quantita;
        }

        Console.WriteLine($"{quantita}x {prodotto} aggiunto al carrello.");
    }
    else
    {
        Console.WriteLine("Prodotto non trovato. Riprova.");
    }
}

// Metodo per rimuovere un prodotto dal carrello
static void RimuoviDalCarrello(Dictionary<string, int> carrello)
{
    Console.Write("\nInserisci il nome del prodotto da rimuovere dal carrello: ");
    string prodotto = Console.ReadLine();

    if (carrello.ContainsKey(prodotto))
    {
        carrello.Remove(prodotto);
        Console.WriteLine($"{prodotto} rimosso dal carrello.");
    }
    else
    {
        Console.WriteLine("Prodotto non trovato nel carrello.");
    }
}

// Metodo per visualizzare il carrello
static void VisualizzaCarrello(Dictionary<string, int> carrello)
{
    Console.WriteLine("\nIl tuo carrello contiene:");
    foreach (var item in carrello)
    {
        Console.WriteLine($"- {item.Key}: {item.Value}x");
    }
}

// Metodo per procedere al pagamento
static void ProcediAlPagamento(Dictionary<string, int> carrello)
{
    Console.WriteLine("\nRiepilogo del carrello:");
    VisualizzaCarrello(carrello);

    Console.WriteLine("\nPagamento completato! Grazie per il tuo acquisto.");
}

// creo un messaggio di uscita
Console.WriteLine("Grazie per aver visitato il Supermercato!");
```