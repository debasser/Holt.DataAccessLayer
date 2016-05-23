using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Holt.DataAccess;
using Holt.DataAccess.DBModel;
using Holt.DataAccess.DataModel;
using System.Linq;

using Holt.DataAccess.Tests.TestClasses;


namespace CrsDalTests
{
    [TestClass]
    public class AbstractionTests
    {


        [TestMethod]
        public void TestGetCustomers()
        {
            var ds = GetDataStore();

            var customers = ds.GetCustomers();
            int expected = 1;
            int actual = customers[0].Id;
            Assert.AreEqual(expected, actual, "1");

            string expectedName = "Nine Inch Nails";
            string actualName = customers[0].Name;
            Assert.AreEqual(expectedName, actualName);
        }


        [TestMethod]
        public void TestGetCustomer()
        {
            var ds = GetDataStore();

            var customer = ds.GetCustomer(1);
            int expected = 1;
            int actual = customer.Id;
            Assert.AreEqual(expected, actual, "1");

            string expectedName = "Nine Inch Nails";
            string actualName = customer.Name;
            Assert.AreEqual(expectedName, actualName);

            // test getting back null object customer
            customer = ds.GetCustomer(0);
            Assert.IsTrue(customer.IsEmpty());

            expectedName = "";
            actualName = customer.Name;
            Assert.AreEqual(expectedName, actualName, "2");


        }


