using UnityEngine;

/// <summary>
/// Generate tentacle
/// </summary>
public class GenerateTentacle : MonoBehaviour
{
    [SerializeField]
    private Transform root = default;

    [SerializeField]
    private GameObject bone = default;

    [SerializeField]
    private Vector3 boneShift = Vector3.zero;

    [SerializeField]
    private GameObject head = default;

    [SerializeField]
    private Vector3 headShift = Vector3.zero;

    [SerializeField]
    private Transform tip = default;

    [SerializeField]
    private Vector3 tipShift = Vector3.zero;

    [Range(2, 20)]
    [SerializeField]
    private int boneAmount = 2;

    public void Generate()
    {
        Clean();

        Transform parent = root;

        for (int i = 0; i < boneAmount; ++i)
        {
            GameObject newBone = Instantiate(bone, parent);
            parent = newBone.transform;

            if (i > 0)
            {
                newBone.transform.localPosition = boneShift;
            }
        }

        GameObject newHead = Instantiate(head, parent);
        newHead.transform.localPosition = headShift;

        tip.SetParent(parent);
        tip.localPosition = tipShift;
    }

    private void Clean()
    {
        tip.parent = null;

        for (int i = 0; i < root.childCount; ++i)
        {
            DestroyImmediate(root.GetChild(i).gameObject);
        }
    }
}