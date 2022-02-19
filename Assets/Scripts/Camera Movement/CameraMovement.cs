using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   Transform targetAngle;

   [SerializeField] TankService tankService; 

  [SerializeField] float OffsetX = 4f;
  [SerializeField] float OffsetZ = 20f;

   [SerializeField] float lerRate; 


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
        float xAxis = Mathf.Lerp(transform.position.x,tankService.tankTransform.position.x,lerRate);
        float zAxis = Mathf.Lerp(transform.position.z,tankService .tankTransform.position.z,lerRate);

        transform.position = new Vector3(xAxis - OffsetX,transform.position.y, zAxis - OffsetZ );
   }

  
    

   void cameraRotation()
   {
       targetAngle = tankService.tankTransform;

       transform.LookAt(targetAngle);
   }
}
    




  