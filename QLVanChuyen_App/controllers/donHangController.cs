using Microsoft.Data.SqlClient;
using QLVanChuyen_App.DAO;
using QLVanChuyen_App.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QLVanChuyen_App.controllers
{
    internal class donHangController
    {
        private SqlConnection conn;
        public donHangController()
        {
            conn = new Connector().GetConnection();
        }
        public int AddDonHang(int? makh, string ghichu)
        {
            string query = @"INSERT INTO DonHang (Makhachhang, TrangThai, Ghichu) 
                            VALUES (@makh, N'Chờ xác nhận', @ghichu);
                            SELECT SCOPE_IDENTITY();"; 
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@makh", makh);
                    command.Parameters.AddWithValue("@ghichu", ghichu);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
                return 0; 
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool AddCTDonHang(int? madh, int? maxe)
        {
            string query = @"INSERT INTO CHITIETVANCHUYEN(MaDonHang, MaXe) VALUES(@madh,@maxe)";
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@madh", madh);
                    command.Parameters.AddWithValue("@maxe", maxe);
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
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
        public DataTable GetDonHangDataTable()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM DonHang";
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

        public DataTable GetDonHangDataTable(string keyword)
        {
            string query = @"SELECT *
                            FROM DonHang
                            WHERE NgayDatHang LIKE @Keyword OR GhiChu LIKE @Keyword OR CAST(MaDonHang AS NVARCHAR) LIKE @Keyword";
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
        public bool RemoveDonHang(int id)
        {
            string query = "DELETE FROM DonHang WHERE MaDonHang = @id";
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
        public DonHang? GetDH_By_ID(int id)
        {
            string query = "SELECT * FROM DonHang WHERE MaDonHang = @id";
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

                        int id_kh = reader.GetInt32(reader.GetOrdinal("MaKhachHang"));
                        DateTime ngaydathang= reader.GetDateTime(reader.GetOrdinal("NgayDatHang"));
                        string trangthai = reader.GetString(reader.GetOrdinal("TrangThai"));
                        string ghichu = reader.GetString(reader.GetOrdinal("GhiChu"));

                        return new DonHang(id, id_kh, ngaydathang, trangthai, ghichu);
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
        public int Get_MaDH_By_CTDH(int id)
        {
            string query = "SELECT MaDonHang FROM ChiTietVanChuyen WHERE MaVanChuyen = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int madh))
                        return madh;
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
        }
        public int Get_MaXe_By_CTDH(int id)
        {
            string query = "SELECT MaXe FROM ChiTietVanChuyen WHERE MaVanChuyen = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
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
        }
        public int Get_MaCTHD_By_HD(int id)
        {
            string query = "SELECT MaVanChuyen FROM ChiTietVanChuyen WHERE MaDonHang = @id";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int MaVanChuyen))
                        return MaVanChuyen;
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
        }
        public bool CapNhat_TrangThai(int id_dh, string? trangthai)
        {
            string query = "UPDATE DonHang SET TrangThai = @trangthai WHERE MaDonHang = @id_dh";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@trangthai", trangthai);
                    command.Parameters.AddWithValue("@id_dh", id_dh);
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
        public int Get_SoLuong()
        {
            string query = "SELECT COUNT(*) FROM DonHang ";
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
        public int Get_SoLuong(string? trangthai)
        {
            string query = "SELECT COUNT(*) FROM DonHang WHERE TrangThai = @trangthai ";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@trangthai", @trangthai);
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
