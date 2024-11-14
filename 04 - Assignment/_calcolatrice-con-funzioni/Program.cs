
double numero1 = ChiediNumero();
string operazione = ChiediOperazione();
double numero2 = ChiediNumero();
double risultato = 0;
double StampaRisultato;

risultato = StampaRisultato();
if (numero2 == 0 && operazione == "/")
{
    Console.WriteLine("Mi dispiace, non puoi dividere per 0");

}
Console.WriteLine("Ciao, scegli un numero: ");
double numero1 = 0;
numero1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("ora scegli un' operazione: +, -, *, /");
string operazione = Console.ReadLine();

Console.WriteLine("Infine, scegli un altro numero: ");
double numero2 = 0;
numero2 = Convert.ToDouble(Console.ReadLine());


risultato = Convert.ToDouble(Console.ReadLine());
switch (operazione)
{
    case "+":
        risultato = numero1 + numero2;
        break;

    case "-":
        risultato = numero2 - numero1;
        break;

    case "*":
        risultato = numero1 * numero2;
        break;

    case "/":
        risultato = numero1 / numero2;
        break;

}
Console.WriteLine($"il risultato è : {numero1} {operazione} {numero2} = {risultato}");

double ChiediNumero();
{
    Console.WriteLine("Ciao, scegli un numero: ");
    return Convert.ToDouble(Console.ReadLine());
}

string ChiediOperazione();
{
    Console.WriteLine("Ora scegli un'operazione: ");
    return Console.ReadLine();
}

void StampaRisultato();

