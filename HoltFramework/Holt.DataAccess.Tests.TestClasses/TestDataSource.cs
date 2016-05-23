using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Holt.DataAccess.DBModel;
using Holt.DataAccess;
using Holt.DataAccess.DataModel;

namespace Holt.DataAccess.Tests.TestClasses
{

    /// <summary>
    /// This is the basis for testing with a test double IDataSource class.  Unit tests can override only the methods they are testing.
    /// </summary>
    public abstract class TestDataSource : IDataSource
    {
        #region --- Customers

        public virtual int CreateNewCustomerId() { throw new NotImplementedException(); }
        public virtual int GetCustomerId(string name) { throw new NotImplementedException(); }
        public virtual void CreateCustomer(CustomerImpl newCrsCustomer) { throw new NotImplementedException(); }
        public virtual void UpdateCustomer(CustomerImpl customer) { throw new NotImplementedException(); }
        public virtual void DeleteCustomer(int id) { throw new NotImplementedException(); }
        public virtual CustomerImpl GetCustomer(string name) { throw new NotImplementedException(); }

        public virtual List<CustomerImpl> GetCustomers() { throw new NotImplementedException(); }
        public virtual CustomerImpl GetCustomer(int customerId) { throw new NotImplementedException(); }

        #endregion --- Customers



        #region --- Jobs

        public virtual void CreateJob(JobImpl job)  { throw new NotImplementedException(); }
        public virtual void UpdateJob(JobImpl job) { throw new NotImplementedException(); }
        public virtual void DeleteJob(int id) { throw new NotImplementedException(); }
        public virtual List<JobImpl> GetJobsByCustomer(int id) { throw new NotImplementedException(); }
        public virtual int CreateNewJobId() { throw new NotImplementedException(); }
        public virtual List<JobImpl> GetJobs()  { throw new NotImplementedException(); }
        public virtual JobImpl GetJob(int jobId) { throw new NotImplementedException(); } 

        #endregion --- Jobs



        #region --- Components


        public virtual void CreateComponent(ComponentImpl component) { throw new NotImplementedException(); }
        public virtual void UpdateComponent(ComponentImpl component) { throw new NotImplementedException(); }
        public virtual void DeleteComponent(int id) { throw new NotImplementedException(); }

        public virtual List<ComponentImpl> GetComponentsByJob(int id) { throw new NotImplementedException(); }
        public virtual List<ComponentImpl> GetComponents() { throw new NotImplementedException(); }
        public virtual ComponentImpl GetComponent(int componentId) { throw new NotImplementedException(); }


        #endregion --- Components


        #region --- Users/Groups


        public virtual GroupImpl GetGroup(string name) { throw new NotImplementedException(); }
        public virtual List<GroupImpl> GetGroups() { throw new NotImplementedException(); }
        public virtual void CreateUser(UserImpl user) { throw new NotImplementedException(); }
        public virtual UserImpl GetUser(string userName) { throw new NotImplementedException(); }
        public virtual List<UserImpl> GetUsers() { throw new NotImplementedException(); }
        public virtual List<UserImpl> GetUsersByGroup(int groupId) { throw new NotImplementedException(); }
        public virtual List<UserImpl> GetUsersInNotificationList(string notificationName) { throw new NotImplementedException(); }
        public virtual List<GroupImpl> GetGroupsInNotificationList(string notificationName) { throw new NotImplementedException(); }
        public virtual void CreateGroup(GroupImpl group) { throw new NotImplementedException(); }
        public virtual void CreateNotificationList(NotificationImpl list) { throw new NotImplementedException(); }
        public virtual NotificationImpl GetNotificationList(string name) { throw new NotImplementedException(); }
        public virtual List<NotificationImpl> GetNotificationLists() { throw new NotImplementedException(); }

        #endregion --- Users/Groups
    }
  

}
