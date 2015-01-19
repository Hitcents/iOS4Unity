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

		public readonly IntPtr Handle;
        private readonly bool _shouldRelease;

		public NSObject(IntPtr handle)
		{
			Handle = handle;
		}

		public NSObject()
		{
			Handle = ObjC.MessageSendIntPtr(ClassHandle, "alloc");
            _shouldRelease = true;
		}

		public string Description
		{
			get { return ObjC.MessageSendString(Handle, "description"); }
		}

		public override string ToString ()
		{
			return Description;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);

			if (Handle != IntPtr.Zero && _shouldRelease)
			{
				Callbacks.UnsubscribeAll(this);
                ObjC.MessageSend(Handle, "release");
			}
		}
	}
}
