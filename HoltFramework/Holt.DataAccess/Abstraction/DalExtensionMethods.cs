using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holt.DataAccess.DataModel;
using Holt.DataAccess.DBModel;

namespace Holt.DataAccess
{
    /// <summary>
    /// extension methods for the data access layer
    /// </summary>
    public static class DalExtensionsMethods
    {
        // indicator that the ID is for a null pattern object
        private const int NULL_ID = -1;
        private const int STATUS_ID = -1;


        #region --- Customers

        /// <summary>
        /// Given a customerImpl, create a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer ToCustomer(this CustomerImpl customerImpl)
        {
            if (!string.IsNullOrEmpty(customerImpl.Address))
            {
                customerImpl.Address = customerImpl.Address.TrimEnd();
            }

            if (!string.IsNullOrEmpty(customerImpl.Name))
            {
                customerImpl.Name = customerImpl.Name.TrimEnd();
            }

            var customer = new Customer() { Id = customerImpl.CustomerId, Address = customerImpl.Address, Name = customerImpl.Name };
            return customer;
        }


        /// <summary>
        /// Given a job, create a customer implemntation
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static CustomerImpl ToCustomerImpl(this Job job)
        {
            var customerImpl = new CustomerImpl() { CustomerId = job.Customer.Id, Address = job.Customer.Address.TrimEnd(), Name = job.Customer.Name.TrimEnd() };
            return customerImpl;
        }


        /// <summary>
        /// Given a job, create a customer implemntation
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static CustomerImpl ToCustomerImpl(this Customer customer)
        {
            var customerImpl = new CustomerImpl() { CustomerId = customer.Id, Name = customer.Name.TrimEnd(), Address = customer.Address.TrimEnd(), Jobs = null };
            return customerImpl;
        }


        /// <summary>
        /// Create a NULL customer to conform to Null Object pattern
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer Empty(this Customer customer)
        {
            return new Customer() { Id = NULL_ID, Name = "", Address = "", Jobs = new List<Job>() };
        }


        /// <summary>
        /// Determine if this is a null pattern object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Customer customer)
        {
            return customer.Id == NULL_ID;
        }


        /// <summary>
        /// Create a NULL customer to conform to Null Object pattern
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerImpl Empty(this CustomerImpl customer)
        {
            return new CustomerImpl() { CustomerId = NULL_ID, Address = "", Name = "", Jobs = new List<JobImpl>() };
        }


        /// <summary>
        /// Determine if this is a null pattern object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool IsEmpty(this CustomerImpl customer)
        {
            return customer.CustomerId == NULL_ID;
        }



        #endregion --- Customers




        #region --- Jobs


        /// <summary>
        /// Create a JobImpl from a regular Job class
        /// </summary>
        /// <param name="job"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static JobImpl ToJobImpl(this Job job, CustomerImpl customer)
        {
            var jobImpl = new JobImpl() { JobId = job.Id, Customer = customer, CustomerId = customer.CustomerId, Description = job.Description.TrimEnd(), State = job.State };
            return jobImpl;
        }


        /// <summary>
        /// Create a JobImpl from a regular Job class
        /// </summary>
        /// <param name="job"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static JobImpl ToJobImpl(this Job job)
        {
            var customerImpl = job.Customer.ToCustomerImpl();
            var jobImpl = new JobImpl() { JobId = job.Id, Customer = customerImpl, Description = job.Description.TrimEnd(), State = job.State };
            return jobImpl;
        }


        /// <summary>
        /// Create a Job from a JobImpl
        /// </summary>
        /// <param name="jobImpl"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Job ToJob(this JobImpl jobImpl, List<Component> components, Customer customer)
        {
            customer.Address = TrimValue(customer.Address);
            customer.Name = TrimValue(customer.Name);

            var job = new Job() { Id = jobImpl.JobId, Description = jobImpl.Description.TrimEnd(), Customer = customer, Components = components };
            return job;
        }


