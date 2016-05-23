using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Holt.DataAccess.DataModel;


namespace CrsDalTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestInitialJobState()
        {
            var j = new Job();

            bool expected = true;
            bool actual = j.IsReady();
            Assert.AreEqual(expected, actual);

            expected = false;
            actual = j.IsComplete();
            Assert.AreEqual(expected, actual);

            j.SetStateComplete();
            expected = true;
            actual = j.IsComplete();
            Assert.AreEqual(expected, actual);

            j.SetState(JobState.READY_STATE);
            expected = true;
            actual = j.IsReady();
            Assert.AreEqual(expected, actual);

            j.SetState(JobState.COMPLETE_STATE);
            expected = true;
            actual = j.IsComplete();
            Assert.AreEqual(expected, actual);

            j.SetStateReady();
            expected = true;
            actual = j.IsReady();
            Assert.AreEqual(expected, actual);

        }
    }
}
