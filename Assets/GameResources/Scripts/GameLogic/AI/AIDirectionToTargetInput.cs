using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Calc direction to target
/// </summary>
public class AIDirectionToTargetInput : TargetDependent
{
	public event Action<Vector3> SetDirectionToTarget;

	[SerializeField]
	private float updateDelay = 0.05f;

	private Coroutine coroutine = null;

	private void OnEnable()
	{
		coroutine = StartCoroutine(SetDirection());
	}

	private void OnDisable()
	{
		if (coroutine != null)
		{
			StopCoroutine(coroutine);
		}
	}

	private IEnumerator SetDirection()
	{
		WaitForSeconds delay = new WaitForSeconds(updateDelay);

		while (true)
		{
			yield return new WaitUntil(() => target != null);

			SetDirectionToTarget?.Invoke(GetNormalizedDirection());

			yield return delay;
		}
	}
}
