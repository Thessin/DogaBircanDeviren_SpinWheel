using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ZoneButton : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private Button btn;

    [SerializeField, HideInInspector]
    private TextMeshProUGUI zoneTxt;

    [SerializeField]
    private Image frameImg, bgImg;

    public event Action<int> OnClicked;

    // Button index num.
    public int BtnNum { get; private set; }

    [SerializeField]
    private AssetReferenceSprite normalBGRef, safeBGRef, superBGRef;
    [SerializeField]
    private AssetReferenceSprite nonSelectedFrameRef, selectedFrameRef, currentFrameRef;

    private AsyncOperationHandle<Sprite> bgImgOpHandle, frameImgOpHandle;

    public ZoneBtnStateBase ZoneBtnState { get; private set; }

    private void OnValidate()
    {
        btn = GetComponent<Button>();
        zoneTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Awake()
    {
        ZoneBtnState = new ZoneNonSelectedState(this);
    }

    private void OnEnable()
    {
        btn.onClick.AddListener(OnBtnClicked);
    }

    private void OnDisable()
    {
        btn.onClick.RemoveListener(OnBtnClicked);
    }

    private void OnDestroy()
    {
        OnClicked = null;
    }

    public void SetupBtn(int zoneNumber, ZoneType zoneType)
    {
        // Setting zone number text.
        zoneTxt.text = (zoneNumber + 1).ToString(); // +1 since levels shouldn't start with 0.
        BtnNum = zoneNumber;

        // Setting background image.
        if (bgImgOpHandle.IsValid()) Addressables.Release(bgImgOpHandle);
        AssetReferenceSprite chosenSpriteRef;
        switch (zoneType)
        {
            case ZoneType.SAFE:
                chosenSpriteRef = safeBGRef;
                break;
            case ZoneType.SUPER:
                chosenSpriteRef = superBGRef;
                break;
            default:
                chosenSpriteRef = normalBGRef;
                break;
        }
        bgImgOpHandle = Addressables.LoadAssetAsync<Sprite>(chosenSpriteRef);
        bgImgOpHandle.Completed += (result) => bgImg.sprite = result.Result;

        // This should be non-selected at first.
        SetBtnState(new ZoneNonSelectedState(this));
    }

    private void OnBtnClicked()
    {
        OnClicked?.Invoke(BtnNum);
    }

    public void SetBtnState(ZoneBtnStateBase zoneBtnState)
    {
        ZoneBtnState.ExitState();
        ZoneBtnState = zoneBtnState;
        ZoneBtnState.EnterState();
    }

    public void SetBtnFrameImg(BtnFrameImageType frameType)
    {
        AssetReferenceSprite chosenRef;
        if (frameImgOpHandle.IsValid()) Addressables.Release(frameImgOpHandle);
        switch (frameType)
        {
            case BtnFrameImageType.SELECTED:
                chosenRef = selectedFrameRef;
                break;
            case BtnFrameImageType.CURRENT:
                chosenRef = currentFrameRef;
                break;
            default:
                chosenRef = nonSelectedFrameRef;
                break;
        }
        frameImgOpHandle = Addressables.LoadAssetAsync<Sprite>(chosenRef);
        frameImgOpHandle.Completed += (result) => frameImg.sprite = result.Result;
    }

    public void LockButton(bool isLock)
    {
        btn.interactable = !isLock;
    }

    public void SetFrameColor(Color color)
    {
        frameImg.color = color;
    }
}

public enum BtnFrameImageType
{
    NON_SELECTED,
    SELECTED,
    CURRENT
}
