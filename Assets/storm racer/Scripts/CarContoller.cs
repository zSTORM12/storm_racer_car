using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    //Inputs variable:
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private float currentbreakForce;
    private float currentsteerAngle;
    private bool isBreaking;

    [SerializeField] public float motorForce = 1000f;
    [SerializeField] public float breakForce;
    [SerializeField] public float maxSteerAngle;
    [SerializeField] private float boostSpeed = 4000f;



    //WheelColliders:
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    //Wheels Transforms(mesh)
    //WheelColliders:
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    
    //Center Of Mass
    public float mass = -0.9f;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, mass, 0f);
    }
   
    //Update the code constantly
    private void FixedUpdate() 
    { 
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        BoostTorque();
    }

    // Inputs = Controlls of the car
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    //Engine controller
    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        backLeftWheelCollider.motorTorque = verticalInput * motorForce;
        backRightWheelCollider.motorTorque = verticalInput * motorForce;

        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();  
        
    }

    private void ApplyBreaking()
    {
        //frontLeftWheelCollider.brakeTorque = currentbreakForce;
        //frontRightWheelCollider.brakeTorque = currentbreakForce;
        backLeftWheelCollider.brakeTorque = currentbreakForce;
        backRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentsteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentsteerAngle;
        frontRightWheelCollider.steerAngle = currentsteerAngle;
    }
    
    private void UpdateWheels()
    {
        UpdateSingleWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheels(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheels(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheels(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
    }

    private void BoostTorque()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            frontLeftWheelCollider.motorTorque = motorForce * 50;
            frontRightWheelCollider.motorTorque = motorForce * 50;
            backLeftWheelCollider.motorTorque = motorForce * 50;
            backRightWheelCollider.motorTorque = motorForce * 50;
        }
        
    }
    
}
