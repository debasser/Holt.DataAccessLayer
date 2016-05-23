using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holt.DataAccess.DataModel
{
    public class Group : IEquatable<Group>, IGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; }


        // list of users in this group
        public List<User> UserList { get; private set; }


        public Group(List<User> userList)
        {
            UserList = userList;
        }


        /// <summary>
        /// Add the given user to the group
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            UserList.Add(user);
        }


        /// <summary>
        /// Delete a user from the group
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Custom comparison for supporting List.Contains() method
        /// </summary>
        /// <param name="otherGroup"></param>
        /// <returns></returns>
        public bool Equals(Group otherGroup)
        {
            return GroupId == otherGroup.GroupId &&
                    Name == otherGroup.Name;
        }

    }
}
