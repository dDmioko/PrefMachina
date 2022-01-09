using ModuleBallistics;
using UnityEngine;

public class AbstractGunWithTeam : AbstractGun
{
    [SerializeField]
    private AbstractTeamMark team = default;
    public AbstractTeamMark Team => team;

    private ShootDataWithTeam shootData = default;

    private void Awake()
    {
        shootData = new ShootDataWithTeam();
        shootData.team = Team;
    }
}
