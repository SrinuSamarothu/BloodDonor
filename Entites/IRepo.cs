using DataLayer.Entities;

namespace DataLayer
{
    public interface IRepo
    {

        public List<Donor> spGetDonors(string bloodGroup);
        public int AddDonor(Donor don);

        public Donor? GetDonor(string email);

        public Donor? UpdateDonor(Donor don);

        public Donor? DeleteDonor(string email);

        public IEnumerable<Donor> GetDonorsByCity(string city);

        public IEnumerable<Donor> GetDonorsByBloodGroup(string bloodGroup);

        public IEnumerable<Donor> GetDonorsByCityAndBG(string city, string bloodGroup);
    }
}
