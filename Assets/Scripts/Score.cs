using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static int goldScore = 50;
    public static int emeraldScore = 100;
    public static int rubyScore = 200;
    public static int diamondScore = 500;
    public static int darkDiamondScore = 500;

    public static int scoreValue = 0;
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + scoreValue;
    }
}
