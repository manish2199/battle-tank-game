using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   Transform targetAngle;

  Transform playerTankTransform; 

  [SerializeField] float OffsetX = 4f;
  [SerializeField] float OffsetZ = 20f;

   [SerializeField] float lerRate; 

  void Start()
  {
      playerTankTransform = PlayerTankService.Instance.tankTransform;
  }


   void Update()
   {
      cameraMovement();     
   }

   void LateUpdate()
   {
       cameraRotation();
   }


   void cameraMovement()
   {
       if(playerTankTransform != null)
       {
        float xAxis = Mathf.Lerp(transform.position.x,playerTankTransform.position.x,lerRate);
        float zAxis = Mathf.Lerp(transform.position.z,playerTankTransform.position.z,lerRate);

        transform.position = new Vector3(xAxis - OffsetX,transform.position.y, zAxis - OffsetZ );
       }
   }

  
    

   void cameraRotation()
   {
       targetAngle = playerTankTransform;

       transform.LookAt(targetAngle);
   }
}
    




  