using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class BinarySearchTreeConverter<T> : JsonConverter<BinarySearchTree<T>> where T : Student
{
    public override BinarySearchTree<T> ReadJson(JsonReader reader, Type objectType, BinarySearchTree<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var array = JArray.Load(reader);
        var bst = new BinarySearchTree<T>();
        foreach (var token in array)
        {
            var value = token.ToObject<T>();
            bst.Add(value);
        }
        return bst;
    }

    public override void WriteJson(JsonWriter writer, BinarySearchTree<T> value, JsonSerializer serializer)
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
