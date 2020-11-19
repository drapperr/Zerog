namespace Zerog.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Zerog.Data.Common.Models;
    using Zerog.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Motherboard> Motherboards { get; set; }

        public DbSet<MotherboardManufacturer> MotherboardManufacturers { get; set; }

        public DbSet<Chipset> Chipsets { get; set; }

        public DbSet<SupportedProcessor> SupportedProcessors { get; set; }

        public DbSet<MemoryType> MemoryTypes { get; set; }

        public DbSet<SoundCard> SoundCards { get; set; }

        public DbSet<LanCard> LanCards { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<FormFactor> FormFactors { get; set; }

        public DbSet<Interface> Interfaces { get; set; }

        //public DbSet<Processor> Processors { get; set; }

        //public DbSet<VideoCard> VideoCards { get; set; }

        //public DbSet<Case> Cases { get; set; }

        //public DbSet<Ram> Rams { get; set; }

        //public DbSet<Storage> Storages { get; set; }

        //public DbSet<PowerSupply> PowerSupplies { get; set; }

        //public DbSet<CpuCooler> CpuCoolers { get; set; }

        //public DbSet<RamManufacturer> RamManufacturers { get; set; }

        //public DbSet<Timing> Timings { get; set; }

        //public DbSet<ProcessorManufacturer> ProcessorManufacturers { get; set; }

        //public DbSet<Socket> Sockets { get; set; }

        //public DbSet<VideoCardManufacturer> VideoCardManufacturers { get; set; }

        //public DbSet<GrphicProcessor> GrphicProcessors { get; set; }

        //public DbSet<ChipsetManufacturer> ChipsetManufacturers { get; set; }

        //public DbSet<VideoCardMemoryType> VideoCardMemoryTypes { get; set; }

        //public DbSet<VideoCardSlot> VideoCardSlots { get; set; }

        //public DbSet<DirectXVersion> DirectXVersions { get; set; }

        //public DbSet<VExtra> Extras { get; set; }

        //public DbSet<CaseManufacturer> CaseManufacturers { get; set; }

        //public DbSet<CaseType> CaseTypes { get; set; }

        //public DbSet<Slot> Slots { get; set; }

        //public DbSet<Fan> Fans { get; set; }

        //public DbSet<Radiator> Radiators { get; set; }

        //public DbSet<CExtra> CExtras { get; set; }

        //public DbSet<Device> Devices { get; set; }

        //public DbSet<StorageManufacturer> StorageManufacturers { get; set; }

        //public DbSet<StorageFormFactor> StorageFormFactors { get; set; }

        //public DbSet<StorgeType> StorgeTypes { get; set; }

        //public DbSet<Connector> Connectors { get; set; }

        //public DbSet<PFC> PFCs { get; set; }

        //public DbSet<PowerSupplyCooler> PowerSupplyCoolers { get; set; }

        //public DbSet<PowerSupplyManufacturer> PowerSupplyManufacturers { get; set; }

        //public DbSet<CpuCoolerManufacturer> CpuCoolerManufacturers { get; set; }

        //public DbSet<CpuCoolerType> CpuCoolerTypes { get; set; }

        //public DbSet<CpuCoolerConnector> CpuCoolerConnectors { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
