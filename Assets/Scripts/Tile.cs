using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public int id, kingId;
    public int x;
    public int y;
    public int playerKind;

    public Tile(int id)
    {
        this.id = id;
    }
    public Tile(int id, int playerKind)
    {
        this.id = id;
        this.playerKind = playerKind;
    }
    public Tile(int id, int playerKind, int kingId)
    {
        this.id = id;
        this.playerKind = playerKind;
        this.kingId = kingId;
    }
    
}
