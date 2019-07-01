using Project.Repository;

namespace Project.WebAPI
{
    public class DIModule : IDIModule
    {
        IInitilizeMap _initilizeMap;
       
        public DIModule(IInitilizeMap initilizeMap)
        {
            _initilizeMap = initilizeMap;
        }
        public void ProcessData()
        {
            _initilizeMap.Load();
        }
    }
}
