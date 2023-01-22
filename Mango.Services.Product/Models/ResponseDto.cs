namespace Mango.Services.ProductAPI.Models
{
    public class ResponseDto
    {
        public bool IsSucess { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessage { get; set; }
    }
}
