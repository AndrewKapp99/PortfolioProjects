using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CharMove : MonoBehaviour
{
    #region Values
    [Header("Movement")]
    [SerializeField] private float ForceOutput;
    [SerializeField] public bool BattleMode;
    [SerializeField] private float BattleSpeed;
    private Vector3 moveVec;
    private Vector3 looking;
    private Rigidbody rb;

    public Vector2 InVector;

    [Header("Camera")]
    [SerializeField] private Transform CamAnchor;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform PlayerMesh;
    public Vector3 lookVec;

    [Header("Transforms")]
    [SerializeField] private Transform WheelArmFL;
    [SerializeField] private Transform WheelArmFR, WheelArmBL, WheelArmBR, MainBody, Cannon;
    [SerializeField] private Cannon cn;
    [SerializeField] private RotateToFace rtf;

    [Header("Misc")]
    public bool Underpower;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        cn.enabled = true;
        rtf.enabled = true;
        ReadyUp();
        PlayerMesh.localRotation = Quaternion.Euler(new Vector3(CamAnchor.localRotation.x, CamAnchor.localRotation.y, CamAnchor.localRotation.z));
    }

    void OnDisable()
    {
        cn.enabled = false;
        rtf.enabled = false;
        ChillOut();
        rb.rotation = PlayerMesh.rotation;
        PlayerMesh.localRotation = Quaternion.identity;
        CamAnchor.localRotation = Quaternion.identity;
    }

    public void Update()
    {
        looking = Camera.forward;
        
        #region Boolean Control
        if (InVector.magnitude != 0 && BattleMode)
        {
            Underpower = true;
        }
        else
        {
            Underpower = false;
        }
        #endregion
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 CamFwd = Camera.forward;
        Vector3 CamRt = Camera.right;

        CamFwd.y = 0f;
        CamRt.y = 0f;

        moveVec = moveVec.normalized;

        Vector3 d = (CamFwd * moveVec.z + CamRt * moveVec.x);

        #region Movement - BattleMode
        if (BattleMode)
        {
            rb.AddForce(d.normalized * ForceOutput);
            if (rb.velocity.magnitude >= BattleSpeed)
            {
                rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
            }
        }
        #endregion
    }

    void ReadyUp()
    {
        WheelArmFL.DOLocalMove(new Vector3(-0.03f, 0, 0), 0.3f);
        WheelArmFR.DOLocalMove(new Vector3(0.03f, 0, 0), 0.3f);
        WheelArmBL.DOLocalMove(new Vector3(-0.03f, 0, 0), 0.3f);
        WheelArmBR.DOLocalMove(new Vector3(0.03f, 0, 0), 0.3f);
        Cannon.DOLocalMove(new Vector3(0f, 9f, -4f), 0.03f);
    }

    void ChillOut()
    {
        WheelArmFL.DOLocalMove(new Vector3(-0.0f, 0, 0), 0.3f);
        WheelArmFR.DOLocalMove(new Vector3(0.0f, 0, 0), 0.3f);
        WheelArmBL.DOLocalMove(new Vector3(-0.0f, 0, 0), 0.3f);
        WheelArmBR.DOLocalMove(new Vector3(0.0f, 0, 0), 0.3f);
        Cannon.DOLocalMove(new Vector3(0f, 4.2f, -4f), 0.3f);
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        InVector = inputVec;
        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
        //PlayerMesh.GetComponent<RotateToFace>().rotateToFace(CamAnchor.rotation);
    }
}
