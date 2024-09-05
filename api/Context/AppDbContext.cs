using Microsoft.EntityFrameworkCore;

namespace api.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options);
