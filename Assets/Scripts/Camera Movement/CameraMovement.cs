using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float DampTime = 0.2f; 
    [SerializeField] float ScreenEdgeBuffer = 4f; 
    [SerializeField] float MinSize  = 6.5f;
    [SerializeField]Camera camera;


    Transform target; 
    float ZoomSpeed;
    Vector3 MoveVelocity;
    Vector3 DesiredPosition;


    private void FixedUpdate()
    {
       target = PlayerTankService.Instance.tankTransform;

        if(target != null)
        {
          Move();

          Zoom();
        }
    }
 

    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position,DesiredPosition, ref MoveVelocity , DampTime);
    }

    private async void FindAveragePosition()
    {
       Vector3 averagePos = new Vector3();
       int numTarget = 0; 
        
    //   for(int i= 0;  i<target.Length;  i++)
    //   {
        // {
        //   continue;
        // }
        // else
        if( target.gameObject.activeSelf )
        {
        averagePos += target.position;
        numTarget++;
        }
    //   }

      if(numTarget > 0)
        averagePos /= numTarget;


      averagePos.y = transform.position.y;

      DesiredPosition = averagePos;

    } 


    private void Zoom()
    {
       float RequiredSize = FindRequiredSize();
       camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, RequiredSize , ref ZoomSpeed , DampTime);
    }

    private float FindRequiredSize()
    { 
        Vector3 DesiredLocalPos = transform.InverseTransformPoint(DesiredPosition);
        
        float size = 0f;

        // for(int i=0; i<target.Length; i++)
        // {
        if(target.gameObject.activeSelf )
        {   // continue;

          Vector3 targetLocalPos = transform.InverseTransformPoint(target.position);

          Vector3 desiredPosToTarget = targetLocalPos - DesiredLocalPos;

          size = Mathf.Max( size , Mathf.Abs(desiredPosToTarget.y));

          size = Mathf.Max( size , Mathf.Abs(desiredPosToTarget.x) / camera.aspect );
        }

        size += ScreenEdgeBuffer;

        size = Mathf.Max(size , MinSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {  
         FindAveragePosition();

         transform.position = DesiredPosition;

         camera.orthographicSize = FindRequiredSize();

    }


// //   Transform targetAngle;

//   Transform playerTankTransform; 

//   [SerializeField] float OffsetX = 4f;
//   [SerializeField] float OffsetZ = 20f;

//    [SerializeField] float lerpRate; 

//   void Start()
//   {
//   }


//    void Update()
//    {
//       cameraMovement();     
//    }

//    void LateUpdate()
//    {
//        cameraRotation();
//    }


//    void cameraMovement()
//    {
//        playerTankTransform = PlayerTankService.Instance.tankTransform;
//        if(playerTankTransform != null)
//        {
//         float xAxis = Mathf.Lerp(transform.position.x,playerTankTransform.position.x,lerpRate);
//         float zAxis = Mathf.Lerp(transform.position.z,playerTankTransform.position.z,lerpRate);

//         transform.position = new Vector3(xAxis - OffsetX,transform.position.y, zAxis - OffsetZ );

//         transform.LookAt(playerTankTransform);
//        } 
//    }


//    void cameraRotation()
//    {
//     //    targetAngle = playerTankTransform; 

       
//    }
}
    




  