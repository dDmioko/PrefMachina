using UnityEngine;

using Leopotam.Ecs;

public class DeactivateOnOffScreenSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter<DeactivateOnOffScreen> _filter = null;

    private Rect screenBox;

    private float outOfScreenDistance;

    public DeactivateOnOffScreenSystem(float outOfScreenDistance) {
        this.outOfScreenDistance = outOfScreenDistance;
    }

    public void Init()
    {
        screenBox = new Rect(-outOfScreenDistance,
            -outOfScreenDistance,
            Screen.width + outOfScreenDistance,
            Screen.height + outOfScreenDistance);
    }

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);

            if (entity.IsAlive() == false)
            {
                continue;
            }

            ref DeactivateOnOffScreen component = ref _filter.Get1(i);

            if (component.gameObject.activeSelf == false)
            {
                continue;
            }

            Vector3 vec3 = Camera.main.WorldToScreenPoint(component.transform.position);
            Vector2 projectileOnRect = new Vector2(vec3.x, vec3.y);

            bool state = screenBox.Contains(projectileOnRect, true);

            component.gameObject.SetActive(state);

            if (component.isDelete)
            {
                Object.Destroy(component.gameObject);
            }
        }
    }
}
