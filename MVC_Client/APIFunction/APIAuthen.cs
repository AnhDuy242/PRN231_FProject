using MVC_Client.Model;

namespace MVC_Client.APIFunction
{
    public class APIAuthen
    {
        internal static bool Login(Account a)
       {     
            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Auth";

            HttpResponseMessage response = client.PostAsJsonAsync(url, a).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}

