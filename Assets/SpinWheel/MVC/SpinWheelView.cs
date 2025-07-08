using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SpinWheelView : MonoBehaviour
{
    [SerializeField]
    private Image wheelImg, pinImg;

    [SerializeField]
    private List<RewardItem> rewardItemObjs = new List<RewardItem>();

    [SerializeField]
    private AssetReferenceSprite bronzePin, bronzeWheel, silverPin, silverWheel, goldenPin, goldenWheel;

    public event Action<RewardInfo> OnSpinRotateComplete;

    private float spinDuration = 3.0f;

    private AsyncOperationHandle<Sprite> pinOpHandle, wheelOpHandle;

    private void OnDestroy()
    {
        // To prevent leaks on scene changes.
        OnSpinRotateComplete = null;
    }

    public void SetupWheel(ZoneInfo info)
    {
        // Setting up reward objects.
        for (int i = 0; i < info.rewards.Length; i++)
        {
            rewardItemObjs[i].Setup(info.rewards[i]);
        }

        // Setting pin and wheel images.
        SetPinAndWheelImg(info);

        // Reset wheel transformation.
        wheelImg.transform.rotation = Quaternion.identity;
    }

    public void SpinTheWheel(float rotation, RewardInfo chosenReward)
    {
        wheelImg.transform.DORotate(new Vector3(0, 0, rotation), spinDuration)
            .SetEase(Ease.InCubic)
            .OnComplete(() => OnSpinRotateComplete?.Invoke(chosenReward));
    }

    private void SetPinAndWheelImg(ZoneInfo info)
    {
        if (pinOpHandle.IsValid()) Addressables.Release(pinOpHandle);
        if (wheelOpHandle.IsValid()) Addressables.Release(wheelOpHandle);

        AssetReferenceSprite pinRef, wheelRef;
        switch (info.zoneType)
        {
            case ZoneType.SAFE:
                pinRef = silverPin;
                wheelRef = silverWheel;
                break;
            case ZoneType.SUPER:
                pinRef = goldenPin;
                wheelRef = goldenWheel;
                break;
            default:
                pinRef = bronzePin;
                wheelRef = bronzeWheel;
                break;
        }

        pinOpHandle = Addressables.LoadAssetAsync<Sprite>(pinRef);
        pinOpHandle.Completed += (result) => pinImg.sprite = result.Result;
        wheelOpHandle = Addressables.LoadAssetAsync<Sprite>(wheelRef);
        wheelOpHandle.Completed += (result) => wheelImg.sprite = result.Result;
    }
}
