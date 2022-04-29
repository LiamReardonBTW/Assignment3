using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavController : MonoBehaviour
{
    public AudioSource btnSound;

    public void LoadGame()
    {
        btnSound.Play();
        StartCoroutine(loadScene("LiamsScene"));
    }

    public void LoadHelp()
    {
        btnSound.Play();
        StartCoroutine(loadScene("LiamsHelpScene"));
    }

    public void LoadMenu()
    {
        btnSound.Play();
        StartCoroutine(loadScene("LiamsMenuScene"));
    }

    public void LoadGallery()
    {
        btnSound.Play();
    }

    public IEnumerator loadScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
