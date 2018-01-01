using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace yyyu.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 将其他类型转化为JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializationStr(Object obj)
        {
            string strJson=JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            return strJson;
        }
        /// <summary>
        /// 将返回的JSON格式的字符串对象转换成对象
        /// </summary>
        /// <typeparam name="T">待转换的对象类型</typeparam>
        /// <param name="jsonStr">字符串</param>
        /// <returns>对象</returns>
        public static T JsonStrToObject<T>(string jsonStr) where T : class
        {
            T obj = JsonConvert.DeserializeObject(jsonStr, typeof(T)) as T;
            return obj;
        }

    }
}
