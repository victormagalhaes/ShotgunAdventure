using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textBox;

    //is callde once per fame, after Update
    void LateUpdate()
    {
        textBox.text = ScoreManager.instance.score.ToString();
    }
}
