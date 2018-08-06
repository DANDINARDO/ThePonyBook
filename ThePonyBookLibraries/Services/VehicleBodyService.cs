using System;
using System.Collections.Generic;
using System.Linq;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;

namespace ThePonyBookLibraries.Services
{
    public class VehicleBodyService : IVehicleBodyService
    {
        private readonly IDbContext _dbContext;

        #region Constructors 

        public VehicleBodyService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<VehicleBody> GetVehicleBodies()
        {
            return RetrieveVehicleBodies();
        }

        public bool CreateVehicleBody(string name)
        {
            return ProcessCreateVehicleBody(name);
        }

        public bool UpdateVehicleBody(int id, string name)
        {
            return ProcessUpdateVehicleBody(id, name);
        }

        public bool DeleteVehicleBody(int id)
        {
            return ProcessDeleteVehicleBody(id);
        }

        #endregion

        #region Private Methods

        private IEnumerable<VehicleBody> RetrieveVehicleBodies()
        {
            try
            {
                var vehicleBodies = _dbContext.VehicleBodies;
                return vehicleBodies;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessCreateVehicleBody(string name)
        {
            try
            {
                var vehicleBody = new VehicleBody()
                {
                    Name = name
                };
                _dbContext.VehicleBodies.Add(vehicleBody);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessUpdateVehicleBody(int id, string name)
        {
            try
            {
                var vehicleBody = _dbContext.VehicleBodies.FirstOrDefault(x => x.Id == id);
                if (vehicleBody == null)
                    return false;

                vehicleBody.Name = name;

                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private bool ProcessDeleteVehicleBody(int id)
        {
            try
            {
                var vehicleBody = _dbContext.VehicleBodies.FirstOrDefault(x => x.Id == id);
                if (vehicleBody == null)
                    return false;
                _dbContext.VehicleBodies.Remove(vehicleBody);
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
