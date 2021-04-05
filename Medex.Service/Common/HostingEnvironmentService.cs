using Medex.Abstractions.Common;

namespace Medex.Service.Common
{
    public class HostingEnvironmentService : IHostingEnvironmentService
    {
        public bool IsProduction { get; private set; }

        public bool GetEnvironment() => IsProduction;

        public void SetEnvironment(bool isProduction)
        {
            this.IsProduction = isProduction;
        }
    }
}
