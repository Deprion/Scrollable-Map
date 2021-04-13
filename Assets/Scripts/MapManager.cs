using UnityEngine;
using UnityEngine.U2D;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private SpriteAtlas mapAtlas;
    [SerializeField]
    private GameObject mapPrefab, mapParent;
    private float ExtraWidth = 1.91f;

    public MapContainer mapContainer;
    public float BorderX, BorderY;
    public static MapManager s_Instance;
    private void Awake()
    {
        if (s_Instance != null) Destroy(this);
        s_Instance = this;
        BuildMap();
    }
    private void BuildMap()
    {
        mapContainer = JsonUtility.FromJson<MapContainer>
            (Resources.Load<TextAsset>("testing_views_settings").ToString());
        for (int i = mapContainer.List.Count - 1; i >= 0; i--)
        {
            var obj = Instantiate(mapPrefab, new Vector2
                (mapContainer.List[i].X, mapContainer.List[i].Y), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = mapAtlas.GetSprite(mapContainer.List[i].Id);
            obj.transform.SetParent(mapParent.transform, false);

            if (mapContainer.List[i].Width == 1.30f)
            {
                obj.transform.localPosition = new Vector2
                    (obj.transform.localPosition.x - ExtraWidth, obj.transform.localPosition.y);
            }

            BorderX = obj.transform.localPosition.x > BorderX ? obj.transform.localPosition.x : BorderX;
            BorderY = obj.transform.localPosition.y < BorderY ? obj.transform.localPosition.y : BorderY;
        }
    }
}
