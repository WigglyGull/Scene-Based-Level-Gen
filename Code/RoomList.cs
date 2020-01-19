//RoomList.cs: A List Of Rooms

using Godot;
using System;

public class RoomList : Node{
    public static PackedScene roomU = ResourceLoader.Load("res://Rooms/RoomU.tscn") as PackedScene;
    public static PackedScene roomD = ResourceLoader.Load("res://Rooms/RoomD.tscn") as PackedScene;
    public static PackedScene roomL = ResourceLoader.Load("res://Rooms/RoomL.tscn") as PackedScene;
    public static PackedScene roomR = ResourceLoader.Load("res://Rooms/RoomR.tscn") as PackedScene;
    public static PackedScene roomUD = ResourceLoader.Load("res://Rooms/RoomUD.tscn") as PackedScene;
    public static PackedScene roomRL = ResourceLoader.Load("res://Rooms/RoomRL.tscn") as PackedScene;
    public static PackedScene roomUR = ResourceLoader.Load("res://Rooms/RoomUR.tscn") as PackedScene;
    public static PackedScene roomUL = ResourceLoader.Load("res://Rooms/RoomUL.tscn") as PackedScene;
    public static PackedScene roomDR = ResourceLoader.Load("res://Rooms/RoomDR.tscn") as PackedScene;
    public static PackedScene roomDL = ResourceLoader.Load("res://Rooms/RoomDL.tscn") as PackedScene;
    public static PackedScene roomULD = ResourceLoader.Load("res://Rooms/RoomULD.tscn") as PackedScene;
    public static PackedScene roomURD = ResourceLoader.Load("res://Rooms/RoomURD.tscn") as PackedScene;
    public static PackedScene roomURL = ResourceLoader.Load("res://Rooms/RoomURL.tscn") as PackedScene;
    public static PackedScene roomLDR = ResourceLoader.Load("res://Rooms/RoomLDR.tscn") as PackedScene;
    public static PackedScene roomUDRL = ResourceLoader.Load("res://Rooms/RoomUDRL.tscn") as PackedScene;
}