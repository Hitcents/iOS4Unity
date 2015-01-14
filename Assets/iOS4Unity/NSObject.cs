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

		private readonly IntPtr _handle;

		public virtual IntPtr Handle
		{
			get { return _handle; }
		}

		public NSObject()
		{
			_handle = ObjC.MessageSendIntPtr(ClassHandle, "alloc");
		}

		public virtual void Dispose()
		{
			GC.SuppressFinalize(this);

			if (Handle != IntPtr.Zero)
			{
				ObjC.MessageSend(Handle, "release");
			}
		}
	}
}
