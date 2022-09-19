using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class placeOnPlace : MonoBehaviour
{
    public GameObject arPrefab;
    public GameObject arSessionOrigin;
    ARRaycastManager aRRaycastManager;
     GameObject spawned;

    List<ARRaycastHit> ray_hits = new List<ARRaycastHit>();

    Touch touch;
    Vector2 touchPosiition;

    private void Awake() {
        aRRaycastManager = arSessionOrigin.GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosiition = touch.position;

            if(aRRaycastManager.Raycast(touchPosiition, ray_hits,TrackableType.PlaneWithinBounds))
            {
               Pose hitPose = ray_hits[0].pose;
               if(spawned == null)
               {
                 spawned = Instantiate(arPrefab,hitPose.position,hitPose.rotation);
               }
            }
        }
    }
}
