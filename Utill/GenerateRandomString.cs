using System;
using System.Linq;
using System.Text;

namespace SpectralWave.Utill
{
    public class GenerateRandomStringManager
    {
        private static readonly char[] CharArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private static readonly Random Random = new Random();

        public static string GenerateRandomString(int length) => new string(Enumerable.Range(0, length).Select(_ => CharArray[Random.Next(CharArray.Length)]).ToArray());
    }
}
