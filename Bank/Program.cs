using Bank.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

// Get ConnectionString configuration
ConnectionString csConfig = new();
builder.Configuration.GetSection("ConnectionString").Bind(csConfig);

// Construct ConnectionString
SqlConnectionStringBuilder csBuilder = new();
csBuilder["Server"] = csConfig.Server;
csBuilder["Database"] = csConfig.Database;
csBuilder["User"] = csConfig.User;
csBuilder["Password"] = csConfig.Password;
csBuilder.TrustServerCertificate = true;

// AddDbContext
builder.Services.AddDbContext<BankDbContext>(opt =>
    opt.UseSqlServer(csBuilder.ConnectionString)
);

// Add Services Here



// Build the Host
using IHost host = builder.Build();
