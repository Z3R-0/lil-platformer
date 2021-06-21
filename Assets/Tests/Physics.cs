using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.IO;

namespace Tests {

    public class Physics {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Gravity() {
            var assetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/testlevels");

            if (assetBundle != null) {
                string[] scenePath = assetBundle.GetAllScenePaths();
                SceneManager.LoadScene(scenePath[0]);

                yield return null;

                GameObject player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                Vector3 testPos = new Vector3(0, 5, 0);

                player.transform.position = testPos;

                yield return new WaitForSeconds(0.5f);
                
                Assert.Less(player.transform.position.y, testPos.y);
            } else {
                Debug.Log("Couldn't load assetBundle");
            }
        }
    }
}
