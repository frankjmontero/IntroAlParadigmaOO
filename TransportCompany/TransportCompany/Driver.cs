﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClientAppClassLIbrary
{
    public class Driver : Person, IDriver
    {
        protected string licenseId;
        protected Vehicle vehicle;
        
        public virtual void SetLicense(string licenseId)
        {
            if (this.age < 18)
            {
                Console.WriteLine("You are not old enough to get a driver's license");
            }
            else if (licenseId == "")
            {
                Console.WriteLine("Please enter a valid driver's license ID"); 
            } else this.licenseId = licenseId;
        }
     
        public string GetLicense()
        {
            return (licenseId != "") ? this.licenseId : "No driver's license yet";
        }

        public void SetVehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }
        public Vehicle GetVehicle()
        {
            return this.vehicle;
        }
                
        protected virtual bool CanDriveThisVehicle()
        {
            return (this.vehicle is Car);           
        }

        public virtual void DriveVehicle()
        {
            if (this.CanDriveThisVehicle())
            {
                this.vehicle.StartEngine();
                Thread.Sleep(2000);
                Console.WriteLine("Driving...");
            }
            else Console.WriteLine($"{this.name} doesn't know how to drive this vehicle");            
        }

        public virtual string ObtainDriverLicense()
        {
           this.SetLicense($"{this.GetName()}{this.GetDateOfBirth().Year}{this.GetDateOfBirth().Month}{this.GetDateOfBirth().Day}");

            return this.licenseId;
        }

    }
}