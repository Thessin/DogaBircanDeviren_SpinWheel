public abstract class ZoneBtnStateBase
{
    protected ZoneButton btn;

    public ZoneBtnStateBase(ZoneButton btn)
    {
        this.btn = btn;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void ZoneSelected(ZoneModel model);
    public abstract void ZoneRewarded(ZoneModel model);
}

public class ZoneNonSelectedState : ZoneBtnStateBase
{
    public ZoneNonSelectedState(ZoneButton btn) : base(btn) { }

    public override void EnterState()
    {
        UnityEngine.Debug.Log("ENTERING NON-SELECTED STATE");
        btn.SetBtnFrameImg(BtnFrameImageType.NON_SELECTED);
    }

    public override void ExitState()
    {

    }

    public override void ZoneRewarded(ZoneModel model)
    {
        if (model.CurrentZoneIndex == btn.BtnNum)
            btn.SetBtnState(new ZoneCurrentState(btn));
    }

    public override void ZoneSelected(ZoneModel model)
    {
        if (model.SelectedZoneIndex == btn.BtnNum)
            btn.SetBtnState(new ZoneSelectedState(btn));
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

    public override void ExitState()
    {

    }

    public override void ZoneRewarded(ZoneModel model)
    {

    }

    public override void ZoneSelected(ZoneModel model)
    {
        if (model.SelectedZoneIndex != btn.BtnNum)
        {
            if (model.CurrentZoneIndex == btn.BtnNum)
                btn.SetBtnState(new ZoneCurrentState(btn));
            else
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
        btn.SetFrameColor(new UnityEngine.Color(0.5f, 0.75f, 0.98f));
    }

    public override void ExitState()
    {
        btn.SetFrameColor(new UnityEngine.Color(1.0f, 1.0f, 1.0f));
    }

    public override void ZoneRewarded(ZoneModel model)
    {
        if (model.CurrentZoneIndex != btn.BtnNum)
        {
            if (model.SelectedZoneIndex == btn.BtnNum)
                btn.SetBtnState(new ZoneSelectedState(btn));
            else
                btn.SetBtnState(new ZoneNonSelectedState(btn));
        }
    }

    public override void ZoneSelected(ZoneModel model)
    {
        if (model.SelectedZoneIndex == btn.BtnNum)
            btn.SetBtnState(new ZoneSelectedState(btn));
    }
}
