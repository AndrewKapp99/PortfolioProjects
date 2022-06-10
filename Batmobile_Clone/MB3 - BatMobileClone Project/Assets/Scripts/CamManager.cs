using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CamManager : MonoBehaviour
{
    [SerializeField] private Transform Camera, PlayerMesh, CamAnchor;
    //public Vector3 A, B;
    public float time, waitTime, turnspeed, top, bottom;
    //public int radius;
    private Quaternion prevRotation;
    //public float theta, dist;
    public bool Moving, Able, Aligned;

    private float t;
    private CharMove cm;
    private Vector3 lookVec;
    private Rigidbody rb;

    private Vector2 mVec;
    // Start is called before the first frame update
    void Start()
    {
        prevRotation = Camera.rotation;
        cm = GetComponent<CharMove>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mVec = cm.InVector;
        #region Camera
        Vector3 angles = CamAnchor.localEulerAngles + lookVec * turnspeed;
        float angle = (CamAnchor.localEulerAngles + lookVec * turnspeed).x;

        if (angle > 180 && angle < top)
        {
            angles.x = top;
        }
        else if (angle < 180 && angle > bottom)
        {
            angles.x = bottom;
        }
        angles.z = 0f;

        /*if (rb.velocity.magnitude >= 1)
        {
            angles.y = Mathf.Lerp(angles.y, rb.velocity.y, 0.5f);
        }*/

        CamAnchor.localEulerAngles = angles;

        #endregion

    }

    public void RotateToFace(Vector3 rot)
    {
        PlayerMesh.DORotate(Camera.TransformDirection(Vector3.forward), 1f);
    }

    public void OnLook(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        lookVec = new Vector3(inputVec.y, inputVec.x, 0f);
    }
}
