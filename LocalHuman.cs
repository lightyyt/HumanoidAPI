using HumanoidAPI.HumanData;
using UnityEngine;

namespace HumanoidAPI;

/// <summary>
/// Human the Local Player Uses
/// </summary>
public static class LocalHuman
{
    /// <summary>
    /// Human Object
    /// </summary>
    public static Human Data;

    /// <summary>
    /// Human Root Object
    /// </summary>
    public static GameObject Human;

    /// <summary>
    /// Game Camera
    /// </summary>
    public static GameObject Camera;

    /// <summary>
    /// Root of the Rig/Ragdoll
    /// </summary>
    public static GameObject RigRoot;

    /// <summary>
    /// The Actual True position of the Player
    /// </summary>
    public static GameObject MovementReference;

    /// <summary>
    /// Ragdoll
    /// </summary>
    public static GameObject Ragdoll;

    public static GameObject Hips;

    public static GameObject Waist;

    public static GameObject Chest;

    public static GameObject Head;

    /// <summary>
    /// HumanArm Object containing the Left Arm
    /// </summary>
    public static HumanArm LeftArm;

    /// <summary>
    /// HumanArm Object containing the Right Arm
    /// </summary>
    public static HumanArm RightArm;

    /// <summary>
    /// HumanLeg Object containing the Left Leg
    /// </summary>
    public static HumanLeg LeftLeg;

    /// <summary>
    /// HumanLeg Object containing the Right Leg
    /// </summary>
    public static HumanLeg RightLeg;

    /// <summary>
    /// Check, if any object is null
    /// </summary>
    /// <returns>True if there is any object that is not set, False if all objects are set</returns>
    public static bool IsAnyNull()
    {
        if (Data == null) { return true; }
        if (Human == null) { return true; }
        if (Camera == null) { return true; }
        if (RigRoot == null) { return true; }
        if (MovementReference == null) { return true; }
        if (Ragdoll == null) { return true; }
        if (Hips == null) { return true; }
        if (Waist == null) { return true; }
        if (Chest == null) { return true; }
        if (Head == null) { return true; }
        if (LeftArm == null) { return true; }
        if (LeftLeg == null) { return true; }
        if (RightArm == null) { return true; }
        if (RightLeg == null) { return true; }

        return false;
    }
}