using Newtonsoft.Json;

namespace BS.EndToEnd.Utils
{
    public static class UtilsExtensions
    {
        /// <summary>
        /// Create json from object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Create StringContent from object
        /// Object is serialized in json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static StringContent ToStringContent(this object obj) {
           return new StringContent(obj.ToJson(), System.Text.Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Create instance of object based on json serialization
        /// </summary>
        /// <typeparam name="T">Type of deserialized Object</typeparam>
        /// <param name="jsonString">String content</param>
        /// <returns>Instance of object</returns>
        public static T FromJson<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
