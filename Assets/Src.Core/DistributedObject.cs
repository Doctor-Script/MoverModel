using UnityEngine;

public class DistributedObject
{
	public readonly DistributedObjectView clinet1View;
	public readonly DistributedObjectView serverView;
	public readonly DistributedObjectView clinet2View;

	public DistributedObject(GameObject prototipe, Manager manager, float x)
	{
		clinet1View = GenerateView(prototipe, manager.client1Line, x);
		serverView = GenerateView(prototipe, manager.serverLine, x);
		clinet2View = GenerateView(prototipe, manager.client2Line, x);
		manager.AddUnit(this);
	}

	public DistributedObject(GameObject prototipe, Manager manager) : this(prototipe, manager, 0f) { }

	private DistributedObjectView GenerateView(GameObject prototipe, GameObject position, float x)
	{
		GameObject result = GameObject.Instantiate<GameObject>(prototipe);
		DistributedObjectView view = result.GetComponent<DistributedObjectView>();
		view.Distributed = this;
		view.SetPosition(position.transform.position + new Vector3(Manager.ZERO_X + x, 0f, 0f));
		return view;
	}

	public void UpdateByTime(float time)
	{
		clinet1View.UpdateByTime(time);
		serverView.UpdateByTime(time);
		clinet2View.UpdateByTime(time);
	}
}
