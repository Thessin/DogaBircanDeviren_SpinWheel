using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpinWheelModel
{
    public ZoneInfo currentZone;
    private Dictionary<int, RewardInfo> currentlyCollectedRewards = new Dictionary<int, RewardInfo>();

    private int rewardedCount = 0; // To know which zone we are at.

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

    public int GetRewardedCount() => rewardedCount;

    public List<RewardInfo> GetCurrentlyCollectedRewards() => currentlyCollectedRewards.Values.ToList();

    public void ResetModel()
    {
        currentZone = null;
        currentlyCollectedRewards.Clear();
        rewardedCount = 0;
    }
}
