using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer
{
    public class Repo : IRepo
    {
        private DonorContext context;
        public Repo(DonorContext context)
        {
            this.context = context;
        }

        public int AddDonor(Donor don)
        {
            don.id = new Guid();
            context.Add(don);
            return context.SaveChanges();
        }


        // ------------------------------------------------------

        public List<Donor> spGetDonors(string bloodGroup) 
        {
            return context.donor.FromSql($"spGetDonors {bloodGroup}").ToList();
        }

        // ------------------------------------------------------
        public Donor? GetDonor(string email)
        {
            try
            {
                return context.donor.Where(d => d.email == email).First();
            }
            catch 
            { 
                return null; 
            }
        }

        public IEnumerable<Donor> GetDonorsByCity(string city) 
        {
            try
            {
                return context.donor.Where(d => d.city == city).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> getSuitableBloodGroups(string bloodGroup)
        {
            List<string> bloodGroups = new List<string>();

            switch (bloodGroup)
            {
                case "A+":
                    bloodGroups.AddRange(new HashSet<string>() { "O+", "A-" , "A+" , "O-" });
                    return bloodGroups;
                case "B+":
                    bloodGroups.AddRange(new HashSet<string>() { "O+", "B-" , "B+" , "O-" });
                    return bloodGroups;
                case "AB+":
                    bloodGroups.AddRange(new HashSet<string>() { "O+", "AB-", "AB+", "A-", "A+" , "B-", "B+" , "O-" });
                    return bloodGroups;
                case "O+":
                    bloodGroups.AddRange(new HashSet<string>() { "O+", "O-" });
                    return bloodGroups;
                case "A-":
                    bloodGroups.AddRange(new HashSet<string>() { "A-", "O-" });
                    return bloodGroups;
                case "B-":
                    bloodGroups.AddRange(new HashSet<string>() { "O-", "B-" });
                    return bloodGroups;
                case "AB-":
                    bloodGroups.AddRange(new HashSet<string>() { "O-" , "A-", "B-" , "AB-" });
                    return bloodGroups;
                case "O-":
                    bloodGroups.AddRange(new HashSet<string>() { "O-" });
                    return bloodGroups;
                default: 
                    return bloodGroups;
            }
            
        }

        public IEnumerable<Donor> GetDonorsByBloodGroup(string bloodGroup)
        {
            List<string> bloodGroupList = getSuitableBloodGroups(bloodGroup);
            List<Donor> donors = new List<Donor>();
            try
            {
                foreach(string bg in bloodGroupList)
                {
                    donors.AddRange(context.donor.Where(d => d.bloodGroup == bg).ToList());
                }
                return donors;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Donor> GetDonorsByCityAndBG(string city, string bloodGroup)
        {
            List<string> bloodGroupList = getSuitableBloodGroups(bloodGroup);
            List<Donor> donors = new List<Donor>();
            try
            {
                foreach (string bg in bloodGroupList)
                {
                    donors.AddRange(context.donor.Where(d => d.bloodGroup == bg).ToList());
                }

                return donors.Where(d => d.city == city).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Donor? UpdateDonor(Donor don)
        {
            Donor donor = GetDonor(don.email);
            if(donor is not null)
            {
                donor.name = don.name;
                donor.age = don.age;
                donor.phnumber = don.phnumber;
                donor.city = don.city;
                donor.bloodGroup = don.bloodGroup;
                donor.weight = don.weight;
                donor.height = don.height;
                donor.profession= don.profession;
                context.Update(donor);
                context.SaveChanges();
                return donor;
            }
            else
            {
                return null;
            }
        }

        public Donor? DeleteDonor(string email)
        {
            Donor donor = GetDonor(email);
            if(donor is not null)
            {
                context.Remove(donor);
                context.SaveChanges();
                return donor;
            }
            else
            {
                return null;
            }
        }


    }
}