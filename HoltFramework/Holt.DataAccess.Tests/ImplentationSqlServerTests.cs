using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Holt.DataAccess;
using Holt.DataAccess.DataModel;
using Holt.DataAccess.DBModel;
using System.Linq;


namespace CrsDalTests
{
    /*
    [TestClass]
    public class ImplentationSqlServerTests
    {
        static SqlServerDataSource dataSource;

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            dataSource = new SqlServerDataSource();
        }


        [TestMethod]
        [Ignore]
        public void TestGetNewCustomerId()
        {
            int actual = dataSource.CreateNewCustomerId();
            Assert.IsTrue(actual >= 0);
        }

        [TestMethod]
        [Ignore]
        public void TestCreateCustomer()
        {
            var customer = new CustomerImpl() {Name = "Cooper Boards", Address = "123", Jobs = null };
            dataSource.CreateCustomer(customer);

            int expected = 0;
            int actual = dataSource.GetCustomerId("Test Customer");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void TestGetJobsByCustomer()
        {
            var jobList = dataSource.GetJobsByCustomer(1);
            Assert.IsTrue(jobList.Count == 2);
        }

        [TestMethod]
        [Ignore]
        public void TestGetComponentsByJob()
        {
            var compList = dataSource.GetComponentsByJob(1);
            Assert.IsTrue(compList.Count == 1);
        }

        [TestMethod]
        [Ignore]
        public void TestGetCustomers()
        {
            var custList = dataSource.GetCustomers();
            Assert.IsTrue(custList.Count == 2);

            var customer1 = custList[0];
            string expected = "Nine Inch Nails";
            string actual = customer1.Name.TrimEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void TestGetCustomer()
        {
            var customer = dataSource.GetCustomer(1);
            string expected = "Nine Inch Nails";
            string actual = customer.Name.TrimEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void TestGetJobs()
        {
            var jobList = dataSource.GetJobs();
            Assert.IsTrue(jobList.Count == 3);
        }

        [TestMethod]
        [Ignore]
        public void TestGetJob()
        {
            var job = dataSource.GetJob(1);
            int expected = 1;
            int actual = job.CustomerId;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void TestGetComponents()
        {
            var compList = dataSource.GetComponents();
            Assert.IsTrue(compList.Count == 1);

            string expected = "new component 1";
            string actual = compList[0].Description.TrimEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void TestGetComponent()
        {
            var comp = dataSource.GetComponent(1);
            string expected = "new component 1";
            string actual = comp.Description.TrimEnd();
            Assert.AreEqual(expected, actual);
   
        }

        [TestMethod]
        [Ignore]
        public void TestAddJobWithInformation()
        {
            var job = new JobImpl();
            dataSource.CreateJob(job);
            //Assert.IsTrue(id > 0);
        }


        [TestMethod]
        [Ignore]
        public void TestCreateCustomerJob()
        {
            var jobImpl = CreateJob();
            dataSource.CreateJob(jobImpl);

            var job = dataSource.GetJob(11);
            string expected = "bogus job";
            string actual = job.Description;
            Assert.AreEqual(expected, actual, "1");
        }

        [TestMethod]
        [Ignore]
        public void TestGroups()
        {
            var groups = dataSource.GetGroups();
            Assert.IsTrue(groups.Count == 2);
        }


        [TestMethod]
        [Ignore]
        public void TestUsers()
        {
            var users = dataSource.GetUsers();
            Assert.IsTrue(users.Count == 2);
        }


        [TestMethod]
        [Ignore]
        public void TestGetUsersByGroup()
        {
            var users = dataSource.GetUsersByGroup(2);
        }

        [TestMethod]
        [Ignore]
        public void TestGetGroupsInNotificationList()
        {
            var groups = dataSource.GetGroupsInNotificationList("JobArrived");
            
        }

        [TestMethod]
        [Ignore]
        public void TestGetNotificationList()
        {
            var notificationImpl = dataSource.GetNotificationList("JobArrived");
            var notificationList = notificationImpl.ToNotificationList();

            Assert.IsTrue(notificationList.Users.Count == 2);
            Assert.IsTrue(notificationList.Groups.Count == 2);

            var count = notificationList.Users.Count(u => u.UserName == "ctb");
            Assert.IsTrue(count == 1);
        }


        /// <summary>
        /// Create a full dummy job
        /// </summary>
        /// <returns></returns>
        private JobImpl CreateJob()
        {
            var customer = new CustomerImpl() { CustomerId = 11, Address = "666 Black Way", Name = "Ajax" };
            var newJobImpl = new JobImpl() { JobId = 11, Customer = customer, CustomerId = customer.CustomerId, Description = "bogus job", State = 1};

            var components = new List<ComponentImpl>();
            components.Add(new ComponentImpl() { ComponentId = 11, Description = "phony component", JobId = newJobImpl.JobId });
            components.Add(new ComponentImpl() { ComponentId = 12, Description = "phony component 2", JobId = newJobImpl.JobId });
            newJobImpl.Components = components;

            return newJobImpl;

        }
    }
    */
}