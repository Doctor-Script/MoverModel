using UnityEngine;

public class PointEffect : DistributedObjectView
{
	private float startTime = 0f;
	private float endTime = float.PositiveInfinity;
	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public override void UpdateByTime(float time) {
		spriteRenderer.enabled = time > startTime && time < endTime;
	}

	public class SpawnCommand : DistributedCommand<PointEffect>
	{
		public SpawnCommand(DistributedObjectView sender, float time) : base(sender, time) { }

		public override void UpdateTime(PointEffect view, float time, float startTime, float lag) {
			view.startTime = startTime;
		}
	}

	public class ConfirmCommand : DistributedCommand<PointEffect>
	{
		public ConfirmCommand(DistributedObjectView sender, float time) : base(sender, time) { }

		public override void UpdateTime(PointEffect view, float time, float startTime, float lag) {
			view.endTime = startTime;
		}
	}

}