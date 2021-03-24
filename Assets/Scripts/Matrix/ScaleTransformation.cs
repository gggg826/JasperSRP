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
}
