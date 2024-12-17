namespace MyApp.Models;
public class Cliente

{
    public int Id { get; set; }
    public string UserName { get; set; }
    public List<Prodotto>  Carrello { get; set; }
    public List<Prodotto> StoricoAcquisti { get; set; }
    public int PercentualeSconto { get; set; }
    public double Credito { get; set; }
}