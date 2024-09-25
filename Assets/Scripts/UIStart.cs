using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    [Header("Delay Times")]
    [SerializeField] float delayTimePlay = 1f;
    
    IEnumerator WaitAndLoad(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }
    public void Play()
    {
        StartCoroutine(WaitAndLoad("Play Again Scene", delayTimePlay));
    }
}
