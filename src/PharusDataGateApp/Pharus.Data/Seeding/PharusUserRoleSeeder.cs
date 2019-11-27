﻿// Utility class for seeding DB data

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Data.Seeding
{
    using System.Linq;

    using Pharus.Domain.Users;

    // _____________________________________________________________
    public class PharusUserRoleSeeder : ISeeder
    {
        private readonly PharusUsersDbContext context;

        public PharusUserRoleSeeder(PharusUsersDbContext context)
        {
            this.context = context;
        }

        // ________________________________________________________
        //
        // Seed new Pharus roles into DB
        // to be added to users
        public void Seed()
        {
            if (!this.context.Roles.Any())
            {
                this.context.Roles.Add(new PharusRole { Name = "Admin", NormalizedName = "ADMIN" });
                this.context.Roles.Add(new PharusRole { Name = "Legal", NormalizedName = "LEGAL" });
                this.context.Roles.Add(new PharusRole { Name = "Risk", NormalizedName = "RISK" });
                this.context.Roles.Add(new PharusRole { Name = "Compliance", NormalizedName = "COMPLIANCE" });
                this.context.Roles.Add(new PharusRole { Name = "Investment", NormalizedName = "INVESTMENT" });
            }

            this.context.SaveChanges();
        }
    }
}
