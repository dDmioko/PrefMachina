using System;
using UnityEngine;

/// <summary>
/// Rotate object to direction
/// </summary>
public class AITargetRotate : MonoBehaviour
{
	[SerializeField]
	private AIDirectionToTargetInput input = default;

	[SerializeField]
	[Range(0, Mathf.PI)]
	private float speed = Mathf.PI;

	private Vector3 direction = Vector3.zero;

	private bool isActive = true;

	private void OnEnable()
	{
		isActive = true;

		input.SetDirectionToTarget += SetDirection;
	}

	private void OnDisable()
	{
		input.SetDirectionToTarget -= SetDirection;
	}

	private void FixedUpdate()
	{
		if (isActive == false)
		{
			return;
		}

		Rotate();		
	}

	private void Rotate()
	{
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, speed, 0);

		transform.rotation = Quaternion.LookRotation(newDirection);
	}

	private void SetDirection(Vector3 normalizedDirection)
	{
		//Note: Rotate only around y axis
		normalizedDirection.y = 0;

		direction = normalizedDirection;
	}

	public void Stop()
	{		
		direction = transform.forward;

		isActive = false;
	}
}
