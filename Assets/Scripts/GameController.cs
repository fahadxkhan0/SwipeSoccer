using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    [SerializeField]
    GameObject ballPrefab;

    GameObject ballinstance;

    
    [SerializeField]
    float ballForce;

    Vector3 mouseStart;
    Vector3 mouseEnd;
    float minSwipeDistance = 15f;
    float zDepth = 30f;

    // Start is called before the first frame update
    void Start()
    {
        CreateBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            mouseStart = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0)){
            mouseEnd = Input.mousePosition;

            if(Vector3.Distance(mouseEnd, mouseStart) > minSwipeDistance){
                Vector3 hitPose= new Vector3(Input.mousePosition.x,Input.mousePosition.y,zDepth);
                hitPose = Camera.main.ScreenToWorldPoint(hitPose);
                ballinstance.transform.LookAt(hitPose);
                ballinstance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ballForce , ForceMode.Impulse);
                Invoke("CreateBall",2f);

        }  
        }
      

    }

    void CreateBall(){
        ballinstance = Instantiate(ballPrefab,ballPrefab.transform.position,Quaternion.identity) as GameObject;

    }
}
