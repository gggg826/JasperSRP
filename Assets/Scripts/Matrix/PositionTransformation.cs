using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTransformation : TransformationBase
{

    public override Vector3 Apply(Vector3 coordinate)
    {
        return m_TransformVector3 + coordinate;
    }

    public override Matrix4x4 Matrix()
    {
        m_TransformMatrix.SetRow(0, new Vector4(1, 0, 0, m_TransformVector3.x));
        m_TransformMatrix.SetRow(1, new Vector4(0, 1, 0, m_TransformVector3.y));
        m_TransformMatrix.SetRow(2, new Vector4(0, 0, 1, m_TransformVector3.z));
        m_TransformMatrix.SetRow(3, new Vector4(0, 0, 0, 1));
        return m_TransformMatrix;
    }
}
