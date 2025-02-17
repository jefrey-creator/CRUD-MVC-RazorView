# ProjectManagementSystem

1. Update connection string at Web.config file
2. Click Tools > NuGet Package Manage > Package Manager Console
3. type the command:
    add-migration "Init"
    update-databse
4. run the application


 <!-- Connection String -->
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Server=BRYCE\SQLEXPRESS;Database=ProjectDb;Integrated Security=True;" providerName="System.Data.SqlClient" />
  </connectionStrings>
