Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
int numeroInserito;
int tentativiMassimi = 5;  
int tentativiEffettuati = 0;  
bool haIndovinato = false;
int numeroUtente = 0;

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi.");

while (tentativiEffettuati < tentativiMassimi && !haIndovinato)  
{  
    Console.Write("Tentativo {0}: ", tentativiEffettuati + 1);  
    
    // numeroUtente = int.Parse(Console.ReadLine());  
    numeroUtente = int.Parse(Console.ReadLine());
    
    tentativiEffettuati++;

    if (numeroUtente < numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è maggiore.");  
    }  
    else if (numeroUtente > numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è minore.");  
    }  
    else  
    {  
        Console.WriteLine("Complimenti! Hai indovinato il numero.");  
        haIndovinato = true;  
    }

    if (!haIndovinato && tentativiEffettuati == tentativiMassimi)  
    {  
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");  
    }  
}