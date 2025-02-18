using System.Globalization;
namespace _37_webApp_Sql.Utilities;
public static class PriceFormatter
{
    ///<summary>
    ///Formatta un valore double come valuta
    ///</summary>
    ///<param name= "price">Il prezzo da formattare.</param>
    ///<returns>Una stringa formattata  come valuta.</returns>
    public static string Format(double price)
    {
        //la localizzazione viene presa dal so
        return price.ToString("C", CultureInfo.CurrentCulture);
    }
}
//esempio 
//<td>@PriceFormatter.Format(Prodotto.Prezzo)</td>