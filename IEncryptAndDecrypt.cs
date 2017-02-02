using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IEncryptAndDecrypt
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
