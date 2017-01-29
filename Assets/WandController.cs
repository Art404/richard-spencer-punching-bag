using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour
{
    public GameObject projectile;
    public GameObject paintObj;
    public float projectile_force;
    public Collider glove;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId touchButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    private GameObject pickup;


    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    private Transform reference
    {
        get
        {
            var top = SteamVR_Render.Top();
            return (top != null) ? top.origin : null;
        }
    }

    private SteamVR_TrackedObject trackedObj;

    // Use this for initialization
    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        // equip the gloves and position them "over" the controllers

        if (glove != null && pickup == null)
        {
            glove.transform.position = this.transform.position;
            // TODO: not hard code transform position and
            // explicitly check for object names ... T_T
            glove.transform.Rotate(180, 0, 0);
            float _x = (float)(-0.1);
            float _z = (float)(0.2);
            if (glove.gameObject.name == "glove_right")
            {
                glove.transform.Translate(_x, 0, _z);
            } else
            {
                glove.transform.Translate(-_x, 0, _z);
            }
        
            pickup = glove.gameObject;
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (controller.GetPressUp(touchButton))
        {
            // 
        }
    }
}
