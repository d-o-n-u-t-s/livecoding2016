using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComboManager : MonoBehaviour {

    [SerializeField] private Number number;

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
    }

    public void Reset() {
        number.SetNumber(0);
        comboCount = 0;
    }
}
