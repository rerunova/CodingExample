using CodingExample.ReleaseRetention.DataModel;

namespace CodingExample.ReleaseRetention
{
    /// <summary>
    /// Provies a set of methods (if extended, otherwise singular) to return a number of recently deployed releases
    /// </summary>
    public class RetentionRuleManager
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private DataContext DataContext;

        /// <summary>
        /// Initalises a new instance of RetentionRuleManager
        /// </summary>
        /// <param name="dataContext">Data containg projects, environments, releases and deployments</param>
        public RetentionRuleManager(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        /// <summary>
        /// Returns a specified number of releases from deployments for all projects
        /// </summary>
        /// <param name="numberOfReleases">Number of Releases to retain</param>
        /// <returns>A List containing the specified number of Releases. If there is less Releases than specified, it will return as many as exists</returns>
        public List<Release> ReleasesToRetain(int numberOfReleases)
        {
            var retainedReleases = new List<Release>();
            var retainedReleaseEnvironmentDictionary = new Dictionary<string, string>();

            var groupedDeployments = DataContext.Deployments.GroupBy(deployment => deployment.ProjectEnvironmentId);

            foreach (var deploymentGroup in groupedDeployments)
            {
                var orderedDeployments = deploymentGroup.OrderByDescending(deployment => deployment.DeployedAt);

                var deploymentReleasesToRetain = GetReleasesToRetain(numberOfReleases, orderedDeployments);

                // Cache current environment for easy access
                var currentEnvironment = orderedDeployments.First().Environment.Id;

                foreach (var release in deploymentReleasesToRetain)
                {
                    // Determine if a release has already been added, to prevent duplicate release results or logs
                    if (!retainedReleaseEnvironmentDictionary.ContainsKey(release.Id))
                    {
                        retainedReleases.Add(release);
                        retainedReleaseEnvironmentDictionary.Add(release.Id, currentEnvironment);
                    }
                    else
                    {
                        retainedReleaseEnvironmentDictionary[release.Id] += $" and {currentEnvironment}";
                    }
                }
            }

            foreach (var retainedEnvironmentRelease in retainedReleaseEnvironmentDictionary)
            {
                Logger.Info($"'{retainedEnvironmentRelease.Key}' kept because it was most recently deployed to '{retainedEnvironmentRelease.Value}'");
            }

            return retainedReleases;
        }
        private IEnumerable<Release> GetReleasesToRetain(int numberToRetain, IEnumerable<Deployment> deployments)
        {
            var releases = new HashSet<Release>();
            var releasedRetained = 0;

            foreach (var deployment in deployments)
            {
                if (releasedRetained >= numberToRetain)
                {
                    break;
                }

                if (!releases.Contains(deployment.Release))
                {
                    releasedRetained++;
                    releases.Add(deployment.Release);
                }
            }

            return releases;            
        }
    }
}