//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class RotateAffector : Affector
{
    protected float Delta;
    protected AnimationCurve RotateCurve;
    protected RSTYPE Type;

    public RotateAffector(float delta, EffectNode node) : base(node)
    {
        Type = RSTYPE.SIMPLE;
        Delta = delta;
    }

    public RotateAffector(AnimationCurve curve, EffectNode node) : base(node)
    {
        Type = RSTYPE.CURVE;
        RotateCurve = curve;
    }

    public override void Update()
    {
        var elapsedTime = Node.GetElapsedTime();
        if (Type == RSTYPE.CURVE)
        {
            Node.RotateAngle = (int) RotateCurve.Evaluate(elapsedTime);
        }
        else if (Type == RSTYPE.SIMPLE)
        {
            var num2 = Node.RotateAngle + Delta * Time.deltaTime;
            Node.RotateAngle = num2;
        }
    }
}

