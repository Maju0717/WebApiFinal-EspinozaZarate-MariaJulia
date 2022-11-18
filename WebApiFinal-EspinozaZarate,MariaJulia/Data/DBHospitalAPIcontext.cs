using Microsoft.EntityFrameworkCore;
using WebApiFinal_EspinozaZarate_MariaJulia.Models;

namespace WebApiFinal_EspinozaZarate_MariaJulia.Data
{
    public class DBHospitalAPIcontext:DbContext
    {
        public DBHospitalAPIcontext(DbContextOptions<DBHospitalAPIcontext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet <Hospital> Hospitals { get; set; }

    }
}
