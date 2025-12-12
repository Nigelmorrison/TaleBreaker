using UnityEngine;

[ExecuteInEditMode]
public class TiltCamera : MonoBehaviour
{
    public float shear = -0.3f;
    Camera cam;
    Matrix4x4 originalProjectionMatrix;
    private void Awake()
    {
        cam = GetComponent<Camera>();
        originalProjectionMatrix = cam.projectionMatrix;
    }

    private void Update()
    {
        Matrix4x4 shearMatrix = Matrix4x4.identity;
        shearMatrix.m12 = shear;
        cam.projectionMatrix = originalProjectionMatrix * shearMatrix;
    }
}
