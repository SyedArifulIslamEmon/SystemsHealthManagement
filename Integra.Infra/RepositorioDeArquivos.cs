using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Integra.Infra
{
    public class RepositorioDeArquivos
    {
        private static string CalculateMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public void ArmazenarArquivo(Stream arquivo, string nomeDoArquivo, DateTime dataDeUpload)
        {
            var path = ObterCaminhoDoArquivo(nomeDoArquivo, dataDeUpload);
            if (!File.Exists(path))
            {
                using (var stream = File.Create(path))
                {
                    arquivo.CopyTo(stream);
                    stream.Close();
                }
            }
        }

        public static string ObterCaminhoDoArquivo(string nomeDoArquivo, DateTime dataDeUpload)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Uploads");
            Directory.CreateDirectory(path);
            var nomeHash = CalculateMd5Hash(nomeDoArquivo + dataDeUpload.ToString("ddMMyyyyhhmmss"));
            path = Path.Combine(path, nomeHash);
            return path;
        }

        public FileStream ObterArquivo(string nomeDoArquivo, DateTime dataDeUpload)
        {
            var path = ObterCaminhoDoArquivo(nomeDoArquivo, dataDeUpload);
            if (File.Exists(path))
                return File.OpenRead(path);
            return null;
        }

        public void RemoverArquivo(string nomeDoArquivo, DateTime dataDeUpload)
        {
            var path = ObterCaminhoDoArquivo(nomeDoArquivo, dataDeUpload);
            if (File.Exists(path))
                File.Delete(path);
        }
    }


}
