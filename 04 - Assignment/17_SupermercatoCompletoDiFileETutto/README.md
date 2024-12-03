# esercitazione 17: Supermercato completo
## Obiettivo

- Implementare un programma che simuli il funzionamento di un supermercaro.
- Il programma deve permettere di: (azione del lavoratore)
- Gestire un catalogo di prodotti(Gestire prodotti del catalogo. Salvare e caricare il catalogo dei prodotti da un file JSON)
- Il programma deve permettere a un cliente di riempire il proprio carrello della spesa(azione del cliente)
- Deve calcolare il totale del carrello e stampare uno scontrino 

## Funzionalità:
Gestione del catalogo prodotti(operazioni CRUD):
- ID codice prodotto
- Nome prodotto
- Prezzo
- Qunatità disponibile(in magazzino che viene decrementata quando un cliente acquista un prodotto)

Gestione del carrello e dello scontrino del cliente:
- Data di acquisto
- Lista dei prodotti acquistati
- Quantità disponibile prodotto
- Totale spesa

Gestione dello store:
- Salvare il catalogo su file.
- Caricare il catalogo del file.
- Salvare lo scontrino su file.
- Caricare lo scontrino dal file.
- Visualizzare il catalogo dei prodotti.
- Visualizzare gli scontrini.
- Implementare alcuni filtri (es. prodotti con prezzo minore di un certo valore, prodotti acquistati in una certa data, ecc.).

## Implementazioni future:

- Gestione operatori del supermercato (anagrafica, ruoli, ecc.).
- Gestione clienti (anagrafica, storico acquisti, ecc.).
- Gestione punti fedeltà (es. sconti, premi, ecc.)
- Gestione magazzino (funzionalità di rifornimento, gestione sottoscorta, ecc.).