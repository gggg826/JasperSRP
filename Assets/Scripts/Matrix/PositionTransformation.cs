using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTransformation : TransformationBase
{

    public override Vector3 Apply(Vector3 coordinate)
    {
        return m_TransformVector3 + coordinate;
    }
}
