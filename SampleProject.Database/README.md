# SampleProject.Database
## Scaffold DbContext
Run the script below to scaffold the database models
#### .NET CLI
`dotnet-ef dbcontext scaffold "Data Source=localhost,1433;Initial Catalog={{Database Name}};User ID=sa;Password={{Password}};Encrypt=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -d -c "SampleDbContext" -f`