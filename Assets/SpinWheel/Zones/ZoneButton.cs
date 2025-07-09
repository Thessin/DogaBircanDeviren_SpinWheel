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

    [SerializeField, HideInInspector]
    private Image bgImg;

    public event Action<int> OnClicked;

    private int btnNum;

    [SerializeField]
    private AssetReferenceSprite normalBGRef, safeBGRef, superBGRef;

    private AsyncOperationHandle<Sprite> bgImgOpHandle;

    private void OnValidate()
    {
        btn = GetComponent<Button>();
        zoneTxt = GetComponentInChildren<TextMeshProUGUI>();
        bgImg = GetComponent<Image>();
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
        btnNum = zoneNumber;

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
    }

    private void OnBtnClicked()
    {
        OnClicked?.Invoke(btnNum);
    }
}
