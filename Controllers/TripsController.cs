using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using arbimed.Data;
using arbimed.Models;

namespace arbimed.Controllers
{
    public class TripsController : Controller
    {
        private readonly ArbimedContext _context;

        public TripsController(ArbimedContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trip.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripId,VehicleId,DriverId,DistanceInKilometers,FuelConsumptionInLitres")] Trip trip)
        {
            if (ModelState.IsValid)
            {

                Boolean isValid = true;
                var driver = _context.Driver.Where(a => a.DriverId == trip.DriverId).FirstOrDefault();
                if (driver != null)
                {

                    driver.UsedVehicleCount += 1;
                    
                }
                else
                {
                    ModelState.AddModelError("DriverID", "DriverID not found!");
                    isValid = false;
                }

                var vehicle = _context.Vehicle.Where(a => a.VehicleID == trip.VehicleId).FirstOrDefault();
                if (vehicle != null)
                {

                    vehicle.LastTripDateTime = DateTime.Now;
                    vehicle.AverageFuelConsumptionInLitres = (vehicle.TotalTravelDistanceInKilometers * vehicle.AverageFuelConsumptionInLitres + trip.FuelConsumptionInLitres) / (vehicle.TotalTravelDistanceInKilometers + trip.DistanceInKilometers);
                    vehicle.TotalTravelDistanceInKilometers += trip.DistanceInKilometers;
                    
                }
                else
                {
                    ModelState.AddModelError("VehicleID", "VehicleID not found!");
                    isValid = false;
                }

                if (isValid)
                {
                    _context.Update(driver);
                    _context.Update(vehicle);
                    _context.Add(trip);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripId,VehicleId,DriverId,DistanceInKilometers,FuelConsumptionInLitres")] Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Boolean isValid = true;
                try
                {
                    var oldtrip = _context.Trip.Where(a => a.TripId == trip.TripId).AsNoTracking<Trip>().FirstOrDefault();

                    if (oldtrip.DriverId != trip.DriverId)
                    {
                        var olddriver = _context.Driver.Where(a => a.DriverId == oldtrip.DriverId).FirstOrDefault();
                        var newdriver = _context.Driver.Where(a => a.DriverId == trip.DriverId).FirstOrDefault();

                        if (newdriver != null)
                        {
                            if (olddriver != null)
                            {

                                olddriver.UsedVehicleCount -= 1;
                                _context.Update(olddriver);
                                
                            }
                            newdriver.UsedVehicleCount += 1;
                            _context.Update(newdriver);
                           
                        }
                        else
                        {

                            ModelState.AddModelError("DriverID", "DriverID not found!");
                            isValid = false;

                        }

                    }

                    if (oldtrip.VehicleId != trip.VehicleId)
                    {
                        var oldvehicle = _context.Vehicle.Where(a => a.VehicleID == oldtrip.VehicleId).FirstOrDefault();
                        var newvehicle = _context.Vehicle.Where(a => a.VehicleID == trip.VehicleId).FirstOrDefault();


                        if (newvehicle != null)
                        {
                            if (oldvehicle != null)
                            {
                                var km = oldvehicle.TotalTravelDistanceInKilometers - oldtrip.DistanceInKilometers;
                                if (km == 0)
                                {
                                    oldvehicle.AverageFuelConsumptionInLitres = Decimal.Zero;
                                    oldvehicle.TotalTravelDistanceInKilometers = Decimal.Zero;

                                }
                                else
                                {
                                    oldvehicle.AverageFuelConsumptionInLitres = (oldvehicle.TotalTravelDistanceInKilometers * oldvehicle.AverageFuelConsumptionInLitres - oldtrip.FuelConsumptionInLitres) / (oldvehicle.TotalTravelDistanceInKilometers - oldtrip.DistanceInKilometers);
                                    oldvehicle.TotalTravelDistanceInKilometers -= trip.DistanceInKilometers;

                                }
                                _context.Update(oldvehicle);
                                
                            }
                            newvehicle.LastTripDateTime = DateTime.Now;
                            newvehicle.AverageFuelConsumptionInLitres = (newvehicle.TotalTravelDistanceInKilometers * newvehicle.AverageFuelConsumptionInLitres + trip.FuelConsumptionInLitres) / (newvehicle.TotalTravelDistanceInKilometers + trip.DistanceInKilometers);
                            newvehicle.TotalTravelDistanceInKilometers += trip.DistanceInKilometers;
                            _context.Update(newvehicle);
                           
                        }
                        else
                        {
                            ModelState.AddModelError("VehicleID", "VehicleID not found!");
                            isValid = false;
                        }

                    }
                    var vehicle = _context.Vehicle.Where(a => a.VehicleID == trip.VehicleId).FirstOrDefault();
                    if (oldtrip.FuelConsumptionInLitres != trip.FuelConsumptionInLitres)
                    {

                        var lt = vehicle.AverageFuelConsumptionInLitres * vehicle.TotalTravelDistanceInKilometers;
                        lt -= (oldtrip.FuelConsumptionInLitres - trip.FuelConsumptionInLitres);
                        vehicle.AverageFuelConsumptionInLitres = lt / vehicle.TotalTravelDistanceInKilometers;
                        _context.Update(vehicle);
                       
                    }
                    if (oldtrip.DistanceInKilometers != trip.DistanceInKilometers)
                    {
                       
                        var lt = vehicle.AverageFuelConsumptionInLitres * vehicle.TotalTravelDistanceInKilometers;
                        var km = oldtrip.DistanceInKilometers;
                        km -= (oldtrip.DistanceInKilometers - trip.DistanceInKilometers);
                        if (km == 0)
                        {
                            vehicle.AverageFuelConsumptionInLitres = Decimal.Zero;
                            _context.Update(vehicle);
                            
                        }
                        else
                        {
                            vehicle.AverageFuelConsumptionInLitres = lt / km;
                            vehicle.TotalTravelDistanceInKilometers = km;
                            _context.Update(vehicle);
                            
                        }

                    }
                    if (isValid)
                    {
                        _context.Update(trip);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(trip);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trip.FindAsync(id);

            var driver = _context.Driver.Where(a => a.DriverId == trip.DriverId).FirstOrDefault();
            if (driver != null)
            {

                driver.UsedVehicleCount -= 1;
                _context.Update(driver);
            }
            var vehicle = _context.Vehicle.Where(a => a.VehicleID == trip.VehicleId).FirstOrDefault();
            if (vehicle != null)
            {
                var km = vehicle.TotalTravelDistanceInKilometers - trip.DistanceInKilometers;
                if (km == 0)
                {
                    vehicle.AverageFuelConsumptionInLitres = Decimal.Zero;
                    vehicle.TotalTravelDistanceInKilometers = Decimal.Zero;

                }
                else
                {
                    vehicle.AverageFuelConsumptionInLitres = (vehicle.TotalTravelDistanceInKilometers * vehicle.AverageFuelConsumptionInLitres - trip.FuelConsumptionInLitres) / (vehicle.TotalTravelDistanceInKilometers - trip.DistanceInKilometers);
                    vehicle.TotalTravelDistanceInKilometers -= trip.DistanceInKilometers;

                }
                _context.Update(vehicle);

            }

            _context.Trip.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.TripId == id);
        }
    }
}
