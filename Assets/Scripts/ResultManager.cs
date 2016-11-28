using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour 
{
    [SerializeField] private Number maxCombo;
    [SerializeField] private Number perfectCount;
    [SerializeField] private Number missCount;

    public void SetData(int maxCombo, int perfectCount, int missCount)
    {
        this.maxCombo.SetNumber(maxCombo);
        this.perfectCount.SetNumber(perfectCount);
        this.missCount.SetNumber(missCount);
    }
}
