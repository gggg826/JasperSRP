using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransformation : TransformationBase
{
    public override Vector3 Apply(Vector3 coordinate)
    {
        coordinate.x *= m_TransformVector3.x;
        coordinate.y *= m_TransformVector3.y;
        coordinate.z *= m_TransformVector3.z;
        return coordinate;
    }

    public override Matrix4x4 Matrix()
    {
        m_TransformMatrix.SetRow(0, new Vector4(m_TransformVector3.x, 0, 0, 0));
        m_TransformMatrix.SetRow(1, new Vector4(0, m_TransformVector3.y, 0, 0));
        m_TransformMatrix.SetRow(2, new Vector4(0, 0, m_TransformVector3.z, 0));
        m_TransformMatrix.SetRow(3, new Vector4(0, 0, 0, 1));
        return m_TransformMatrix;
    }
}
