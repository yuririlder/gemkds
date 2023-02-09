using GEMEscolar.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace GEMEscolar.Core.Controllers
{
    public class MainControllerApi : Controller
    {

        private Users _userLogado = null;
        public Users UserLogado
        {
            get
            {
                if (_userLogado == null)
                {
                    _userLogado = HttpContext.Session.GetObjectFromJson<Users>("User");
                    _userLogado = _userLogado == null ? new Users() : _userLogado;
                }
                return _userLogado;
            }

            set => _userLogado = value;
        }
    }
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var j = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            session.SetString(key, JsonConvert.SerializeObject(value, j));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static void DelObjectFromJson(this ISession session)
        {
            session.Clear();
        }
    }
}
