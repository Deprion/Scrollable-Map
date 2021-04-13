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

        float maxX = MapManager.s_Instance.BorderX - camWidth;
        float minY = MapManager.s_Instance.BorderY + camHeight/2;
        
        float endX;

        // Не знаю как фиксить выход за рамки при высоком aspect, кроме как магическими цифрами

        if (cam.aspect >= 2) endX = Mathf.Clamp(target.x, camWidth / 2 + 2.6f, maxX);
        else endX = Mathf.Clamp(target.x, camWidth / 2 + 1.91f, maxX);

        float endY = Mathf.Clamp(target.y, minY, -camHeight/2);

        return new Vector3(endX, endY, target.z);
    }
}
