//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class LinearForceAffector : Affector
{
    protected Vector3 Force;

    public LinearForceAffector(Vector3 force, EffectNode node) : base(node)
    {
        Force = force;
    }

    public override void Update()
    {
        Node.Velocity += Force * Time.deltaTime;
    }
}

