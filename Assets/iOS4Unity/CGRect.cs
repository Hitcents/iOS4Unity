using System;

namespace iOS4Unity
{
    [Serializable]
    public struct CGRect 
    {
        public static readonly CGRect Empty;

        private float x;
        private float height;
        private float width;
        private float y;

        public float Bottom
        {
            get
            {
                return this.Y + this.Height;
            }
        }

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
                return this.Width <= 0 || this.Height <= 0;
            }
        }

        public float Left
        {
            get
            {
                return this.X;
            }
        }

        public CGPoint Location
        {
            get
            {
                return new CGPoint(this.X, this.Y);
            }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public float Right
        {
            get
            {
                return this.X + this.Width;
            }
        }

//        public CGSize Size
//        {
//            get
//            {
//                return new CGSize(this.Width, this.Height);
//            }
//            set
//            {
//                this.Width = value.Width;
//                this.Height = value.Height;
//            }
//        }

        public float Top
        {
            get
            {
                return this.Y;
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

        public CGRect(CGPoint location, CGSize size)
        {
            this = default(CGRect);
            this.X = location.X;
            this.Y = location.Y;
            this.Width = size.Width;
            this.Height = size.Height;
        }

        public CGRect(float x, float y, float width, float height)
        {
            this = default(CGRect);
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public static CGRect FromLTRB(float left, float top, float right, float bottom)
        {
            return new CGRect(left, top, right - left, bottom - top);
        }

        public static CGRect Inflate(CGRect rect, float x, float y)
        {
            CGRect result = new CGRect(rect.X, rect.Y, rect.Width, rect.Height);
            result.Inflate(x, y);
            return result;
        }

        public static CGRect Intersect(CGRect a, CGRect b)
        {
            if (!a.IntersectsWithInclusive(b))
            {
                return CGRect.Empty;
            }
            return CGRect.FromLTRB(Math.Max(a.Left, b.Left), Math.Max(a.Top, b.Top), Math.Min(a.Right, b.Right), Math.Min(a.Bottom, b.Bottom));
        }

        public static CGRect Union(CGRect a, CGRect b)
        {
            return CGRect.FromLTRB(Math.Min(a.Left, b.Left), Math.Min(a.Top, b.Top), Math.Max(a.Right, b.Right), Math.Max(a.Bottom, b.Bottom));
        }

        public bool Contains(float x, float y)
        {
            return x >= this.Left && x < this.Right && y >= this.Top && y < this.Bottom;
        }

        public bool Contains(CGRect rect)
        {
            return this.x <= rect.x && this.Right >= rect.Right && this.y <= rect.y && this.Bottom >= rect.Bottom;
        }

        public bool Contains(CGPoint pt)
        {
            return this.Contains(pt.X, pt.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is CGRect && this == (CGRect)obj;
        }

        public override int GetHashCode()
        {
            return (int)(this.X + this.Y + this.Width + this.Height);
        }

        public void Inflate(CGSize size)
        {
            this.X -= size.Width;
            this.Y -= size.Height;
            this.Width += size.Width * 2;
            this.Height += size.Height * 2;
        }

        public void Inflate(float x, float y)
        {
            this.Inflate(new CGSize(x, y));
        }

        public void Intersect(CGRect rect)
        {
            this = CGRect.Intersect(this, rect);
        }

        public bool IntersectsWith(CGRect rect)
        {
            return this.Left < rect.Right && this.Right > rect.Left && this.Top < rect.Bottom && this.Bottom > rect.Top;
        }

        private bool IntersectsWithInclusive(CGRect r)
        {
            return this.Left <= r.Right && this.Right >= r.Left && this.Top <= r.Bottom && this.Bottom >= r.Top;
        }

        public void Offset(float x, float y)
        {
            this.X += x;
            this.Y += y;
        }

        public void Offset(CGPoint pos)
        {
            this.Offset(pos.X, pos.Y);
        }

        public override string ToString()
        {
            return string.Format("{{X={0},Y={1},Width={2},Height={3}}}", x, y, width, height);
        }

        public static bool operator ==(CGRect left, CGRect right)
        {
            return left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;
        }

        public static bool operator !=(CGRect left, CGRect right)
        {
            return left.X != right.X || left.Y != right.Y || left.Width != right.Width || left.Height != right.Height;
        }
    }
}
