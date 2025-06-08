using UnityEngine;

namespace HumanoidAPI.HumanData;

public class HumanArm
{
    public GameObject Arm;

    public GameObject Forearm;

    public GameObject Hand;

    public HumanArm(GameObject chest, string armSide)
    {
        Arm = chest.transform.Find(armSide + "Arm").gameObject;
        Forearm = Arm.transform.Find(armSide + "Forearm").gameObject;
        Hand = Forearm.transform.Find(armSide + "Hand").gameObject;
    }
}