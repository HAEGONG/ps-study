namespace ps_study
{
    public abstract class BaseClass
    {
        protected abstract string SetTitle();

        protected virtual bool ShouldRun()
        {
            return true;
        }
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
