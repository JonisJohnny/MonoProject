using System;
using System.Collections.Generic;


namespace Project.Model.Common
{
    
    public class PagedCollection<T>:IPagedCollection<T>
    {

        public int TotalRecords { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
    

}
