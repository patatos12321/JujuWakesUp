using System.Collections.Generic;
using System.Linq;

public class FighterPieuvre : IFighter
{
    public IFightingMove[] KnownMoves;
    public string FighterName => "Pieuvre";
    public int MaxHp => 30;
    public int CurrentHp => 30;
    public List<IFightingMove> FightingMoves => KnownMoves.ToList();
}
