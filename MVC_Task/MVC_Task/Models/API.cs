using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace MVC_Task.Models
{
    public static class API
    {
        private static int maxPages = 20;
        private static int perPage = 20;
        public static int MoviesNo { get; } = maxPages * perPage;
        private static string key = "ca8e030f4275593f6aa2fbd107c56e65";
        public static async Task<List<Movie>> GetMoviesPage(int pageNo)
        {
            //string url = $"https://api.themoviedb.org/3/movie/popular?api_key={key}&language=en-US&page={pageNo}";
            string url = $"https://api.themoviedb.org/3/movie/top_rated?api_key={key}&language=en-US&page={pageNo}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string text = await response.Content.ReadAsStringAsync();
            Result res = new JavaScriptSerializer().Deserialize<Result>(text);
            return res.Results ;

        }

        private static List<Movie> movies_data;
        public static List<Movie> GetMoviesData()
        {
            if (movies_data != null) return movies_data;
            movies_data = new List<Movie>(MoviesNo);
            for (int i = 1; i <= maxPages; ++i)
            {
                Task<List<Movie>> task = Task.Run<List<Movie>>(async () => await API.GetMoviesPage(i));
                movies_data.AddRange(task.Result);
            }

            return movies_data;
        }


        public static int CustomerNo { get;} = 200;
        private static List<Customers> cust_data;

        private static async Task<List<Customers>> CustomerApi()
        {
            string url = $"https://randomuser.me/api/?results={CustomerNo}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string text = await response.Content.ReadAsStringAsync();
            CustResult res = new JavaScriptSerializer().Deserialize<CustResult>(text);
            return res.Results;
        }
        public static List<Customers> GetCustomersData()
        {
            if (cust_data == null)
            {
                cust_data = new List<Customers>(CustomerNo);
                Task<List<Customers>> task = Task.Run<List<Customers>>(async () => await API.CustomerApi());
                cust_data.AddRange(task.Result);
            }

            return cust_data;
        }


    }
}