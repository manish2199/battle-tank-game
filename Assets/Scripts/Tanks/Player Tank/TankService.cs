using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{    
    [SerializeField] TankView tankPrefab;
    
    TankModel tankModel;

    PlayerTankController tankController;

    public Transform tankPosition;
    
    protected override void Awake()
	{
		base.Awake();
	}

    void Start()
    {
       tankModel = new TankModel(6f,350f);
       tankController = new PlayerTankController(tankModel,tankPrefab , tankPosition);
    }

}
