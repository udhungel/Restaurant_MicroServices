using Manago.Web.Models;
using Mango.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Manago.Web.Services.IServices
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient{ get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();              
                message.Headers.Add("Accept", "application/json"); 
                message.RequestUri = new Uri(apiRequest.ApiUrl);  //Uri to send 
                client.DefaultRequestHeaders.Clear(); //clear any default request header on client
                if (apiRequest.Data !=null) //check if apiRequest has data
                {
                  message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8,"application/json"); // set it to message.Content also Serialize it 
                }
                //once we have populated the data we get response from client 
                //Api response
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST: 
                                    message.Method = HttpMethod.Post; 
                    break;
                    case SD.ApiType.PUT:
                                    message.Method = HttpMethod.Put;
                    break;
                    case SD.ApiType.DELETE:
                                    message.Method = HttpMethod.Delete;
                    break;
                    default: message.Method = HttpMethod.Get;
                    break;
                         
                }
                //call the client and send the API message
                apiResponse = await client.SendAsync(message);  
                //get a response we need to convert to string 
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { ex.Message },
                    IsSucess = false

                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;                
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
