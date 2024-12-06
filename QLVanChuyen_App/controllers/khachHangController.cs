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
    internal class khachHangController
    {
        private readonly SqlConnection conn;
        public khachHangController()
        {
            conn = new Connector().GetConnection();
        }
        public int? addKhachHang(string? hoten, string? sdt, string? diachi)
        {
            string query = @"
        INSERT INTO KhachHang (TenKhachhang, SDT, DiaChi) 
        VALUES (@hoten, @sdt, @diachi); 
        SELECT SCOPE_IDENTITY();"; 

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@hoten", hoten);
                    command.Parameters.AddWithValue("@sdt", sdt);
                    command.Parameters.AddWithValue("@diachi", diachi);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}");
                return null;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool RemoveKhachHang(int id)
        {
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @id";
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
        public DataTable GetKhachHangDataTable()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM KhachHang";
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

        public DataTable GetKhachHangDataTable(string keyword)
        {
            string query = @"SELECT *
                            FROM KhachHang
                            WHERE SDT LIKE @Keyword OR TenKhachHang LIKE @Keyword OR CAST(MaKhachHang AS NVARCHAR) LIKE @Keyword";
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
        public bool EditKhachHang(int id, string? hoten, string? sdt, string? diachi)
        {
            string query = "UPDATE KHACHHANG SET TenKhachHang = @hoten, SDT = @sdt, DiaChi = @diachi WHERE MaKhachHang = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@hoten", hoten);
                    command.Parameters.AddWithValue("@sdt", sdt);
                    command.Parameters.AddWithValue("@diachi", diachi);
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
        public KhachHang? GetKH_By_ID(int id)
        {
            string query = "SELECT * FROM KhachHang WHERE MaKhachHang = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        string tenhkh = reader.GetString(reader.GetOrdinal("TenKhachHang"));
                        string sdt = reader.GetString(reader.GetOrdinal("SDT"));
                        string ghichu = reader.GetString(reader.GetOrdinal("DiaChi"));
                        return new KhachHang(id, tenhkh, sdt, ghichu);
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
        }
        public int Get_SoLuong()
        {
            string query = "SELECT COUNT(*) FROM khachHang ";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int cnt))
                        return cnt;
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
