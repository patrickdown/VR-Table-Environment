using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignPlayer : MonoBehaviour
{

    public GameObject cameraRig;
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Equals))
        {
            var headPos = head.transform.position;
            headPos.y = 0;

            var headForward = head.transform.forward;
            headForward.y = 0;
            headForward.Normalize();

            var playerPos = transform.position;
            playerPos.y = 0;

            var playerForward = -playerPos.normalized;

            var rigPos = cameraRig.transform.position;
            rigPos.y = 0;

            var centerDist = (headPos - rigPos).magnitude;

            var headDirToRigDir = Quaternion.FromToRotation(headForward, rigPos-headPos);

            var newPos = playerPos + headDirToRigDir * playerForward * centerDist;
            newPos.y = cameraRig.transform.position.y;

            cameraRig.transform.position = newPos;
            cameraRig.transform.rotation = Quaternion.FromToRotation(headForward, playerForward);
        }
    }
}
