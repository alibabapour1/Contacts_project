using System.Data.Entity;

public class ContactsDbContext : DbContext
{
    public DbSet<Contacts> Contacts { get; set; }
}
