using UnityEngine;
using UnityEngine.UI;

public class StuffManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Text text;

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
            print("x: " + posX);
            print("y: " + posY);
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
