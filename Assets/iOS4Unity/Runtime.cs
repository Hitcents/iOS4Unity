using System;
using System.Collections.Generic;

namespace iOS4Unity
{
    public static class Runtime 
    {
        private static object _contructorLock = new object(), _objectLock = new object();

        private static readonly Dictionary<Type, Func<IntPtr, object>> _constructors = new Dictionary<Type, Func<IntPtr, object>>
        {
            { typeof(NSData), h => new NSData(h) },
            { typeof(NSObject), h => new NSObject(h) },
            { typeof(UIApplication), h => new UIApplication(h) },
            { typeof(UIViewController), h => new UIViewController(h) },

            { typeof(UIScreenMode), h => new UIScreenMode(h) },
            { typeof(UIScreen), h => new UIScreen(h) },
            { typeof(UIView), h => new UIView(h) },
            { typeof(UIWindow), h => new UIWindow(h) },
            { typeof(SKProduct), h => new SKProduct(h) },
        };
        private static readonly Dictionary<IntPtr, object> _objects = new Dictionary<IntPtr, object>();
    	
        public static void RegisterType<T>(Func<IntPtr, object> constructor) where T : NSObject
        {
            lock (_contructorLock)
            {
                _constructors[typeof(T)] = constructor;
            }
        }

        public static T GetNSObject<T>(IntPtr handle) where T : NSObject
        {
            if (handle == IntPtr.Zero)
                return null;

            lock (_objectLock)
            {
                object obj;
                if (_objects.TryGetValue(handle, out obj))
                    return (T)obj;
            }

            return ConstructNSObject<T>(handle);
        }

        public static T ConstructNSObject<T>(IntPtr handle) where T : NSObject
        {
            if (handle == IntPtr.Zero)
                return null;

            Func<IntPtr, object> constructor;
            lock (_contructorLock)
            {
                if (!_constructors.TryGetValue(typeof(T), out constructor))
                {
                    throw new NotImplementedException("Type's constructor not registered: " + typeof(T));
                }
            }
            return (T)constructor(handle);
        }

        public static void RegisterNSObject(NSObject obj)
        {
            if (obj == null || obj.Handle == IntPtr.Zero)
                return;

            lock (_objectLock)
            {
                _objects[obj.Handle] = obj;
            }
        }

        public static void UnregisterNSObject(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return;

            lock (_objectLock)
            {
                _objects.Remove(handle);
            }
        }
    }
}
