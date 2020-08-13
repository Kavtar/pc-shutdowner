using static ShutDowner.Jobs;

namespace ShutDowner
{
    internal class Service
    {
        public bool Start()
        {
            ShutDown();
            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
