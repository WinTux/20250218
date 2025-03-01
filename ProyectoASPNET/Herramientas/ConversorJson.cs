using Newtonsoft.Json;
using ProyectoASPNET.Models;
using System.Runtime.CompilerServices;
namespace ProyectoASPNET.Herramientas
{
    public static class ConversorJson
    {
        // Objectos C# -> JSON
        public static void SetObjetoAjson(this ISession sesion, string llave, object p) { 
            sesion.SetString(llave, JsonConvert.SerializeObject(p));
        }
        // JSON -> Objetos C#
        public static T GetObjetoDesdeJson<T>(this ISession sesion, string llave) {
            var valor = sesion.GetString(llave);
            return valor == null ? default(T) : JsonConvert.DeserializeObject<T>(valor);    
        }
    }
}
