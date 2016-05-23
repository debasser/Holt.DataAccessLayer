using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Holt.DataAccess.DataModel
{
    [DataContract]
    public class Job : IEquatable<Job>
    {

        /// <summary>
        /// Job ID
        /// </summary>
        [DataMember]        
        public int Id { get; set; }

        /// <summary>
        /// Job description
        /// </summary>
        [DataMember]        
        public string Description { get; set; }

        /// <summary>
        /// State of the job
        /// </summary>
        [DataMember]
        public int State { get; set; }

        /// <summary>
        /// Associated customer id
        /// </summary>
        [DataMember]        
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer detail
        /// </summary>
        [DataMember]        
        public Customer Customer { get; set; }

        /// <summary>
        /// List of components associate with this job
        /// </summary>
        [DataMember]        
        public List<Component> Components { get; set; }



        /// <summary>
        /// Set the initial job state
        /// </summary>
        public Job()
        {
            State = JobState.READY_STATE;
        }


        
        /// <summary>
        /// Change to given state
        /// </summary>
        /// <param name="newState"></param>
        public void SetState(int newState)
        {
            State = newState;
        }
        

        /// <summary>
        /// Set the current state
        /// </summary>
        public void SetStateReady()
        {
            State = JobState.READY_STATE;
        }


        /// <summary>
        /// Set the current state
        /// </summary>
        public void SetStateComplete()
        {
            State = JobState.COMPLETE_STATE;
        }


        /// <summary>
        /// Determine if the state is ready
        /// </summary>
        /// <returns></returns>
        public bool IsReady()
        {
            return State == JobState.READY_STATE;
        }


        /// <summary>
        /// Determine if the state is complete
        /// </summary>
        /// <returns></returns>
        public bool IsComplete()
        {
            return State == JobState.COMPLETE_STATE;
        }


        /// <summary>
        /// Customer comparison for List.Contains()
        /// </summary>
        /// <param name="otherJob"></param>
        /// <returns></returns>
        public bool Equals(Job otherJob)
        {
            return Id == otherJob.Id &&
                    Description == otherJob.Description;
        }

    }
}
