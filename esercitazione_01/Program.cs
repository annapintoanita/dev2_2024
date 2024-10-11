// Console.WriteLine("Hello World!");
Console.WriteLine("Inserisci il tuo nome: "); // stampo un messaggio a video
// Console.ReadKey();
string? nome = Console.ReadLine(); // definisco una variabile di tipo string e la inizializzo con il valore inserito dall'utente\
Console.WriteLine($"Ciao {nome}"); // stampo il valore della variabile nome
                                    // usando l'interpolazione delle stringhe
Console.WriteLine("Schiaccia un tasto per terminare il programma");
Console.ReadKey(); // attendo la pressione di un tasto da parte dell'utente