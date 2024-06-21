using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class HeapConverter<T> : JsonConverter<Heap<T>> where T : Student
{
    public override Heap<T> ReadJson(JsonReader reader, Type objectType, Heap<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var array = JArray.Load(reader);
        var heap = new Heap<T>(SortBy.Name); 
        foreach (var token in array)
        {
            var value = token.ToObject<T>();
            heap.Add(value);
        }
        return heap;
    }

    public override void WriteJson(JsonWriter writer, Heap<T> value, JsonSerializer serializer)
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
