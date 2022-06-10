using UnityEngine;

public class RotateToFace : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cam;

    void Update()
    {
        Vector3 angles = cam.localRotation.eulerAngles;

        transform.localRotation = Quaternion.Euler(new Vector3(0f, angles.y, 0f));
    }
}
