

namespace Project.WebAPI
{
    public class Application : IApplication
    {
        IDIModule _dIModule;

        public Application(IDIModule dIModule)
        {
            _dIModule = dIModule;
        }
        public void Run()
        {
            _dIModule.ProcessData();
        }
    }
}
