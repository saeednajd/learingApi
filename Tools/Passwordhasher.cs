using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using webapitwo.Model;

namespace learingApi.Tools
{
    public class Passwordhasher
    {
        public static string Hashpass(string password)
        {


            // var hash = Rfc2898DeriveBytes.Pbkdf2("string", RandomNumberGenerator.GetBytes(16),
            //  10000, hashAlgorithm: HashAlgorithmName.SHA256, 32
            // );
            var sha = SHA256.Create();
            var asbytes = Encoding.Default.GetBytes(password);
            var hashedpassword = sha.ComputeHash(asbytes);

            // var asbytes = Encoding.Default.GetBytes(password);
            // var hashedpassword = SHA256.HashData(asbytes);

            return Convert.ToBase64String(hashedpassword);
        }
        public static bool Ispasscorrect(string userpass, string dbsavedpass)
        {

            var userinput = Hashpass(userpass);
            if (userinput == dbsavedpass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}