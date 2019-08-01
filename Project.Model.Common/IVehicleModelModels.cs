using System;

namespace Project.Model.Common
{
    public interface IVehicleModelModels
    {
        Guid Id { get; set; }
        Guid Makeid { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
