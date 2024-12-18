namespace MyApp.Models; // da rimuovere e risistemare dal codice

    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public int Giacenza { get; set; }
        public string Categoria { get; set; }
    }
