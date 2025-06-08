using System.Collections.Generic;
using UnityEngine;

namespace HumanoidAPI;

/// <summary>
/// Default Game Elements that don't require their own separate Class
/// </summary>
public static class GameElements
{
    /// <summary>
    /// Inbuilt FPS Counter of Human: Fall Flat
    /// </summary>
    public static GameObject FpsCounter;
    
    /// <summary>
    /// List of all Human Objects
    /// </summary>
    public static Human[] Humans;
    
    /// <summary>
    /// List of all Player Objects (Better than "Humans")
    /// </summary>
    public static List<OnlineHuman> Players = [];

    /// <summary>
    /// Built-In FreeCam
    /// </summary>
    public static GameObject FreeRoamCamera;
}