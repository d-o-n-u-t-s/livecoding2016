using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Number : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] numbers;

    public void SetNumber(int value)
    {
        for(var i = 0; i < 3; i++) {
            var val = value % 10;
            images[i].sprite = numbers[val];
            images[i].gameObject.SetActive(val != 0);
            value = value / 10;
        }
        images[0].gameObject.SetActive(true);
    }

    #if !アタッチ用
    [ContextMenu("Set")]
    public void tmp()
    {
        var tmp = GetComponentsInChildren<Image>();
        Array.Reverse(tmp);
        images = new [] { tmp[0], tmp[1], tmp[2] };
    }
    #endif
}
