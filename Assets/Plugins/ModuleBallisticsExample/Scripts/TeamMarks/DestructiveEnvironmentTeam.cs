using System.Collections.Generic;
using UnityEngine;

public class DestructiveEnvironmentTeam : AbstractTeamMark
{
	private static List<Transform> team = default;
	public static List<Transform> Team => team;

	private void OnEnable()
	{
		if (team == null)
		{
			team = new List<Transform>();
		}

		team.Add(transform);
	}

	private void OnDisable()
	{
		team.Remove(transform);
	}
}