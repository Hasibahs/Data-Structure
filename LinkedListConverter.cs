using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class LinkedListConverter<T> : JsonConverter<LinkedList<T>> where T : Student
{
    public override LinkedList<T> ReadJson(JsonReader reader, Type objectType, LinkedList<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var array = JArray.Load(reader);
        var list = new LinkedList<T>();
        foreach (var token in array)
        {
            var value = token.ToObject<T>();
            list.AddLast(value);
        }
        return list;
    }

    public override void WriteJson(JsonWriter writer, LinkedList<T> value, JsonSerializer serializer)
    {
        var array = new JArray();
        foreach (var item in value)
        {
            var token = JToken.FromObject(item);
            array.Add(token);
        }
        array.WriteTo(writer);
    }
}
