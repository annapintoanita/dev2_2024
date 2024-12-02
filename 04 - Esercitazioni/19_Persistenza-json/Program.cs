//GESTIONE FILE JSON

using Newtonsoft.Json;

//LETTURA DI UN FILE JSON

string path =@"test.json";//in queso caso il file è nella stessa cartella del programma
string json = File.ReadAllText(path);//legge il file

//ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON

dynamic obj = JsonConvert.DeserializedObject(json);//deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} età: {obj.eta}");// stampa il file

//ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON CON PIU LIVELLI

/*
{
    "nome": "Anita",
    "cognome": "Pinto",
    "eta": 32   
    "indirizzo": {
        "via": "via roma",
        "citta": "roma",
        "cap": "00100"
    },
    "numeriDiTelefono":[
    {"tipo": "casa", "numero": "1234-5678"},
    {"tipo": "ufficio", "numero":"8765-4321}
    ],
    "lingueparlate": ["italiano","inglese", "spagnolo"],
    "sposato":false,
    "patente": null
}
*/

string path2 = @"test2.json"; // in questo caso il file è nella stessa cartella del programma
string json2= File.ReadAllText(path2); //legge il file

dynamic obj2 = JsonConvert.DeserializeObject(json2); //deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta {obj2.eta}");

string path3 = @"test3.json"; // in questo caso il file è nella stessa cartella del programma
string json3= File.ReadAllText(path3);

dynamic obj3 = JsonConvert.DeserializeObject(json3);

//stampa il file
Console.WriteLine($"nome: {obj3.nome} cognome: {obj3.cognome} eta {obj3.eta} impiegato: {obj3.impiegato} via: {obj3.indirizzo.via} citta: {obj3.indirizzo.città} cap: {obj3.indirizzo}");
//stampa i numeri di telefono (tramite indice)
Console.WriteLine($"tipo: {obj3.numeriDiTelefono[0].tipo} numero: {obj3.numeriDiTelefono[0].numero"});
//stampo le lngue parlate
Console.WriteLine($"lingua:{obj3.lingueparlate[0]}");
//stampo se è sposato
Console.WriteLine($"sposato: {obj3.sposato}");
//stampo se ha la patente
Console.WriteLine($"patente: {obj3.patente}");