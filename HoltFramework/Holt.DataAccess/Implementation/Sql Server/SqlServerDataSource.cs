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
    /// This class is a SQL Server-specific data source implementation
    /// </summary>
    public class SqlServerDataSource : IDataSource
    {
        private CrsDalDb db = new CrsDalDb();


 

        #region --- Customer Methods



        /// <summary>
        /// Add the given customer
        /// </summary>
        /// <param name="newCrsCustomer"></param>
        public void CreateCustomer(CustomerImpl newCrsCustomer)
        {
            newCrsCustomer.CustomerId = CreateNewCustomerId();

            db.CustomerImpls.Add(newCrsCustomer);
            db.SaveChanges();
        }


        /// <summary>
        /// Update the given customer
        /// </summary>
        /// <param name="customer"></param>
        public void UpdateCustomer(CustomerImpl customer)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Return the maximum customer id in the customers table.  This can be used to generate the next ID when adding a new customer
        /// </summary>
        /// <returns></returns>
        public int CreateNewCustomerId()
        {
            return (from c in db.CustomerImpls
                    select c.CustomerId).DefaultIfEmpty(0).Max() + 1;
        }


        /// <summary>
        /// Get the customer ID based on the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetCustomerId(string name)
        {
            return (from c in db.CustomerImpls
                    where c.Name == name
                    select c.CustomerId).SingleOrDefault();
        }




        /// <summary>
        /// Get a list of all customers
        /// </summary>
        /// <returns></returns>
        public List<CustomerImpl> GetCustomers()
        {
            return (from customer in db.CustomerImpls select customer).ToList();
        }


        /// <summary>
        /// Get a given customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerImpl GetCustomer(int customerId)
        {
            // look for the single customer.  if exactly one is found, we're good, else there is an error
            return (from c in db.CustomerImpls
                    where c.CustomerId == customerId
                    select c).SingleOrDefault();
        }


        /// <summary>
        /// Get a given customer by name
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerImpl GetCustomer(string customerName)
        {
            // look for the single customer.  if exactly one is found, we're good, else there is an error
            return (from c in db.CustomerImpls
                    where c.Name == customerName
                    select c).SingleOrDefault();
        }



        /// <summary>
        /// Delete a customer by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCustomer(int id)
        {
            var customer = (from c in db.CustomerImpls
                           where c.CustomerId == id
                           select c).Single();

            db.CustomerImpls.Remove(customer);
            db.SaveChanges();
        }


        /// <summary>
        /// delete a customer by name
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCustomer(string name)
        {
            var customer = (from c in db.CustomerImpls
                           where c.Name == name
                           select c).Single();

            db.CustomerImpls.Remove(customer);
            db.SaveChanges();

        }



        #endregion --- Customer Methods


        



        #region --- Job Methods


        /// <summary>
        /// Save a job by class
        /// </summary>
        /// <param name="job"></param>
        public void CreateJob(JobImpl job)
        {
            db.JobImpls.Add(job);
            db.SaveChanges();
        }


        /// <summary>
        /// Update the given job
        /// </summary>
        /// <param name="id"></param>
        public void UpdateJob(JobImpl job)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete the given job
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJob(int jobId)
        {
            var job = (from j in db.JobImpls
                       where j.JobId == jobId
                       select j).Single();

            db.JobImpls.Remove(job);
            db.SaveChanges();

        }


        /// <summary>
        /// Create a new job ID
        /// </summary>
        /// <returns></returns>
        public int CreateNewJobId()
        {
            return (from j in db.JobImpls
                    select j.JobId).DefaultIfEmpty(0).Max() + 1;
        }



         /// <summary>
        /// Given a customer id, get all jobs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JobImpl> GetJobsByCustomer(int customerId)
        {
            return (from job in db.JobImpls
                    where job.CustomerId == customerId
                    select job).ToList();
        }

        /// <summary>
        /// Get a list of all jobs
        /// </summary>
        /// <returns></returns>
        public List<JobImpl> GetJobs()
        {
            return (from job in db.JobImpls select job).ToList();
        }


        /// <summary>
        /// Get the specified job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public JobImpl GetJob(int jobId)
        {
            return (from j in db.JobImpls
                    where j.JobId == jobId
                    select j).SingleOrDefault();
        }



        #endregion --- Job Methods









        #region --- Component Methods


        /// <summary>
        /// Create the given component
        /// </summary>
        /// <param name="component"></param>
        public void CreateComponent(ComponentImpl component)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Update the given component
        /// </summary>
        /// <param name="component"></param>
        public void UpdateComponent(ComponentImpl component)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete the given component
        /// </summary>
        /// <param name="id"></param>
        public void DeleteComponent(int componentId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get a list of all comnponents associated with the given job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ComponentImpl> GetComponentsByJob(int jobId)
        {
            return (from component in db.ComponentImpls
                    where component.JobId == jobId
                    select component).ToList();

        }


        /// <summary>
        /// Get all components
        /// </summary>
        /// <returns></returns>
        public List<ComponentImpl> GetComponents()
        {
            return (from component in db.ComponentImpls select component).ToList();
        }


        /// <summary>
        /// Get the specified component
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public ComponentImpl GetComponent(int componentId)
        {
            return (from c in db.ComponentImpls
                    where c.ComponentId == componentId
                    select c).SingleOrDefault();

        }

        #endregion --- Component Methods



        #region ---Users/Groups


        /// <summary>
        /// Get the list of groups
        /// </summary>
        /// <returns></returns>
        public List<GroupImpl> GetGroups()
        {
            return (from g in db.GroupImpls
                         select g).ToList();
        }


        /// <summary>
        /// get the given group
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GroupImpl GetGroup(string name)
        {
            return (from g in db.GroupImpls
                        where g.Name == name
                        select g).SingleOrDefault();
        }

        /// <summary>
        /// Return all users
        /// </summary>
        /// <returns></returns>
        public List<UserImpl> GetUsers()
        {
            return (from u in db.UserImpls
                    select u).ToList();
        }


        /// <summary>
        /// Return given user
        /// </summary>
        /// <returns></returns>
        public UserImpl GetUser(string name)
        {
            return (from u in db.UserImpls
                    where u.UserName == name
                    select u).SingleOrDefault();
        }



        /// <summary>
        /// Get all users in the given group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<UserImpl> GetUsersByGroup(int groupId)
        {
            return db.GetUsersByGroup(groupId).ToList();
        }


        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(UserImpl user)
        {
            db.UserImpls.Add(user);
            db.SaveChanges();
        }


        /// <summary>
        /// Create the given group
        /// </summary>
        /// <param name="group"></param>
        public void CreateGroup(GroupImpl group)
        {
            db.GroupImpls.Add(group);
            db.SaveChanges();
        }

        /// <summary>
        /// Create the given list
        /// </summary>
        /// <param name="list"></param>
        public void CreateNotificationList(NotificationImpl list)
        {
            db.NotificationImpls.Add(list);
            db.SaveChanges();
        }


        /// <summary>
        /// Get the given notification list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NotificationImpl GetNotificationList(string name)
        {
            return (from n in db.NotificationImpls
                   where n.NotificationName == name
                   select n).SingleOrDefault();
        }


        /// <summary>
        /// Get a list of all notification lists
        /// </summary>
        /// <returns></returns>
        public List<NotificationImpl> GetNotificationLists()
        {
            return (from n in db.NotificationImpls
                    select n).ToList(); ;
        }


        /// <summary>
        /// Get all users in the given notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public List<UserImpl> GetUsersInNotificationList(string notificationName)
        {
            return db.GetUsersByNotification(notificationName).ToList();
        }


        /// <summary>
        /// Get all groups in the notification list.
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public List<GroupImpl> GetGroupsInNotificationList(string notificationName)
        {
            return db.GetGroupsByNotification(notificationName).ToList();
        }


        #endregion ---Users/Groups
    }
}
