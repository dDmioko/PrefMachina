using ModuleBallistics;
using UnityEngine;

public class AbstractGunWithTeam : AbstractGun
{
    [SerializeField]
    private AbstractTeamMark team = default;
    public AbstractTeamMark Team => team; 
}
