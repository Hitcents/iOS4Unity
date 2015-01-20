using System;
using iOS4Unity;
using NUnit.Framework;

namespace iOS4Unity
{
    [TestFixture]
    public class UIWindowTests
    {
        [Test]
        public void NewObject()
        {
            var obj = new UIWindow();

            Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
            Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
        }

        [Test]
        public void NewObjectDispose()
        {
            var obj = new UIWindow();
            obj.Dispose();
        }

        [Test]
        public void NewObjectWithFrame()
        {
            var frame = new CGRect(1, 2, 3, 4);
            var obj = new UIWindow(frame);
            Assert.AreEqual(frame, obj.Frame);
        }

        [Test]
        public void IsKeyWindow()
        {
            var obj = new UIWindow();
            Assert.IsFalse(obj.IsKeyWindow);
        }

        [Test]
        public void WindowLevel()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            Assert.AreEqual(UIWindowLevel.Normal, window.WindowLevel);
        }

        [Test]
        public void Screen()
        {
            var screen = UIApplication.SharedApplication.KeyWindow.Screen;
            Assert.IsNotNull(screen);
            Assert.AreNotEqual(IntPtr.Zero, screen.Handle);
        }
    }
}
