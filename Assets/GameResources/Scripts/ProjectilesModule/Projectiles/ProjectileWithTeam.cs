using ModuleBallistics;

public class ProjectileWithTeam : AbstractProjectile
{
    private AbstractTeamMark team = default;
    public AbstractTeamMark Team => team;

    public virtual void Init(ShootDataWithTeam shootData, AbstractProjectileData projectileData)
	{
        base.Init(shootData, projectileData);

        team = shootData.team;
	}
}
