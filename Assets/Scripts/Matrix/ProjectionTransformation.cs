using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionTransformation : TransformationBase
{
    enum ProjectionType
    {
        Orthographic,
        Perspective,
    }

    [SerializeField]
    private float m_FocalLength;

    [SerializeField]
    private ProjectionType m_Type;

    public override Vector3 Apply(Vector3 coordinate)
    {
        return coordinate;
    }

    public override Matrix4x4 Matrix()
    {
        switch (m_Type)
        {
            case ProjectionType.Orthographic:
                return OrthographicMatrix();
            case ProjectionType.Perspective:
                return PerspectiveMatrix();
            default:
                return OrthographicMatrix();
        }
    }

    private Matrix4x4 OrthographicMatrix()
    {
        m_TransformMatrix.SetRow(0, new Vector4(1, 0, 0, 0));
        m_TransformMatrix.SetRow(1, new Vector4(0, 1, 0, 0));
        m_TransformMatrix.SetRow(2, new Vector4(0, 0, 0, 0));
        m_TransformMatrix.SetRow(3, new Vector4(0, 0, 0, 1));
        return m_TransformMatrix;
    }

    private Matrix4x4 PerspectiveMatrix()
    {
        m_TransformMatrix.SetRow(0, new Vector4(m_FocalLength, 0, 0, 0));
        m_TransformMatrix.SetRow(1, new Vector4(0, m_FocalLength, 0, 0));
        m_TransformMatrix.SetRow(2, new Vector4(0, 0, 0, 0));
        m_TransformMatrix.SetRow(3, new Vector4(0, 0, 1, 0));
        return m_TransformMatrix;
    }
}
