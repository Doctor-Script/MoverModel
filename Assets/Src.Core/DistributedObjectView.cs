using UnityEngine;

public class DistributedObjectView : MonoBehaviour
{
	private DistributedObject distributedObject;
	private float x;

	public virtual void SetPosition(Vector3 position) {
		transform.position = position;
	}

	public virtual void UpdateByTime(float time) { }

	public float X
	{
		get {
			return x;
		}
		set
		{
			if (value < 0f) {
				value = 0f;
			}
			x = value;
			transform.position = new Vector3(x + Manager.ZERO_X, transform.position.y, transform.position.z);
		}
	}

	public DistributedObject Distributed {
		get {
			return distributedObject;
		}
		internal set {
			distributedObject = value;
		}
	}
}