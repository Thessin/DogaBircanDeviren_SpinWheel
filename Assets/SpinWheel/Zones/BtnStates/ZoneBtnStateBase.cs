public abstract class ZoneBtnStateBase
{
    protected ZoneButton btn;

    public ZoneBtnStateBase(ZoneButton btn)
    {
        this.btn = btn;
    }

    public abstract void EnterState();
    public abstract void OnBtnClicked(int clickedBtnIndex);
}

public class ZoneNonSelectedState : ZoneBtnStateBase
{
    public ZoneNonSelectedState(ZoneButton btn) : base(btn) { }

    public override void EnterState()
    {
        UnityEngine.Debug.Log("ENTERING NON-SELECTED STATE");
        btn.SetBtnFrameImg(BtnFrameImageType.NON_SELECTED);
    }

    public override void OnBtnClicked(int clickedBtnIndex)
    {
        if (clickedBtnIndex == btn.BtnNum)
        {
            btn.SetBtnState(new ZoneSelectedState(btn));
        }
    }
}

public class ZoneSelectedState : ZoneBtnStateBase
{
    public ZoneSelectedState(ZoneButton btn) : base(btn) { }

    public override void EnterState()
    {
        UnityEngine.Debug.Log("ENTERING SELECTED STATE");
        btn.SetBtnFrameImg(BtnFrameImageType.SELECTED);
    }

    public override void OnBtnClicked(int clickedBtnIndex)
    {
        if (clickedBtnIndex != btn.BtnNum)
        {
            btn.SetBtnState(new ZoneNonSelectedState(btn));
        }
    }
}

public class ZoneCurrentState : ZoneBtnStateBase
{
    public ZoneCurrentState(ZoneButton btn) : base(btn) { }

    public override void EnterState()
    {
        btn.SetBtnFrameImg(BtnFrameImageType.CURRENT);
    }

    public override void OnBtnClicked(int clickedBtnIndex)
    {
        if(clickedBtnIndex == btn.BtnNum)
        {
            btn.SetBtnState(new ZoneSelectedState(btn));
        }
    }
}