        /// <summary>
        /// Create a NULL job to conform to Null Object pattern
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Job Empty(this Job job)
        {
            var customer = new Customer() { Id = NULL_ID, Name = "", Address = "", Jobs = new List<Job>() };
            return new Job() { Id = NULL_ID, Description = "", CustomerId = NULL_ID, State = JobState.UNKNOWN_STATE, Customer = customer, Components = new List<Component>() };
        }


        /// <summary>
        /// Determine if this is a null pattern object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Job job)
        {
            return job.Id == NULL_ID;
        }


        /// <summary>
        /// Create a NULL job to conform to Null Object pattern
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static JobImpl Empty(this JobImpl job)
        {
            return new JobImpl() { JobId = NULL_ID, CustomerId = NULL_ID, Description = "", State = 1, Customer = new CustomerImpl().Empty(), Components = new List<ComponentImpl>() };
        }


        /// <summary>
        /// Determine if this is a null pattern object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool IsEmpty(this JobImpl job)
        {
            return job.JobId == NULL_ID;
        }


        #endregion --- Jobs




        #region --- Components



        /// <summary>
        /// Convert a ComponentImpl from a straight Component object
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public static ComponentImpl ToComponentImpl(this Component component)
        {
            var componentImpl = new ComponentImpl() { ComponentId = component.Id, Description = component.Description.TrimEnd(), JobId = component.JobId };
            return componentImpl;
        }


        /// <summary>
        /// Create a Component from a ComponentImpl
        /// </summary>
        /// <param name="componentImpl"></param>
        /// <returns></returns>
        public static Component ToComponent(this ComponentImpl componentImpl)
        {
            var component = new Component() {Id = componentImpl.ComponentId, Description = componentImpl.Description.TrimEnd(), JobId = componentImpl.JobId };
            return component;
        }


        /// <summary>
        /// Create a list of Components from a list of ComponentImpls
        /// </summary>
        /// <param name="componentImpl"></param>
        /// <returns></returns>
        public static List<Component> ToComponents(this List<ComponentImpl> componentImpls)
        {
            var components = new List<Component>();
            foreach (var componentImpl in componentImpls)
            {
                components.Add(componentImpl.ToComponent());
            }
            return components;
        }


        /// <summary>
        /// Create a NULL component to conform to Null Object pattern
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Component Empty(this Component component)
        {
            return new Component() { Id = NULL_ID, JobId = NULL_ID, Description = "" };
        }


        /// <summary>
        /// Determine if this is a null pattern object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Component component)
        {
            return component.Id == NULL_ID;
        }


        /// <summary>
        /// Create a NULL component to conform to Null Object pattern
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static ComponentImpl Empty(this ComponentImpl component)
        {
            return new ComponentImpl() { ComponentId = NULL_ID, Description = "", JobId = NULL_ID, Job = new JobImpl().Empty() };
        }


        /// <summary>
        /// Determine if this is a null pattern object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool IsEmpty(this ComponentImpl component)
        {
            return component.ComponentId == NULL_ID;
        }



        #endregion --- Components



        #region --- Users/Groups


        /// <summary>
        /// Create a Usaer from a UserImpl
        /// </summary>
        /// <param name="userImpl"></param>
        /// <returns></returns>
        public static User ToUser(this UserImpl userImpl)
        {
            var user = new User()
            {
                UserName = userImpl.UserName.TrimEnd(),
                FullName = userImpl.FullName.TrimEnd(),
                EmailAddress = userImpl.EmailAddress.TrimEnd(),
                Status = userImpl.Status
            };

            return user;
        }


        /// <summary>
        /// Convert a user to user impl
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserImpl ToUserImpl(this User user)
        {
            var userImpl = new UserImpl()
            {
                UserName = user.UserName.Trim(),
                FullName = user.FullName.Trim(),
                EmailAddress = user.EmailAddress.Trim(),
                Status = user.Status
            };

            return userImpl;
        }


