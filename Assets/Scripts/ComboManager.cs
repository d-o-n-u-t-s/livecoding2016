using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ComboManager : MonoBehaviour {

    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] numbers;
    [SerializeField] private List<Animation> otakuAnimations;

    int comboCount;


	// Use this for initialization
	void Start () {
        Reset();
	}

    public void AddScore() {
        comboCount++;

        var value = comboCount;
        for(var i = 0; i < 3; i++) {
            var val = value % 10;
            images[i].sprite = numbers[val];
            if(val != 0) {
                images[i].gameObject.SetActive(true);
            }
            value = value / 10;
        }

        // オタクアニメーション開始
        if(comboCount >= 10) {
            otakuAnimations.ForEach(o => { 
                if(!o.isPlaying) {
                    o.Play();
                }
            });
        }
    }

    public void Reset() {
        comboCount = 0;
        for(var i = 1; i < 3; i++) {
            images[i].gameObject.SetActive(false);
        }
        images[0].sprite = numbers[0];
    }
}
