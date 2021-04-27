using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class SnapTurn : MonoBehaviour
{
    public XRNode inputSource;
    public XRRig inputRig;
    public XRInteractorLineVisual lineRendering;
    private float curVAL;
    // Start is called before the first frame update
    void Start()
    {
        curVAL = 0;
        lineRendering.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputAxis);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggered);
        if ((inputAxis[0] > 0.3) && (curVAL <= 0.3))
        {
            inputRig.RotateAroundCameraUsingRigUp(45);
            curVAL = inputAxis[0];
        }
        else if (((inputAxis[0] < -0.3) && (curVAL >= -0.3)))
        {
            inputRig.RotateAroundCameraUsingRigUp(-45);
            curVAL = inputAxis[0];
        }
        if (triggered) lineRendering.enabled = true;
        else lineRendering.enabled = false;
        curVAL = inputAxis[0];
    }
}
