namespace ChromaExpVanila
{
    internal class Program
    {
        // please use the TrayApp for activation
        private static void Main()
        {
            var executor = new Executor();
            executor.Execute();
        }
    }
}