using System.Data;
using System.Data.SqlClient;
using USOS.Entities;
using USOS.Models;

namespace USOS.DAL
   
{
    public class AdminDAL
    {
        public string cnn = "";

        public AdminDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetConnectionString("DefaultConnection");
        }

        public bool Login(AdminLogin admin)
        {
            string username = null;
            string password = null;
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetByLogin", cn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar);
                    cmd.Parameters["@Username"].Value = admin.Username;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        username = reader["Username"].ToString();
                        password = reader["Password"].ToString();
                    }
                }
            }
            if(username is not null && PasswordSalt.CheckMatch(password, admin.Password))
            {
                return true;
            }
            return false;
        }
        public void AddAdmin(AdminAdd admin)
        {
            string saltedPassword = PasswordSalt.CalculateHash(admin.Password);
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("AddAdmin", cn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar);
                    cmd.Parameters["@Username"].Value = admin.Username;
                    cmd.Parameters.Add("@Nickname", SqlDbType.NVarChar);
                    cmd.Parameters["@Nickname"].Value = admin.Nickname;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar);
                    cmd.Parameters["@Password"].Value = saltedPassword;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Open();
                    IDataReader reader = cmd.ExecuteReader();
                }
            }
        }
        public bool DeleteAdmin(string username)
        {
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAdmin", cn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar);
                    cmd.Parameters["@Username"].Value = username;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Open();
                    IDataReader reader = cmd.ExecuteReader();
                }
            }
            return true;
        }
    }
}
