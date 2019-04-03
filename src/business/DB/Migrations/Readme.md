dotnet ef migrations add init -p ..\Business\Business.csproj -o ..\Business\DB\Migrations -c ImageOrganizerContex
dotnet ef migrations script -p ..\Business\Business.csproj -o ..\Business\DB\Migrations\migrations.sql -c ImageOrganizerContex -i
