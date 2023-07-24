using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    //---Bound in Unity Editor---
    [SerializeField]
    private Vector2 MinPosition;
    [SerializeField]
    private Vector2 MaxPosition;
    [SerializeField]
    private Vector2 PlayerPush;
    [SerializeField]
    private float CamSize;

    //---Dynamically Set---
    private CameraController Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SetCamConstraints();
            PushPlayer(collision.gameObject);
        }
    }

    void SetCamConstraints()
    {
        Camera.CamSize = CamSize;
        Camera.MinPosition = MinPosition;
        Camera.MaxPosition = MaxPosition;
        Debug.Log("Setting constraints");
    }
    void PushPlayer(GameObject player)
    {
        Vector3 push = new Vector3(PlayerPush.x, PlayerPush.y, player.transform.position.z);
        player.transform.position += push;
    }
}
