using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [Range(-2f,2f)]
    public float speed = 0.5f;
    private float offset;
    private Material mat;
    
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    
    void Update()
    {
        offset += (Time.deltaTime * speed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}