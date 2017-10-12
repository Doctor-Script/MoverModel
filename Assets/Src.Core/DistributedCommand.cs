using UnityEngine;

public abstract class DistributedCommand {
	public abstract void UpdateTimeAll(float time);
}

public abstract class DistributedCommand<TSender> : DistributedCommand where TSender : DistributedObjectView
{
	private readonly DistributedObjectView sender;
	private readonly DistributedObject unit;
	private readonly float startTime;

	private const float LAG = 1f;

	public DistributedCommand(DistributedObjectView sender, float startTime)
	{
		this.sender = sender;
		this.unit = sender.Distributed;
		this.startTime = startTime;
	}

	public abstract void UpdateTime(TSender view, float time, float startTime, float lag);

	public override sealed void UpdateTimeAll(float time)
	{
		UpdateTime(sender as TSender, time, startTime, 0f);
		if (sender != unit.serverView) {
			UpdateTime(unit.serverView as TSender, time, startTime + LAG, LAG);
			UpdateOnClients(time, startTime + 2f * LAG, 2f * LAG);
		} else {
			UpdateOnClients(time, startTime + LAG, LAG);
		}
	}

	private void UpdateOnClients(float time, float startTime, float lag)
	{
		if (sender != unit.clinet1View) {
			UpdateTime(unit.clinet1View as TSender, time, startTime, lag);
		}
		if (sender != unit.clinet2View) {
			UpdateTime(unit.clinet2View as TSender, time, startTime, lag);
		}
	}
}