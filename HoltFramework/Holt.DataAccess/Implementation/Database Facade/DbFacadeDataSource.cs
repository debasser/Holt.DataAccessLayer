using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Holt.DataAccess.DBModel;

namespace Holt.DataAccess
{

    /// <summary>
    /// This class uses the IDataSource interface to implement a dummy database that returns only hard-coded values.  It contains the following:
    ///     Three customers (ids 1-3)
    ///     Three jobs (ids 1-3)
    ///     Three components (ids 1-3)
    ///     
    ///     Customer 1 contains jobs 1,2
    ///     Customer 2 contains job 3
    ///     Customer 3 has no jobs
    ///     
    ///     Job 1 has component 1, customer 1
    ///     Job 2 has component 2, customer 1
    ///     Job 3 has component 3, customer 2
    ///     
    ///     Component 1 has job 1
    ///     Component 2 has job 2
    ///     Component 3 has job 3
    ///     
    ///     Two users "user1", "user2"
    ///     One group "Group 1"
    ///         "group1" contains "user1"
    ///     
    ///     Two notification lists
    ///         "JobArrived" contains "user1"
    ///         "JobTerminated" contains "user2" and "group1"
    ///     
    /// </summary>
    public class DbFacadeDataSource : IDataSource
    {
        private const int MAX_CUSTOMERS = 3;
        private const int MAX_JOBS = 3;
        private const int MAX_COMPONENTS = 3;
        private const int MAX_GROUPS = 1;
        private const int MAX_USERS = 2;
        private const int MAX_NOTIFICATION_LISTS = 2;


        // dictionaries for easy access
        private Dictionary<string, NotificationImpl> notificationDictionary = new Dictionary<string, NotificationImpl>();

        // lists of objects
        public List<CustomerImpl> CustomerImplList { get; protected set; }
        public List<JobImpl> JobImplList { get; protected set; }
        public List<ComponentImpl> ComponentImplList { get; protected set; }
        public List<UserImpl> UserImplList { get; protected set; }
        public List<GroupImpl> GroupImplList { get; protected set; }
        public List<NotificationImpl> NotificationImpList {get; protected set;}


        /// <summary>
        /// Construct the dummy data
        /// </summary>
        public DbFacadeDataSource()
        {
            // create the impl lists
            CustomerImplList = CreateCustomerImpls();
            JobImplList = CreateJobImpls(CustomerImplList);
            ComponentImplList = CreateComponentImpls(JobImplList);

            // set the jobs into the customer impls
            JobImplList[0].Customer = CustomerImplList[0];
            JobImplList[1].Customer = CustomerImplList[0];
            JobImplList[2].Customer = CustomerImplList[1];

            // set the jobs into the customer impls
            CustomerImplList[0].Jobs = new List<JobImpl>() {JobImplList[0], JobImplList[1]};
            CustomerImplList[1].Jobs = new List<JobImpl>() {JobImplList[2]};

            // create users and notifications
            UserImplList = CreateUserImpls();
            GroupImplList = CreateGroupImpls(UserImplList);
            NotificationImpList = CreateNotificationImpls(UserImplList, GroupImplList);

            for (int i = 0; i < MAX_NOTIFICATION_LISTS; i++)
            {
                notificationDictionary.Add(NotificationImpList[i].NotificationName, NotificationImpList[i]);
            }
        }


        #region --- Customer Methods


        /// <summary>
        /// Add the given customer
        /// </summary>
        /// <param name="newCrsCustomer"></param>
        public void CreateCustomer(CustomerImpl newCrsCustomer) { }


        /// <summary>
        /// Update the given customer
        /// </summary>
        /// <param name="id"></param>
        public void UpdateCustomer(CustomerImpl customer){}


        /// <summary>
        /// Delete a customer by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCustomer(int customerId){}

        public int CreateNewCustomerId()
        {
            return 0;
        }

            
        /// <summary>
        /// Get the cutomer ID based on name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetCustomerId(string name)
        {
            return CustomerImplList.Where(c => c.Name == name).Select(c => c.CustomerId).SingleOrDefault();
        }


        /// <summary>
        /// Get a list of ComponentImpl
        /// </summary>
        /// <returns></returns>
        public List<CustomerImpl> GetCustomers()
        {
            return CustomerImplList;
        }


        /// <summary>
        /// Get the given customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerImpl GetCustomer(int customerId)
        {
            if (!ValidCustomerId(customerId))
            {
                return null;
            }

            return CustomerImplList.Where(c => c.CustomerId == customerId).Select(c => c).SingleOrDefault();
        }


        /// <summary>
        /// get a customer by name
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public CustomerImpl GetCustomer(string customerName)
        {
            return CustomerImplList.Where(c => c.Name == customerName).Select(c => c).SingleOrDefault();
        }


        #endregion --- Customer Methods




        #region --- Job Methods


