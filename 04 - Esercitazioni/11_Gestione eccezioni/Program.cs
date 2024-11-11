// GESTIONE ECCEZIONI
//La gestione delle eccezioni e un meccanismo che permette di gestire gli errori chdurante l'esecuzione di un programma

//è possibile usare il Try.Parse però l'eccezione non viene gestita ma solo notificata
int number = int.Parse("abc");

//è possibile gestire l'errore in conversione
try
{
    int number2 = int.Parse("abc");
}
catch (FormatException e)
{
    Console.WriteLine("Errore: " + e.Message);
}
catch (Exception e)
{
    Console.WriteLine("Errore: " + e.Message);
}
finally
{
    Console.WriteLine("Il blocco finally viene sempre eseguito");
}
//ci sono diversi tipi di costrutto per la gestione delle eccezioni in c#
//- try-catch
//- try-catch-finally
