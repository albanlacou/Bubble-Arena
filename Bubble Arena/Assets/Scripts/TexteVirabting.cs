using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TexteVirabting : MonoBehaviour
{
    private RectTransform rt;
    private Vector3 originalScale;
    public float modificateur;

    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        originalScale = rt.localScale;
        Vector3 newScale = new Vector3(originalScale.x + modificateur, originalScale.y + modificateur, originalScale.z + modificateur);
        rt.DOSizeDelta(newScale, 1f).OnComplete(() =>
        {
            rt.DOSizeDelta(originalScale, 1f);
        }) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
