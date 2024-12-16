using Newtonsoft.Json;

public class CarrelloRepository
{

    private readonly string folderPath = "Data/Carrello"; //crea per il file json
    public void SalvaCarrello(List<Carrello> carrello)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var carrello2 in carrello)
        {
            string filePath = Path.Combine(folderPath, $"{carrello.Id}.json"); //percorso del file JSON
            string jsonData = JsonConvert.SerializeObject(carrello, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Carrello salvato in {filePath}: \n");
        }
    }

    public List<Carrello> CaricaCarrello()
    {

        List<Carrello> carrello = new List<Carrello>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Carrello carrello = JsonConvert.DeserializeObject<Carrello>(readJsonData);
                carrello.Add(carrello);
            }
        }
        return carrello;

    }
  
}