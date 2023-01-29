using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HeroCollider : MonoBehaviour
{
    public int countEsquiveObstacle;

    // Start is called before the first frame update
    void Start()
    {
        countEsquiveObstacle = 0;
        Debug.Log(GameOverMenu.isGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.CompareTag("Pièce d'or"))
        {
            Destroy(collider.gameObject);
            Score.scoreValue += Score.goldScore;

        }
        else if (collider.CompareTag("Emeraude"))
        {
            Destroy(collider.gameObject);
            Score.scoreValue += Score.emeraldScore;
        }
        else if (collider.CompareTag("Rubis"))
        {
            Destroy(collider.gameObject);
            Score.scoreValue += Score.rubyScore;
        }
        else if (collider.CompareTag("Diamant"))
        {
            Destroy(collider.gameObject);
            Score.scoreValue += Score.diamondScore;
        }
        else if (collider.CompareTag("Diamant sombre"))
        {
             Destroy(collider.gameObject);
            Score.scoreValue -= Score.darkDiamondScore;

        }


        if (collider.CompareTag("Obstacle")){
            Debug.Log("Collision, BOOM !");
            if (countEsquiveObstacle == 1)
            {
                Debug.Log("You're dead !");
                GameOverMenu.isGameOver= true;
                // Display menu too say that you're dead
            }
            countEsquiveObstacle++;
            
        }


    }
}
