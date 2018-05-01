using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

    public Tile[] tiles;
    public bool waitingForPlayer;
    public AudioClip winAudioClip;

    private Animator animator;

    public void checkWinningCondition()
    {
        if (puzzleIsCompleted())
        {
            waitingForPlayer = false;
            StartCoroutine(winScript());
        }
    }

    void Randomize()
    {
        foreach (Tile tile in tiles)
        {
            tile.SetState(Random.Range(0,2));
        }
    }

    private bool puzzleIsCompleted()
    {
        int product = 1;
        foreach (Tile tile in tiles)
        {
            product *= tile.state;
        }
        if (product == 1)
        {
            return true;
        }
        return false;
    }

    IEnumerator winScript()
    {
        animator.SetTrigger("win");
        SoundManager.instance.stopMusic();
        SoundManager.instance.playSingle(winAudioClip);
        yield return new WaitForSeconds(10f);
        GameManager.instance.level += 1;
        Destroy(gameObject);
    }
    
    void Start() 
    {
        Randomize();
        waitingForPlayer = true;
        animator = GetComponent<Animator>();
	}
}
