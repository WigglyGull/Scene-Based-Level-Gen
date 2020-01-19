//Level.cs: Resonable for spawning the actual room
using Godot;
using System;

public class Level : Node2D{
    public bool up, down, left, right;
    [Export] public int roomIndex;
    bool setRoom;

    public override void _Process(float delta){
        if(!setRoom){
            PickRoom();
            setRoom = false;
        }
    }

    /*
    Spawns a room from RoomList.cs depending on direction bools 
    Todo: Add more rooms to make it more random, currently
    there is just one for every direction just for example.
    */

    void PickRoom(){
        if(up){
            if(down){
                if(right){
                    if(left){
                        Node roomInst = RoomList.roomUDRL.Instance() as Node2D;
                        AddChild(roomInst);
                    }else{
                        Node roomInst = RoomList.roomURD.Instance() as Node2D;
                        AddChild(roomInst);
                    }
                }else if(left){
                    Node roomInst = RoomList.roomULD.Instance() as Node2D;
                    AddChild(roomInst);
                }else{
                    Node roomInst = RoomList.roomUD.Instance() as Node2D;
                    AddChild(roomInst);
                }
            }else{
                if(right){
                    if(left){
                       Node roomInst = RoomList.roomURL.Instance() as Node2D;
                        AddChild(roomInst);
                    }else{
                        Node roomInst = RoomList.roomUR.Instance() as Node2D;
                        AddChild(roomInst);
                    }
                }else if(left){
                    Node roomInst = RoomList.roomUL.Instance() as Node2D;
                    AddChild(roomInst);
                }else{
                    Node roomInst = RoomList.roomU.Instance() as Node2D;
                    AddChild(roomInst);
                }
            }
            return;
        }
        if(down){
            if(right){
                if(left){
                    Node roomInst = RoomList.roomLDR.Instance() as Node2D;
                    AddChild(roomInst);
                }else{
                    Node roomInst = RoomList.roomDR.Instance() as Node2D;
                    AddChild(roomInst);
                }
            }else if(left){
                Node roomInst = RoomList.roomDL.Instance() as Node2D;
                AddChild(roomInst);
            }else{
                Node roomInst = RoomList.roomD.Instance() as Node2D;
                AddChild(roomInst);
            }
            return;
        }
        if(right){
            if(left){
                Node roomInst = RoomList.roomRL.Instance() as Node2D;
                AddChild(roomInst);
            }else{
                Node roomInst = RoomList.roomR.Instance() as Node2D;
                AddChild(roomInst);
            }
        }else{
            Node roomInst = RoomList.roomL.Instance() as Node2D;
            AddChild(roomInst);
        }
    }
}