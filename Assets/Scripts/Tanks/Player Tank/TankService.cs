using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{    
    [SerializeField] TankView tankPrefab;
    
    TankModel tankModel;

    PlayerTankController tankController;

    [SerializeField]  Transform tankInstantiatePosition;

    [HideInInspector] public Transform tankTransform;


    protected override void Awake()
	{
		base.Awake();
	}

    void Start()
    {
       tankModel = new TankModel(6f,250f);
       tankController = new PlayerTankController(tankModel, tankPrefab , tankInstantiatePosition);
       tankTransform = tankController.TankV.TankTransform;
    }


}
