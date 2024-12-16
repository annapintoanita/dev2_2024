public class Cassa 
 {
   
    public int Id { get; set; }
    public string Dipendente { get; set; }
    public List<Prodotto> Acquisti { get; set; }
     public bool ScontrinoProcessato { get; set; }
 }