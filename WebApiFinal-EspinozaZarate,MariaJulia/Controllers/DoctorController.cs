using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiFinal_EspinozaZarate_MariaJulia.Models;
using WebApiFinal_EspinozaZarate_MariaJulia.Data;


namespace WebApiFinal_EspinozaZarate_MariaJulia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DBHospitalAPIcontext _context;

        public DoctorController(DBHospitalAPIcontext context)
        {
            _context = context;
        }

        // GET /api/doctor/listar
        [HttpGet("/api/doctor/listar")]
        public List<Doctor> Get()
        {
            List<Doctor> doctors = (from d in _context.Doctors
                                    select d).ToList();
            return doctors;
        }


        // GET /api/doctor/Doctor_No
        [HttpGet("{Doctor_No}")]
        public ActionResult<Doctor> Get(int Doctor_No)
        {
            Doctor doctor = (from d in _context.Doctors
                             where d.Doctor_No == Doctor_No
                             select d).SingleOrDefault();
            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }


        // GET /api/doctor/especialidad
        [HttpGet("/api/doctor/especialidad/{especialidad}")]
        public ActionResult<List<Doctor>> Get(string especialidad)
        {
            var doctor = (from d in _context.Doctors
                          where d.Especialidad == especialidad
                          select d).ToList();
            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }


        // POST /api/doctor
        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/doctor
        [HttpDelete("{Doctor_No}")]
        public ActionResult Delete(int Doctor_No, [FromBody] Doctor doctor)
        {
            if (Doctor_No != doctor.Doctor_No)
            {
                return BadRequest();
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok();
        }


        // PUT /api/doctor/No
        [HttpPut("{Doctor_No}")]
        public ActionResult Put(int Doctor_No, [FromBody] Doctor doctor)
        {
            if (Doctor_No != doctor.Doctor_No)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }
    }
}
