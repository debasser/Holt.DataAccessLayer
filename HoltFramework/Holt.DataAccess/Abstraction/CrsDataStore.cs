using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using Holt.DataAccess;
using Holt.DataAccess.DataModel;
using Holt.DataAccess.DBModel;


namespace Holt.DataAccess
{
    /// <summary>
    /// This class encapsulates the CRS data source, which is SQL Server.  If a method returns an object it will be an implementation class.
    /// </summary>
    public class CrsDataStore : DataStore
    {
        public CrsDataStore() : base(new SqlServerDataSource()) { }
        public CrsDataStore(IDataSource dataSource) : base(dataSource) { }



        #region --- Customer methods


        /// <summary>
        /// Add the given customer
        /// </summary>
        /// <param name="newCrsCustomer"></param>
        public override void CreateCustomer(Customer newCustomer)
        {
            var customer = newCustomer.ToCustomerImpl();
            dataSource.CreateCustomer(customer);
        }

        /// <summary>
        /// Get a list of all customers
        /// </summary>
        /// <returns></returns>
        public override List<Customer> GetCustomers()
        {
            var crsCustomers = dataSource.GetCustomers();

            var customers = new List<Customer>();
            foreach (var customer in crsCustomers)
            {
                customers.Add(customer.ToCustomer());
            }

            return customers;
        }


        /// <summary>
        /// Given an id get the customer information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Customer GetCustomer(int id)
        {
            var crsCustomer = dataSource.GetCustomer(id);
            if (crsCustomer == null)
            {
                return new Customer().Empty();
            }

            // illustrate building customer object from more than one source
            var customer = crsCustomer.ToCustomer();
            customer.IsGoldCustomer = IsGoldCustomer(id);
            return customer;

            //return crsCustomer.ToCustomer();
         
        }


        /// <summary>
        /// Get the current max customer id.  this can be used for generating the next one.
        /// </summary>
        /// <returns></returns>
        public override int GetNewCustomerId()
        {
            return dataSource.CreateNewCustomerId();
        }


        /// <summary>
        /// Delete a customer by ID
        /// </summary>
        /// <param name="id"></param>
        public override void DeleteCustomer(int id)
        {
            dataSource.DeleteCustomer(id);
        }


        #endregion --- Customer methods




        #region --- Job methods


        /// <summary>
        /// Add a job class
        /// </summary>
        /// <param name="job"></param>
        public override void CreateJob(Job job)
        {
            dataSource.CreateJob(job.ToJobImpl());
        }


        /// <summary>
        /// Create a full job complete with customer and component info
        /// </summary>
        /// <param name="job"></param>
        public override void CreateCustomerJob(Job job)
        {
            string location = "n/a";
            try
            {
                location = "creating customer/job objects";
                var customer = job.ToCustomerImpl();
                var newJobImpl = job.ToJobImpl(customer);

                location = "creating components";
                var components = job.Components;
                var componentList = new List<ComponentImpl>();
                foreach (var component in components)
                {
                    var componentImpl = component.ToComponentImpl();
                    componentList.Add(componentImpl);
                }

                location = "adding components";
                newJobImpl.Components = componentList;

                location = "saving job";                                 
                dataSource.CreateJob(newJobImpl);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Failed to create customer job at location [{0}].  Error = [{1}]", location, ex.Message));
            }
        }




        /// <summary>
        /// Change the state of the job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="newState"></param>
        public override void SetState(Job job, int newState)
        {
            job.SetState(newState);
        }


        /// <summary>
        /// Get job information based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Job GetJob(int id)
        {
            var crsJob = dataSource.GetJob(id);
            if (crsJob == null)
            {
                return new Job().Empty();
            }

            var crsComponents = dataSource.GetComponentsByJob(id);
            return crsJob.ToJob(crsComponents.ToComponents(), CreateCustomer(crsJob.Customer));
        }


        /// <summary>
        /// get a list of all jobs
        /// </summary>
        /// <returns></returns>
        public override List<Job> GetJobs()
        {
            var crsJobs = dataSource.GetJobs();

            var jobs = new List<Job>();
            foreach (var crsJob in crsJobs)
            {
                var crsCustomer = crsJob.Customer;
                var crsComponents = dataSource.GetComponentsByJob(crsJob.JobId);
                jobs.Add(crsJob.ToJob(crsComponents.ToComponents(), CreateCustomer(crsCustomer)));
            }

            return jobs;
        }


        /// <summary>
        /// Get all jobs for the given customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override List<Job> GetJobsByCustomer(int id)
        {
            var jobs = new List<Job>();
            var crsJobs = dataSource.GetJobsByCustomer(id);

            foreach (var crsJob in crsJobs)
            {
                var crsCustomer = crsJob.Customer;
                var crsComponents = dataSource.GetComponentsByJob(crsJob.JobId);
                jobs.Add(crsJob.ToJob(crsComponents.ToComponents(), CreateCustomer(crsCustomer)));
            }

            return jobs;
        }


