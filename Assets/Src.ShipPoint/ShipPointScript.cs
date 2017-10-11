using UnityEngine;

public class ShipPointScript : ModelingScript
{
	public GameObject shipPrefab;
	public GameObject pointPrefab;

	private DistributedObject unit;
	private DistributedObject point;
	
	void Start()
	{
		unit = GenerateShip();
		point = GeneratePoint(3f);

		UseCommand(new Ship.MoveCommand(unit.clinet1View, 1f));
		UseCommand(new PointEffect.SpawnCommand(point.clinet1View, 2f));
		UseCommand(new PointEffect.ConfirmCommand(point.serverView, 5f));
	}

	public DistributedObject GenerateShip() {
		return new DistributedObject(shipPrefab, manager);
	}

	public DistributedObject GeneratePoint(float x) {
		return new DistributedObject(pointPrefab, manager, x);
	}
}
