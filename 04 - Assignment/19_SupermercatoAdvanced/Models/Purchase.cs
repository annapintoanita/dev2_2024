
public class Purchase
{
public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public Prodotto Prodotto { get; set; }
    public int Quantita { get; set; }
    public DateTime Data { get; set; }
    public bool Stato { get; set; }
}