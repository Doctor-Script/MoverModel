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
		point = GeneratePoint();

		UseCommand(new Ship.MoveCommand(unit.clinet1View, 1f));
		UseCommand(new PointEffect.SpawnCommand(point.clinet1View, 3f));
	}

	public DistributedObject GenerateShip() {
		return new DistributedObject(shipPrefab, manager);
	}

	public DistributedObject GeneratePoint() {
		return new DistributedObject(pointPrefab, manager);
	}
}
