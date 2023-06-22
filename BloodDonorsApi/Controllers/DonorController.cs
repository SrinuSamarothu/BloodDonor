using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;

namespace BloodDonorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private IRepo repo;

        public DonorController(IRepo repo)
        {
            this.repo = repo;
        }


        [HttpGet("get/all")]

        public IActionResult getAll([FromQuery]string bg)
        {
            List<Donor> donor = repo.spGetDonors(bg);
            if (donor is not null)
            {
                return Ok(donor);
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpGet("get/{email}")]

        public IActionResult get([FromRoute]string email)
        {
            Donor? donor = repo.GetDonor(email);
            if(donor is not null)
            {
                return Ok(donor);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getbyCity/{city}")]

        public IActionResult getByCity([FromRoute]string city)
        {
            var donors = repo.GetDonorsByCity(city);
            if(donors is not null)
            {
                return Ok(donors);
            }
            else
            {
                return BadRequest("No donors are available");
            }
        }

        [HttpGet("getbyBloodGroup/")]

        public IActionResult getByBloodGroup([FromQuery] string bloodgroup)
        {
            var donors = repo.GetDonorsByBloodGroup(bloodgroup);
            if (donors is not null)
            {
                return Ok(donors);
            }
            else
            {
                return BadRequest("No donors are available");
            }
        }

        [HttpGet("getbyBloodGroup/{city}")]

        public IActionResult getByCityAndBG([FromRoute]string city, [FromQuery] string bloodgroup)
        {
            var donors = repo.GetDonorsByCityAndBG(city, bloodgroup);
            if (donors is not null)
            {
                return Ok(donors);
            }
            else
            {
                return BadRequest("No donors are available");
            }
        }


        [HttpPost("add")]

        public IActionResult add([FromBody]Donor donor)
        {
            int result = repo.AddDonor(donor);
            if(result > 0)
            {
                return Created("Add", donor);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]

        public IActionResult update([FromBody]Donor donor)
        {
            Donor? don = repo.UpdateDonor(donor);
            if(don is not null)
            {
                return Ok(donor);
            }
            else
            {
                return BadRequest("Unable to update");
            }
        }

        [HttpDelete("delete/{email}")]
        public IActionResult delete([FromRoute]string email)
        {
            Donor? donor = repo.DeleteDonor(email);
            if (donor is not null)
            {
                return Ok(donor);
            }
            else
            {
                return BadRequest("unable to delete");
            }
        }
    }
}
