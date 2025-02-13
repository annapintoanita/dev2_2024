using System.ComponentModel.DataAnnotations;
public class Categoria
{
    public int Id {get; set;}

    [Required(ErrorMessage = "Il nome della categoria è obbligatoria.")]
    [StringLength(100, ErrorMessage = "Il nome non può superarare i 100 caratteri.")]
    public string Nome {get; set;}

}