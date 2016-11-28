using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ComboManager : MonoBehaviour {

    [SerializeField] private Number number;
    [SerializeField] private List<Otaku> otakues;

    public int MaxCombo { get; private set; }
    private int comboCount;

	// Use this for initialization
	void Start () {
        Reset();
	}

    public void AddScore() {
        comboCount++;
        MaxCombo = Mathf.Max(MaxCombo, comboCount);
        number.SetNumber(comboCount);

        // オタクアニメーション開始
        otakues.ForEach(o => o.SetAnimation(comboCount));
    }

    public void Reset() {
        number.SetNumber(0);
        comboCount = 0;
        otakues.ForEach(o => o.SetAnimation(comboCount));
    }
}
