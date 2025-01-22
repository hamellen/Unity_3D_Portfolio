using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine.SceneManagement;


public class UI_LoadinScene : MonoBehaviour
{
    public static string NextScene;

    Slider progressbar;
    public static void LoadingScene(string _scene) {

        NextScene = _scene;
        Manager.SCENEMANAGER.LoadScene(_scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        progressbar = GetComponentInChildren<Slider>();
        StartCoroutine(Process());
    }

    IEnumerator Process() {

        AsyncOperation op = SceneManager.LoadSceneAsync(NextScene);
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone) {

            yield return null;
            if (op.progress < 0.9f)
            {
                progressbar.value = op.progress;
            }
            else {
                timer += Time.unscaledDeltaTime;
                progressbar.value = Mathf.Lerp(0.9f, 1.0f, timer);
                if (progressbar.value >= 1f) {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
