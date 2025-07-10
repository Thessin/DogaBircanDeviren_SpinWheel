using System.Collections;
using System.Collections.Generic;

public class SpinWheelModel
{
    public ZoneInfo currentZone;
    public Dictionary<int, RewardInfo> currentlyCollectedRewards = new Dictionary<int, RewardInfo>();

    private int rewardedCount = 0;

    public void AddReward(RewardInfo reward)
    {
        rewardedCount++;

        int rewardId = reward.GetRewardId();

        if (currentlyCollectedRewards.ContainsKey(rewardId))
            currentlyCollectedRewards[rewardId].rewardMultiplier += reward.rewardMultiplier;
        else
            currentlyCollectedRewards.Add(rewardId, reward);
    }

    public bool IsSpinnable()
    {
        return rewardedCount == currentZone.zoneIndex;
    }

    public void ResetModel()
    {
        currentZone = null;
        currentlyCollectedRewards.Clear();
        rewardedCount = 0;
    }
}
