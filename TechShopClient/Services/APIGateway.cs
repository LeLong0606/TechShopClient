using Newtonsoft.Json;
using System.Net;
using System.Security.Policy;
using System.Text;
using TechShopClient.Models;

namespace TechShopClient.Services
{
    public class APIGateway
    {
        private string _ProductUrl = "https://localhost:7236/api/Product";
<<<<<<< HEAD
        private string _RegisterUserUrl = "https://localhost:7236/api/Auth/register";
        private string _LoginUserUrl = "https://localhost:7236/api/Auth/login";

        private HttpClient httpClient = new HttpClient();

        public UserDTO Register(UserDTO userDTO)
        {
            if (_RegisterUserUrl.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(userDTO);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(_RegisterUserUrl, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<UserDTO>(result);
                    if (data != null)
                    {
                        userDTO = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error" + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            finally { }
            return userDTO;
        }
    
=======
        private HttpClient httpClient = new HttpClient();
>>>>>>> 1030ce4df5ce2d4ddd7939efd1ab1b3bba2cc101
        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();
            if(_ProductUrl.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(_ProductUrl).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Product>>(result);
                    if(datacol != null)
                    {
                        products = datacol;
                    }    
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error" + result);
                }    
            }
            catch (Exception ex)
            {
                throw new Exception("Error" +  ex.Message);
            }
            finally { }
            return products;
        }

        public Product CreateProduct(Product product)
        {
            if (_ProductUrl.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(product);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(_ProductUrl, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Product>(result);
                    if (data != null)
                    {
                        product = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error" + result);
                }    
            }
            catch (Exception ex)
            {
                throw new Exception ("Error" + ex.Message);
            }
            finally { }
            return product;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            _ProductUrl = _ProductUrl + "/" + id;
            if (_ProductUrl.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(_ProductUrl).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Product>(result);
                    if (data != null)
                    {
                        product = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error" + result);
                }    
            }
            catch (Exception ex)
            {
                throw new Exception ("Error" + ex.Message );
            }
            finally { }
            return product;
        }

        public void UpdateProduct(Product product)
        {
            if (_ProductUrl.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int id = product.id;
            _ProductUrl = _ProductUrl + "/" + id;
            string json = JsonConvert.SerializeObject(product);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(_ProductUrl, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if(!response.IsSuccessStatusCode) 
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error" + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            finally { }
            return;
        }

        public void DeleteProduct(int id)
        {
            if (_ProductUrl.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _ProductUrl = _ProductUrl + "/" + id;
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(_ProductUrl).Result;
                if(!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error" + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            finally { }
            return;
        }

    }
}
