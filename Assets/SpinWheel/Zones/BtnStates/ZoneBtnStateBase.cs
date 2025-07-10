public abstract class ZoneBtnStateBase
{
    protected ZoneButton btn;

    public ZoneBtnStateBase(ZoneButton btn)
    {
        this.btn = btn;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void OnBtnClicked(ZoneButton clickedBtn);
}

public class ZoneNonSelectedState : ZoneBtnStateBase
{
    public ZoneNonSelectedState(ZoneButton btn) : base(btn) { }

    public override void EnterState()
    {
        UnityEngine.Debug.Log("ENTERING NON-SELECTED STATE");
    }

    public override void ExitState()
    {
        UnityEngine.Debug.Log("EXITING NON-SELECTED STATE");
    }

    public override void OnBtnClicked(ZoneButton clickedBtn)
    {
        if (clickedBtn == btn)
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
    }

    public override void ExitState()
    {
        UnityEngine.Debug.Log("EXITING SELECTED STATE");
    }

    public override void OnBtnClicked(ZoneButton clickedBtn)
    {
        
    }
}
