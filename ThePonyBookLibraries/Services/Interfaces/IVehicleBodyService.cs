using System.Collections.Generic;
using ThePonyBookLibraries.Repositories.EF;

namespace ThePonyBookLibraries.Services.Interfaces
{
    public interface IVehicleBodyService
    {
        /// <summary>
        /// Get all vehicle bodies
        /// </summary>
        /// <returns>IEnumerable of vehicle body objects</returns>
        IEnumerable<VehicleBody> GetVehicleBodies();

        /// <summary>
        /// Create vehcile body
        /// </summary>
        /// <param name="name">Vehicle body name</param>
        /// <returns>Create vehicle body</returns>
        bool CreateVehicleBody(string name);

        /// <summary>
        /// Update vehicle body
        /// </summary>
        /// <param name="id">Vehicle body id</param>
        /// <param name="name">Vehicle body name</param>
        /// <returns>Bool vehicle body record updated </returns>
        bool UpdateVehicleBody(int id, string name);

        /// <summary>
        /// Delete vehicle body
        /// </summary>
        /// <param name="id">Vehicle body id</param>
        /// <returns>Delete vehicle body</returns>
        bool DeleteVehicleBody(int id);
    }
}