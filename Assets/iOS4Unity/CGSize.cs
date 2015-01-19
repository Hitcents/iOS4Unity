using System;
using System.Globalization;

namespace iOS4Unity
{
    public struct CGSize 
    {
        public static readonly CGSize Empty;

        private float width;
        private float height;

        public float Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (double)this.Width == 0 && (double)this.Height == 0;
            }
        }

        public float Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public CGSize(CGPoint pt)
        {
            this = default(CGSize);
            this.Width = pt.X;
            this.Height = pt.Y;
        }

        public CGSize(CGSize size)
        {
            this = default(CGSize);
            this.Width = size.Width;
            this.Height = size.Height;
        }

        public CGSize(float width, float height)
        {
            this = default(CGSize);
            this.Width = width;
            this.Height = height;
        }

        public static CGSize Add(CGSize sz1, CGSize sz2)
        {
            return new CGSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        public static CGSize Subtract(CGSize sz1, CGSize sz2)
        {
            return new CGSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        public override bool Equals(object obj)
        {
            return obj is CGSize && this == (CGSize)obj;
        }

        public override int GetHashCode()
        {
            return (int)this.Width ^ (int)this.Height;
        }

        public CGPoint ToCGPoint()
        {
            return new CGPoint(this.Width, this.Height);
        }

//        public Size ToSize()
//        {
//            checked
//            {
//                int num = (int)this.Width;
//                int num2 = (int)this.Height;
//                return new Size(num, num2);
//            }
//        }

        public override string ToString()
        {
            return string.Format("{{Width={0}, Height={1}}}", width.ToString(CultureInfo.CurrentCulture), height.ToString(CultureInfo.CurrentCulture));
        }

        //
        // Operators
        //
        public static CGSize operator +(CGSize sz1, CGSize sz2)
        {
            return new CGSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        public static bool operator ==(CGSize sz1, CGSize sz2)
        {
            return sz1.Width == sz2.Width && sz1.Height == sz2.Height;
        }

        public static explicit operator CGPoint(CGSize size)
        {
            return new CGPoint(size.Width, size.Height);
        }

        public static bool operator !=(CGSize sz1, CGSize sz2)
        {
            return sz1.Width != sz2.Width || sz1.Height != sz2.Height;
        }

        public static CGSize operator -(CGSize sz1, CGSize sz2)
        {
            return new CGSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }
    }
}
