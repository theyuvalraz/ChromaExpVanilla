using Topshelf;

namespace ChromaExpVanilla
{
    internal class Program
    {
        private static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<Executor>(s =>
                {
                    s.ConstructUsing(name => new Executor());
                    s.WhenStarted(tc => tc.Execute());
                    s.WhenStopped( tc => tc.Execute());
                } );
                x.RunAsLocalSystem();
            } );
        }
    }
}