using System;
using System.Collections.Generic;
using AOT;


namespace iOS4Unity
{
	public static class Callbacks
	{
		private static readonly Dictionary<string, Delegate> _delegates = new Dictionary<string, Delegate>();
		private static readonly Dictionary<IntPtr, Dictionary<IntPtr, Action<IntPtr>>> _callbacksIntPtr = new Dictionary<IntPtr, Dictionary<IntPtr, Action<IntPtr>>>();
		private static readonly Dictionary<IntPtr, Dictionary<IntPtr, Action<IntPtr, int>>> _callbacksIntPtrInt = new Dictionary<IntPtr, Dictionary<IntPtr, Action<IntPtr, int>>>();

		public static void SubscribeIntPtr(NSObject obj, string selector, Action<IntPtr> callback)
		{
			Dictionary<IntPtr, Action<IntPtr>> dictionary;
			if (!_callbacksIntPtr.TryGetValue(obj.Handle, out dictionary))
			{
				_callbacksIntPtr[obj.Handle] =
					dictionary = new Dictionary<IntPtr, Action<IntPtr>>();
			}
			dictionary[ObjC.GetSelector(selector)] = callback;

			if (!_delegates.ContainsKey(selector))
			{
				Action<IntPtr, IntPtr, IntPtr> del = OnCallbackIntPtr;
				if (!ObjC.AddMethod(obj.ClassHandle, selector, del, "v@:@"))
				{
					throw new InvalidOperationException("AddMethod failed for selector " + selector);
				}
				else
				{
					_delegates[selector] = del;
				}
			}
		}

		public static void SubscribeIntPtrInt(NSObject obj, string selector, Action<IntPtr, int> callback)
		{
			Dictionary<IntPtr, Action<IntPtr, int>> dictionary;
			if (!_callbacksIntPtrInt.TryGetValue(obj.Handle, out dictionary))
			{
				_callbacksIntPtrInt[obj.Handle] =
					dictionary = new Dictionary<IntPtr, Action<IntPtr, int>>();
			}
			dictionary[ObjC.GetSelector(selector)] = callback;
			
			if (!_delegates.ContainsKey(selector))
			{
				Action<IntPtr, IntPtr, IntPtr, int> del = OnCallbackIntPtrInt;
				if (!ObjC.AddMethod(obj.ClassHandle, selector, del, "v@:@l"))
				{
					throw new InvalidOperationException("AddMethod failed for selector " + selector);
				}
				else
				{
					_delegates[selector] = del;
				}
			}
		}

		public static void UnsubscribeIntPtr(NSObject obj)
		{
			_callbacksIntPtr.Remove(obj.Handle);
		}

		public static void UnsubscribeIntPtrInt(NSObject obj)
		{
			_callbacksIntPtr.Remove(obj.Handle);
		}

		public static void UnsubscribeAll(NSObject obj)
		{
			_callbacksIntPtr.Remove(obj.Handle);
			_callbacksIntPtr.Remove(obj.Handle);
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr>))]
		private static void OnCallbackIntPtr(IntPtr @this, IntPtr selector, IntPtr arg1)
		{
			Dictionary<IntPtr, Action<IntPtr>> dictionary;
			if (_callbacksIntPtr.TryGetValue(@this, out dictionary))
			{
				Action<IntPtr> callback;
				if (dictionary.TryGetValue(selector, out callback))
				{
					callback(arg1);
				}
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr, int>))]
		private static void OnCallbackIntPtrInt(IntPtr @this, IntPtr selector, IntPtr arg1, int arg2)
		{
			Dictionary<IntPtr, Action<IntPtr, int>> dictionary;
			if (_callbacksIntPtrInt.TryGetValue(@this, out dictionary))
			{
				Action<IntPtr, int> callback;
				if (dictionary.TryGetValue(selector, out callback))
				{
					callback(arg1, arg2);
				}
			}
		}
	}
}