        /// <summary>
        /// Create a list of Components from a list of ComponentImpls
        /// </summary>
        /// <param name="componentImpl"></param>
        /// <returns></returns>
        public static List<User> ToUsers(this List<UserImpl> userImpls)
        {
            var users = new List<User>();
            foreach (var userImpl in userImpls)
            {
                users.Add(userImpl.ToUser());
            }
            return users;
        }


        /// <summary>
        /// Create an empty UserImpl
        /// </summary>
        /// <param name="userImpl"></param>
        /// <returns></returns>
        public static User Empty(this UserImpl userImpl)
        {
            var emptyUserImpl = new User()
            {
                UserName = string.Empty,
                FullName = string.Empty,
                EmailAddress = string.Empty,
                Status = NULL_ID
            };

            return emptyUserImpl;

        }


        /// <summary>
        /// Determine if the given UserImpl is empty
        /// </summary>
        /// <param name="userImpl"></param>
        /// <returns></returns>
        public static bool IsEmpty(this UserImpl userImpl)
        {
            return userImpl.Status == STATUS_ID;
        }


        /// <summary>
        /// Return the given group
        /// </summary>
        /// <param name="groupImpl"></param>
        /// <returns></returns>
        public static Group ToGroup(this GroupImpl groupImpl)
        {
            var userList = groupImpl.Users.ToList().ToUsers();
            
            var group = new Group(userList)
            {
                GroupId = groupImpl.GroupId,
                Name = groupImpl.Name.TrimEnd()
            };

            return group;
        }


        public static GroupImpl ToGroupImpl(this Group group)
        {
            var groupImpl = new GroupImpl()
            {
                GroupId = group.GroupId,
                Name = group.Name.Trim()
            };

            return groupImpl;
        }


        /// <summary>
        /// Return a list of all groups
        /// </summary>
        /// <param name="groupImpls"></param>
        /// <returns></returns>
        public static List<Group> ToGroups(this List<GroupImpl> groupImpls)
        {
            var groups = new List<Group>();
            foreach (var groupImpl in groupImpls)
            {
                groups.Add(groupImpl.ToGroup());
            }

            return groups;
        }


        /// <summary>
        /// Create an empty Group
        /// </summary>
        /// <param name="groupImpl"></param>
        /// <returns></returns>
        public static Group Empty(this GroupImpl groupImpl)
        {
            var userList = groupImpl.Users.ToList().ToUsers();

            var group = new Group(userList)
            {
                GroupId = NULL_ID,
                Name = string.Empty
            };

            return group;
        }


        /// <summary>
        /// See if the group impl is empty
        /// </summary>
        /// <param name="groupImpl"></param>
        /// <returns></returns>
        public static bool IsEmpty(this GroupImpl groupImpl)
        {
            return groupImpl.GroupId == NULL_ID;
        }



        #endregion --- Users/Groups



        #region --- Notifications

        /// <summary>
        /// Transform a notification impl to a notification
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static NotificationList ToNotificationList(this NotificationImpl list)
        {
            var notificationList = new NotificationList(list.NotificationName, list.Users.ToList().ToUsers(), list.Groups.ToList().ToGroups())
            {
                Type = list.Type,
                //Users = list.Users.ToList().ToUsers(),
                //Groups = list.Groups.ToList().ToGroups()
            };

            return notificationList;
        }


        /// <summary>
        /// Transform a list of notification list IMPLs to a list of notification lists
        /// </summary>
        /// <param name="notificationImplList"></param>
        /// <returns></returns>
        public static List<NotificationList> ToNotificationLists(this List<NotificationImpl> notificationImplList)
        {
            var notificationLists = new List<NotificationList>();
            foreach (var notificationImpl in notificationImplList)
            {
                notificationLists.Add(notificationImpl.ToNotificationList());
            }
            return notificationLists;

        }


        #endregion --- Notifications





        /// <summary>
        /// Trim the given string if it's not null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string TrimValue(string value)
        {
            return value = (!string.IsNullOrEmpty(value)) ? value.TrimEnd() : null;
        }
         

    }



}
