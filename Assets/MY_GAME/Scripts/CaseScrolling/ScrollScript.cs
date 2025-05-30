using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public CaseScript cs;
    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rt != null)
        {
            rt.anchoredPosition += new Vector2(cs.scrollSpeed * Time.deltaTime, 0);
        }
    }
}