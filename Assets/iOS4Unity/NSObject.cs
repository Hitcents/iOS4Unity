using System;
using System.Runtime.InteropServices;

namespace iOS4Unity
{
	public class NSObject : IDisposable 
	{
		private static readonly IntPtr _classHandle;

		static NSObject()
		{
			_classHandle = ObjC.GetClass("NSObject");
		}

		public virtual IntPtr ClassHandle
		{
			get { return _classHandle; }
		}

		~NSObject()
		{
			Dispose();
		}

		public IntPtr Handle;

		public NSObject(IntPtr handle)
		{
			Handle = handle;
		}

		public NSObject()
		{
			Handle = ObjC.MessageSendIntPtr(ClassHandle, "alloc");
		}

		public string Description
		{
			get { return ObjC.MessageSendString(Handle, "description"); }
		}

		public override string ToString ()
		{
			return Description;
		}

		public virtual void Dispose()
		{
			GC.SuppressFinalize(this);

			if (Handle != IntPtr.Zero)
			{
				Callbacks.UnsubscribeAll(this);
				ObjC.MessageSend(Handle, "release");
			}
		}
	}
}
