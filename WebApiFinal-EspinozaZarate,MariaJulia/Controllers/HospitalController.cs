using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinal_EspinozaZarate_MariaJulia.Models;
using WebApiFinal_EspinozaZarate_MariaJulia.Data;
using System.Collections.Generic;
using System.Linq;


namespace WebApiFinal_EspinozaZarate_MariaJulia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly DBHospitalAPIcontext _context;

        public HospitalController(DBHospitalAPIcontext context)
        {
            _context = context;
        }


        // GET /api/hospital
        [HttpGet]
        public dynamic Get()
        {
            var hospitals = (from h in _context.Hospitals
                             select new { h.Nombre, h.Telefono, h.Num_Cama }).ToList();
            if (hospitals == null)
            {
                return NotFound();
            }

            return hospitals;
        }


        // GET /api/hospital/Num_Cama
        [HttpGet("{Num_Cama}")]
        public dynamic Get(int Num_Cama)
        {
            var hospitals = (from h in _context.Hospitals
                             where h.Num_Cama > Num_Cama
                             select new { h.Nombre, h.Telefono, h.Num_Cama }).ToList();
            if (hospitals == null)
            {
                return NotFound();
            }

            return hospitals;
        }


        // POST /api/hospital
        [HttpPost]
        public ActionResult Post([FromBody] Hospital hospital)
        {
            if (hospital == null)
            {
                return BadRequest();
            }

            _context.Hospitals.Add(hospital);
            _context.SaveChanges();

            return Ok();
        }

    }

}

