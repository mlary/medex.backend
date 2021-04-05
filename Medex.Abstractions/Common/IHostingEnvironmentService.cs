namespace Medex.Abstractions.Common
{
    public interface IHostingEnvironmentService
    {
        void SetEnvironment(bool isProduction);

        bool GetEnvironment();
    }
}
