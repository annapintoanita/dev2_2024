# SORTEGGIO PARTECIPANTI

## Versione 1

## Obiettivo

- Scrivere un programma che permette di sorteggiare i partecipanti del corso da una lista di nomi. 

- I nomi vengono gestiti senza un inserimento da parte dell'utente, cioè inizializzati nel programma.

- Il programma estrae un partecipante singolo alla volta e lo stampa a video.

```csharp


List<string>listaPartecipanti= new List<string>
{
    "Andrea", "Anita", "Diego", "Felipe", "Giorgio", "Ivan", "Sofia", "Tamer"
    };
    foreach (var nome in listaPartecipanti)
    {
        Console.WriteLine(nome);
    }
 Random random = new Random();

 int nomeCasuale= random.Next(listaPartecipanti.Count);
  Console.WriteLine("E' stato sorteggiato " + listaPartecipanti[nomeCasuale] );
```


## Comandi di versionamento

```bash

git add --all
git commit -m "versione12"
git push -u origin main

```

## Versione 2

## Obiettivo

- Scrivere un programma che permette di sorteggiare più volte i partecipanti del corso da una lista di nomi.

- Il programma deve chiedere all'utente se vuole estrarre un altro partecipante.

- I nomi dei partecipanti estratti vengono rimossi dalla lista.


```csharp

//CODICE

```

## Comandi di versionamento

```bash


```

