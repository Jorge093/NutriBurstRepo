namespace NutriBurst.Web.Models
{
    public class ResultadoLLamada
    {
        public bool Ok { get; set; }
        public string ErrorMessage { get; set; }
        public string Exception { get; set; }
        public object data { get; set; }
        public string RedirectUrl { get; set; }
    }
}
