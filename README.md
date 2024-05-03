Welcome to MedPro 🧑‍⚕️

Use of SqlServer Express on Linux docker:
 docker pull mcr.microsoft.com/mssql/server:2019-latest

And create a container
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=DoctorPro123456" -p 1433:1433 --name sql_doctor -d mcr.microsoft.com/mssql/server:2019-latest

Apply the migrations
 dotnet ef database update -s ../MedPro.Api/MedPro.Api.csproj 