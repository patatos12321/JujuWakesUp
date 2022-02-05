using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightingMovesBehaviour : MonoBehaviour
{
    public IFightingMove[] FightingMoves;
    public Button[] MoveButtons;
    public Text[] MoveTexts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetFightingMoves(IFightingMove[] fightingMoves)
    {
        FightingMoves = fightingMoves;
        for (int index = 0; index < MoveButtons.Length; index++)
        {
            if (fightingMoves.Length < index + 1)
            {
                MoveButtons[index].gameObject.SetActive(false);
            }
            else 
            { 
                MoveTexts[index].text = FightingMoves[index].MoveName;
            }
        }
    }
}
