namespace CodingExample.ReleaseRetention.DataModel
{
    public class Project
    {
        public Project(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
    }
}
