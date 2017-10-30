using System;
using Microsoft.EntityFrameworkCore;
namespace RazorDemo.Models
{
public class RazorDemoContext : DbContext
{
    public RazorDemoContext(DbContextOptions<RazorDemoContext> options)
            : base(options)
    {
    }

    public DbSet<Student> Student { get; set; }
}
}
