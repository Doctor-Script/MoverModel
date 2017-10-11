using UnityEngine;

public class Ship : DistributedObjectView
{
	private float speed = 1f;

	public override void SetPosition(Vector3 position) {
		transform.position = new Vector3(Distributed.ZeroX, position.y + 1f, position.z);
	}

	public class MoveCommand : DistributedCommand<Ship>
	{
		public MoveCommand(DistributedObjectView sender, float time) : base(sender, time) { }

		public override void UpdateTime(Ship view, float time, float startTime) {
			view.X = GetMovingTime(time, startTime) * view.speed;
		}

		private float GetMovingTime(float time, float startTime)
		{
			float result = time - startTime;
			if (result < 0f) {
				return 0f;
			}
			return result;
		}
	}
}