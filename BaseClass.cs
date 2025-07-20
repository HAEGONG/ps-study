namespace ps_study
{
    public abstract class BaseClass
    {
        protected abstract string SetTitle();
        protected abstract bool ShouldRun();
        protected abstract void Example();

        public void Run()
        {
            if (!ShouldRun())
                return;
            
            Console.WriteLine($"--- Example of: {SetTitle()} ---");
            Example();
        }
    }
}
