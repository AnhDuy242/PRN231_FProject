using MVC_Client.Model.Customer;

namespace MVC_Client.APIFunction
{
    public class APICustomer
    {
        internal static void AddCustomer(CustomerVM customer)
        {


            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Customer/AddCustomer/Add";

            HttpResponseMessage response = client.PostAsJsonAsync(url, customer).Result;
            

        }

        internal static void DeleteCustomer(string CustomerId)
        {
            //CustomerVM orders = new CustomerVM();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Customer/Delete/{CustomerId}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    orders = response.Content.ReadFromJsonAsync<CustomerVM>().Result;
            //}

            //return orders;


        }

        internal static List<CustomerVM> GetAllCustomer()
        {
            List<CustomerVM> orders = new List<CustomerVM>();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/GetAllCustomer";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<CustomerVM>>().Result;
            }

            return orders;
        }

        internal static List<CustomerVM> GetCustomerById(string id)
        {

            List<CustomerVM> orders = new List<CustomerVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Customer/GetSupplierById/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<CustomerVM>>().Result;
            }

            return orders;
        }

        //internal static List<CustomerVM> GetCustomerDetail(string id)
        //{
        //    List<CustomerVM> products = new List<CustomerVM>();

        //    HttpClient client = new HttpClient();

        //    string url = "http://localhost:5015/api/Customer/GetAllCustomer";

        //    HttpResponseMessage response = client.GetAsync(url).Result;
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        products = response.Content.ReadFromJsonAsync<List<CustomerVM>>().Result;
        //    }

        //    return products;
        //}

        internal static void UpdateCustomer(CustomerVM customer)
        {
            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Customer/UpdateCustomer/{customer.CustomerId}";

            HttpResponseMessage response = client.PutAsJsonAsync(url, customer).Result;
        }
    }
}
