#pragma warning disable 0414 // private field assigned but not used.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manages car control input and configuration locally without networking.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Local/RCC Local Network")]
public class RCC_LocalControl : MonoBehaviour
{

    // Main RCC, Rigidbody, and WheelColliders. 
    private RCC_CarControllerV3 carController;
    private RCC_WheelCollider[] wheelColliders;
    private Rigidbody rigid;

    // Variables for storing car states and configurations locally.
    private float updateTime = 0;

    private VehicleInput currentVehicleInputs = new VehicleInput();
    private VehicleTransform currentVehicleTransform = new VehicleTransform();
    private VehicleLights currentVehicleLights = new VehicleLights();

    bool CB_running = false;

    // Structs for storing the state of the car
    #region STRUCTS

    #region Transform

    public struct VehicleTransform
    {
        public Vector3 position;
        public Quaternion rotation;

        public Vector3 rigidLinearVelocity;
        public Vector3 rigidAngularVelocity;
    }

    #endregion Transform

    #region Inputs

    public struct VehicleInput
    {
        public float gasInput;
        public float brakeInput;
        public float steerInput;
        public float handbrakeInput;
        public float boostInput;
        public float clutchInput;
        public float idleInput;
        public int gear;
        public int direction;
        public bool changingGear;
        public float fuelInput;
        public bool engineRunning;
        public bool canGoReverseNow;
    }

    #endregion Inputs

    #region Lights

    public struct VehicleLights
    {
        public bool lowBeamHeadLightsOn;
        public bool highBeamHeadLightsOn;
        public RCC_CarControllerV3.IndicatorsOn indicatorsOn;
    }

    #endregion Lights

    #endregion

    void Start()
    {
        // Getting RCC, wheelcolliders, rigidbody of the vehicle.
        carController = GetComponent<RCC_CarControllerV3>();
        wheelColliders = GetComponentsInChildren<RCC_WheelCollider>();
        rigid = GetComponent<Rigidbody>();

        // Allow player to control the vehicle.
        carController.externalController = false;
        carController.SetCanControl(true);

        currentVehicleTransform = new VehicleTransform();
    }

    void FixedUpdate()
    {
        // Handle local player inputs.
        if (!CB_running)
            StartCoroutine(HandlePlayerInputs());
    }

    IEnumerator HandlePlayerInputs()
    {
        CB_running = true;

        // Capture player inputs from the car controller.
        currentVehicleInputs.gasInput = carController.gasInput;
        currentVehicleInputs.brakeInput = carController.brakeInput;
        currentVehicleInputs.steerInput = carController.steerInput;
        currentVehicleInputs.handbrakeInput = carController.handbrakeInput;
        currentVehicleInputs.boostInput = carController.boostInput;
        currentVehicleInputs.clutchInput = carController.clutchInput;
        currentVehicleInputs.idleInput = carController.idleInput;
        currentVehicleInputs.gear = carController.currentGear;
        currentVehicleInputs.direction = carController.direction;
        currentVehicleInputs.changingGear = carController.changingGear;
        currentVehicleInputs.fuelInput = carController.fuelInput;
        currentVehicleInputs.engineRunning = carController.engineRunning;
        currentVehicleInputs.canGoReverseNow = carController.canGoReverseNow;

        // Handle lights input locally.
        currentVehicleLights.lowBeamHeadLightsOn = carController.lowBeamHeadLightsOn;
        currentVehicleLights.highBeamHeadLightsOn = carController.highBeamHeadLightsOn;
        currentVehicleLights.indicatorsOn = carController.indicatorsOn;

        yield return new WaitForSeconds(.02f);

        // Update transform locally.
        currentVehicleTransform.position = transform.position;
        currentVehicleTransform.rotation = transform.rotation;
        currentVehicleTransform.rigidLinearVelocity = rigid.velocity;
        currentVehicleTransform.rigidAngularVelocity = rigid.angularVelocity;

        yield return new WaitForSeconds(.02f);

        CB_running = false;
    }
}
