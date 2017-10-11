using UnityEngine;

public class DistributedObject
{
	public readonly DistributedObjectView clinet1View;
	public readonly DistributedObjectView serverView;
	public readonly DistributedObjectView clinet2View;
	private readonly Manager manager;

	public DistributedObject(GameObject prototipe, Manager manager)
	{
		this.manager = manager;
		clinet1View = GenerateView(prototipe, manager.client1Line);
		serverView = GenerateView(prototipe, manager.serverLine);
		clinet2View = GenerateView(prototipe, manager.client2Line);
		manager.AddUnit(this);
	}

	private DistributedObjectView GenerateView(GameObject prototipe, GameObject position)
	{
		GameObject result = GameObject.Instantiate<GameObject>(prototipe);
		DistributedObjectView view = result.GetComponent<DistributedObjectView>();
		view.Distributed = this;
		view.SetPosition(position.transform.position);
		return view;
	}

	public void UpdateByTime(float time)
	{
		clinet1View.UpdateByTime(time);
		serverView.UpdateByTime(time);
		clinet2View.UpdateByTime(time);
	}

	public float ZeroX {
		get {
			return manager.zeroX;
		}
	}
}
