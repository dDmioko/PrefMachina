using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set player as target to components
/// </summary>
public class FindTarget : MonoBehaviour
{
    [SerializeField]
    private Teams[] targetsTeams = default;

    [SerializeField]
    private TargetDependent[] targetables = default;

    [SerializeField]
    private float updateDelay = 0.05f;

    private Transform target = default;

    private Coroutine coroutine = null;

    private void OnEnable()
    {
        coroutine = StartCoroutine(Find());
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private void Set()
    {
        foreach (TargetDependent targetable in targetables)
        {
            targetable.SetTarget(target);
        }
    }

    private IEnumerator Find()
    {
        WaitForSeconds delay = new WaitForSeconds(updateDelay);

        while (true)
        {
            List<Transform> list = GetList();

            if (list.Count == 0)
            {
                yield return delay;

                continue;
            }

            float minDistance = Vector3.Distance(transform.position, list[0].transform.position);
            target = list[0].transform;

            for (int i = 1; i < targetsTeams.Length; ++i)
            {
                float distance = Vector3.Distance(transform.position, list[i].transform.position);

                if (minDistance > distance)
                {
                    minDistance = distance;
                    target = list[i].transform;
                }
            }

            Set();

            yield return delay;
        }
    }

    private List<Transform> GetList()
    {
        List<Transform> list = new List<Transform>();

        foreach (Teams team in targetsTeams)
        {
            list.AddRange(GetList(team));
        }

        return list;
    }

    private List<Transform> GetList(Teams team)
    {
        switch (team)
        {
            case Teams.Good:

                return GoodTeam.Team;

            case Teams.Bad:

                return BadTeam.Team;

            case Teams.DestractiveEnvironment:

                return DestructiveEnvironmentTeam.Team;

            default:

                return null;
        }
    }

    public enum Teams
    {
        Good,
        Bad,
        DestractiveEnvironment
    }
}
