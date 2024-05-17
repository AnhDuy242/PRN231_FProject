using MVC_Client.Model.Customer;
using MVC_Client.Model.Product;

namespace MVC_Client.APIFunction
{
    internal class APIProduct
    {
        internal static ProductAdd AddProduct(ProductAdd product)
        {


            ProductAdd orders = new ProductAdd();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Product/AddProduct/Add";

            HttpResponseMessage response = client.PostAsJsonAsync(url, product).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<ProductAdd>().Result;
            }

            return orders;

        }

        internal static ProductVM DeleteProduct(int id)
        {
            ProductVM orders = new ProductVM();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Product/DeleteProduct/Delete/{id}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<ProductVM>().Result;
            }

            return orders;
        }




        internal static List<ProductVM> GetAllProducts()
        {
            List<ProductVM> products = new List<ProductVM>();

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Product/GetAllProduct/GetAll";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = response.Content.ReadFromJsonAsync<List<ProductVM>>().Result;
            }

            return products;
        }

       

        internal static List<ProductVM> GetProductByCatId(int id)
        {
            List<ProductVM> products = new List<ProductVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Product/GetProduct/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = response.Content.ReadFromJsonAsync<List<ProductVM>>().Result;
            }

            return products;
        }

        internal static List<ProductVM> GetProductById(int id)
        {
            List<ProductVM> products = new List<ProductVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Product/GetProductById/SearchById/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = response.Content.ReadFromJsonAsync<List<ProductVM>>().Result;
            }

            return products;
        }

        internal static List<ProductDetail> GetProductDetail(int id)
        {
            List<ProductDetail> products = new List<ProductDetail>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Product/GetProductDetail/ProductDetail/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = response.Content.ReadFromJsonAsync<List<ProductDetail>>().Result;
            }

            return products;
        }

        internal static void UpdateProduct(ProductDetail p)
        {

            ProductDetail orders = new ProductDetail();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Product/UpdateProductDetail/{p.ProductId}";

            HttpResponseMessage response = client.PutAsJsonAsync(url, p).Result;

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    orders = response.Content.Readf<ProductDetail>().Result;
            //}

            //return orders;
        }


    }
}