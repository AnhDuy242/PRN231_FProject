using MVC_Client.Model.Category;

namespace MVC_Client.APIFunction
{
    public class APICategory
    {
        

        internal static void AddNewCategory(CategoryVM category)
        {
          

            HttpClient client = new HttpClient();

            string url = "http://localhost:5015/api/Category/CreateCategory";

            HttpResponseMessage response = client.PostAsJsonAsync(url, category).Result;
           

        }

        internal static void DeleteCategory(int id)
        {
            CategoryVM orders = new CategoryVM();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Category/DeleteCategory/{id}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;
           

           
        }

        internal static List<CategoryVM> GetAllCategory()
        {
       

            List<CategoryVM> orders = new List<CategoryVM>();

            HttpClient client = new HttpClient();

            string url = " http://localhost:5015/api/Category/GetAllCategory";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<CategoryVM>>().Result;
            }

            return orders;
        }

        internal static List<CategoryVM> GetCategory(int id)
        {
        
            List<CategoryVM> orders = new List<CategoryVM>();

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Category/GetCategory/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<CategoryVM>>().Result;
            }

            return orders;
        }

      

        internal static void UpdateCategory(CategoryVM category)
        {
          

            HttpClient client = new HttpClient();

            string url = $"http://localhost:5015/api/Category/UpdateCategory/{category.CategoryId}";

            HttpResponseMessage response = client.PutAsJsonAsync(url, category).Result;
        }
    }
}
