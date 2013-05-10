using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace ServiceDataLib
{
    public class Conn
    {
        public static string BuildConnectionString()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string serverName = "bib5adtui9.database.windows.net,1433";
            string databaseName = "New_Users";
            string userId = "wqxhouse@bib5adtui9";
            string password = "Ww6789012345";
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
            new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.UserID = userId;
            sqlBuilder.Password = password;
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.Encrypt = true;
            sqlBuilder.ConnectTimeout = 30;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
            new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/WineDataModel.csdl|
                                       res://*/WineDataModel.ssdl|
                                       res://*/WineDataModel.msl";


            return entityBuilder.ToString();
        }
    }
}
