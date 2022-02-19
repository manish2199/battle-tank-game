using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{    
    
    [SerializeField] TankScriptableObjectList tankScriptableObjectList;
    
    [SerializeField]  Transform tankInstantiatePosition;
    
    TankModel tankModel; 
    
    PlayerTankController tankController;

    [HideInInspector] public Transform tankTransform;

    protected override void Awake()
	{
		base.Awake();
	}

    void Start()
    {
      
       instantiateTank(); 

    }
 
    void instantiateTank()
    {

       TankScriptableObject tank = getRandomTank();
        
       tankModel = new TankModel(tank);
       tankController = new PlayerTankController(tankModel,tank.tankPrefab, tankInstantiatePosition);
       tankTransform = tankController.TankV.TankTransform;

    }

    TankScriptableObject getRandomTank()
    {
        int max =(tankScriptableObjectList.tankLists.Length - 1);
        TankScriptableObject tank = tankScriptableObjectList.tankLists[getRandomNumber(0,max)];
       return tank;
    }


    int getRandomNumber(int max , int min)
    {
        return Random.Range(max,min);    
    }


}
