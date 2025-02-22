Creato modello Fornitore co Id e Nome.
Nel modello Prodotto.cs ho aggiunto il campo IdFornitore.
In ProdottoViewModel ho aggiunto il FornitoreNome.

In ProdottoViewModel abbiamo tutti i campi che servono all'utente per poter visualizzare i dati nelle pagine (ad esempio invece che l ID del fornitore, abbiamo inserito il Nome, perchè all'utente non interessa il suo ID.).
In Prodotto abbiamo inserito tutti i campi necessari per il funzionamento dell'app.

In DatabaseInitializer abbiamo creato anche la tabella per i fornitori e fatto il seeding (cioè inserimento di default per non avere una tabella vuota), e modificato la creazione della tabella dei prodotti(aggiungendo la colonna Fornitori) e il suo seeding (inserendo l'id del fornitore attraverso una query). Stesso procedimento per la tabella Categorie.

Date le modifiche nel modello del ProdottoViewModel bisognava cambiare le query per leggere i dati dal database includendo nella query la LEFT JOIN che collega il nome del fornitore attraverso il suo ID. (come anche per le categorie).
Adattato le query di tutte le operazioni CRUD in considerazione della modifica ai modelli(aggiunta del fornitoreId, es--> in Edit -->FornitoreId = @idFornitore / cmd.Parameters.AddWithValue("@idFornitore", Prodotto.IdFornitore); ).

Aggiunto in tutte le View la colonna del Fornitore sia nell'intestazione che nel contenuto (in html).

Creato una pagina apposita per la gestione CRUD dei Fornitori nella cartella dei Fornitori.

```csharp
  var Prodotti = DbUtils.ExecuteReader("SELECT Id, Nome, Prezzo, CategoriaId, FornitoreId FROM Prodotti WHERE Id = @id",
            reader => new Prodotto
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                IdFornitore = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
            },
            cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
            }
            );
             Prodotto = Prodotti.First();
```
Appunti:
Il metodo EXECUTEREADER accetta due argomenti : 1) la query, 2) parametri aggiuntivi della classe SQLite. In questo caso esegue il readerper leggere dal database e invece IL CMD è una variabile attraverso la quale utilizziamo il metodo ADDWITHVALUE ( --> inserisce al posto di @id un parametro scelto da noi (in questo caso l'id che sarebbe l'argomento passato dall'ONGET ) della classe SQLite. In questo modo evitiamo le sql injection( codice sql scritto a posta per manipolare il database inserendo codice dannoso).

EXECUTEREADER ritorna una lista quindi anche se la query ci ritorna un unico elemento, esso è salvato nella lista di un singolo elemento. Se vogliamo usare quell'elemento come singolo oggetto del modello bisogna tirarlo fuori utilizzando il metodo .First assegnandogli il risultato ad una variabile in questao caso Prodotto (Prodotti è la lista da cui viene preso il singolo elemento)