using UnityEngine;

namespace HumanoidAPI.HumanData;

public class HumanLeg
{
    public GameObject Thigh;

    public GameObject Leg;

    public GameObject LegEnd;

    public GameObject Foot;

    public HumanLeg(GameObject hips, string legSide)
    {
        Thigh = hips.transform.Find(legSide + "Thigh").gameObject;
        Leg = Thigh.transform.Find(legSide + "Leg").gameObject;
        Foot = Leg.transform.Find(legSide + "Foot").gameObject;
        LegEnd = Leg.transform.Find(legSide + "Leg_end").gameObject;
    }
}