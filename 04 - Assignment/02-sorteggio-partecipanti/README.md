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

Random random = new Random();//metodo random per sorteggiare i nomi casualmente
//creo la lista di nomi dei partecipanti
List<string> listaPartecipanti = new List<string> { "Andrea", "Anita", "Diego", "Felipe", "Giorgio", "Ivan", "Sofia", "Tamer" };
int nomeCasuale; // mi sono creata un indice
string nomeEstratto; //aggiungo una variabile stringa
int conteggioP = listaPartecipanti.Count;
string risposta;


do
{
    nomeCasuale = random.Next(conteggioP);

    foreach (var nome in listaPartecipanti) // utilizzo il foreach per stamparli tutti
    {
        Console.WriteLine(nome);
    }

    nomeEstratto = listaPartecipanti[nomeCasuale];

    Console.WriteLine($"E' stato sorteggiato {nomeEstratto}"); // ho inserito l'indice nel Console.WriteLine

    listaPartecipanti.RemoveAt(nomeCasuale);

    conteggioP--;

    if (conteggioP == 0)
    {
        Console.WriteLine("Non ci sono più nomi da estrarre");
        break;
    }


    Console.WriteLine("Vuoi estrarre un altro nome? s/n");
    risposta= Console.ReadLine().ToLower();

      while (risposta != "s" && risposta != "n")
    {
        Console.WriteLine("Risposta non valida. Vuoi estrarre di nuovo? (s/n)");
        risposta = Console.ReadLine().ToLower();
        Console.Clear();
    }
}
while (risposta =="s");


```

## Comandi di versionamento

```bash
git add --all
git commit -m "versione 2"
git push -u origin main

```

## Versione 3

## Obiettivo:

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendoli in gruppi.
- Il programma deve chiedere all'utente il numero di squadre e il numero di partecipanti per squadra.
- Se il numero dei partecipanti non è divisibile per il numero di squadre, i partecipanti rimanenti vengono assegnati ad un gruppo in modo casuale.