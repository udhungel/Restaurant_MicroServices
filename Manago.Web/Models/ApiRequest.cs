using static Manago.Web.SD;

namespace Manago.Web.Models
{
    public class ApiRequest
    {
        //type get post pust or delete
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; } 
        public object Data { get; set; } 
        public string AccessToken { get; set; } 
    }
}
