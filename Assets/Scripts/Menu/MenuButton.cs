using UnityEngine;
using UnityEngine.SceneManagement;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private bool shouldResumeTimeScale = false;

        public void ChangeScene(string sceneName)
        {
            if (shouldResumeTimeScale)
                Time.timeScale = 1;

            SceneManager.LoadSceneAsync(sceneName);
        }


        public void QuitApplication()
        {
            Application.Quit();
        }


        public void PauseTime()
        {
            Time.timeScale = 0;
        }


        public void ResumeTime()
        {
            Time.timeScale = 1;
        }
    }
}