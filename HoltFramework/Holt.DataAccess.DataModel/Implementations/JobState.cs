using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holt.DataAccess.DataModel
{
    public static class JobState
    {

        public const int READY_STATE = 1;
        public const int COMPLETE_STATE = 2;
        public const int UNKNOWN_STATE = 3;


        public const string READY = "Ready";
        public const string COMPLETE = "Complete";
        public const string UNKNOWN = "Unknown";
        

        
        /// <summary>
        /// Return the value for the ready state
        /// </summary>
        public static int Ready
        {
            get { return READY_STATE; }
        }


        /// <summary>
        /// return the value for the complete state
        /// </summary>
        public static int Complete
        {
            get { return COMPLETE_STATE; }
        }



        /// <summary>
        /// Extension method to convert int value into state name
        /// </summary>
        /// <param name="intState"></param>
        /// <returns></returns>
        public static string ToStateName(this int intState)
        {
            switch (intState)
            {
                case READY_STATE:
                    return READY;

                case COMPLETE_STATE:
                    return COMPLETE;
                
                default:
                    return UNKNOWN;
            }
        }


    }
}
