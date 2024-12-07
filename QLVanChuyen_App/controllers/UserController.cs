using Microsoft.Data.SqlClient;
using QLVanChuyen_App.DAO;
using QLVanChuyen_App.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.controllers
{
    internal class UserController
    {
        private MaHoa mahoa;
        private readonly SqlConnection conn;

        public UserController()
        {
            mahoa = new MaHoa();
            conn = new Connector().GetConnection();
        }

        public Users LoginUser(string username, string password)
        {
            string hashpass = mahoa.HashPassword(password);
            string query = "SELECT * FROM Users WHERE Username = @username";

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("UserId"));
                        string hashPass = reader.GetString(reader.GetOrdinal("Pass"));
                        string role = reader.GetString(reader.GetOrdinal("Role"));

                        var user = new Users(id, username, hashPass, role);

                        if (user == null || !user.Password.Equals(hashpass))
                        {
                            return null;
                        }
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return null;
        }

        public bool SignupUser(string username, string password)
        {
            string hashPassword = mahoa.HashPassword(password);
            string query = "INSERT INTO Users(Username, Pass, Role) VALUES(@Username, @Pass, 'User')";

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Pass", hashPassword);

                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Người dùng đã tồn tại");
                    return false;
                }
                else
                {
                    MessageBox.Show($"Lỗi SQL: {ex.Message}");
                }
                return false;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
        public bool RemoveUser(string username)
        {
            string query = "DELETE FROM Users WHERE Username = @Username";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        public bool ChangeRole(string username, string role)
        {
            string query = "UPDATE Users SET Role = @Role WHERE Username = @Username";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool ChangePassword(string username, string newPassword)
        {
            string query = "UPDATE Users SET Pass = @Pass WHERE Username = @Username";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string hashPassword = mahoa.HashPassword(newPassword);
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Pass", hashPassword);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable GetUserDataTable()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT UserID, Username, Role FROM Users";
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return dataTable;
        }

        public DataTable GetUserDataTable(string keyword)
        {
            string query = @"SELECT UserID, Username, Role
                            FROM Users
                            WHERE Username LIKE @Keyword OR CAST(UserID AS NVARCHAR) LIKE @Keyword";
            DataTable dataTable = new DataTable();
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }



        public string GetRoleCount(string role)
        {
            string query = "SELECT COUNT(*) as Count FROM Users WHERE Role = @Role";
            try
            {
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Role", role);
                    var result = command.ExecuteScalar();
                    return result?.ToString() ?? "0";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return "null";
            }
        }
    }
}
