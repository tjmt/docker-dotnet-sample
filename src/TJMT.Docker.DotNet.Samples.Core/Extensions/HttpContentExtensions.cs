using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TJMT.Docker.DotNet.Samples.Core.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            return json.ReadAsJsonAsync<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ReadAsJsonAsync<T>(this string json)
        {
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}
