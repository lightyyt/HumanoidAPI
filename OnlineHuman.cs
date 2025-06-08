using HumanoidAPI.HumanData;
using UnityEngine;

namespace HumanoidAPI;

/// <summary>
/// Human the Local Player Uses
/// </summary>
public class OnlineHuman
{
    /// <summary>
    /// Human Object
    /// </summary>
    public Human Data;

    /// <summary>
    /// Human Root Object
    /// </summary>
    public GameObject Human;

    /// <summary>
    /// Root of the Rig/Ragdoll
    /// </summary>
    public GameObject RigRoot;
    
    /// <summary>
    /// Ragdoll
    /// </summary>
    public GameObject Ragdoll;

    public GameObject Hips;

    public GameObject Waist;

    public GameObject Chest;

    public GameObject Head;

    /// <summary>
    /// HumanArm Object containing the Left Arm
    /// </summary>
    public HumanArm LeftArm;

    /// <summary>
    /// HumanArm Object containing the Right Arm
    /// </summary>
    public HumanArm RightArm;

    /// <summary>
    /// HumanLeg Object containing the Left Leg
    /// </summary>
    public HumanLeg LeftLeg;

    /// <summary>
    /// HumanLeg Object containing the Right Leg
    /// </summary>
    public HumanLeg RightLeg;

    /// <summary>
    /// Check, if any object is null
    /// </summary>
    /// <returns>True if there is any object that is not set, False if all objects are set</returns>
    public bool IsAnyNull()
    {
        if (Data == null) { return true; }
        if (Human == null) { return true; }
        if (RigRoot == null) { return true; }
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