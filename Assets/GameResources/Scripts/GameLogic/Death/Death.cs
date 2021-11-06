using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Events on object death
/// </summary>
public class Death : MonoBehaviour
{
	public UnityEvent Died;
	public UnityEvent ZeroHealth;

	[SerializeField] private Health health = default;

	[SerializeField] private bool isKillOnZeroHealth = true;

	private void OnEnable()
	{
		health.AmountChanged += OnHealthChanged;
	}

	private void OnHealthChanged(int amount, int difference)
	{
		if (amount > 0)
		{
			return;
		}

		ZeroHP();
	}

	private void ZeroHP()
	{
		ZeroHealth.Invoke();

		if (isKillOnZeroHealth)
		{
			Kill();
		}
	}

	public void Kill()
	{
		Died.Invoke();

		gameObject.SetActive(false);
	}
}