        [TestMethod]
        public void TestGetMaxCustomerId()
        {
            var ds = GetDataStore();

            int expected = 66;
            int actual = ds.GetNewCustomerId();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGetJob()
        {
            var ds = GetDataStore();
            var job = ds.GetJob(1);

            string expected = "Brass Tools";
            string actual = job.Customer.Name;
            Assert.AreEqual(expected, actual, "1");

            job = ds.GetJob(0);

            expected = "";
            actual = job.Customer.Name;
            Assert.AreEqual(expected, actual, "2");
            Assert.IsTrue(job.IsEmpty());
        }


        [TestMethod]
        public void TestGetJobs()
        {
            var ds = GetDataStore();

            var jobs = ds.GetJobs();
            Assert.IsTrue(jobs.Count == 1);

            string expected = "Brass Nails";
            string actual = jobs[0].Customer.Name;
            Assert.AreEqual(expected, actual, "2");
        }


        [TestMethod]
        public void TestGetJobsByCustomer()
        {
            var ds = GetDataStore();
            //var ds = GetSqlServerDataStore();

            /*
            var db = new CrsDalDb();
            var components = (from c in db.ComponentImpls
                                  where c.JobId == 1
                                  select c).ToList();

            foreach (var component in components)
            {
                int compId = component.ComponentId;
                string name = component.Description;
                int jobId = component.JobId;
            }
            */

            
            var jobs = ds.GetJobsByCustomer(1);
            Assert.IsTrue(jobs.Count == 1);

            string expected = "Nine Inch Nails";
            string actual = jobs[0].Customer.Name;
            Assert.AreEqual(expected, actual, "2");
        }

        [TestMethod]
        public void TestGetComponentsByJob()
        {
            var ds = GetDataStore();
            
            var components = ds.GetComponentsByJob(1);
            Assert.IsTrue(components.Count == 1);

            string expected = "Component1";
            string actual = components[0].Description;
            Assert.AreEqual(expected, actual, "2");
        }


        [TestMethod]
        public void TestGetComponents()
        {
            var ds = GetDataStore();

            var components = ds.GetComponents();
            Assert.IsTrue(components.Count == 1);

            string expected = "Component1";
            string actual = components[0].Description;
            Assert.AreEqual(expected, actual, "2");

        }

        [TestMethod]
        public void TestGetComponent()
        {
            var ds = GetDataStore();
            var component = ds.GetComponent(1);
            Assert.IsNotNull(component);

            string expected = "Component1";
            string actual = component.Description;
            Assert.AreEqual(expected, actual, "2");

            component = ds.GetComponent(0);
            Assert.IsNotNull(component);

            expected = "";
            actual = component.Description;
            Assert.AreEqual(expected, actual, "2");
            Assert.IsTrue(component.IsEmpty());
        }


        [TestMethod]
        public void TestCreateCustomerJob()
        {
            var ds = GetDataStore();
            var job = CreateJob();

            ds.CreateCustomerJob(job);

            int expected = 2;
            int actual = job.Components.Count;
            Assert.AreEqual(expected, actual, "1");

            expected = 1;
            actual = job.Customer.Id;
            Assert.AreEqual(expected, actual, "2");

        }


        [TestMethod]
        public void TestCustomerImplEmpty()
        {
            var customer = new CustomerImpl().Empty();
            Assert.IsTrue(customer.IsEmpty());
        }


        [TestMethod]
        public void TestJobImplEmpty()
        {
            var job = new JobImpl().Empty();
            Assert.IsTrue(job.IsEmpty());
        }


        [TestMethod]
        public void TestComponentImplEmpty()
        {
            var component = new Component().Empty();
            Assert.IsTrue(component.IsEmpty());
        }

        /*
        [TestMethod]
        [Ignore]
        public void TestGetUsersByGroup()
        {
            var dataStore = GetSqlServerDataStore();
            var users = dataStore.GetUsersByGroup(2);
            Assert.IsTrue(users.Count == 3);
        }


        [TestMethod]
        [Ignore]
        public void TestGetUsersInNotificationList()
        {
            var dataStore = GetSqlServerDataStore();
            var users = dataStore.GetUsersInNotificationList("JobArrived");
            Assert.IsTrue(users.Count == 2);
        }


        [TestMethod]
        [Ignore]
        public void TestGetGroupsInNotificationList()
        {
            var dataStore = GetSqlServerDataStore();
            var groups = dataStore.GetGroupsInNotificationList("JobArrived");
            Assert.IsTrue(groups.Count == 2);
        }


        [TestMethod]
        [Ignore]
        public void TestGetUsersInGroup()
        {
            var dataStore = GetSqlServerDataStore();
            var groups = dataStore.GetGroupsInNotificationList("JobArrived");

            var users = dataStore.GetUsersByGroup(groups[0].GroupId);
            Assert.IsTrue(users.Count == 2);
        }


        [TestMethod]
        [Ignore]
        public void TestCreateUser()
        {
            var dataStore = GetSqlServerDataStore();

            var user = CreateUser("ctb");
            dataStore.CreateUser(user);
        }


        [TestMethod]
        [Ignore]
        public void TestCreateGroup()
        {
            var dataStore = GetSqlServerDataStore();

            var group = CreateGroup();
            dataStore.CreateGroup(group);
        }

        [TestMethod]
        [Ignore]
        public void TestGetNotificationList()
        {
            var datastore = GetSqlServerDataStore();

            var notificationList = datastore.GetNotificationList("JobArrived");
            Assert.IsNotNull(notificationList);

            int count = notificationList.Users.Count(u => u.UserName == "ctb");
            Assert.IsTrue(count == 1);
        }
        */

        #region --- private

        /// <summary>
        /// return a data store using the dummy datasource
        /// </summary>
        /// <returns></returns>
        private CrsDataStore GetDataStore()
        {
            var dataSource = new DummyDataSource();
            return new CrsDataStore(dataSource);
        }

        /// <summary>
        /// return a data store using the sql server datasource
        /// </summary>
        /// <returns></returns>
        private CrsDataStore GetSqlServerDataStore()
        {
            var dataSource = new SqlServerDataSource();
            return new CrsDataStore(dataSource);
        }


        /// <summary>
        /// Create a dummy job
        /// </summary>
        /// <returns></returns>
        private Job CreateJob()
        {
            var customer = new Customer() { Id = 1, Address = "456 foobar", Name = "Helen of Troy" };
            var newJob = new Job() { Id = 1, Customer = customer, CustomerId = customer.Id, Description = "bogus job", State = JobState.READY_STATE};

            var components= new List<Component>();
            components.Add(new Component(){ Id = 1, Description = "phony component", JobId = newJob.Id });
            components.Add(new Component() { Id = 2, Description = "phony component 2", JobId = newJob.Id });

            newJob.Components = components;
            return newJob;
        }

        /// <summary>
        /// Create a user impl
        /// </summary>
        /// <returns></returns>
        private User CreateUser(string userName)
        {

            var user = new User()
            {
                UserName = userName,
                FullName = "xx",
                Status = 1,
                EmailAddress = "foobar.com"
            };


            return user;
        }


        private List<User> CreateUserList()
        {
            var userList = new List<User>()
            {
                CreateUser("ctb1"),
                CreateUser("ctb2")
            };

            return userList;
        }
      


        /// <summary>
        /// Create a group object
        /// </summary>
        /// <returns></returns>
        private Group CreateGroup()
        {
            return new Group(CreateUserList())
            {
                GroupId = 100,
                Name = "new group"
            };
        }


        // test class for mocking up data
        class DummyDataSource : TestDataSource
        {

            #region --- Customers



            public override int CreateNewCustomerId()
            {
                return 66;
            }
            public override int GetCustomerId(string name) 
            {
                return 1;
            }

            public override List<CustomerImpl> GetCustomers()
            {
                var customers = new List<CustomerImpl>();
                customers.Add(new CustomerImpl() { CustomerId = 1, Name = "Nine Inch Nails", Jobs = null });
                return customers;
            }

            public override CustomerImpl GetCustomer(int customerId)
            {
                if (customerId == 0)
                {
                    // simulate no customer found
                    return null;
                }

                return new CustomerImpl() { CustomerId = Convert.ToInt32(customerId), Name = "Nine Inch Nails", Jobs = null };
            }



            #endregion --- Customers



            #region --- Jobs


            public override List<JobImpl> GetJobsByCustomer(int id)
            {
                var crsCustomer = new CustomerImpl() { CustomerId = 11, Name = "Nine Inch Nails", Jobs = null };

                var jobs = new List<JobImpl>();
                jobs.Add(new JobImpl() { JobId = 1, CustomerId = 1, Description = "Job1", Customer = crsCustomer, State = 1});
                return jobs;
            }


            public override int CreateNewJobId()
            {
                return 1;
            }


            public override List<JobImpl> GetJobs()
            {
                var customer = new CustomerImpl() { CustomerId = 1, Name = "Brass Nails           ", Address = "123           ", Jobs = null };
                var jobs = new List<JobImpl>();
                jobs.Add(new JobImpl() { JobId = 1, Description = "Job1      ", CustomerId = 1, Customer = customer });
                return jobs;
            }


            public override JobImpl GetJob(int jobId)
            {
                if (jobId == 0)
                {
                    // simulate null object return
                    return null;
                }

                var customer = new CustomerImpl() { CustomerId = 1, Name = "Brass Tools", Address = "123 Fairway", Jobs = null };
                return new JobImpl() { JobId = 1, CustomerId = 1, Description = "job1", Customer = customer, State = 1 };
            }

            public override void CreateJob(JobImpl job)
            {
                return;
            }


            #endregion --- Jobs



            #region --- Components


            public override List<ComponentImpl> GetComponentsByJob(int id)
            {
                var components = new List<ComponentImpl>();
                components.Add(new ComponentImpl() { ComponentId = 1, JobId = 1, Description = "Component1" });
                return components;
            }

            public override List<ComponentImpl> GetComponents()
            {
                var components = new List<ComponentImpl>();
                components.Add(new ComponentImpl() { ComponentId = 1, Description = "Component1", JobId = 1 });
                return components;
            }

            public override ComponentImpl GetComponent(int componentId)
            {
                if (componentId == 0)
                {
                    // simluate null object pattern
                    return null;
                }

                return new ComponentImpl() { ComponentId = 1, Description = "Component1", JobId = 1 };
            }



            #endregion --- Components


            #region --- Users/Groups
            #endregion --- Users/Groups
        }

        #endregion --- private
    }
}
