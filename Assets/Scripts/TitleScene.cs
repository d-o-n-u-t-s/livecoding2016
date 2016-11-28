using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScene : MonoBehaviour {

    private const string liveScene = "Live";

    [SerializeField] private Button button;

    void Start () {
        button.onClick.AddListener(() => {
            UnityEngine.SceneManagement.SceneManager.LoadScene(liveScene);
        });
    }
}
