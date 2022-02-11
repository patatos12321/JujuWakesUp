using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FightingMovesBehaviour : MonoBehaviour
{
    public CombatBehaviour CombatBehaviour;
    public IFightingMove[] FightingMoves;
    public Button[] MoveButtons;
    public Text[] MoveTexts;

    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < MoveButtons.Length; index++)
        {
            MoveButtons[index].onClick.AddListener(() => TaskOnClick(index));
        }
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

    void TaskOnClick(int moveIndex)
    {
        CombatBehaviour.PlayerMove = FightingMoves.First(f => f.MoveName == MoveTexts[moveIndex].text);
    }
}
