using Kinta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kinta.DAL
{
    //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions
    public class CategoryDAL
    {
        public static bool Insert(CategoryModel categoryObj)
        {
            var conStr = @"Data Source=DESKTOP-763MQFN\SQLEXPRESS;Initial Catalog=Kinta;Integrated Security=True";

            var query = "INSERT INTO dbo.category (id, code,name,description,parent_code,child_code,path,tag,created_time,updated_time)"
                                          + "VALUES(@id,@code,@name,@description,@parent_code,@child_code,@path,@tag,@created_time,@updated_time)";

            categoryObj.Id = Guid.NewGuid().ToString();
            categoryObj.CreatedTime = DateTime.Now;
            categoryObj.UpdatedTime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(conStr))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", categoryObj.Id);
                command.Parameters.AddWithValue("@code", categoryObj.Code);
                command.Parameters.AddWithValue("@name", categoryObj.Name);
                command.Parameters.AddWithValue("@description", categoryObj.Description);
                command.Parameters.AddWithValue("@parent_code", categoryObj.ParentCode);
                command.Parameters.AddWithValue("@child_code", categoryObj.ChildCode);
                command.Parameters.AddWithValue("@path", categoryObj.Path);
                command.Parameters.AddWithValue("@tag", categoryObj.Tag);
                command.Parameters.AddWithValue("@created_time", categoryObj.CreatedTime);
                command.Parameters.AddWithValue("@updated_time", categoryObj.UpdatedTime);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("" + ex);
                }
            }

            return true;
        }
    }
}
