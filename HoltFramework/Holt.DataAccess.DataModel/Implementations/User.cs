using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holt.DataAccess.DataModel
{
    public class User : IUser, IEquatable<User>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int Status { get; set; }



        /// <summary>
        /// Custom comparison for List.Contains() method
        /// </summary>
        /// <param name="otherUser"></param>
        /// <returns></returns>
        public bool Equals(User otherUser)
        {
            return UserName == otherUser.UserName &&
                    FullName == otherUser.FullName &&
                    EmailAddress == otherUser.EmailAddress;
        }

    }
}
