﻿using FD.SampleData.Data.Generators;
using FD.SampleData.Models.HumanResources;
using FD.SampleData.Models.Individual;
using FD.SampleData.Models.Production;
using FD.SampleData.Models.Purchasing;
using FD.SampleData.Models.Sales;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FD.SampleData.Contexts
{
    public class SalesDbContext : BaseDbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual DbSet<JobCandidate> JobCandidates { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CountryRegion> CountryRegions { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonPhone> PersonPhones { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Illustration> Illustrations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductModelIllustration> ProductModelIllustrations { get; set; }
        public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotoes { get; set; }
        public virtual DbSet<ProductProductPhoto> ProductProductPhotoes { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<ScrapReason> ScrapReasons { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
        public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchives { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderRouting> WorkOrderRoutings { get; set; }
        public virtual DbSet<ProductVendor> ProductVendors { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        public virtual DbSet<SalesReason> SalesReasons { get; set; }
        public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }
        public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<ProductDocument> ProductDocuments { get; set; }

        public SalesDbContext()
        {
        }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .HasMany<EmailAddress>()
                .WithOne(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany<PersonPhone>()
                .WithOne(p => p.Person);

            modelBuilder.Entity<Password>()
                .HasOne<Person>()
                .WithOne(p => p.Password)
                .HasForeignKey<Password>(p => p.BusinessEntityID);
        }

        public override async Task Seed(int? seedSize)
        {
            // seed addresses and people
            List<Address> addresses = await IndividualGenerator.GenerateAddresses();
            await AddRangeAsync(addresses);
            await SaveChangesAsync();

            List<Person> people = await IndividualGenerator.GenerateIndividuals();
            await AddRangeAsync(people);
            await SaveChangesAsync();
        }

    }
}