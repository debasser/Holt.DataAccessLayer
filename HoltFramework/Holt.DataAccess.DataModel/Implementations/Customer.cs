using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Holt.DataAccess.DataModel
{
    [DataContract]
    public class Customer : IEquatable<Customer>
    {
        /// <summary>
        /// customer id
        /// </summary>
        [DataMember]        
        public int Id { get; set; }

        /// <summary>
        /// customer name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// customer address
        /// </summary>
        [DataMember]        
        public string Address { get; set; }

        /// <summary>
        /// list of jobs for this customer
        /// </summary>
        [DataMember]        
        public List<Job> Jobs { get; set; }

        /// <summary>
        /// speicifies if this is a "gold", i.e., valued customer
        /// </summary>
        [DataMember]
        public bool IsGoldCustomer { get; set; }



        /// <summary>
        /// Custom comparison for supporting List.Contains()
        /// </summary>
        /// <param name="otherCustomer"></param>
        /// <returns></returns>
        public bool Equals(Customer otherCustomer)
        {
            return Id == otherCustomer.Id &&
                    Name == otherCustomer.Name &&
                    Address == otherCustomer.Address;
        }
    }
}
