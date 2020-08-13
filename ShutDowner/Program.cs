using System;
using Topshelf;

namespace ShutDowner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(cfg => 
            {
                cfg.Service<Service>(ins => 
                {
                    ins.ConstructUsing(() => new Service());
                    ins.WhenStarted(a => a.Start());
                    ins.WhenStopped(a => a.Stop());
                });

                cfg.SetServiceName("ShutDowner");
                cfg.SetServiceName("Scheduled PC Shutdowner Service");
                cfg.SetDescription("The service shuts down computer automatically at midnight;" +
                                    "Is useful for people who are lazy enough to do it manually.");

                cfg.StartAutomatically();
            });
        }
    }
}
