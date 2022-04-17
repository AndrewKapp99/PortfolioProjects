using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CharMove : MonoBehaviour
{
    #region Values
    [Header("Movement")]
    [SerializeField] private float force;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float SprintForce;
    [SerializeField] private float SprintSpeed;
    [SerializeField] private float DodgeForce;
    [SerializeField] private Transform CamTransform;

    [Header("Camera")]
    [SerializeField] private GameObject Cam;
    [SerializeField] private float FOV;
    [SerializeField] private float SprintFOV;
    [Range(0, 5)] public float stopFacter;
    [Range(0, 5)] public float counterForceMagnitude;
    [SerializeField] private Transform playerMesh;
    public float x, y, z;
    public bool isSprinting = false;
    public bool isDodgeing = false;

    private Rigidbody rb;
    private float SPD, _fov;
    private CinemachineVirtualCamera _cam;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _cam = Cam.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Inputs
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        y = 0f;

        rb.drag = 0;

        if (Input.GetKey(KeyCode.Q))
        {
            y = 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            y = -1f;
        }
        #endregion

        #region Vector Manipulation

        Vector3 CamFwd = CamTransform.forward;
        Vector3 CamRt = CamTransform.right;

        CamFwd.y = 0f;
        CamRt.y = 0f;

        CamFwd = CamFwd.normalized;
        CamRt = CamRt.normalized;

        Vector3 direction = new Vector3(x, y, z);
        direction = direction.normalized;

        Vector3 d = (CamFwd * direction.z + CamRt * direction.x + new Vector3(0, direction.y, 0));
        Vector3 moveDirection = d.normalized;

        #endregion

        #region Movement
        rb.AddForce(moveDirection * force);

        if (rb.velocity.magnitude >= SPD)
        {
            rb.drag = 0.3f;
            rb.AddForce(-(rb.velocity.normalized) * force * counterForceMagnitude);
        }

        if (x == 0 && z == 0)
        {
            rb.drag = stopFacter;
        }

        if (rb.velocity.magnitude <= 15)
            isSprinting = false;

        #endregion

        #region Sprint
        if (isSprinting)
        {
            SPD = SprintSpeed;
            _fov = Mathf.Lerp(_fov, SprintFOV, 0.05f);
        }
        else
        {
            SPD = maxSpeed;
            _fov = Mathf.Lerp(_fov, FOV, 0.05f);
        }
        #endregion

        #region Camera Management
        _cam.m_Lens.FieldOfView = _fov;

        if (rb.velocity.magnitude >= 0.5f && new Vector3(x, y, z).magnitude != 0)
        {
            playerMesh.rotation = Quaternion.LookRotation(CamFwd);

        }
        #endregion

        #region Dodge
        if (isDodgeing)
        {
            Vector3 DDirection;
            if (Mathf.Abs(x) > 0)
            {
                DDirection = new Vector3(x, 0, 0);
            }
            else if (Mathf.Abs(z) > 0)
            {
                DDirection = new Vector3(0, 0, z);
            }
            else
            {
                DDirection = new Vector3(0, 0, -1f);
            }

            DDirection = (CamFwd * direction.z + CamRt * direction.x + new Vector3(0, direction.y, 0));
            rb.AddForce(DDirection.normalized * DodgeForce);
        }
        #endregion
    }
}
