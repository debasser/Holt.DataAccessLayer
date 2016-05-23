using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using Holt.DataAccess.DBModel;
using Holt.DataAccess.DataModel;

namespace Holt.DataAccess.Extensions
{

    /// <summary>
    /// This class provides extension methods for the CRS and users of it
    /// </summary>
    public static class ExtensionsMethods
    {

        /// <summary>
        /// Write the generic T class as XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public static void ToXml<T>(this object obj, string fileName)
        {
            try
            {
                using (var writer = new XmlTextWriter(fileName, null))
                {
                    var ser = new DataContractSerializer(typeof(T));
                    ser.WriteObject(writer, obj);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to write XML.  Error = " + ex.Message);
            }

        }


        /// <summary>
        /// Read the generic T class from xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T ReadXml<T>(this object obj, string fileName)
        {
            try
            {
                var ser = new DataContractSerializer(typeof(T));
                using (var reader = XmlReader.Create(fileName))
                {
                    return (T)ser.ReadObject(reader);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to read XML.  Error = " + ex.Message);
            }

        }


        /// <summary>
        /// Serialize a class to a JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJson<T>(this object o)
        {
            var ms = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(ms, o);

            ms.Position = 0;
            var sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Given a json string stream, convert it to the specified class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T FromJson<T>(this Stream jsonStream)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            T obj = (T)serializer.ReadObject(jsonStream);
            return obj;
        }


        /// <summary>
        /// Given a json string, convert it into a stream that can be used to re-generate the class
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static Stream ToStream(this string inputString)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(inputString);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }



        /// <summary>
        /// Normalize a JSON string returned by the CRS web service.  It is prefixed with the name of the called method, which must be stripped off.  Here is
        /// an example output from the web service:
        ///     "{\"GetCustomerResult\":{\"Address\":null,\"Id\":1,\"Jobs\":null,\"Name\":\"Nine Inch Nails                                   \"}}"
        ///     
        /// This method changes it to the following:
        ///     "{\"Address\":null,\"Id\":1,\"Jobs\":null,\"Name\":\"Nine Inch Nails                                   \"}"
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string NormalizeJson(this string json)
        {
            int index = json.IndexOf(':') + 1;
            json = json.Substring(index);

            index = json.LastIndexOf('}');
            json = json.Substring(0, index);

            return json;

        }


        /// <summary>
        /// Given a customerImpl, create a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer ToCustomer(this CustomerImpl customerImpl)
        {
            var customer = new Customer(){ Id = customerImpl.CustomerId, Address = customerImpl.Address.TrimEnd(), Name = customerImpl.Name.TrimEnd()};
            return customer;
        }
    }

}
