﻿using FreelApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Infraestructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
               .HasMany(u => u.Skills)
               .WithOne()
               .HasForeignKey(p => p.idSkill)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
