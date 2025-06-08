using HumanoidAPI.HumanData;
using UnityEngine;

namespace HumanoidAPI.Internal;

internal static class Setup
{
    internal static void SetupLocalHuman()
    {
        if (!LocalHuman.IsAnyNull()) {return;}
        
        LocalHuman.Data = Human.all[0];
        LocalHuman.Camera = GameObject.Find("CameraController");
        LocalHuman.Human = LocalHuman.Camera.transform.parent.gameObject;
        LocalHuman.RigRoot = LocalHuman.Human.transform.Find("Ball").gameObject;
        LocalHuman.MovementReference = LocalHuman.RigRoot.transform.Find("Sphere").gameObject;
        LocalHuman.Ragdoll = LocalHuman.RigRoot.transform.Find("Ragdoll(Clone)").gameObject;
        LocalHuman.Hips = LocalHuman.Ragdoll.transform.Find("Hips").gameObject;
        LocalHuman.Waist = LocalHuman.Hips.transform.Find("Waist").gameObject;
        LocalHuman.Chest = LocalHuman.Waist.transform.Find("Chest").gameObject;
        LocalHuman.Head = LocalHuman.Chest.transform.Find("Head").gameObject;
        LocalHuman.LeftArm = new HumanArm(LocalHuman.Chest, "Left");
        LocalHuman.RightArm = new HumanArm(LocalHuman.Chest, "Right");
        LocalHuman.LeftLeg = new HumanLeg(LocalHuman.Hips, "Left");
        LocalHuman.RightLeg = new HumanLeg(LocalHuman.Hips, "Right");
    }

    internal static void SetupOnlineHumans()
    {
        //Debug.Log(GameElements.Humans.Length + " : " + GameElements.Players.Count);

        //Check if any plais invalid, if so, refresh
        if (GameElements.Humans.Length == GameElements.Players.Count)
        {
            foreach (OnlineHuman human in GameElements.Players)
            {
                if (human.IsAnyNull())
                {
                    GameElements.Players.Clear();
                    break;
                }
            }
        }
        
        
        if (GameElements.Humans.Length == GameElements.Players.Count) return;
        GameElements.Players.Clear();
        foreach (var humanObject in GameElements.Humans)
        {
            var newHuman = new OnlineHuman
            {
                Data = humanObject,
                RigRoot = humanObject.gameObject
            };
            newHuman.Human = newHuman.RigRoot.transform.parent.gameObject;
            newHuman.Ragdoll = newHuman.RigRoot.transform.Find("Ragdoll(Clone)").gameObject;
            newHuman.Hips = newHuman.Ragdoll.transform.Find("Hips").gameObject;
            newHuman.Waist = newHuman.Hips.transform.Find("Waist").gameObject;
            newHuman.Chest = newHuman.Waist.transform.Find("Chest").gameObject;
            newHuman.Head = newHuman.Chest.transform.Find("Head").gameObject;
            newHuman.LeftArm = new HumanArm(newHuman.Chest, "Left");
            newHuman.RightArm = new HumanArm(newHuman.Chest, "Right");
            newHuman.LeftLeg = new HumanLeg(newHuman.Hips, "Left");
            newHuman.RightLeg = new HumanLeg(newHuman.Hips, "Right");
            GameElements.Players.Add(newHuman);
        }
    }
    internal static void SetupGameElements()
    {
        GameElements.FpsCounter = GameObject.Find("Game(Clone)/FPS");
        GameElements.Humans = Human.all.ToArray();
        GameElements.FreeRoamCamera = GameObject.Find("FreeRoamCamera");
    }
}