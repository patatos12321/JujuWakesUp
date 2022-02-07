using System.Collections.Generic;
using System.Linq;

public class FighterJuju : IFighter
{
    public IFightingMove[] KnownMoves;
    public string FighterName => "Juju";

    public int MaxHp => 50;

    public int CurrentHp => 50;

    public List<IFightingMove> FightingMoves => KnownMoves.ToList();
}
