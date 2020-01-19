//Room.cs: Class holding each indiual rooms info
using Godot;
using System;

public class Room{
    public Vector2 gridPos;
    public int type;
    public int index;
    public bool doorTop, doorBot, doorLeft, doorRight;

    public Room(Vector2 _gridPos, int _type, int _index){
        gridPos = _gridPos;
        type = _type;
        index = _index;
    }
}