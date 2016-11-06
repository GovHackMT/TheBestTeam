using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace ESaudeApi.Tools
{
    public class SessaoSistema
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SobreNome { get; set; }

        public string Autenticacao { get; set; }




        public static void NewSession(HttpContext context, SessaoSistema sessao)
        {
            try
            {

                var sessaoBase64 = Uri.EscapeDataString(Base64Encode(Newtonsoft.Json.JsonConvert.SerializeObject(sessao, Newtonsoft.Json.Formatting.None)));
                context.Response.Cookies.Append(MD5("SessaoAppSaude"),
                    sessaoBase64
                    , new CookieOptions()
                    {
                        Expires = DateTime.Now.AddDays(30)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static SessaoSistema GetSession(HttpContext context)
        {
            SessaoSistema sessao = null;
            try
            {
                var cookieSessao = Base64Decode(Uri.UnescapeDataString(context.Request.Cookies[MD5("SessaoAppSaude")]));
                sessao = Newtonsoft.Json.JsonConvert.DeserializeObject<SessaoSistema>(cookieSessao);

                return sessao;
            }
            catch
            {
                return sessao;
            }
        }

        public static void Logout(HttpContext context)
        {
            context.Response.Cookies.Append(MD5("SessaoAppSaude"), ""
            , new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            });
        }


        public static string MD5(string value)
        {

            byte[] input = ASCIIEncoding.ASCII.GetBytes(value);

            using (System.Security.Cryptography.MD5 hash = System.Security.Cryptography.MD5.Create())
            {
                return BitConverter.ToString(hash.ComputeHash(input))
                    .Replace("-", "").ToLower();
            }
        }

        //Base64Encode
        static public string Base64Encode(string toEncode)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(toEncode);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Base64Decode
        static public string Base64Decode(string encodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }


}
