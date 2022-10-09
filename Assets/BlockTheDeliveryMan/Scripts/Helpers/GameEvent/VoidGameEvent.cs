using UnityEngine;

/// <summary>
/// Game events require a type, so we create an empty type for void function
/// </summary>
public struct Void { };

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event/Void")]
public class VoidGameEvent : GameEvent<Void> { }