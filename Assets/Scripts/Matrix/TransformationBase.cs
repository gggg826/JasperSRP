using UnityEngine;

public abstract class TransformationBase : MonoBehaviour
{
    [SerializeField]
    protected Vector3 m_TransformVector3;

    protected Matrix4x4 m_TransformMatrix = new Matrix4x4();

    public abstract Vector3 Apply(Vector3 coordinate);

    public abstract Matrix4x4 Matrix();

}
