using DoctorVisit.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // key
            HasKey(u => u.Id);
            // properties
            Property(u => u.Username).IsRequired();
            Property(u => u.Email).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.PasswordSalt).IsRequired();
            Property(u => u.InsertedOn).IsRequired();
            Property(u => u.IsActive).IsRequired();
            // table
            ToTable("User");
        }
    }
}
