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
        public void ChangeScene(string sceneName)
        {
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