using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // The static point of interest             // a

    [Header("Inscribed")]
    public float easing = 0.05f;
    public Vector2    minXY  = Vector2.zero;

    [Header("Dynamic")]
    public float camZ; // The desired Z pos of the camera 

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate () {
        Vector3 destination = Vector3.zero;
        if ( POI != null ) {
            Rigidbody poiRigid = POI.GetComponent<Rigidbody>();
            if ( ( poiRigid != null ) && poiRigid.IsSleeping() ) {            // d
                POI = null;
            }
        }
        if ( POI != null ) {
            destination = POI.transform.position;
        }
        destination.x = Mathf.Max( minXY.x, destination.x );
        destination.y = Mathf.Max( minXY.y, destination.y );
        // Force destination.z to be camZ to keep the camera far enough away
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
    }
    // void Start() {…}  // Please delete the unused Start() and Update() methods
    // void Update() {…}
}
    
