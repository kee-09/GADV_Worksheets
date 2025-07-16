using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public virtual void Unlock()
    {
        // Base unlock behavior (optional)
    }

    public void Shake()
    {
        Debug.Log("You hear something rattle inside the chest.");
    }
}

public class AncientChest : TreasureChest
{
    public override void Unlock()
    {
        Debug.Log("You unlock the ancient chest with an ancient key.");
    }
}

public class MagicChest : TreasureChest
{
    public override void Unlock()
    {
        Debug.Log("You cast a spell to unlock the magic chest.");
    }
}

class Program
{
    static void Main()
    {
        TreasureChest ancient = new AncientChest();
        TreasureChest magic = new MagicChest();

        ancient.Unlock();
        magic.Unlock();

        ancient.Shake();
        magic.Shake();
    }
}

