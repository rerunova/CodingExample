namespace CodingExample.ReleaseRetention.DataModel
{
    public class Deployment
    {
        public Deployment(string id, Release release, Environment environment, DateTime deployedAt)
        {
            Id = id;
            Release = release;
            Environment = environment;
            DeployedAt = deployedAt;
        }

        public string Id { get; private set; }
        public Release Release { get; private set; }
        public Environment Environment { get; private set; }
        public DateTime DeployedAt { get; private set; }
        public string ProjectEnvironmentId 
        { 
            get
            {
                return $"{Release.Project.Id} {Environment.Id}";                
            } 
        }
    }
}
