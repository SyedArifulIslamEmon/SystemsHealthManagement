using System;
using System.Text;

namespace Integra.Infra
{
    public class GeradorDeSenhas
    {
        public enum RandomType { Alpha, Alphanumeric, Numeric }


        private static readonly Random Random = new Random();
        private static readonly StringBuilder SbReturn = new StringBuilder();

        /// <summary>   
        /// Return number   
        /// </summary>   
        /// <param name="minimum">from</param>   
        /// <param name="maximum">to</param>   
        /// <returns>int</returns>   
        public static int ObterNumeroAleatorio(int minimum, int maximum)
        {
            return Random.Next(minimum, maximum + 1);
        }

        /// <summary>   
        /// Returns random string   
        /// </summary>   
        /// <param name="type">type Apha, Numeric or Aphnumeric</param>   
        /// <param name="length">string length</param>   
        /// <returns>string</returns>   
        public static string Gerar(RandomType type, int length)
        {
            switch (type)
            {
                case RandomType.Numeric:
                    return ObterNumero(length);
                case RandomType.Alpha:
                    return ObterAlfa(length);
                case RandomType.Alphanumeric:
                    return ObterAlfaNumerico(length);
                default:
                    return ObterAlfaNumerico(length);
            }
        }

        /// <summary>   
        /// Return a string with numbers   
        /// </summary>   
        /// <param name="length">length of string return</param>   
        /// <returns>string random</returns>   
        private static string ObterNumero(int length)
        {
            SbReturn.Clear();

            for (int i = 0; i < length; i++)
            {
                //returns 48 to 57, ie from 0 to 9 according to the character map   
                var number = (char)Random.Next(48, 58);
                SbReturn.Append(number);
            }

            return SbReturn.ToString();
        }

        /// <summary>   
        /// Return a string with letters   
        /// </summary>   
        /// <param name="length">length of string return</param>   
        /// <returns>string random</returns>   
        private static string ObterAlfa(int length)
        {
            SbReturn.Clear();

            for (var i = 0; i < length; i++)
            {
                if (Convert.ToBoolean(Random.Next(0, 2)))
                {
                    //returns 97 to 122 , ie from a to z according to the character map   
                    var character = (char)Random.Next(97, 123);
                    SbReturn.Append(character);
                }
                else
                {
                    //returns 65 to 90, ie from A to Z according to the character map   
                    var c = (char)Random.Next(65, 91);
                    SbReturn.Append(c);
                }
            }
            return SbReturn.ToString();
        }

        /// <summary>   
        /// Return a string with letters and numbers   
        /// </summary>   
        /// <param name="length">length of string return</param>   
        /// <returns>string random</returns>   
        private static string ObterAlfaNumerico(int length)
        {
            SbReturn.Clear();

            for (var i = 0; i < length; i++)
            {
                if (Convert.ToBoolean(Random.Next(0, 2)))
                {
                    if (Convert.ToBoolean(Random.Next(0, 2)))
                    {
                        //returns 97 to 122 , ie from a to z according to the character map   
                        var character = (char)Random.Next(97, 123);
                        SbReturn.Append(character);
                    }
                    else
                    {
                        //returns 65 to 90, ie from A to Z according to the character map   
                        var character = (char)Random.Next(65, 91);
                        SbReturn.Append(character);
                    }
                }
                else
                {
                    //returns 48 to 57, ie from 0 to 9 according to the character map   
                    var number = (char)Random.Next(48, 58);
                    SbReturn.Append(number);
                }
            }
            return SbReturn.ToString();
        }

    }
}
