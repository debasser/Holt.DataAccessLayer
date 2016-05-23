using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Holt.DataAccess.DataModel;

namespace Holt.DataAccess.DataModel
{

    /// <summary>
    /// Definition of the notification list interaface
    /// </summary>
    public interface INotificationList
    {

        /// <summary>
        /// Name of the list
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Type of notification
        /// </summary>
        int Type { get; }

        /// <summary>
        /// Lists of users/groups
        /// </summary>
        List<User> Users { get; }
        List<Group> Groups { get; }
    }
}
