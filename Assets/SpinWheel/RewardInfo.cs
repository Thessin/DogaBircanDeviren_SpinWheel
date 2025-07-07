public class RewardInfo
{
    public RewardSO rewardSO;
    public int rewardMultiplier;

    public string GetRewardMultiplierTxt()
    {
        return (rewardMultiplier / 1000).ToString("D") + "K";
    }
}
