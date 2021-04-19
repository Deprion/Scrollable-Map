using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StuffManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Text text;

/*    private float width, height;

    private Dictionary<(float, float), string> mapDictionary = new Dictionary<(float, float), string>();

    void Awake()
    {
        cam = cam ? cam : Camera.main;

        width = MapManager.s_Instance.mapContainer.List[0].Width;
        height = MapManager.s_Instance.mapContainer.List[0].Height;

        foreach (MapContainer.MapRepresentation mp in MapManager.s_Instance.mapContainer.List)
        {
            float posX = (float)Math.Round(mp.X, 2);
            float posY = (float)Math.Round(mp.Y, 2);
            print("X: " + posX);
            print("Y: " + posY);

            mapDictionary.Add((posX, posY), mp.Id);
        }
    }
    private void OnEnable()
    {
        float posX = cam.transform.position.x - cam.orthographicSize * cam.aspect;
        float posY = cam.transform.position.y + cam.orthographicSize;

        float endX = (float)Math.Round(Mathf.Floor(posX / width) * width, 2);
        endX = endX < 0 ? 0 : endX;

        float endY = (float)Math.Round(Mathf.Floor(posY / height) * height, 2);
        print(endX);
        print(endY);

        text.text = mapDictionary[(endX, endY)];
    }
}*/
    void Awake()
    {
        cam = cam ? cam : Camera.main;
    }
    private void OnEnable()
    {
        foreach (MapContainer.MapRepresentation mp in MapManager.s_Instance.mapContainer.List)
        {
            float posX = cam.transform.position.x - cam.orthographicSize * cam.aspect;
            float posY = cam.transform.position.y + cam.orthographicSize;

            if (mp.X - 2.56f <= posX && mp.X + 2.56f >= posX &&
                mp.Y - 2.56f <= posY && mp.Y + 2.56f >= posY)
            {
                text.text = mp.Id;
            }
        }
    }
    private void OnDisable()
    {
        text.text = null;
    }
}
