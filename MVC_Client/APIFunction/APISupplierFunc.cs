using MVC_Client.Model.Supplier;

namespace MVC_Client.APIFunction
{
    public class APISupplierFunc
    {
        internal static SupplierAdd AddSupplier(SupplierAdd supplier)
        {
            SupplierAdd orders = new SupplierAdd();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Supplier/AddSupplier/Add";

            HttpResponseMessage response = client.PostAsJsonAsync(url, supplier).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<SupplierAdd>().Result;
            }

            return orders;
        }
        //big update
        internal static void DeleteSupplier(int id)
        {
           
            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Supplier/DeleteSupplier/{id}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;
            
        }

        internal static List<SupplierVM> GetAllSuppliers()
        {

            List<SupplierVM> orders = new List<SupplierVM>();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Supplier/GetAllSupplier";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<SupplierVM>>().Result;
            }

            return orders;
        }

        

        internal static List<SupplierVM> GetSupplierById(int id)
        {

            List<SupplierVM> orders = new List<SupplierVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Supplier/GetSupplierById/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<SupplierVM>>().Result;
            }

            return orders;
        }

        internal static void UpdateSupplier(SupplierVM supplier)
        {
            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Supplier/UpdateSupplier/{supplier.SupplierId}";

            HttpResponseMessage response = client.PutAsJsonAsync(url, supplier).Result;
        }
    }
}
