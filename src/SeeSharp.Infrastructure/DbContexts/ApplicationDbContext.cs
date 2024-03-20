﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeeSharp.Application.Common.Interfaces;
using SeeSharp.Domain.Models;

namespace SeeSharp.Infrastructure.DbContexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
	public ApplicationDbContext()
	{

	}
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<BlogPost> BlogPosts { get; set; }
	public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SeeSharpBlog_Auth;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
	}
}

