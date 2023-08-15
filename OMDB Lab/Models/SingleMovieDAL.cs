using Newtonsoft.Json;
using System.Net;

namespace OMDB_Lab.Models
{
    public class SingleMovieDAL
    {
        public static SingleMovieModel GetMovie(string title)
        {
            //Setup
            string url = $"http://www.omdbapi.com/?i=tt3896198&apikey=b8fb13c1&t={title}";


            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert it to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to c#
            SingleMovieModel result = JsonConvert.DeserializeObject<SingleMovieModel>(JSON);
            return result;
        }
    }
}
