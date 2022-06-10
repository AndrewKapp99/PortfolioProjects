using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class BattleMode : MonoBehaviour
{
    [SerializeField] private WheelCollider BattleWheel;
    [SerializeField] private Transform WheelArmFL, WheelArmFR, WheelArmBL, WheelArmBR, MainBody;
    public float power;

    private float angle;
    public bool moving;
    private Vector2 inVec;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        BattleWheel.enabled = true;
        ReadyUp();
    }
    void OnDisable()
    {
        BattleWheel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inVec.magnitude != 0)
        {
            moving = true;
        }

        if (inVec.magnitude == 0)
        {
            moving = false;
        }
    }

    void FixedUpdate()
    {
        float steer = angle;
        float motor = power * inVec.normalized.magnitude;
        if (!moving)
        {
            motor = 0.0f;
        }

        BattleWheel.motorTorque = motor;
        BattleWheel.steerAngle = angle;
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.transform.position = position;
        transform.transform.rotation = rotation;
    }

    public void RotateToFace(Vector3 Direction)
    {
        if (transform.localRotation.eulerAngles == Direction)
        {
            return;
        }

    }

    void OnMove(InputValue value)
    {
        inVec = value.Get<Vector2>();
        angle = Mathf.Atan2(inVec.x, inVec.y);

        angle = angle * 180 / Mathf.PI;
    }

    void ReadyUp()
    {
        WheelArmFL.DOMove(new Vector3(-0.03f, 0, 0), 0.3f);
        WheelArmFR.DOMove(new Vector3(0.03f, 0, 0), 0.3f);
        WheelArmBL.DOMove(new Vector3(-0.03f, 0, 0), 0.3f);
        WheelArmBR.DOMove(new Vector3(0.03f, 0, 0), 0.3f);
    }
}

[System.Serializable]
public class Axle
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform rightT, leftT;
    public float Distribution;
}
