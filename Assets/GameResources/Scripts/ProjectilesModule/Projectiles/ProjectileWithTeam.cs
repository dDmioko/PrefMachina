using ModuleBallistics;

public class ProjectileWithTeam : AbstractProjectile
{
    private AbstractTeamMark team = default;
    public AbstractTeamMark Team => team;

    public override void Init(ShootData shootData, AbstractProjectileData projectileData)
	{
        base.Init(shootData, projectileData);

        team = (shootData as ShootDataWithTeam).team;
	}
}
