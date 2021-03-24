using UnityEngine;

public abstract class TransformationBase : MonoBehaviour
{
    [SerializeField]
    protected Vector3 m_TransformVector3;

    public abstract Vector3 Apply(Vector3 coordinate);
}
