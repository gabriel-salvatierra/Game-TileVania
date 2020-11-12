using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

    int startingSceneIndex = -1;

    public int GetStartingSceneIndex() {
        return startingSceneIndex;
    }

    void Awake() {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ScenePersist[] scenePersists = FindObjectsOfType<ScenePersist>();
        if (scenePersists.Length <= 1) {
            // I am alone
            DontDestroyOnLoad(gameObject);
        } else {
            bool destroyMe = false;
            // We are Two
            foreach (ScenePersist scenePersist in scenePersists) {
                if (scenePersist != this) {
                    // It's not me
                    if (scenePersist.GetStartingSceneIndex() != startingSceneIndex) {
                        // You have nothing to do here
                        Destroy(scenePersist.gameObject);
                    } else {
                        // I have nothing to do here
                        destroyMe = true;
                    }
                }
            }

            if (destroyMe) {
                // Seppuku!
                Destroy(gameObject);
            } else {
                // They are all dead, I will survive!
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    void Update() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startingSceneIndex) {
            Destroy(gameObject);
        }
    }
}
