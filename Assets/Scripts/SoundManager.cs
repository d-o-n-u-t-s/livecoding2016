using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private NoteManager noteManager;
    [SerializeField] private ComboManager comboManager;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioClip se;

    public float Time { get { return bgm.time; } }

    private bool isLoading;

    void Update()
    {
        if(!bgm.isPlaying && !isLoading) {
            StartCoroutine(loadResult());
        }
    }

    private IEnumerator loadResult()
    {
        isLoading = true;
        var loader = SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
        yield return loader;

        GameObject.FindObjectOfType<ResultManager>().SetData(
            comboManager.MaxCombo,
            noteManager.PerfectCount,
            noteManager.MissCount
        );
        SceneManager.UnloadScene("Live");
    }

    public void PlaySE()
    {
        bgm.PlayOneShot(se);
    }
}
