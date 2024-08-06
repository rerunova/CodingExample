using CodingExample.ReleaseRetention.DataModel;

namespace CodingExample.ReleaseRetention.Tests
{
    public static class DummyTestData
    {
        public static Project Project1 = new Project("Project-1", "Random Quotes");
        public static Project Project2 = new Project("Project-2", "Pet Shop");

        public static DataModel.Environment Environment1 = new DataModel.Environment("Environment-1", "Staging");
        public static DataModel.Environment Environment2 = new DataModel.Environment("Environment-2", "Production");

        public static Release Release1 = new Release("Release-1", Project1, "1.0.0", new System.DateTime(2000, 1, 1, 9, 0, 0));
        public static Release Release2 = new Release("Release-2", Project1, "1.0.1", new System.DateTime(2000, 1, 2, 9, 0, 0));
        public static Release Release8 = new Release("Release-8", Project1, "2.0.0", new System.DateTime(2000, 1, 2, 9, 0, 0));

        public static Release Release3 = new Release("Release-3", Project1, null, new System.DateTime(2000, 1, 2, 9, 0, 0));
        public static Release Release4 = new Release("Release-4", Project2, "1.0.1", new System.DateTime(2000, 1, 2, 9, 0, 0));
        public static Release Release5 = new Release("Release-5", Project2, "1.0.1-cli", new System.DateTime(2000, 1, 2, 9, 0, 0));
        public static Release Release6 = new Release("Release-6", Project2, "1.0.2", new System.DateTime(2000, 1, 2, 9, 0, 0));
        public static Release Release7 = new Release("Release-7", Project2, "1.0.3", new System.DateTime(2000, 1, 2, 9, 0, 0));
        

        public static Deployment Deployment1 = new Deployment("Deployment-1", Release1, Environment1, new System.DateTime(2000, 1, 1, 10, 0, 0));
        public static Deployment Deployment2 = new Deployment("Deployment-2", Release2, Environment1, new System.DateTime(2000, 1, 1, 10, 0, 0));
        public static Deployment Deployment3 = new Deployment("Deployment-3", Release2, Environment2, new System.DateTime(2000, 1, 1, 11, 0, 0));
        public static Deployment Deployment4 = new Deployment("Deployment-4", Release4, Environment1, new System.DateTime(2000, 1, 1, 12, 0, 0));

        public static Deployment Deployment5 = new Deployment("Deployment-5", Release8, Environment1, new System.DateTime(2000, 1, 1, 10, 2, 0));
        public static Deployment Deployment6 = new Deployment("Deployment-6", Release2, Environment1, new System.DateTime(2000, 1, 1, 10, 3, 0));
        public static Deployment Deployment7 = new Deployment("Deployment-7", Release8, Environment1, new System.DateTime(2000, 1, 1, 10, 4, 0));
        public static Deployment Deployment8 = new Deployment("Deployment-8", Release2, Environment1, new System.DateTime(2000, 1, 1, 10, 5, 0));
    }
}