using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FieldInfoMessages
{
    public const string FUEL_STATION = "Fuel station, refilled fuel!";
    public const string EMPTY_FIELD = "This field does nothing";
    public const string RANDOM = "Random field!";
    public const string SWAP_PLACES = "Select a player to swap palces with";
    public const string STEAL_FUEL = "Select a player to steal his fuel";
    public const string LOCK_ENEMY = "Select an enemy to break his engines";
    public const string DAMAGE_ENEMY = "Select an enemy to damage!";
    public const string LOCK_PLAYER = "Your engines shut down!";
    public const string HEAL_PLAYER = "Ship repaired!";
    public const string DAMAGE_PLAYER = "You took damage!";
    public const string MOVE_FORWARD = "Moving random number of fields forward!";
    public const string MOVE_BACKWARDS = "Moving random number of fields backwards!";
    public const string PLACE_MINE = "Select a field to place a mine!";
    public const string TELEPORT_PLAYER = "Select a field to teleport to!";

    public static string[] fieldInfoMessages =
    {FUEL_STATION, EMPTY_FIELD, RANDOM, SWAP_PLACES, STEAL_FUEL,
         LOCK_ENEMY, DAMAGE_ENEMY, LOCK_PLAYER, HEAL_PLAYER,
         DAMAGE_PLAYER, MOVE_FORWARD, MOVE_BACKWARDS, PLACE_MINE, TELEPORT_PLAYER
    };

    /* public const string FIELD_NAME_FUEL_STATION = "Fuel Station";
     public const string FIELD_NAME_EMPTY_FIELD = "Empty Field";
     public const string FIELD_NAME_RANDOM = "Random Field";
     public const string FIELD_NAME_SWAP_PLACES = "Swap Places Field";
     public const string FIELD_NAME_STEAL_FUEL = "Steal Enemy Fuel";
     public const string FIELD_NAME_LOCK_ENEMY = "Lock Enemy Field";
     public const string FIELD_NAME_DAMAGE_ENEMY = "Damage Enemy Field";
     public const string FIELD_NAME_LOCK_PLAYER = "Lock Field";
     public const string FIELD_NAME_HEAL_PLAYER = "Heal Player";
     public const string FIELD_NAME_DAMAGE_PLAYER = "Damage Player Field";
     public const string FIELD_NAME_MOVE_FORWARD = "Move Forward";
     public const string FIELD_NAME_MOVE_BACKWARDS = "Move Back Field";
     public const string FIELD_NAME_PLACE_MINE = "Place Mine Field";
     public const string FIELD_NAME_TELEPORT_PLAYER = "Teleport Field";*/

    public static readonly Type FIELD_NAME_FUEL_STATION = typeof(FuelStation);
    public static readonly Type FIELD_NAME_EMPTY_FIELD = typeof(EmptyField);
    public static readonly Type FIELD_NAME_RANDOM = typeof(EffectRandom);
    public static readonly Type FIELD_NAME_SWAP_PLACES = typeof(EffectSwapPlaces);
    public static readonly Type FIELD_NAME_STEAL_FUEL = typeof(EffectStealFuel);
    public static readonly Type FIELD_NAME_LOCK_ENEMY = typeof(EffectLockEnemy);
    public static readonly Type FIELD_NAME_DAMAGE_ENEMY = typeof(EffectDamageEnemy);
    public static readonly Type FIELD_NAME_LOCK_PLAYER = typeof(EffectLockPlayer);
    public static readonly Type FIELD_NAME_HEAL_PLAYER = typeof(EffectHealPlayer);
    public static readonly Type FIELD_NAME_DAMAGE_PLAYER = typeof(EffectDamagePlayer);
    public static readonly Type FIELD_NAME_MOVE_FORWARD = typeof(EffectMoveForward);
    public static readonly Type FIELD_NAME_MOVE_BACKWARDS = typeof(EffectMoveBackwards);
    public static readonly Type FIELD_NAME_PLACE_MINE = typeof(EffectPlaceMine);
    public static readonly Type FIELD_NAME_TELEPORT_PLAYER = typeof(EffectTeleport);

    public static readonly Type[] fieldGameObjectTypes =
   {   FIELD_NAME_FUEL_STATION, FIELD_NAME_EMPTY_FIELD, FIELD_NAME_RANDOM,
        FIELD_NAME_SWAP_PLACES, FIELD_NAME_STEAL_FUEL,
        FIELD_NAME_LOCK_ENEMY, FIELD_NAME_DAMAGE_ENEMY,
        FIELD_NAME_LOCK_PLAYER, FIELD_NAME_HEAL_PLAYER,
        FIELD_NAME_DAMAGE_PLAYER, FIELD_NAME_MOVE_FORWARD,
        FIELD_NAME_MOVE_BACKWARDS, FIELD_NAME_PLACE_MINE, FIELD_NAME_TELEPORT_PLAYER
    };
}