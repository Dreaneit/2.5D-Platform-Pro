using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseGame()
    {
        SetTimeScale(0f);
    }

    public void ResumeGame()
    {
        SetTimeScale(1f);
    }

    private void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }
}
