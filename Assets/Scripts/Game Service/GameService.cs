using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] GameObject[] enviourmentalGameObjects;

    bool startDestroyingEnviorment = false;


    // Update is called once per frame
    void Update()
    {
       if( PlayerTankService.Instance.IsPlayerDied && !startDestroyingEnviorment && EnemyTankService.Instance.enemiesDies)
       {
           startCoroutine();
       }    
    }


   void startCoroutine()
   {
       if(!startDestroyingEnviorment)
      {
       startDestroyingEnviorment = true;
       StartCoroutine(startDestruction());
      }
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
