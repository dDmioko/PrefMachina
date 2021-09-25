using UnityEngine;

/// <summary>
/// Entity to spawn
/// </summary>
[CreateAssetMenu(fileName = "SpawnEntity", menuName = "Spawn")]
public class SpawnEntity : ScriptableObject
{
    [SerializeField]
    private string id;
    public string Id => id;

    [SerializeField] 
    private GameObject prefab;
    public GameObject Prefab => prefab;
}
