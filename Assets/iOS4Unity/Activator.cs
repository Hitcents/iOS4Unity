using System;
using System.Collections.Generic;

namespace iOS4Unity
{
    internal static class Activator 
    {
        private static readonly Dictionary<Type, Func<IntPtr, object>> _constructors = new Dictionary<Type, Func<IntPtr, object>>
        {
            { typeof(NSObject), h => new NSObject(h) },
            { typeof(UIScreenMode), h => new UIScreenMode(h) },
            { typeof(UIScreen), h => new UIScreen(h) },
            { typeof(UIView), h => new UIView(h) },
            { typeof(UIWindow), h => new UIWindow(h) },
            { typeof(UIViewController), h => new UIViewController(h) },
            { typeof(SKProduct), h => new SKProduct(h) },
        };
    	
        public static T CreateFromHandle<T>(IntPtr handle) where T : NSObject
        {
            //First get the constructor
            Func<IntPtr, object> constructor;
            if (!_constructors.TryGetValue(typeof(T), out constructor))
            {
                throw new NotImplementedException("ArrayFromHandle not implemented for: " + typeof(T));
            }
            return (T)constructor(handle);
        }
    }
}
