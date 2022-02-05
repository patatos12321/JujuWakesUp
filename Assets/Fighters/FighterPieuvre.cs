using System.Collections.Generic;
using System.Linq;

public class FighterJuju : IFighter
{
    public IFightingMove[] KnownMoves;
    public string FighterName => "Juju";

    public int MaxHp => 480;

    public int CurrentHp => 480;

    public List<IFightingMove> FightingMoves => KnownMoves.ToList();
}
