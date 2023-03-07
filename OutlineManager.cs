using UnityEngine;

class OutlineManager : MonoBehaviour
{
    private Outline[] outlines;

    private void Start()
    {
        outlines = GetComponentsInChildren<Outline>();
    }

    private void Update()
    {
        foreach (Outline outline in outlines)
        {
            outline.transform.position = outline.target.position;
            outline.transform.rotation = outline.target.rotation;
        }
    }
}