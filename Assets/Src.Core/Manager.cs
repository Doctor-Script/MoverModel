using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
	public ModelingScript modelingScript;

	public GameObject client1Line;
	public GameObject serverLine;
	public GameObject client2Line;

	public MediaPlayerUI playerUI;

	public readonly float zeroX = -7;

	private List<DistributedObject> units = new List<DistributedObject>();
	private List<DistributedCommand> commands = new List<DistributedCommand>();

	void Awake() {
		modelingScript.Init(this);
	}

	void Update()
	{
		foreach (var command in commands) {
			command.UpdateTimeAll(playerUI.CurrentTime);
		}

		foreach (var unit in units) {
			unit.UpdateByTime(playerUI.CurrentTime);
		}
	}

	public void AddUnit(DistributedObject unit) {
		units.Add(unit);
	}

	public void UseCommand(DistributedCommand command) {
		commands.Add(command);
	}
}