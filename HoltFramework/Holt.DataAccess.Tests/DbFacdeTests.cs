using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Holt.DataAccess.Tests
{
    [TestClass]
    public class DbFacdeTests
    {
        [TestMethod]
        public void TestInitialize()
        {
            var db = new DbFacadeDataSource();
            Assert.IsTrue(db.CustomerImplList.Count == 3);
            Assert.IsTrue(db.JobImplList.Count == 3);
        }

        #region --- Customer Tests

        [TestMethod]
        public void TestGetCustomerId()
        {
            var db = new DbFacadeDataSource();
            int expected = 1;
            int actual = db.GetCustomerId("Customer1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCustomers()
        {
            var db = new DbFacadeDataSource();
            var customers = db.GetCustomers();
            Assert.IsTrue(customers.Count == 3);

            string expected = "Customer2";
            string actual = customers[1].Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCustomerById()
        {
            var db = new DbFacadeDataSource();
            var customer = db.GetCustomer(1);

            string expected = "Customer1";
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCustomerByName()
        {
            var db = new DbFacadeDataSource();
            var customer = db.GetCustomer("Customer1");

            string expected = "Customer1";
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }


        #endregion --- Customer Tests



        #region --- Job Tests


        [TestMethod]
        public void TestGetJob()
        {
            var db = new DbFacadeDataSource();
            var job = db.GetJob(1);
            Assert.IsTrue(job.Description == "Job 1");
        }


        [TestMethod]
        public void TestGetJobs()
        {
            var db = new DbFacadeDataSource();
            var jobs = db.GetJobs();
            Assert.IsTrue(jobs.Count == 3);

            Assert.IsTrue(jobs[0].Description == "Job 1");
            Assert.IsTrue(jobs[1].Description == "Job 2");
            Assert.IsTrue(jobs[2].Description == "Job 3");
        }



        [TestMethod]
        public void TestGetJobsByCustomer()
        {
            var db = new DbFacadeDataSource();
            var jobs = db.GetJobsByCustomer(1);
            Assert.IsTrue(jobs.Count == 2);

            Assert.IsTrue(jobs[0].Description == "Job 1");
            Assert.IsTrue(jobs[1].Description == "Job 2");
        }


        #endregion --- Job Tests



        #region --- Component Tests

        [TestMethod]
        public void TestGetComponentsByJob()
        {
            var db = new DbFacadeDataSource();
            var component = db.GetComponentsByJob(1);
            Assert.IsTrue(component.Count == 1);
            Assert.IsTrue(component[0].Description == "Component 1");
        }


        [TestMethod]
        public void TestGetComponents()
        {
            var db = new DbFacadeDataSource();
            var component = db.GetComponents();
            Assert.IsTrue(component.Count == 3);
            Assert.IsTrue(component[0].Description == "Component 1");
        }


        [TestMethod]
        public void TestGetComponent()
        {
            var db = new DbFacadeDataSource();
            var component = db.GetComponent(1);
            Assert.IsTrue(component.Description == "Component 1");
        }


        #endregion --- Component Tests


        #region --- User/Group Tests

        [TestMethod]
        public void TestGetGroups()
        {
            var db = new DbFacadeDataSource();
            var groups = db.GetGroups();
            Assert.IsTrue(groups.Count == 1);
            Assert.IsTrue(groups[0].Name == "Group 1"); 
        }


        [TestMethod]
        public void TestGetGroupByName()
        {
            var db = new DbFacadeDataSource();
            var group = db.GetGroup("Group 1");
            Assert.IsTrue(group.Name == "Group 1");
        }


        [TestMethod]
        public void TestGetUsers()
        {
            var db = new DbFacadeDataSource();
            var users = db.GetUsers();

            Assert.IsTrue(users.Count == 2);
            Assert.IsTrue(users[0].UserName == "User1");
        }


        [TestMethod]
        public void TestGetUserByName()
        {
            var db = new DbFacadeDataSource();
            var user = db.GetUser("User1");
            Assert.IsTrue(user.FullName == "User 1");
        }

        [TestMethod]
        public void TestGetUsersByGroup()
        {
            var db = new DbFacadeDataSource();
            var users = db.GetUsersByGroup(1);

            Assert.IsTrue(users.Count == 1);
        }

        [TestMethod]
        public void TestGetUsersByGroupNull()
        {
            var db = new DbFacadeDataSource();
            var users = db.GetUsersByGroup(2);

            Assert.IsNull(users);
        }


        [TestMethod]
        public void TestGetUsersInNotificationList()
        {
            var db = new DbFacadeDataSource();
            var users = db.GetUsersInNotificationList("JobArrived");

            Assert.IsTrue(users.Count == 1);
            Assert.IsTrue(users[0].FullName == "User 1");
        }


        [TestMethod]
        public void TestGetGroupsInNotificationList()
        {
            var db = new DbFacadeDataSource();
            var groups = db.GetGroupsInNotificationList("JobTerminated");

            Assert.IsTrue(groups.Count == 1);
            Assert.IsTrue(groups[0].Name == "Group 1");
        }

        [TestMethod]
        public void TestGetNotificationList()
        {
            var db = new DbFacadeDataSource();
            var list = db.GetNotificationList("JobArrived");

            Assert.IsTrue(list.Type == 1);
        }


        [TestMethod]
        public void TestGetNotificationLists()
        {
            var db = new DbFacadeDataSource();
            var lists = db.GetNotificationLists();

            Assert.IsTrue(lists.Count == 2);
            Assert.IsTrue(lists[0].NotificationName == "JobArrived");
        }


        #endregion --- User/Group Tests
    }
}
