//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class UIGeometry
{
    public BetterList<Color32> cols = new BetterList<Color32>();
    private Vector3 mRtpNormal;
    private Vector4 mRtpTan;
    private BetterList<Vector3> mRtpVerts = new BetterList<Vector3>();
    public BetterList<Vector2> uvs = new BetterList<Vector2>();
    public BetterList<Vector3> verts = new BetterList<Vector3>();

    public void ApplyOffset(Vector3 pivotOffset)
    {
        for (var i = 0; i < verts.size; i++)
        {
            verts.buffer[i] += pivotOffset;
        }
    }

    public void ApplyTransform(Matrix4x4 widgetToPanel, bool normals)
    {
        if (verts.size > 0)
        {
            mRtpVerts.Clear();
            var num = 0;
            var size = verts.size;
            while (num < size)
            {
                mRtpVerts.Add(widgetToPanel.MultiplyPoint3x4(verts[num]));
                num++;
            }
            mRtpNormal = widgetToPanel.MultiplyVector(Vector3.back).normalized;
            var normalized = widgetToPanel.MultiplyVector(Vector3.right).normalized;
            mRtpTan = new Vector4(normalized.x, normalized.y, normalized.z, -1f);
        }
        else
        {
            mRtpVerts.Clear();
        }
    }

    public void Clear()
    {
        verts.Clear();
        uvs.Clear();
        cols.Clear();
        mRtpVerts.Clear();
    }

    public void WriteToBuffers(BetterList<Vector3> v, BetterList<Vector2> u, BetterList<Color32> c, BetterList<Vector3> n, BetterList<Vector4> t)
    {
        if (mRtpVerts != null && mRtpVerts.size > 0)
        {
            if (n == null)
            {
                for (var i = 0; i < mRtpVerts.size; i++)
                {
                    v.Add(mRtpVerts.buffer[i]);
                    u.Add(uvs.buffer[i]);
                    c.Add(cols.buffer[i]);
                }
            }
            else
            {
                for (var j = 0; j < mRtpVerts.size; j++)
                {
                    v.Add(mRtpVerts.buffer[j]);
                    u.Add(uvs.buffer[j]);
                    c.Add(cols.buffer[j]);
                    n.Add(mRtpNormal);
                    t.Add(mRtpTan);
                }
            }
        }
    }

    public bool hasTransformed
    {
        get
        {
            return mRtpVerts != null && mRtpVerts.size > 0 && mRtpVerts.size == verts.size;
        }
    }

    public bool hasVertices
    {
        get
        {
            return verts.size > 0;
        }
    }
}

