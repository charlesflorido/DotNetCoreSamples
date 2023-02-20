using System;
using Newtonsoft.Json;

namespace SampleProject.UsefulTypes
{
    public class DefinableJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var isGenericType = objectType.IsGenericType;
            if (isGenericType)
            {
                var typeDef = objectType.GetGenericTypeDefinition();
            }
            
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Definable<>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var canConvert = CanConvert(objectType);
            if(CanConvert(objectType))
            {
                if (existingValue == null)
                {
                    var defaultValue = Activator.CreateInstance(objectType.GetGenericTypeDefinition()) as IDefinable;
                    defaultValue.IsDefined = true;
                    return defaultValue;
                }
                else
                {
                    var definable = existingValue as IDefinable;
                    definable.IsDefined = true;
                    definable.SetValue(ReadJson(reader, definable.GetValueType(), definable.GetValue(), serializer));
                    return existingValue;
                }
            }
            else
            {
                return serializer.Deserialize(reader, objectType);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

