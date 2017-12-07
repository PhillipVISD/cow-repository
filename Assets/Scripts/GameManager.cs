using System;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public static class GameManager
    {
        public static void LoadScene(String scene)
        {
            SceneManager.LoadScene(scene);
        }

        public static void restart()
        {
            LoadScene("Menu");
            StaticData.Reset();
        }
    }
}