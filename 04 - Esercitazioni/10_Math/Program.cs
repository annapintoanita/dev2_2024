//MATH

//La libreria Math in c# è una collezione di metodi statici che forniscono funzionalità matematiche di base, coma calcoli su numeri, 
//trigonometria, logaritmi ecosì via

//abs
//Il metodo Math.Abs() restituisce il valore assoluto di un numero. Il valore assoluto di un numero è il numero stesso senza il segno meno.

int number1 = -10;
int absNumber = Math.Abs(number1);
Console.WriteLine(absNumber);

//arrotondamenti
//celiling
//Il metodo Math.Ceiling() restituisce il piu piccolo intero maggiore o uguae a un numero decimale.
double number2 = 10.1;
double ceilingNumber = Math.Ceiling(number2);
Console.WriteLine(ceilingNumber);

//floor
//Il metdodo Math.Floor() restituisce il più grande intero minore o uguale a un numero decimle.
double number3 = 10.9;
double floorNumber = Math.Floor(number3);
Console.WriteLine(floorNumber);

//round
//il metodo Math.Round() arrotonda un numero decimale al numero intero piu vicino.
double number4 = 10.5000;
double intNumber = Math.Round(number4);
double roundNumber = Math.Round(number4, 2);// posso utilizzare un secondo parametro per specificare il numero di cifre decimali
Console.WriteLine(intNumber);
Console.WriteLine(roundNumber);