        #endregion --- Job methods


        #region --- Component methods

        /// <summary>
        /// Get all components for the given job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override List<Component> GetComponentsByJob(int id)
        {
            return dataSource.GetComponentsByJob(id).ToComponents();
        }


        /// <summary>
        /// Get all defined components
        /// </summary>
        /// <returns></returns>
        public override List<Component> GetComponents()
        {
            return dataSource.GetComponents().ToComponents();
        }


        /// <summary>
        /// Get a component by id
        /// </summary>
        /// <returns></returns>
        public override Component GetComponent(int id)
        {
            var component = dataSource.GetComponent(id);
            if (component == null)
            {
                return new Component().Empty();
            }

            return component.ToComponent();
        }


        #endregion --- Component methods


        #region --- Groups/User methods

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        public override void CreateUser(User user)
        {
            var userImpl = user.ToUserImpl();
            dataSource.CreateUser(userImpl);
        }


        /// <summary>
        /// get a list of all users
        /// </summary>
        /// <returns></returns>
        public override List<User> GetUsers()
        {
            var userImpls = dataSource.GetUsers();
            return userImpls.ToUsers();
        }


        /// <summary>
        /// Get the given user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override User GetUser(string userName)
        {
            var userImpl = dataSource.GetUser(userName);
            return userImpl.ToUser();
        }


        /// <summary>
        /// Get a list of groups
        /// </summary>
        /// <returns></returns>
        public override List<Group> GetGroups()
        {
            var groupImpls = dataSource.GetGroups();
            return groupImpls.ToGroups();
        }


        /// <summary>
        /// Get the given group
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override Group GetGroup(string name)
        {
            var groupImpl = dataSource.GetGroup(name);
            return groupImpl.ToGroup();
        }

        /// <summary>
        /// Create a group
        /// </summary>
        /// <param name="user"></param>
        public override void CreateGroup(Group group)
        {
            var groupImpl = group.ToGroupImpl();
            dataSource.CreateGroup(groupImpl);
        }



        /// <summary>
        /// Get all the users in a given group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public override List<User> GetUsersByGroup(int groupId)
        {
            var userImpls = dataSource.GetUsersByGroup(groupId);
            return userImpls.ToUsers();
        }


        /// <summary>
        /// Get a list of all users in the given notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public override List<User> GetUsersInNotificationList(string notificationName)
        {
            var userImpls = dataSource.GetUsersInNotificationList(notificationName);
            return userImpls.ToUsers();
        }


        /// <summary>
        /// Get all groups in the given notification
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public override List<Group> GetGroupsInNotificationList(string notificationName)
        {
            var groupImpls = dataSource.GetGroupsInNotificationList(notificationName);
            return groupImpls.ToGroups();
        }




        #endregion --- Groups/User methods


        #region --- Notification methods


        /// <summary>
        /// Return a populated notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public override NotificationList GetNotificationList(string notificationName)
        {
            var notificationListImpl = dataSource.GetNotificationList(notificationName);
            return notificationListImpl.ToNotificationList();
        }


        /// <summary>
        /// get all notification lists
        /// </summary>
        /// <returns></returns>
        public override List<NotificationList> GetNotificationLists()
        {
            var notificationList = dataSource.GetNotificationLists();
            return notificationList.ToNotificationLists();
        }


        #endregion --- Notification methods





       /// <summary>
        /// Get a full customer job with customer and component info based on an integer id (as opposed to string)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Job GetCustomerJob(int id)
        {
            string location = "n/a";
            try
            {

                location = "getting crs objects";
                var crsJob = dataSource.GetJob(id);

                var crsCustomer = dataSource.GetCustomer(crsJob.Customer.CustomerId);

                var crsComponents = dataSource.GetComponentsByJob(crsJob.JobId);

                location = "creating components";
                var components = new List<Component>();
                foreach (var crsComponent in crsComponents)
                {
                    components.Add(crsComponent.ToComponent());
                }

                location = "creating job";
                var job = new Job()
                {
                    Id = crsJob.JobId,
                    CustomerId = crsCustomer.CustomerId,
                    Description = crsJob.Description,
                    State = crsJob.State,
                    Customer = crsCustomer.ToCustomer(),
                    Components = components
                };

                return job;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Failed to get customer job at location [{0}].  Error = [{1}]", location, ex.Message));
            }
        }


        #region --- private

        /// <summary>
        /// dummy method to illustrate how abstract customer class can get data from more than one source
        /// </summary>
        private bool IsGoldCustomer(int id)
        {
            return true;
        }

        #endregion

    }
}
