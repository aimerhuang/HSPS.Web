color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd HSPS.Web.Api

dotnet publish -o ..\HSPS.Web.Api\bin\Debug\net8.0\

md ..\.PublishFiles

xcopy ..\HSPS.Web.Api\bin\Debug\net8.0\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd