using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holt.DataAccess;
using Holt.DataAccess.DBModel;
using Holt.DataAccess.DataModel;

namespace Holt.DataAccess
{
    /// <summary>
    /// This abstract base class is used to define specific data sources (sometimes called data stores in the code)
    /// </summary>
    public abstract class DataStore
    {
        protected IDataSource dataSource;


        protected DataStore(IDataSource ds)
        {
            dataSource = ds;
        }


        #region --- Customer methods

        /// <summary>
        /// Get a list of all customers
        /// </summary>
        /// <returns></returns>
        public abstract List<Customer> GetCustomers();


        /// <summary>
        /// Get customer data based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Customer GetCustomer(int id);


        /// <summary>
        /// Add the given customer class
        /// </summary>
        /// <param name="newCustomer"></param>
        public abstract void CreateCustomer(Customer newCustomer);


        /// <summary>
        /// Delete a customer by id
        /// </summary>
        /// <param name="id"></param>
        public abstract void DeleteCustomer(int id);


        /// <summary>
        /// Get a new customer id
        /// </summary>
        /// <returns></returns>
        public abstract int GetNewCustomerId();

        
        #endregion --- Customer methods


        #region --- Job methods


        /// <summary>
        /// Add a new job based a class
        /// </summary>
        /// <param name="job"></param>
        public abstract void CreateJob(Job job);

        /// <summary>
        /// Create a full job with customer and component information
        /// </summary>
        /// <param name="job"></param>
        public abstract void CreateCustomerJob(Job job);


        /// <summary>
        /// Get a full job object for given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Job GetCustomerJob(int id);


        /// <summary>
        /// Change the state of the given job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="newState"></param>
        public abstract void SetState(Job job, int newState);


        /// <summary>
        /// Get job information based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Job GetJob(int id);


        /// <summary>
        /// Get a list of all jobs
        /// </summary>
        /// <returns></returns>
        public abstract List<Job> GetJobs();


        /// <summary>
        /// Get all the jobs associated with a given customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract List<Job> GetJobsByCustomer(int id);


        #endregion --- Job methods




        #region --- Component methods


        /// <summary>
        /// Get all the components for given job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract List<Component> GetComponentsByJob(int id);


        /// <summary>
        /// Get all components
        /// </summary>
        /// <returns></returns>
        public abstract List<Component> GetComponents();


        /// <summary>
        /// Get a component by id
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public abstract Component GetComponent(int componentId);

        
        #endregion --- Component methods



        /// <summary>
        /// Given a crsCustomer, create a data model Customer
        /// </summary>
        /// <param name="crsCustomer"></param>
        /// <returns></returns>
        protected Customer CreateCustomer(CustomerImpl crsCustomer)
        {
            var customer = new Customer();
            customer.Id = crsCustomer.CustomerId;
            customer.Name = TrimValue(crsCustomer.Name);
            customer.Address = TrimValue(crsCustomer.Address);

            return customer;

        }


        #region --- Users/Groups


        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        public abstract void CreateUser(User user);


        /// <summary>
        /// Get a list of all users
        /// </summary>
        /// <returns></returns>
        public abstract List<User> GetUsers();

        /// <summary>
        /// Get the given user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public abstract User GetUser(string userName);

        /// <summary>
        /// Create the given group
        /// </summary>
        /// <param name="gruop"></param>
        public abstract void CreateGroup(Group group);

        /// <summary>
        /// Get a list of groups
        /// </summary>
        /// <returns></returns>
        public abstract List<Group> GetGroups();

        /// <summary>
        /// Get the given group
        /// </summary>
        /// <returns></returns>
        public abstract Group GetGroup(string name);


        /// <summary>
        /// Get all the users in a given group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public abstract List<User> GetUsersByGroup(int groupId);


        /// <summary>
        /// Get all the users in a given notification list
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public abstract List<User> GetUsersInNotificationList(string notificationName);


        /// <summary>
        /// Get a list of groups in this notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public abstract List<Group> GetGroupsInNotificationList(string notificationName);


        /// <summary>
        /// Get a populated notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public abstract NotificationList GetNotificationList(string notificationName);

        /// <summary>
        /// Get all notification lists
        /// </summary>
        /// <returns></returns>
        public abstract List<NotificationList> GetNotificationLists();




        #endregion --- Users/Groups


        /// <summary>
        /// Trim the given string if it's not null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string TrimValue(string value)
        {
            return value = (!string.IsNullOrEmpty(value)) ? value.TrimEnd() : null;
        }
         
    }
}
