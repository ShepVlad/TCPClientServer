using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JsonModelData
{
    public static class JsonFortmat
    {
        public static User GetPackageFromJson(string jsonString)
        {
            User user = new User();
            user = JsonConvert.DeserializeObject<User>(jsonString);
            return user;
        }

        public static string GetJsonFromPackage(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            return json;
        }
    }
}
