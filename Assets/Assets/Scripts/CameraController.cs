using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //---Accessed by Room Controller---
    public Vector2 MinPosition;
    public Vector2 MaxPosition;
    public float CamSize;

    //---Bound in Unity Editor---
    [SerializeField]
    private Transform Target; //Should be player???


    //---Set Dynamically---
    private Camera MainCam;

    // Start is called before the first frame update
    void Start()
    {
        MainCam = GetComponent<Camera>();  //Sets Camera from self
    }

    // Update is called once per frame
    void Update()
    {
        ConstrainCamera();
    }

    void ConstrainCamera()
    {
        if (Target != null)
        {
            //Follow Target
            transform.position = new Vector3 (Target.position.x, Target.position.y, transform.position.z);

            //Keep min/max
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, MinPosition.x, MaxPosition.x);
            pos.y = Mathf.Clamp(pos.y, MinPosition.y, MaxPosition.y);
            transform.position = pos;
        }
    }

    
}
