using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class SnapTurn : MonoBehaviour
{
    public XRNode inputSource;
    public XRRig inputRig;
    private float curVAL;
    // Start is called before the first frame update
    void Start()
    {
        curVAL = 0;     
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputAxis);

        if ((inputAxis[0] > 0.3) && (curVAL <= 0.3))
        {
            Debug.Log("Should be turning right");
            inputRig.RotateAroundCameraUsingRigUp(45);
            curVAL = inputAxis[0];
        }
        else if (((inputAxis[0] < -0.3) && (curVAL >= -0.3)))
        {
            Debug.Log("Should be turning left");
            inputRig.RotateAroundCameraUsingRigUp(-45);
            curVAL = inputAxis[0];
        }
        curVAL = inputAxis[0];
    }
}
