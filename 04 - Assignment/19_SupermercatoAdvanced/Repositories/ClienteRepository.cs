namespace MyApp.Models;
using Newtonsoft.Json;

public class ClienteRepository
{

    private readonly string folderPath = "Data/Cliente"; //crea per il file json
    public void SalvaClienti(List<Cliente> clienti)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var cliente in clienti)
        {
            string filePath = Path.Combine(folderPath, $"{cliente.Id}.json"); //percorso del file JSON
            string jsonData = JsonConvert.SerializeObject(cliente, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Prodotto salvato in {filePath}: \n");
        }
    }

    public List<Cliente> CaricaClienti()
    {

        List<Cliente> clienti = new List<Cliente>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(readJsonData);
                clienti.Add(cliente);
            }
        }
        return clienti;

    }
  
}