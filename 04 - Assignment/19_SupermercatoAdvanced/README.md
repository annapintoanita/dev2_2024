# SUPERMERCATO ADVANCED

Implementare le entità che compongono un supermercato.

> Partendo dalla soluzione dell'esercizio `27_Classi8parte` implementare le seguenti entità:
- **Dipendente**:
Avrà i campi (ID,nome,cognome) ed un campo`ruolo` di tipo `String` che rappresenta ill ruolo del dipendente (es. "cassiere","magazziniere")
Implementare i metodi `getRuolo` e `setRuolo`.



- Magazziniere: può aggiungere o rimuovere prodotti dal magazzino

- Amministratore: rappresenta un amministratore del supermercato. Un amministratore è un dipendente con ruolo "amministratore".
  Può impostare il ruolo dei dipendenti. Implementare il metodo setRuolo che accetta come parametri un dipendente e una stringa
  rappresentante il ruolo da assegnare al dipendente.

| Dipendente | Tipi di dato | Note |
| --- | --- | --- |
| ID | int | viene generato in automatico con un progressivo |
|cognome | String | viene assegnato dall' admin |
|ruolo | String| viene assegnato dall' admin e può essere magazziniere o cassiere |

| Cliente | Tipo di dato | Note |
| --- | --- | --- | 
| ID | int | viene generato in automatico con un progressivo |
| username | string |  ognuno decide come vuole farlo |
| carrello | prodotto[] | |
| storico acquisti | purchases[] | |
| percentuale sconto | int | viene incrementata a seconda del valore dello storico degli acquisti |
| credito | double | viene utilizzato per fare gli acquisti |

| Prodotto | Tipo di dato | Note |
| ---  | --- | --- |
| ID | int | viene generato in automatico con un progressivo |
| nome | string | viene inserito dal magazziniere |
| prezzo | double | viene inserito dal magazziniere |
| quantità | int | viene inserito dal magazziniere |
 | --- | --- |
 | categoria | ID |

Purchases è lo stato nel quale si trova l'acquisto di un cliente. Prima di essere passato in cassa.

 - Quando viene passato allo stato `completato` la cassa può processare lo scontrino.

 | Purchases | Tipo di dato | Note |
 | --- | --- |--- |
 | ID | int | viene generato in automatico con un progressivo |
| cliente | cliente | |
| prodotti | prodotto[] | viene inserito dal cliente |
| quantita | int | viene inserito dal cliente |
| data | Date | viene generato in automatico con la data corrente (quando il cliente completa l'acquisto) |
| stato | Bool | lo stato di un acquisto di default e `in corso` e può essere modificato dal cliente in `completato` o `annullato` |

| Cassa | Tipo di dato | Note |
| --- | --- | --- |
| ID | int | viene generato in automatico con un progressivo |
| dipendente | Dipendente | |
| acquisti | purchases[] | |
| scontrino processato | bool | di default è `false` e diventa `true` quando la cassa ha processato lo scontrino|


- Ruoli:


| **Cassiere** | **Magazziniere** | **Amministratore** | **Cliente** |
| --- | --- | --- | --- |
| Può registrare i prodotti acquistati da un cliente che ha degli acquisti in stato completato e calcolare il totale da pagare generando lo scontrino | Può visualizzare, aggiungere o rimuovere prodotti dal magazzino, può gestire le categorie |  Può impostare il ruolo dei dipendenti. | Può aggiungere o rimuovere prodotti e cambiare lo stato dell'ordine.

# Diagramma prodotto
- Dall'inserimento del prodotto in magazzino, alla fine dell' acquisto.

```mermaid
flowchart TD
   A[SCELTA RUOLO] --> B(Magazziniere) --> |creazione prodotto|C
    C{ID
    NOME
    PREZZO
    GIACENZA
    CATEGORIE
    }-->D
    D[CLIENTE] --> |aggiunge prodotto al carrello|E
    E(CASSA) --> F[Cassiere]-->|scontrino|G{Cambio stato purchase e aggiornamento giacenza in magazzino}
   
```


