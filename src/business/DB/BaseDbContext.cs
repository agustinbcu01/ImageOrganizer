using Business.DB.Dbo;
using Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DB
{
    public class BaseDbContext : DbContext
    {
        protected readonly IUserService _userService;
       // protected readonly DbContextOptions options;
        protected readonly ITimeService _timeService;

        public BaseDbContext(DbContextOptions options, IUserService userService, ITimeService timeService) : base(options)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
        }

        public override int SaveChanges()
        {
            // get entries that are being Added or Updated
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            var identityName = _userService.CurrentUser;
            var now = _timeService.CurrentTime;

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as TrackData;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = identityName ?? "unknown";
                    entity.CreatedAt = now;
                }
                else
                {
                    entity.UpdatedBy = identityName ?? "unknown";
                    entity.UpdatedAt = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
