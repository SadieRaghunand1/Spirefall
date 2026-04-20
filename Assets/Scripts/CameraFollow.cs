using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;


    //OLD
    // Update is called once per frame
    /*void Update()
    {
        transform.position = playerPos.position + offset;
    }*/

    //NEW
    //Removed code, camera now moves based on its attachement to the player object
}
