using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holt.DataAccess.DBModel;

namespace Holt.DataAccess
{

    /// <summary>
    /// This interface defines a data source.  Note that all parameters are of type string, even when it would be more reasonable to
    /// use integers.  The reason for this is to allow web service implementations, since they can only work with strings.
    /// </summary>
    public interface IDataSource
    {

        #region --- Customer Methods


        /// <summary>
        /// Add the given customer
        /// </summary>
        /// <param name="newCrsCustomer"></param>
        void CreateCustomer(CustomerImpl newCrsCustomer);

        
        /// <summary>
        /// Update the given customer
        /// </summary>
        /// <param name="id"></param>
        void UpdateCustomer(CustomerImpl customer);


        /// <summary>
        /// Delete a customer by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteCustomer(int customerId);

        /// <summary>
        /// Get a new customer id.  this is used to create a unique key for the customer.
        /// </summary>
        /// <returns></returns>
        int CreateNewCustomerId();


        /// <summary>
        /// Get the cutomer ID based on name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetCustomerId(string name);


        /// <summary>
        /// Get a list of ComponentImpl
        /// </summary>
        /// <returns></returns>
        List<CustomerImpl> GetCustomers();


        /// <summary>
        /// Get the given customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        CustomerImpl GetCustomer(int customerId);


        /// <summary>
        /// get a customer by name
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        CustomerImpl GetCustomer(string customerName);


        #endregion --- Customer Methods





        #region --- Job Methods


        /// <summary>
        /// Add a job by class
        /// </summary>
        /// <param name="job"></param>
        void CreateJob(JobImpl job);


        /// <summary>
        /// Update the given job
        /// </summary>
        /// <param name="id"></param>
        void UpdateJob(JobImpl job);


        /// <summary>
        /// Delete a job by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteJob(int jobId);


        /// <summary>
        /// Create a new job ID
        /// </summary>
        /// <returns></returns>
        int CreateNewJobId();

        /// <summary>
        /// Get the given job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        JobImpl GetJob(int jobId);

        /// <summary>
        /// Get all jobs
        /// </summary>
        /// <returns></returns>
        List<JobImpl> GetJobs();

        /// <summary>
        /// get all jobs by customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<JobImpl> GetJobsByCustomer(int customerId);



        #endregion --- Job Methods




        #region --- Component Methods


        /// <summary>
        /// Create the given component
        /// </summary>
        /// <param name="component"></param>
        void CreateComponent(ComponentImpl component);


        /// <summary>
        /// Update the given component
        /// </summary>
        /// <param name="component"></param>
        void UpdateComponent(ComponentImpl component);


        /// <summary>
        /// Delete the given component
        /// </summary>
        /// <param name="id"></param>
        void DeleteComponent(int comopnentId);

        
        /// <summary>
        /// Get all components by job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ComponentImpl> GetComponentsByJob(int jobId);

        /// <summary>
        /// Get all components
        /// </summary>
        /// <returns></returns>
        List<ComponentImpl> GetComponents();

        /// <summary>
        /// Get the given component
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        ComponentImpl GetComponent(int componentId);

        #endregion --- Component Methods


        #region --- Users/Groups


        /// <summary>
        /// Get a list of all groups
        /// </summary>
        /// <returns></returns>
        List<GroupImpl> GetGroups();

        /// <summary>
        /// Get the given group
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        GroupImpl GetGroup(string name);

        /// <summary>
        /// Create the given user
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(UserImpl user);


        /// <summary>
        /// Get a list of all users
        /// </summary>
        /// <returns></returns>
        List<UserImpl> GetUsers();


        /// <summary>
        /// Get a specifiec user
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        UserImpl GetUser(string name);


        /// <summary>
        /// Create the given group
        /// </summary>
        /// <param name="group"></param>
        void CreateGroup(GroupImpl group);


        /// <summary>
        /// Get all users by group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<UserImpl> GetUsersByGroup(int groupId);


        /// <summary>
        /// Get all users in the given notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        List<UserImpl> GetUsersInNotificationList(string notificationName);


        /// <summary>
        /// Get a list of all groups in the notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        List<GroupImpl> GetGroupsInNotificationList(string notificationName);


        /// <summary>
        /// Create a new notification list
        /// </summary>
        /// <param name="list"></param>
        void CreateNotificationList(NotificationImpl list);


        /// <summary>
        /// get the given notification list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        NotificationImpl GetNotificationList(string name);

        /// <summary>
        /// Get a list of all notification lists
        /// </summary>
        /// <returns></returns>
        List<NotificationImpl> GetNotificationLists();


        #endregion --- Users/Groups

    }
}
