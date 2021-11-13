using UnityEngine;

public class BGscroller : MonoBehaviour
{
    public CameraFollow cam;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        offset += (Time.deltaTime * cam.currentVelocity.y) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
