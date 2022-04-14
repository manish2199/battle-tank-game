using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] GameObject[] enviourmentalGameObjects;

    bool startDestroyingEnviorment = false;


   private void OnEnable()
  {
      PlayerTankService.OnPlayerDeath += startCoroutine;
  }

  private void OnDisable()
  {
      PlayerTankService.OnPlayerDeath -= startCoroutine;
  }

   void startCoroutine()
   {
       StartCoroutine(startDestruction());
   }


    IEnumerator startDestruction()
    {
       for(int i = 0; i< enviourmentalGameObjects.Length; i++)
       {
            Destroy(enviourmentalGameObjects[i]);

            yield return new WaitForSeconds(1f);
       }
    }
}
