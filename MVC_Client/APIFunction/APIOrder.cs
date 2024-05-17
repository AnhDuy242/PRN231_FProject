using MVC_Client.Model;
using MVC_Client.Model.Category;
using MVC_Client.Model.Order;

namespace MVC_Client.APIFunction
{
    public class APIOrder
    {
       

        internal static void AddNewOrder(OrderAdd order)
        {
            OrderAdd orders = new OrderAdd();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Order/AddOrder/Add";

            HttpResponseMessage response = client.PostAsJsonAsync(url, order).Result;
        }

        internal static OrderVM DeleteProduct(int id)
        {

            OrderVM orders = new OrderVM();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Order/DeleteOrder/{id}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<OrderVM>().Result;
            }

            return orders;
        }

        internal static List<OrderVM> GetAllOrders()
        {
            List<OrderVM> orders = new List<OrderVM>();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Order/GetAllOrder/OrderDE/All";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<OrderVM>>().Result;
            }

            return orders;
        }

        internal static List<OrderVM> GetOrderByDate(string from, string to)
        {
            List<OrderVM> orders = new List<OrderVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Order/GetOrderBydate/{from}/{to}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<OrderVM>>().Result;
            }

            return orders;
        }

    

        internal static List<OrderDetailVm> GetOrderDetailById(int id)
        {

            List<OrderDetailVm> orders = new List<OrderDetailVm>();

            HttpClient client = new HttpClient();

            string url = $" http://localhost:5015/api/Order/GetOrderDetailById/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<OrderDetailVm>>().Result;
            }

            return orders;
        }

        internal static List<OrderVM> GetOrderById(int id)
        {
            List<OrderVM> products = new List<OrderVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Order/GetOrder/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = response.Content.ReadFromJsonAsync<List<OrderVM>>().Result;
            }

            return products;
        }

        internal static void UpdateOrder(OrderVM order)
        {
            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Order/UpdateOrder/{order.OrderId}";

            HttpResponseMessage response = client.PutAsJsonAsync(url, order).Result;
        }
    }
}
