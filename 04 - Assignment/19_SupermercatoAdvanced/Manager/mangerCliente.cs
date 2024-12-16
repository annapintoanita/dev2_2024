public class ClienteManager 
{
    private int Id;
    private string UserName;
    private List <Cliente> clienti;
    private List<Prodotto>  carrello ;
    private List<Prodotto> StoricoAcquisti;
    private ClienteRepository repository ;
    private int clienteId;
    private int PercentualeAcquisti;
    private double Credito;


    public ClienteManager(List<Cliente> Clienti)
    {
         
       clienti = Clienti;
       repository = new ClienteRepository();
       clienteId = 1;

    foreach (var cliente in clienti)
        {
            if (cliente.Id >= Id)
            {
                clienteId = cliente.Id + 1;
            }
        }

    }

    public void AggiungiCliente(Cliente cliente)
    { //assegna automaticamente un ID univoco
        cliente.Id = Id;
        //incrementa il prossimo ID per il prossimo cliente
        Id++;
        clienti.Add(cliente);
        Console.WriteLine($"Cliente aggiunto con ID: {cliente.Id}");
    }
     public List<Cliente> OttieniCliente()
    {
        return clienti;
    }

    public void StampaClientiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"UserName",-20} {"StoricoAcquisti", -10} {"Carrello", -10} {"PercentualeSconto",-10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var cliente in clienti)
        {
            Console.WriteLine(
                $"{cliente.Id,-5} {cliente.UserName,-20} {cliente.StoricoAcquisti,-10} {cliente.Carrello,-10}{cliente.PercentualeSconto, -10}"
            );
        }
    }

    public Cliente TrovaCliente(int id)
    {
        foreach (var cliente in clienti)
        {
            if (cliente.Id == id)
            {
                return cliente; 
            }
        }
        return null;
    }
    public void AggiornaCliente(int id, Cliente nuovoCliente)
    {
        var cliente = TrovaCliente(id);
        if (cliente != null)
        {
            cliente.Id = nuovoCliente.Id;
            cliente.UserName = nuovoCliente.UserName;
            cliente.StoricoAcquisti = nuovoCliente.StoricoAcquisti;
            cliente.Carrello = nuovoCliente.Carrello;
            cliente.PercentualeSconto = nuovoCliente.PercentualeSconto;
        }
    }
    public void EliminaCliente(int id)
    {
        var cliente = TrovaCliente(id);
        if (cliente != null)
        {
            cliente.Remove(cliente);
            //elimina il file json corrispondente al  prodotto
            string filePath = Path.Combine("Clienti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Cliente eliminato: {filePath}");
        }
    }

}