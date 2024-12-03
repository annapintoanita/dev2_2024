//GESTIONE FILE JSON

using Newtonsoft.Json;


//LETTURA DI UN FILE JSON
// LEGGERE UN FILE JSON

string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
string json = File.ReadAllText(path); // legge il file

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON
dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} età: {obj.eta}");

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON CON PIU' LIVELLI
string path2 = @"test2.json"; // in questo caso il file è nella stessa cartella del programma
string json2 = File.ReadAllText(path2); // legge il file

dynamic obj2 = JsonConvert.DeserializeObject(json2); // deserializza il file
Console.WriteLine($"nome: {obj2.nome} cognome: {obj2.cognome} età: {obj2.eta}");

string path3 = @"test3.json"; // in questo caso il file è nella stessa cartella del programma
string json3 = File.ReadAllText(path3); // legge il file

dynamic obj3 = JsonConvert.DeserializeObject(json3); // deserializza il file

// stampa il file
Console.WriteLine($"nome: {obj3.nome} cognome: {obj3.cognome} eta: {obj3.eta} impiegato: {obj3.impiegato} via: {obj3.indirizzo.via} citta: {obj3.indirizzo.citta} cap: {obj3.indirizzo.cap}");

// stampa i numeri di telefono (tramite indice)
Console.WriteLine($"tipo: {obj3.numeriDiTelefono[0].tipo} numero: {obj3.numeriDiTelefono[0].numero}");

// stampo le lingue parlate
Console.WriteLine($"lingua: {obj3.lingueparlate[0]}");

// stampo se è sposato
Console.WriteLine($"sposato: {obj3.sposato}");

// stampo se ha la patente
Console.WriteLine($"patente: {obj3.patente}");

// creo un oggetto con i dati inseriti
var obj4 = new
{
    nome = "Mario",
    cognome = "Rossi",
    indirizzo = "via roma 10",
    citta = "Roma"
};

// serializza l'oggetto
string json4 = JsonConvert.SerializeObject(obj4, Formatting.Indented);

// scrivo il file
File.WriteAllText("test4.json", json4);

// ESEMPIO DI SCRITTURA DI DATI IN UN FILE JSON CON SERIALIZZAZIONE CON PIU' LIVELLI
var obj5 = new
{
    nome = "Mario Rossi",
    eta = 30,
    impiegato = true,
    indirizzo = new
    {
        via = "Via roma 10",
        citta = "Roma",
        CAP = "00100"
    },
    numeroditelefono = new[]
    {
                new { tipo = "casa", numero = "1234-5678" },
                new { tipo = "ufficio", numero = "8765-4321" }
            },
    lingueparlate = new[] { "italiano", "inglese", "spagnolo" },
    sposato = false,
    patente = (string)null
};

// serializza l'oggetto
string json5 = JsonConvert.SerializeObject(obj5, Formatting.Indented);

// scrive il file
File.AppendAllText("tes5.json", json5); // SCRIVE IL FILE


/*var obj4 = new
{

}*/


// esempio di scrittura di più oggetti in un file json
var obj6 = new[]
{
    new {nome= "Mario", cognome= "Rossi"},
    new {nome= "Luca", cognome= "Bianchi"},
};
//serializzo l'array
string json6 = JsonConvert.SerializeObject(obj6, Formatting.Indented);
// scrivo il file
File.WriteAllText("test6.json", json6);

// 07 ESEMPIO DI AGGIUNTA DI UN OGGETTO IN UN FILE JSON

//leggo il file
string json7 = File.ReadAllText("test6.json");
//deserializzo il file
dynamic obj7 = JsonConvert.DeserializeObject(json7);
//aggiungo un oggetto all'array
var obj7new = new { nome = "Paolo", cognome = "Verdi" };
//converto l'oggetto in array
List<dynamic> list = obj7.ToObject<list<dynamic>>();
list.Add(obj7new);
//serializzo l'array
string json7new = JsonConvert.SerializeObject(list, Formatting.Indented);
//scrivo il file
File.WriteAllText("test6.json", json7new);

//08 ESEMPIO DI MODIFICA DI UN OGGETTO IN UN FILE JSON  


//leggo un file
string json8 = File.ReadAllText("test6.json");
//deserializzo il file
dynamic obj8 = JsonConvert.DeserializeObject(json8);
//rimuovo l'oggetto dall'array
list<dynamic> list8 = obj8.ToObject<list<dynamic>>();
list8.RemoveAt(0);
//serializzo l'array
string json8new = JsonConvert.SerializeObject(list8, Formatting.Indented);
//scrivo il file
File.WriteAlLText("test6.json", json8new);

//09 ESEMPIO DI MODIFICA DI UN OGGETTO IN UN FILE JSON
//LEGGO IL FILE
string json9 = File.ReadAllText("test6.json");
//deserializza il file
dynamic obj9 = JsonConvert.DeserializeObject(json9);
//modifico l'oggetto nell'array
list<dynamic> list9 = obj9.ToObject<list<dynamic>>();
list9[0].nome = "Giovanni";
//serializzo l'array
string json9new = JsonConvert.SerializeObject(list9, Formatting.Indented);
//scrivo il file
File.WriteAlLText("test6.json", json9new);

//10 ESEMPIO DI LETTURA DI UN FILE JSON CON UN ARRAY DI OGGETTI

/*
[
    {
    "nome" :"Mario",
    "cognome" :"Rossi"
    },
    {
        "nome": "Luca",
        "cognome":"Bianchi"
    }
]
*/

string pat10 = @"test6.json"; //in questo caso il file è  nella stessa cartella del programma
string json10 = File.ReadAllText(pat10);//legge il file

dynamic obj10 = json.Convert.DeserializeObject(json10);//deserializza il file

//stampo il file
foreach (var iem in obj10)
{
    Console.WriteLine($"nome: {item.nome} cognome ; {item.cognome}");
}