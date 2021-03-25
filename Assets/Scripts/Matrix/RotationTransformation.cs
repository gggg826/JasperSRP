using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTransformation : TransformationBase
{
    private float m_RadX;
    private float m_RadY;
    private float m_RadZ;

    private float m_SinX;
    private float m_CosX;
    private float m_sinY;
    private float m_CosY;
    private float m_sinZ;
    private float m_CosZ;

    private Vector3 m_XAxis = Vector3.one;
    private Vector3 m_YAxis = Vector3.one;
    private Vector3 m_ZAxis = Vector3.one;

    public override Vector3 Apply(Vector3 coordinate)
    {
        //三轴旋转弧度
        m_RadX = Mathf.Deg2Rad * m_TransformVector3.x;
        m_RadY = Mathf.Deg2Rad * m_TransformVector3.y;
        m_RadZ = Mathf.Deg2Rad * m_TransformVector3.z;

        m_SinX = Mathf.Sin(m_RadX);
        m_CosX = Mathf.Cos(m_RadX);
        m_sinY = Mathf.Sin(m_RadY);
        m_CosY = Mathf.Cos(m_RadY);
        m_sinZ = Mathf.Sin(m_RadZ);
        m_CosZ = Mathf.Cos(m_RadZ);



        //按XYZ矩阵相乘顺序得到：
        //x轴的旋转矩阵为 (cosY*cosZ, sinZ, -sinY*cosZ)
        m_XAxis.x = m_CosY * m_CosZ;
        m_XAxis.y = m_sinZ;
        m_XAxis.z = -m_sinY * m_CosZ;

        //y轴的旋转矩阵为 (-cosY*sinZ, cosX*cosZ-sinX*sinY*sinZ, sinX*cosZ + cosX*sinY*sinZ)
        m_YAxis.x = -m_CosY * m_sinZ;
        m_YAxis.y = m_CosX * m_CosZ - m_SinX * m_sinY * m_sinZ;
        m_YAxis.z = m_SinX * m_CosZ + m_CosX * m_sinY * m_sinZ;

        //z轴的旋转矩阵为 (sinY, -sinX*cosY, cosX*cosY)
        m_ZAxis.x = m_sinY;
        m_ZAxis.y = -m_SinX * m_CosY;
        m_ZAxis.z = m_CosX * m_CosY;

        return m_XAxis * coordinate.x + m_YAxis * coordinate.y + m_ZAxis * coordinate.z;
    }

    public override Matrix4x4 Matrix()
    {
        //三轴旋转弧度
        m_RadX = Mathf.Deg2Rad * m_TransformVector3.x;
        m_RadY = Mathf.Deg2Rad * m_TransformVector3.y;
        m_RadZ = Mathf.Deg2Rad * m_TransformVector3.z;

        m_SinX = Mathf.Sin(m_RadX);
        m_CosX = Mathf.Cos(m_RadX);
        m_sinY = Mathf.Sin(m_RadY);
        m_CosY = Mathf.Cos(m_RadY);
        m_sinZ = Mathf.Sin(m_RadZ);
        m_CosZ = Mathf.Cos(m_RadZ);

        m_TransformMatrix.SetRow(0, new Vector4(m_CosY * m_CosZ, -m_CosY * m_sinZ, m_sinY, 0));
        m_TransformMatrix.SetRow(1, new Vector4(m_sinZ, m_CosX * m_CosZ - m_SinX * m_sinY * m_sinZ, -m_SinX * m_CosY, 0));
        m_TransformMatrix.SetRow(2, new Vector4(-m_sinY * m_CosZ, m_SinX * m_CosZ + m_CosX * m_sinY * m_sinZ, m_CosX * m_CosY, 0));
        m_TransformMatrix.SetRow(3, new Vector4(0, 0, 0, 1));
        return m_TransformMatrix;
    }
}
