using UnityEngine;
using System.Collections;

public class SpawnPrefab : MonoBehaviour 
{
    public AudioClip[] hitSounds;           //Hit sounds;
    public AudioClip[] gameOverSounds;      //Game over sounds;

    void FixedUpdate()
    {
        //if object exist and game is over, disable it;
        gameObject.SetActive(!GameManager.gameOver); 
    }

    //The player has 4 edge colliders for each color side. They are tagged the same as 4 colored objects 
    //and here on collision we are doing things depends on are tags the same or not;
    void OnCollisionEnter2D(Collision2D col)
    {
        //If yes - adding score and playing hit sounds,
        if (col.gameObject.CompareTag(this.gameObject.tag))
        {
            GameManager.AddScore();
            GameManager.PlaySound(hitSounds[Random.Range(0, hitSounds.Length)]);
        }
        //if not, playing game over sounds and calling GameManager's function to set gameOver state to true;
        else
        {
            GameManager.PlaySound(gameOverSounds[Random.Range(0, gameOverSounds.Length)]);
            GameManager.GameOver(true);
        }

        //Disable object in any case;
        gameObject.SetActive(false);
    }
}
