using System.Collections;
using System.Collections.Generic;

public class SpinWheelModel
{
    public ZoneInfo currentZone;
    public Dictionary<int, RewardInfo> currentlyCollectedRewards = new Dictionary<int, RewardInfo>();

    public void AddReward(RewardInfo reward)
    {
        int rewardId = reward.rewardSO.GetRewardId();

        if (currentlyCollectedRewards.ContainsKey(rewardId))
            currentlyCollectedRewards[rewardId].rewardMultiplier += reward.rewardMultiplier;
        else
            currentlyCollectedRewards.Add(rewardId, reward);
    }
}
