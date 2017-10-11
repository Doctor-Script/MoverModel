using UnityEngine;

public class PointEffect : DistributedObjectView
{
	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public class SpawnCommand : DistributedCommand<PointEffect>
	{
		public SpawnCommand(DistributedObjectView sender, float time) : base(sender, time) { }

		public override void UpdateTime(PointEffect view, float time, float startTime)
		{
			view.X = 2f;
			view.spriteRenderer.enabled = time > startTime;
		}
	}
}