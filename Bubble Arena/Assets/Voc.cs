using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Voc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TMP_Text text;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = slider.value.ToString();
    }
}