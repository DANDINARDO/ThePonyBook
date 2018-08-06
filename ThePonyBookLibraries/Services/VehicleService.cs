using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IDbContext _dbContext;

        #region Constructors 

        public VehicleService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Vehicle> GetVehicles()
        {
            return RetrieveVehicles();
        }

        public bool CreateVehicle(string name, int? vehicleManufacturerId)
        {
            return ProcessCreateVehicle(name, vehicleManufacturerId);
        }

        public bool UpdateVehicle(int id, string name, int? vehicleManufacturerId, bool active)
        {
            return ProcessUpdateVehicle(id, name, vehicleManufacturerId, active);
        }

        public bool DeleteVehicle(int id)
        {
            return ProcessDeleteVehicle(id);
        }

        #endregion

        #region Private Methods

        private IEnumerable<Vehicle> RetrieveVehicles()
        {
            try
            {
                var vehicles = _dbContext.Vehicles;
                return vehicles;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessCreateVehicle(string name, int? vehicleManufacturerId)
        {
            try
            {
                var vehicleManufacturer = (vehicleManufacturerId != null) ? _dbContext.VehicleManufacturers.FirstOrDefault(x => x.Id == vehicleManufacturerId) : null;
                var vehicle = new Vehicle()
                {
                    Name = name,
                    Manufacturer = vehicleManufacturer,
                    Active = true
                };
                _dbContext.Vehicles.Add(vehicle);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessUpdateVehicle(int id, string name, int? vehicleManufacturerId, bool active)
        {
            try
            {
                var vehicle = _dbContext.Vehicles.FirstOrDefault(x => x.Id == id);
                if (vehicle == null)
                    return false;

                var vehicleManufacturer = (vehicleManufacturerId != null) ? _dbContext.VehicleManufacturers.FirstOrDefault(x => x.Id == vehicleManufacturerId) : null;

                vehicle.Name = name;
                vehicle.Manufacturer = vehicleManufacturer;
                vehicle.Active = active;

                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessDeleteVehicle(int id)
        {
            try
            {
                var vehicle = _dbContext.Vehicles.FirstOrDefault(x => x.Id == id);
                if (vehicle == null)
                    return false;
                _dbContext.Vehicles.Remove(vehicle);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        #endregion
    }
}
