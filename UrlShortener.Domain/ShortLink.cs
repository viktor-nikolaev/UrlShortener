using System;
using System.Linq;
using System.Text;

namespace UrlShortener.Domain
{
    // I prefer DDD approach
    // that's why UrlShortener class is not separated from the model
    public class ShortLink
    {
        public ShortLink(string sourceUrl)
        {
            SourceUrl = sourceUrl;
        }

        [Obsolete("For binders only", true)]
        private ShortLink()
        {
        }

        private const string Alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        private static readonly int Base = Alphabet.Length;

        public int Id { get; private set; }
        public string SourceUrl { get; private set; }

        public string Encode()
        {
            int num = Id;
            var sb = new StringBuilder();
            while (num > 0)
            {
                sb.Insert(0, Alphabet[num % Base]);
                num = num / Base;
            }

            return sb.ToString();
        }

        public static int Decode(string str)
        {
            return str.Aggregate(0, (current, c) => current * Base + Alphabet.IndexOf(c));
        }
    }
}