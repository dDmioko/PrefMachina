using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Trigger event than target close enough, then deactivate this script
/// </summary>
public class CloseDistanceToTarget : TargetDependent
{
	public UnityEvent TargetAchieved;

	[SerializeField]
	private float triggerDistance = 2.5f;

	[SerializeField]
	private float checkDelay = 0;

	private Coroutine coroutine = null;

	private void OnEnable()
	{
		coroutine = StartCoroutine(CheckDistance());
	}

	private void OnDisable()
	{
		Stop();
	}

	private IEnumerator CheckDistance()
	{
		WaitForSeconds delay = new WaitForSeconds(checkDelay);

		while (true)
		{
			yield return new WaitUntil(() => target != null);

			if (Vector3.Distance(transform.position, target.position) < triggerDistance)
			{
				TargetAchieved?.Invoke();				
			}

			yield return delay;
		}
	}

	public void Stop()
	{
		if (coroutine != null)
		{
			StopCoroutine(coroutine);			
			coroutine = null;
		}
	}
}
