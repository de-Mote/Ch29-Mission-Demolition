using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    static public FollowCam S;
    public bool _____________________________;
    public GameObject poi;
    public float camZ;
    public Vector2 minXY;

    public float easing = 0.05f;
    void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }
    void Update()
    {
        // if there's only one line following an if, it doesn't need braces
        if (poi == null) return; // return if there is no poi
        // Get the position of the poi
        Vector3 destination = poi.transform.position;
        // Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        // Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        // Retain a destination.z of camZ
        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
        // Set the orthographicSize of the Camera to keep Ground in view
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }
}
