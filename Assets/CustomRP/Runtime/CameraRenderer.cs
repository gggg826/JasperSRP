using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraRenderer : MonoBehaviour
{
    private ScriptableRenderContext m_Context;
    private Camera m_Camera;

    public void Render(ScriptableRenderContext context, Camera camera)
    {
        m_Context = context;
        m_Camera = camera;    
    }
}
