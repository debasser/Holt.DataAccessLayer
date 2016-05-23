using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holt.DataAccess.DataModel
{

    /// <summary>
    /// Definition of the group interface
    /// </summary>
    public interface IGroup
    {
        /// <summary>
        /// Add a user to the group
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);

        /// <summary>
        /// Delete a user from the group
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);

    }
}
