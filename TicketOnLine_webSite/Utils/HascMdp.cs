using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicketOnLine_webSite.Utils
{
    public class HascMdp : IHascMdp
    {
        public string HashMdp(string mdp)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            HashAlgorithm hashAlgorithm = new SHA512Managed();
            byte[] result = hashAlgorithm.ComputeHash(unicodeEncoding.GetBytes(mdp));
            string MdpH = Convert.ToBase64String(result);
            return MdpH;
        }
    }
}
