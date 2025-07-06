using UnityEngine;
using UnityEngine.AddressableAssets;

public class RewardSO : ScriptableObject
{
    public AssetReferenceSprite rewardImgRef;
    public int rewardMultiplier;

    public string GetRewardMultiplierTxt()
    {
        return (rewardMultiplier / 1000).ToString("D") + "K";
    }
}
