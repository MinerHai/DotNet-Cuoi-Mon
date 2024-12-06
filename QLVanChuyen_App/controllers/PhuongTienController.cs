using Microsoft.Data.SqlClient;
using QLVanChuyen_App.DAO;
using QLVanChuyen_App.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.controllers
{
    internal class PhuongTienController
    {
        private readonly SqlConnection conn;
        public PhuongTienController()
        {
            conn = new Connector().GetConnection();
        }
        public bool addPhuongTien(string? bienso, string? taixe, string? loaixe)
        {
            string query = "INSERT INTO XeVanChuyen VALUES(@bienso, @taixe, @loaixe)";

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@bienso", bienso);
                    command.Parameters.AddWithValue("@taixe", taixe);
                    command.Parameters.AddWithValue("@loaixe", loaixe);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Biển số xe đã tồn tại");
                    return false;
                }
                MessageBox.Show($"Lỗi SQL: {ex.Message}");
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
        public bool RemovePhuongTien(int id)
        {
            string query = "DELETE FROM XeVanChuyen WHERE MaXe = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
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
        public DataTable GetPhuongTienDataTable()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM XeVanChuyen";
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
        public List<string> getDS_BienSo()
        {
            List<string> bienSoList = new List<string>();
            string query = "SELECT BienSo FROM XeVanChuyen";
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bienSoList.Add(reader["BienSo"].ToString());
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
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return bienSoList;
        }

        public DataTable GetPhuongTienDataTable(string keyword)
        {
            string query = @"SELECT *
                            FROM XeVanChuyen
                            WHERE BienSo LIKE @Keyword OR CAST(MaXe AS NVARCHAR) LIKE @Keyword";
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
        public bool EditPhuongTien(int id, string? bienso, string? taixe, string? loaixe)
        {
            string query = "UPDATE XeVanChuyen SET BienSo = @bienso, TaiXe = @taixe, LoaiXe = @loaixe WHERE MaXe = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@bienso", bienso);
                    command.Parameters.AddWithValue("@taixe", taixe);
                    command.Parameters.AddWithValue("@loaixe", loaixe);
                    command.Parameters.AddWithValue("@id", id);
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
        public int GetID_By_BienSo(string? bienso)
        {
            string query = "SELECT MaXe FROM XeVanChuyen WHERE BienSo = @bienso";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@bienso", bienso);
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int maXe))
                        return maXe;
                    else
                        return 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public PhuongTien? GetPT_By_ID(int? id)
        {
            string query = "SELECT * FROM XeVanChuyen WHERE MaXe = @MaXe";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaXe", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        int maXe = reader.GetInt32(reader.GetOrdinal("MaXe"));
                        string bienSo = reader.GetString(reader.GetOrdinal("BienSo"));
                        string taiXe = reader.GetString(reader.GetOrdinal("TaiXe"));
                        string loaiXe = reader.GetString(reader.GetOrdinal("LoaiXe"));

                        return new PhuongTien(maXe, bienSo, taiXe, loaiXe);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public int Get_SoLuong()
        {
            string query = "SELECT COUNT(*) FROM XeVanChuyen ";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int maXe))
                        return maXe;
                    else
                        return 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

    }

}