        /// <summary>
        /// Add a job by class
        /// </summary>
        /// <param name="job"></param>
        public void CreateJob(JobImpl job){}


        /// <summary>
        /// Update the given job
        /// </summary>
        /// <param name="id"></param>
        public void UpdateJob(JobImpl job){}


        /// <summary>
        /// Delete a job by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJob(int jobId){}


        /// <summary>
        /// Create a new job ID
        /// </summary>
        /// <returns></returns>
        public int CreateNewJobId()
        {
            return 0;
        }

        /// <summary>
        /// Get the given job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public JobImpl GetJob(int jobId)
        {
            if (!ValidJobId(jobId))
            {
                return null;
            }

            return JobImplList[jobId - 1];
        }

        /// <summary>
        /// Get all jobs
        /// </summary>
        /// <returns></returns>
        public List<JobImpl> GetJobs()
        {
            return JobImplList;
        }


        /// <summary>
        /// get all jobs by customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JobImpl> GetJobsByCustomer(int customerId)
        {
              return JobImplList.Where(c => c.CustomerId == customerId).Select(c => c).ToList();
        }



        #endregion --- Job Methods



        #region --- Component Methods


        /// <summary>
        /// Create the given component
        /// </summary>
        /// <param name="component"></param>
        public void CreateComponent(ComponentImpl component) { }


        /// <summary>
        /// Update the given component
        /// </summary>
        /// <param name="component"></param>
        public void UpdateComponent(ComponentImpl component) { }


        /// <summary>
        /// Delete the given component
        /// </summary>
        /// <param name="id"></param>
        public void DeleteComponent(int comopnentId) { }


        /// <summary>
        /// Get all components by job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ComponentImpl> GetComponentsByJob(int jobId)
        {
            return ComponentImplList.Where(c => c.JobId == jobId).Select(c => c).ToList();
        }


        /// <summary>
        /// Get all components
        /// </summary>
        /// <returns></returns>
        public List<ComponentImpl> GetComponents()
        {
            return ComponentImplList;
        }


        /// <summary>
        /// Get the given component
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public ComponentImpl GetComponent(int componentId)
        {
            return ComponentImplList.Where(c => c.ComponentId == componentId).SingleOrDefault();
        }

        #endregion --- Component Methods



        #region --- Users/Groups


        /// <summary>
        /// Get a list of all groups
        /// </summary>
        /// <returns></returns>
        public List<GroupImpl> GetGroups()
        {
            return GroupImplList;
        }

        /// <summary>
        /// Get the given group
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GroupImpl GetGroup(string name)
        {
            return GroupImplList.Where(g => g.Name == name).SingleOrDefault();
        }


        /// <summary>
        /// Create the given user
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(UserImpl user) { }


        /// <summary>
        /// Get a list of all users
        /// </summary>
        /// <returns></returns>
        public List<UserImpl> GetUsers()
        {
            return UserImplList;
        }


        /// <summary>
        /// Get a specifiec user
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserImpl GetUser(string name)
        {
            return UserImplList.Where(u => u.UserName == name).SingleOrDefault();
        }


        /// <summary>
        /// Create the given group
        /// </summary>
        /// <param name="group"></param>
        public void CreateGroup(GroupImpl group) { }


        /// <summary>
        /// Get all users by group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<UserImpl> GetUsersByGroup(int groupId)
        {
            if (!ValidGroupId(groupId))
            {
                return null;
            }

            return GroupImplList[groupId-1].Users.ToList();
        }


        /// <summary>
        /// Get all users in the given notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public List<UserImpl> GetUsersInNotificationList(string notificationName)
        {
            return notificationDictionary[notificationName].Users.ToList();
        }


        /// <summary>
        /// Get a list of all groups in the notification list
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns></returns>
        public List<GroupImpl> GetGroupsInNotificationList(string notificationName)
        {
            return notificationDictionary[notificationName].Groups.ToList();
        }


        /// <summary>
        /// Create a new notification list
        /// </summary>
        /// <param name="list"></param>
        public void CreateNotificationList(NotificationImpl list) { }


        /// <summary>
        /// get the given notification list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NotificationImpl GetNotificationList(string name)
        {
            return NotificationImpList.Where(n => n.NotificationName == name).SingleOrDefault();
        }
            

        /// <summary>
        /// Get a list of all notification lists
        /// </summary>
        /// <returns></returns>
        public List<NotificationImpl> GetNotificationLists()
        {
            return NotificationImpList;
        }


        #endregion --- Users/Groups


        #region --- Private Methods



