using UnityEngine;
using UnityEngine.UIElements;
public class Transform : MonoBehaviour, ITransform
{
    public Vector3 position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Quaternion rotation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Vector3 scale { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Matrix4x4 matrix => throw new System.NotImplementedException();

}
