using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PursuitMode : MonoBehaviour
{
    [SerializeField] private Transform CamAnchor;
    [SerializeField] private List<AxleInfo> Axles;
    [SerializeField] float PowerDistribution = 0.5f;
    [SerializeField] float Power, MaxSteeringAngle, BrakingForce, BrakingDistribution;


    private float RearPowerDist, FrontPowerDist, InputIntensity,
                    steeringIn, steering,
                    FrontBrakeDist, BackBrakeDist;
    private float brakes;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        FrontPowerDist = 1 - PowerDistribution;
        RearPowerDist = PowerDistribution;
        FrontBrakeDist = 1 - BrakingDistribution;
        BackBrakeDist = BrakingDistribution;

        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        foreach (AxleInfo info in Axles)
        {
            info.LeftWheel.enabled = true;
            info.RightWheel.enabled = true;
            info.LeftWheelT.gameObject.GetComponent<SphereCollider>().enabled = false;
            info.RightWheelT.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    void OnDisable()
    {
        foreach (AxleInfo info in Axles)
        {
            info.LeftWheel.enabled = false;
            info.RightWheel.enabled = false;
            info.LeftWheelT.gameObject.GetComponent<SphereCollider>().enabled = true;
            info.RightWheelT.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float steer = steeringIn * MaxSteeringAngle;
        float motor = InputIntensity * Power;


        foreach (AxleInfo axleInfo in Axles)
        {
            if (axleInfo.steer)
            {
                axleInfo.LeftWheel.steerAngle = steer;
                axleInfo.RightWheel.steerAngle = steer;
            }
            if (brakes > 0 && rb.velocity.magnitude < 0.2f)
            {
                axleInfo.LeftWheel.motorTorque = -1 * Power;
                axleInfo.RightWheel.motorTorque = -1 * Power;
            }
            if (brakes > 0.01)
            {
                axleInfo.LeftWheel.brakeTorque = brakes * BrakingForce;
                axleInfo.RightWheel.brakeTorque = brakes * BrakingForce;
            }
            if (brakes == 0)
            {
                axleInfo.LeftWheel.brakeTorque = 0.0f;
                axleInfo.RightWheel.brakeTorque = 0.0f;
            }
            if (axleInfo.motor)
            {
                axleInfo.LeftWheel.motorTorque = motor;
                axleInfo.RightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.LeftWheel, axleInfo.LeftWheelT);
            ApplyLocalPositionToVisuals(axleInfo.RightWheel, axleInfo.RightWheelT);
        }
    }

    void Update()
    {
        //CamAnchor.eulerAngles = Vector3.Lerp(CamAnchor.rotation.eulerAngles, rb.velocity.normalized, 0.5f);
    }

    public void OnAccelerate(InputValue input)
    {
        InputIntensity = input.Get<float>();

    }

    public void OnSteering(InputValue input)
    {
        steeringIn = input.Get<Vector2>().x;
    }

    public void OnBrake(InputValue value)
    {
        float brakeIntensity = value.Get<float>();
        brakes = brakeIntensity;
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.transform.position = position;
        transform.transform.rotation = rotation;
    }



}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider LeftWheel;
    public Transform LeftWheelT;
    public WheelCollider RightWheel;
    public Transform RightWheelT;
    public bool motor;
    public bool steer;
}
