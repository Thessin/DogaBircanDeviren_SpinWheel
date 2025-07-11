using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private RewardItem rewardItemGO;

    [SerializeField]
    private Transform rewardItemParent;

    private List<RewardItem> rewardItems = new List<RewardItem>();

    public void UpdateInventory(SpinWheelModel wheelModel)
    {
        List<RewardInfo> rewardList = wheelModel.GetCurrentlyCollectedRewards();

        if (rewardItems.Count < rewardList.Count) // Need to create new reward items, since there is not enough reward items.
        {
            for (int i = rewardItems.Count; i < rewardList.Count; i++)
            {
                RewardItem itemObj = Instantiate(rewardItemGO, rewardItemParent);
                itemObj.name += "_" + i;
                rewardItems.Add(itemObj);
            }
        }

        for (int i = 0; i < rewardList.Count; i++)
        {
            RewardItem item = rewardItems[i];

            item.gameObject.SetActive(true);
            item.transform.SetAsLastSibling();  // New ones should stick to bottom.
            item.Setup(rewardList[i]);
        }
    }

    public void ResetView()
    {
        foreach (RewardItem item in rewardItems)
        {
            item.gameObject.SetActive(false);
        }
    }
}
