using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private Image itemImage;

    [SerializeField, HideInInspector]
    private TextMeshProUGUI multiplierTxt;

    private AsyncOperationHandle<Sprite> spriteLoadHandle;

    private void OnValidate()
    {
        itemImage = GetComponentInChildren<Image>();
        multiplierTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setup(RewardInfo info)
    {
        // Need to release the old sprite asset.
        if (spriteLoadHandle.IsValid())
            Addressables.Release(spriteLoadHandle);

        spriteLoadHandle = Addressables.LoadAssetAsync<Sprite>(info.rewardSO.GetRewardImgRef());
        spriteLoadHandle.Completed += (result) => itemImage.sprite = result.Result;

        multiplierTxt.text = "x" + info.GetRewardMultiplierTxt();
    }
}
