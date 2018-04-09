using System;
using Topshelf;
using Topshelf.HostConfigurators;

namespace ChromaExpVanilla
{
    internal class Program
    {
        private static void Main()
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<Executor>(s =>
                {
                    s.ConstructUsing(name => new Executor());
                    s.WhenStarted(tc => tc.Execute());
                    s.WhenStopped( tc => tc.Execute());
                } );
                x.StartAutomatically();
                x.SetInstanceName("RazKey");
                x.RunAsLocalService();
            } );
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}