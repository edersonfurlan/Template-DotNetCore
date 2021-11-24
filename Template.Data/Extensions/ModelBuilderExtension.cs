using System;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("6aa22e78-eb19-4a8e-998b-ce8bbe1886f0"), Name = "User Default", Email = "userdefault@template.com" }
                );
            return builder;
        }
    }
}
