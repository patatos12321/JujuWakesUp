using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFighter
{
    string FighterName { get; }
    int MaxHp { get; }
    int CurrentHp { get; set; }
    List<IFightingMove> FightingMoves { get; }
    string BattleSongName { get; }
}
