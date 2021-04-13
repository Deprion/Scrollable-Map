using System.Collections.Generic;
using System;

[Serializable]
public class MapContainer
{
    public List<MapRepresentation> List = new List<MapRepresentation>();
    [Serializable]
    public class MapRepresentation
    {
        public string Id, Type;
        public float X, Y, Width, Height;
        public MapRepresentation(string id, string type, float posX, float posY, float width, float height)
        {
            Id = id;
            Type = type;
            X = posX;
            Y = posY;
            Width = width;
            Height = height;
        }
        public MapRepresentation(string id, string type, float posX, float width, float height)
        {
            Id = id;
            Type = type;
            X = posX;
            Width = width;
            Height = height;
        }
        public MapRepresentation(string id, string type, float width, float height)
        {
            Id = id;
            Type = type;
            Width = width;
            Height = height;
        }
    }
}
