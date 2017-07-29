using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton Design Pattern
    // point to class ScoreManager
    public static ScoreManager instance;
    // When the gameObject is initialized; before start; every reload scene
    private void Awake()
    {
        // make sure that there's only one instance of ScoreManager. If, by accident another copy is created, then destroy every other but the first one 
        // if instance isnt null, then destroy the component
        if (instance != null)
        {
            Destroy(this);

            // skip the rest of the code
            return;
        }

        // Assign myself to instance
        instance = this;
    }

    // when reload scene, this will persist
    public static int lives;

    // reset value
    public int score;
}
