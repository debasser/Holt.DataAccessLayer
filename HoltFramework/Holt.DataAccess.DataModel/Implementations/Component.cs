using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Holt.DataAccess.DataModel
{
    [DataContract]
    public class Component : IEquatable<Component>
    {
        /// <summary>
        /// Component id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Associated job id
        /// </summary>
        [DataMember]        
        public int JobId { get; set; }

        /// <summary>
        /// component description
        /// </summary>
        [DataMember]        
        public string Description { get; set; }


        /// <summary>
        /// Custom comparison to support List.Contains()
        /// </summary>
        /// <param name="otherComponent"></param>
        /// <returns></returns>
        public bool Equals(Component otherComponent)
        {
            return Id == otherComponent.Id &&
                    JobId == otherComponent.JobId &&
                    Description == otherComponent.Description;

        }
    }
}
