namespace CodingExample.ReleaseRetention.DataModel
{
    public class DataContext
    {
        public DataContext()
        {
            Releases = new List<Release>();
            Deployments = new List<Deployment>();
            Projects = new List<Project>();
            Environments = new List<Environment>();
        }

        public List<Release> Releases { get; set; }

        public List<Deployment> Deployments { get; set; }

        public List<Project> Projects { get; set; }

        public List<Environment> Environments { get; set; }
    }
}
