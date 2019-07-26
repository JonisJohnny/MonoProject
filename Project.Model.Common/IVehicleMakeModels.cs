using System;

namespace Project.Model.Common
{
    public interface IVehicleMakeModels
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

    }

}
