
using System.Security.Cryptography;
using JWT.Algorithms;

namespace InventarySystemAPI.Config
{
    public class JwtConfig
    {
        private static RS256Algorithm? algorithm;
        private static RSA? certificate;

        public static RSA GetCertificate()
        {
            if (certificate == null)
            {
                certificate = RSA.Create();
            }
            return certificate;
        }

        public static RS256Algorithm GetAlgorithm()
        {
            if (algorithm == null)
            {
                algorithm = new RS256Algorithm(GetCertificate());
            }
            return algorithm;
        }
    }
}