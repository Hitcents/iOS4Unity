using System;
using AOT;

namespace iOS4Unity
{
	public sealed class NSNotificationCenter : NSObject
	{
		private static readonly IntPtr _classHandle;
		private static readonly Action<IntPtr, IntPtr> _onNotification = OnNotification;
		
		static NSNotificationCenter()
		{
			_classHandle = ObjC.GetClass("NSNotificationCenter");
		}
		
		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}
		
		private NSNotificationCenter(IntPtr handle)
		{
			Handle = handle;
		}

		public static NSNotificationCenter DefaultCenter
		{
			get { return new NSNotificationCenter(ObjC.MessageSendIntPtr(_classHandle, "defaultCenter")); }
		}

		public unsafe NSObject AddObserver(string name, NSObject obj, Action handler)
		{
			var block = new BlockLiteral();
			block.Setup(_onNotification, handler);

			var handle = ObjC.MessageSendIntPtr(Handle, "addObserverForName:object:queue:usingBlock:", name, obj == null ? IntPtr.Zero : obj.Handle, IntPtr.Zero, (IntPtr)((void*)(&block)));
			block.Cleanup();

			return new NSObject(handle);
		}

		public void PostNotificationName(string name, NSObject obj = null)
		{
			ObjC.MessageSend(Handle, "postNotificationName:object:", name, obj == null ? IntPtr.Zero : obj.Handle);
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr>))]
		private unsafe static void OnNotification(IntPtr block, IntPtr notification)
		{
			var ptr = (BlockLiteral*)((void*)block);
			Action action = (Action)ptr->Target;
			if (action != null)
			{
				action();
			}
		}

		public override void Dispose()
		{
			//Doesn't need to release
		}
	}
}
