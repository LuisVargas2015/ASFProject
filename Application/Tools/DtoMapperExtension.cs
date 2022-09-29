using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Service.Common.Mapping
{
    // no sirve para mappear otra clase, solo funciona si se tiene las misma propiedades
    // lo cual no es usual se recomienda usar AUTOMAPPER
    public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {

           

            return JsonSerializer.Deserialize<T>(
                
                JsonSerializer.Serialize(value)
                
                );
        }
    }
}
