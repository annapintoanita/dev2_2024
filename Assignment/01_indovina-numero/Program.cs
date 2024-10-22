Random random = new Random();
int numeroDaIndovinare = random.Next(1, 101);  
int punteggio = 100;  
bool haIndovinato = false;

Console.WriteLine("Indovina il numero (tra 1 e 100). Punteggio massimo: 100 punti.");

while (!haIndovinato && punteggio > 0)  
{  
    Console.Write("Tentativo: ");  
    int numeroUtente = int.Parse(Console.ReadLine());  
    punteggio -= 2;

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
        Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
        haIndovinato = true;  
    }

    if (!haIndovinato && punteggio == 0)  
    {  
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");  
    }  
}