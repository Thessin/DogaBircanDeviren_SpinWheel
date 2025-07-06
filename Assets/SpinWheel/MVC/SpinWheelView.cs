using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelView : MonoBehaviour
{
    [SerializeField]
    private Image wheelImg;

    public void SetupRewards(ZoneInfo info)
    {
        foreach (RewardSO item in info.rewards)
        {

        }
    }

    public void SpinImg(float rotation)
    {
        // TODO: Spin image with DoTween by given rotation count.
    }
}
