using UnityEngine;

/// <summary>
/// Entity to spawn
/// </summary>
[CreateAssetMenu(fileName = "SpawnEntity", menuName = "Spawn")]
public class SpawnEntity : ScriptableObject
{
    [SerializeField]
    private string id = default;
    public string Id => id;

    [SerializeField] 
    private GameObject prefab = default;
    public GameObject Prefab => prefab;
}
