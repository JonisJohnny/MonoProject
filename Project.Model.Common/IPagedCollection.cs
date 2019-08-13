using System;
using System.Collections.Generic;

namespace Project.Model.Common
{
    public interface IPagedCollection<T>
    {

        int TotalRecords { get; set; }
        IEnumerable<T> Items { get; set; }
    }

}
