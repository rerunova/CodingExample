namespace CodingExample.ReleaseRetention.DataModel
{
    public class Release
    {
        public Release(string id, Project project, string? version, DateTime created)
        {
            Id = id;
            Project = project;
            Version = version;
            Created = created;
        }

        public string Id { get; private set; }
        public Project Project { get; private set; }
        public string? Version { get; private set; }
        public DateTime Created { get; private set; }
    }
}
