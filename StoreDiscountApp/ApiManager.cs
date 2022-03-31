using StoreDiscountApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace StoreDiscountApp
{
    public static class ApiManager
    {
        public const string ApiUrl = "https://localhost:44327/api/";
        public static HttpResponseMessage Get(string entityName,string data = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = ApiUrl + entityName + data;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(apiUrl);
                    response.Wait();
                    return response?.Result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static HttpResponseMessage Post<T>(T model) where T : IEntity
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = ApiUrl + model.GetType().Name + "/";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync(apiUrl, model);
                    response.Wait();
                    return response?.Result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static HttpResponseMessage Put<T>(T model) where T : IEntity
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = ApiUrl + model.GetType().Name + "/";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PutAsJsonAsync(apiUrl, model);
                    response.Wait();
                    return response?.Result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static HttpResponseMessage Delete(string entityName, string data = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string apiUrl = ApiUrl + entityName + data;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(900);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync(apiUrl);
                    response.Wait();
                    return response?.Result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static T GetData<T>(this HttpResponseMessage message) where T : IEntity
        {
            if (message.StatusCode == System.Net.HttpStatusCode.OK)
            {
              return  message.Content.ReadAsAsync<T>().Result;
            }
            return null;
        }
        public static List<T> GetData<T>(this HttpResponseMessage message, bool IsCollection = true) where T : IEntity
        {
            if (message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return message.Content.ReadAsAsync<List<T>>().Result;
            }
            return null;
        }
    }
}