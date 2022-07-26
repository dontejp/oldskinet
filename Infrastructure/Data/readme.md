#restart database

~drop data base

dotnet ef database drop -p Infrastructure -s API

~delete migrations

dotnet ef migrations remove -p Infrastructure -s API

~restart the migrations

dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations