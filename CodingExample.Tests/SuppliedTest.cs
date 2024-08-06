using CodingExample.ReleaseRetention;
using CodingExample.ReleaseRetention.DataModel;
using CodingExample.ReleaseRetention.Tests;

namespace CodingExample.Tests
{
    [TestClass]
    public class SuppliedTest
    {
        [TestMethod]
        public void SingleReleaseSingleKeep()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);

            var retentionManager = new RetentionRuleManager(testDataContext);

            var releases = retentionManager.ReleasesToRetain(1);

            Assert.AreEqual(1, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
        }

        [TestMethod]
        public void DoubleReleaseSingleKeep()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(1);

            Assert.AreEqual(1, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
        }

        [TestMethod]
        public void DoubleReleaseDoubleKeep()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment3);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(1);

            Assert.AreEqual(2, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
            Assert.AreEqual(DummyTestData.Release2, releases[1]);
        }

        [TestMethod]
        public void TestZeroRelease()
        {
            var testDataContext = new DataContext();

            var retentionManager = new RetentionRuleManager(testDataContext);

            var releases = retentionManager.ReleasesToRetain(1);

            Assert.AreEqual(0, releases.Count);            
        }

        [TestMethod]
        public void TestZeroReleaseToRetain()
        {
            var testDataContext = new DataContext();

            var retentionManager = new RetentionRuleManager(testDataContext);
            testDataContext.Deployments.Add(DummyTestData.Deployment1);

            var releases = retentionManager.ReleasesToRetain(0);

            Assert.AreEqual(0, releases.Count);
        }

        [TestMethod]
        public void TestReleaseWithLessThanRetain()
        {
            var testDataContext = new DataContext();

            var retentionManager = new RetentionRuleManager(testDataContext);
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);

            var releases = retentionManager.ReleasesToRetain(1);

            Assert.AreEqual(1, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
        }

        [TestMethod]
        public void TestReleaseWithRetain()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(2);

            Assert.AreEqual(2, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
            Assert.AreEqual(DummyTestData.Release2, releases[1]);
        }

        [TestMethod]
        public void TestReleaseWithGreaterThanRetain()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(3);

            Assert.AreEqual(2, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
            Assert.AreEqual(DummyTestData.Release2, releases[1]);
        }

        [TestMethod]
        public void TestReleasesWithRollbacks()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);
            testDataContext.Deployments.Add(DummyTestData.Deployment5);
            testDataContext.Deployments.Add(DummyTestData.Deployment6);
            testDataContext.Deployments.Add(DummyTestData.Deployment7);
            testDataContext.Deployments.Add(DummyTestData.Deployment8);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(3);

            Assert.AreEqual(3, releases.Count);

            Assert.AreEqual(DummyTestData.Release2, releases[0]);
            Assert.AreEqual(DummyTestData.Release8, releases[1]);
            Assert.AreEqual(DummyTestData.Release1, releases[2]);
        }

        [TestMethod]
        public void TestMultiEnvironmentReleases()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);
            testDataContext.Deployments.Add(DummyTestData.Deployment3);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(1);

            Assert.AreEqual(2, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
            Assert.AreEqual(DummyTestData.Release2, releases[1]);
        }

        [TestMethod]
        public void TestMultiProjectEnvironmentReleases()
        {
            var testDataContext = new DataContext();
            testDataContext.Deployments.Add(DummyTestData.Deployment1);
            testDataContext.Deployments.Add(DummyTestData.Deployment2);
            testDataContext.Deployments.Add(DummyTestData.Deployment3);
            testDataContext.Deployments.Add(DummyTestData.Deployment4);

            var retention = new RetentionRuleManager(testDataContext);

            var releases = retention.ReleasesToRetain(1);

            Assert.AreEqual(3, releases.Count);
            Assert.AreEqual(DummyTestData.Release1, releases[0]);
            Assert.AreEqual(DummyTestData.Release2, releases[1]);
            Assert.AreEqual(DummyTestData.Release4, releases[2]);            
        }
    }
}