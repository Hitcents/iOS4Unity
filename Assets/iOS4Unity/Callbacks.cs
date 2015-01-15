using System;
using System.Collections.Generic;
using AOT;


namespace iOS4Unity
{
	public static class Callbacks
	{
		private static readonly Dictionary<string, Delegate> _delegates = new Dictionary<string, Delegate>();
		private static readonly Dictionary<IntPtr, Dictionary<IntPtr, Methods>> _callbacks = new Dictionary<IntPtr, Dictionary<IntPtr, Methods>>();

		private class Methods
		{
			public Action Action;
			public Action<int> ActionInt;
		}

		private static Methods GetMethods(NSObject obj, string selector)
		{
			Dictionary<IntPtr, Methods> dictionary;
			if (!_callbacks.TryGetValue(obj.Handle, out dictionary))
			{
				_callbacks[obj.Handle] = dictionary = new Dictionary<IntPtr, Methods>();
			}

			IntPtr selectorHandle = ObjC.GetSelector(selector);

			Methods methods;
			if (!dictionary.TryGetValue(selectorHandle, out methods))
			{
				dictionary[selectorHandle] = methods = new Methods();
			}

			return methods;
		}

		public static void Subscribe(NSObject obj, string selector, EventHandler callback)
		{
			var methods = GetMethods(obj, selector);
			methods.Action = () => callback(obj, EventArgs.Empty);

			if (!_delegates.ContainsKey(selector))
			{
				Action<IntPtr, IntPtr, IntPtr> del = OnCallback;
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

		public static void Subscribe(NSObject obj, string selector, EventHandler<EventArgs<int>> callback)
		{
			var methods = GetMethods(obj, selector);
			methods.ActionInt = i => callback(obj, new EventArgs<int> { Value = i });
			
			if (!_delegates.ContainsKey(selector))
			{
				Action<IntPtr, IntPtr, IntPtr, int> del = OnCallbackInt;
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

		public static void Unsubscribe(NSObject obj, string selector)
		{
			var methods = GetMethods(obj, selector);
			methods.Action = null;
		}

		public static void UnsubscribeInt(NSObject obj, string selector)
		{
			var methods = GetMethods(obj, selector);
			methods.ActionInt = null;
		}

		public static void UnsubscribeAll(NSObject obj)
		{
			_callbacks.Remove(obj.Handle);
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr>))]
		private static void OnCallback(IntPtr @this, IntPtr selector, IntPtr arg1)
		{
			Dictionary<IntPtr, Methods> dictionary;
			if (_callbacks.TryGetValue(@this, out dictionary))
			{
				Methods methods;
				if (dictionary.TryGetValue(selector, out methods) && methods.Action != null)
				{
					methods.Action();
				}
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr, int>))]
		private static void OnCallbackInt(IntPtr @this, IntPtr selector, IntPtr arg1, int arg2)
		{
			Dictionary<IntPtr, Methods> dictionary;
			if (_callbacks.TryGetValue(@this, out dictionary))
			{
				Methods methods;
				if (dictionary.TryGetValue(selector, out methods) && methods.ActionInt != null)
				{
					methods.ActionInt(arg2);
				}
			}
		}
	}
}