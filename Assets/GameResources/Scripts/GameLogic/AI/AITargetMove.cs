using UnityEngine;

/// <summary>
/// Move object
/// </summary>
public class AITargetMove : MonoBehaviour
{
	[SerializeField]
	private AIDirectionToTargetInput input = default;

	[SerializeField]
	private Rigidbody body = default;

	[SerializeField]
	private float acceleration = 30f;

	[SerializeField]
	private float maxSpeed = 15f;

	[SerializeField]
	[Range(0, 180)]
	private float towardsAngle = 180f;

	private Vector3 velocity = Vector3.zero;

	private bool isActive = true;

	private void OnEnable()
	{
		isActive = true;

		input.SetDirectionToTarget += SetVelocity;
	}

	private void OnDisable()
	{
		input.SetDirectionToTarget -= SetVelocity;
	}

	private void FixedUpdate()
	{
		if (isActive == false)
		{
			return;
		}

		body.velocity = velocity;
	}

	private void SetVelocity(Vector3 normalizedDirection)
	{
		if (isActive == false)
		{
			return;
		}

		if (Vector3.Angle(transform.forward, normalizedDirection) < towardsAngle)
		{
			velocity = normalizedDirection * GetSpeed();
		}
	}

	private float GetSpeed()
	{
		float speed = body.velocity.magnitude;

		if (speed < maxSpeed)
		{
			speed += acceleration * Time.fixedDeltaTime;

			speed = Mathf.Min(speed, maxSpeed);
		}

		return speed;
	}

	public void Stop()
	{
		body.velocity = Vector3.zero;
		velocity = Vector3.zero;

		isActive = false;
	}
}
