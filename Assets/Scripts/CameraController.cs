using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float zoomScale;
    [SerializeField][Range(1, 5)]
    private float zoomLimitMin, zoomLinitMax;

    private Vector3 originPos;

    public GameObject prefab;

    void Awake()
    {
        cam = cam ? cam : Camera.main;
    }
    void Update()
    {
        MoveCamera();
        Scroll();
    }

    private void MoveCamera()
    {
        if (Input.GetMouseButtonDown(0)) originPos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Vector3 dif = originPos - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = ClampCamera(cam.transform.position + dif);
        }
    }

    private void Scroll()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            cam.orthographicSize = Mathf.Clamp
                (cam.orthographicSize + (zoomScale * -Input.mouseScrollDelta.y), zoomLimitMin, zoomLinitMax);
        }

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 target)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = camWidth - MapManager.s_Instance.mapContainer.List[0].Width / 2f;

        float maxX = MapManager.s_Instance.BorderX - camWidth + 
            MapManager.s_Instance.mapContainer.List[MapManager.s_Instance.mapContainer.List.Count - 1].Width/2f;

        float minY = MapManager.s_Instance.BorderY + camHeight - 
            MapManager.s_Instance.mapContainer.List[0].Height / 2f;

        float maxY = -camHeight + MapManager.s_Instance.mapContainer.List[0].Height / 2f;

        float endX = Mathf.Clamp(target.x, minX, maxX);

        float endY = Mathf.Clamp(target.y, minY, maxY);

        return new Vector3(endX, endY, target.z);
    }
}
