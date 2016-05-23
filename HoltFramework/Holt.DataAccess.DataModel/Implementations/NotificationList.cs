using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Holt.DataAccess.DataModel
{

    /// <summary>
    /// This class keeps a list of users/groups to be notifiedby email when told to do so
    /// </summary>
    public class NotificationList : INotificationList, IEquatable<NotificationList>
    {
        private List<User> userList = new List<User>();
        private List<Group> groupList = new List<Group>();

        /// <summary>
        /// expose user list
        /// </summary>
        public List<User> Users
        {
            get { return userList; }
        }


        /// <summary>
        /// Expose group list
        /// </summary>
        public List<Group> Groups
        {
            get { return groupList; }
        }


        /// <summary>
        /// List name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// NotificationList type
        /// </summary>
        public int Type { get; set; }


        /// <summary>
        /// Set the list name
        /// </summary>
        /// <param name="name"></param>
        public NotificationList(string name, List<User> users, List<Group> groups)
        {
            Name = name;
            userList = users;
            groupList = groups;
        }


        /// <summary>
        /// Custom comparison for List.Contains()
        /// </summary>
        /// <param name="otherList"></param>
        /// <returns></returns>
        public bool Equals(NotificationList otherList)
        {
            return Name == otherList.Name &&
                    Type == otherList.Type;
        }
    }
}