        /// <summary>
        /// Create the customers (with no jobs)
        /// </summary>
        /// <returns></returns>
        protected List<CustomerImpl> CreateCustomerImpls()
        {
            var customerList = new List<CustomerImpl>()
            {
                new CustomerImpl()
                {
                    CustomerId = 1, 
                    Name = "Customer1", 
                    Address = "1 Fairway Ave.", 
                    Jobs = new List<JobImpl>()
                },

                new CustomerImpl()
                {
                    CustomerId = 2, 
                    Name = "Customer2", 
                    Address = "2 Barney Ave.", 
                    Jobs = new List<JobImpl>()
                },

                new CustomerImpl()
                {
                    CustomerId = 3, 
                    Name = "Customer3", 
                    Address = "3 Fred Dr.", 
                    Jobs = new List<JobImpl>()
                }
            };

            return customerList;
        }


        /// <summary>
        /// Create the jobs (with no components)
        /// </summary>
        /// <returns></returns>
        protected List<JobImpl> CreateJobImpls(List<CustomerImpl> customerImpls)
        {
            var jobList = new List<JobImpl>()
            {
                new JobImpl()
                {
                    JobId = 1, 
                    CustomerId = 1, 
                    Customer = customerImpls[0], 
                    Description = "Job 1", 
                    State = 1, 
                    Components = new List<ComponentImpl>()
                },

                new JobImpl()
                {
                    JobId = 2,
                    CustomerId = 1,
                    Customer = customerImpls[0],
                    Description = "Job 2",
                    State = 1,
                    Components = new List<ComponentImpl>()
                },

                new JobImpl()
                {
                    JobId = 3,
                    CustomerId = 2,
                    Customer = customerImpls[1],
                    Description = "Job 3",
                    State = 1,
                    Components = new List<ComponentImpl>()
                },

            };

            return jobList;
        }


        /// <summary>
        /// Create the component impls
        /// </summary>
        /// <param name="jobImpls"></param>
        /// <returns></returns>
        protected List<ComponentImpl> CreateComponentImpls(List<JobImpl> jobImpls)
        {
            var componentList = new List<ComponentImpl>()
            {
                new ComponentImpl()
                {
                    ComponentId = 1,
                    JobId = 1,
                    Description = "Component 1",
                    Job = jobImpls[0]
                },
                
                new ComponentImpl()
                {
                    ComponentId = 2,
                    JobId = 2,
                    Description = "Component 2",
                    Job = jobImpls[1]
                },

                new ComponentImpl()
                {
                    ComponentId = 2,
                    JobId = 3,
                    Description = "Component 3",
                    Job = jobImpls[2]
                }

            };

            return componentList;

        }


        /// <summary>
        /// Create the user impl list (with no groups or notifications)
        /// </summary>
        /// <returns></returns>
        protected List<UserImpl> CreateUserImpls()
        {
            var list = new List<UserImpl>()
            {
                new UserImpl() {UserName = "User1", FullName = "User 1", EmailAddress = "user1@foo.com", Status = 1},
                new UserImpl() {UserName = "User2", FullName = "User 2", EmailAddress = "user2@foo.com", Status = 1},
            };

            return list;
        }


        /// <summary>
        /// Create the groups with users
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        protected List<GroupImpl> CreateGroupImpls(List<UserImpl> users)
        {
            var list = new List<GroupImpl>()
            {
                new GroupImpl() 
                {
                        GroupId = 1, 
                        Name = "Group 1", 
                        Users = new List<UserImpl>(){ users[0]}, 
                        Notifications = new List<NotificationImpl>()}
            };

            return list;
        }

        /// <summary>
        /// Create the notification impls
        /// </summary>
        /// <param name="users"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        protected List<NotificationImpl> CreateNotificationImpls(List<UserImpl> users, List<GroupImpl> groups)
        {
            var list = new List<NotificationImpl>()
            {
                new NotificationImpl() 
                {
                    NotificationName = "JobArrived",
                    Type = 1,
                    Users = new List<UserImpl>(){users[0]},
                    Groups = new List<GroupImpl>()
                },

                new NotificationImpl() 
                {
                    NotificationName = "JobTerminated",
                    Type = 2,
                    Users = new List<UserImpl>(){users[1]},
                    Groups = new List<GroupImpl>() {groups[0]}
                }
            };

            return list;

        }

        /// <summary>
        /// Validate the job id
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        protected bool ValidJobId(int jobId)
        {
            return jobId > 0 && jobId <= MAX_JOBS;
        }

        /// <summary>
        /// Validate the customer id
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        protected bool ValidCustomerId(int id)
        {
            return id > 0 && id <= MAX_CUSTOMERS;
        }

        /// <summary>
        /// Validate the component id
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        protected bool ValidComponentId(int id)
        {
            return id > 0 && id <= MAX_COMPONENTS;
        }

        /// <summary>
        /// Validate the group id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool ValidGroupId(int id)
        {
            return id > 0 && id <= MAX_GROUPS;
        }

        /// <summary>
        /// Validate the user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool ValidUserId(int id)
        {
            return id > 0 && id <= MAX_USERS;
        }
 
        #endregion --- Private Methods
    }
}


