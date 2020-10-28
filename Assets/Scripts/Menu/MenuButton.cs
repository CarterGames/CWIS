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
    }
}