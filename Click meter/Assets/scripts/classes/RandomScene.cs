using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Assets.scripts.classes
{
    /// <summary>
    /// Random scene picker
    /// </summary>
    class RandomScene
    {
        private static string[] scenes = new string[2] { "Video", "FruitDefence" };

        public static void loadRandomScene() {
            int random = Random.Range(0, 2);
            SceneManager.LoadScene(scenes[random]);
        }
    }
}
