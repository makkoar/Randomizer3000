using System.Security.Cryptography;
using System.Text;

namespace Randomizer3000
{
    class Cryptography
    {
        public static string GetMd5Hash(string Input)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.Default.GetBytes(Input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
    }
}
