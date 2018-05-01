using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public int state;
    public Puzzle parentPuzzle;
    public Tile[] adjacentTiles;

    private Animator animator;

    public void SetState(int newState)
    {
        state = newState;
        animator.SetInteger("state",newState);
    }

    public void OnMouseDown()
    {
        if (parentPuzzle.waitingForPlayer == false)
        {
            return;
        }
        SetState((state+1)%2);
        foreach(Tile tile in adjacentTiles)
        {
            tile.SetState((tile.state + 1) % 2);
        }
        parentPuzzle.checkWinningCondition();
    }
    
	void Awake() 
    {
        animator = GetComponent<Animator>();
	}
}
