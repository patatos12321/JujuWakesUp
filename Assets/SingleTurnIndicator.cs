using UnityEngine;

public class SingleTurnIndicator : MonoBehaviour
{
    public int TurnNumber;
    public bool IsPlayerActive = false;
    public bool IsEnemyActive = false;
    public bool IsTurnActive = true;

    public GameObject EnemyIndicator;
    public GameObject PlayerIndicator;
    public GameObject InactiveIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyIndicator.SetActive(IsEnemyActive);
        PlayerIndicator.SetActive(IsPlayerActive);
        InactiveIndicator.SetActive(!IsTurnActive);
    }
}
