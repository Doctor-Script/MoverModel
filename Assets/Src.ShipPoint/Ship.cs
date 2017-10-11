﻿using UnityEngine;

public class Ship : DistributedObjectView
{
	private float speed = 1f;

	public override void SetPosition(Vector3 position) {
		base.SetPosition(position + new Vector3(0f, 1f, 0f));
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