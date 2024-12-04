using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.controllers
{
    internal class MaHoa
    {
        private MD5 md;
        public MaHoa()
        {
            try
            {
                md = MD5.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public string HashPassword(string password)
        {
            if (md == null)
                throw new InvalidOperationException("Lỗi MD5 không nhận.");

            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md.ComputeHash(inputBytes);

            StringBuilder hexString = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hexString.Append(b.ToString("X2"));
            }

            return hexString.ToString();
        }
    }
}
