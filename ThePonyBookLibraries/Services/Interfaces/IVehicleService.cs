using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IVehicleService
    {
        /// <summary>
        /// Get all vehicles
        /// </summary>
        /// <returns>IEnumearble of Vehicle Objects</returns>
        IEnumerable<Vehicle> GetVehicles();

        /// <summary>
        /// Create a new vehicle record
        /// </summary>
        /// <param name="name"></param>
        /// <param name"vehicleManufacturerId">Vehicle manufacturer id</param>
        /// <returns></returns>
        bool CreateVehicle(string name, int? vehicleManufacturerId);

        /// <summary>
        /// Update vehicle
        /// </summary>
        /// <param name="id">Vehicle id</param>
        /// <param name="name">Vehicle name</param>
        /// <param name"vehicleManufacturerId">Vehicle manufacturer id</param>
        /// <param name="active">Active (bool)</param>
        /// <returns>Bool record updated</returns>
        bool UpdateVehicle(int id, string name, int? vehicleManufacturerId, bool active);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Vehicle id</param>
        /// <returns>Bool Vehicle Deleted</returns>
        bool DeleteVehicle(int id);
    }
}