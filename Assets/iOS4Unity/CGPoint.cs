using System;
using System.Globalization;

[Serializable]
public struct CGPoint 
{
    public static readonly CGPoint Empty;

    private float x;
    private float y;

    public bool IsEmpty
    {
        get
        {
            return (double)this.X == 0 && (double)this.Y == 0;
        }
    }

    public float X
    {
        get
        {
            return this.x;
        }
        set
        {
            this.x = value;
        }
    }

    public float Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }

    public CGPoint(float x, float y)
    {
        this = default(CGPoint);
        this.X = x;
        this.Y = y;
    }

//    public static CGPoint Add(CGPoint pt, SizeF sz)
//    {
//        return new CGPoint(pt.X + sz.Width, pt.Y + sz.Height);
//    }

//    public static CGPoint Add(CGPoint pt, Size sz)
//    {
//        return new CGPoint(pt.X + (float)sz.Width, pt.Y + (float)sz.Height);
//    }
//
//    public static CGPoint Subtract(CGPoint pt, Size sz)
//    {
//        return new CGPoint(pt.X - (float)sz.Width, pt.Y - (float)sz.Height);
//    }
//
//    public static CGPoint Subtract(CGPoint pt, SizeF sz)
//    {
//        return new CGPoint(pt.X - sz.Width, pt.Y - sz.Height);
//    }

    public override bool Equals(object obj)
    {
        return obj is CGPoint && this == (CGPoint)obj;
    }

    public override int GetHashCode()
    {
        return (int)this.X ^ (int)this.Y;
    }

    public override string ToString()
    {
        return string.Format("{{X={0}, Y={1}}}", x.ToString(CultureInfo.CurrentCulture), y.ToString(CultureInfo.CurrentCulture));
    }

//    public static CGPoint operator +(CGPoint pt, Size sz)
//    {
//        return new CGPoint(pt.X + (float)sz.Width, pt.Y + (float)sz.Height);
//    }
//
//    public static CGPoint operator +(CGPoint pt, SizeF sz)
//    {
//        return new CGPoint(pt.X + sz.Width, pt.Y + sz.Height);
//    }

    public static bool operator ==(CGPoint left, CGPoint right)
    {
        return left.X == right.X && left.Y == right.Y;
    }

    public static bool operator !=(CGPoint left, CGPoint right)
    {
        return left.X != right.X || left.Y != right.Y;
    }

//    public static CGPoint operator -(CGPoint pt, SizeF sz)
//    {
//        return new CGPoint(pt.X - sz.Width, pt.Y - sz.Height);
//    }
//
//    public static CGPoint operator -(CGPoint pt, Size sz)
//    {
//        return new CGPoint(pt.X - (float)sz.Width, pt.Y - (float)sz.Height);
//    }
}
