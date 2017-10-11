using UnityEngine;

public abstract class ModelingScript : MonoBehaviour
{
	protected Manager manager;
	
	public void Init(Manager manager) {
		this.manager = manager;
	}

	protected void UseCommand(DistributedCommand command) {
		manager.UseCommand(command);
	}
}