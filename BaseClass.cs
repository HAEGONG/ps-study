namespace ps_study
{
    public abstract class BaseClass
    {
        protected abstract string SetTitle();
        protected abstract bool ShouldRun();

        public virtual void Run()
        {
            if (!ShouldRun())
                return;
            
            Console.WriteLine($"--- Example of: {SetTitle()} ---");
        }
    }
}
