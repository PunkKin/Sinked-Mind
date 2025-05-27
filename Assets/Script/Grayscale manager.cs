using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grayscalemanager : MonoBehaviour
{
    public Shader _shader;
    [SerializeField] GameObject player;

    public RenderTexture output;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.current != null)
        {
            Camera.current.targetTexture = output;
            Camera.current.RenderWithShader(_shader, "RenderType");
            Camera.current.targetTexture = null;
        }
    }
}
