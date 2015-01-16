using System;
using System.Runtime.InteropServices;

namespace iOS4Unity
{
	public struct BlockLiteral
	{
		private static readonly IntPtr _classHandle;

		static BlockLiteral()
		{
			_classHandle = ObjC.GetClass("__NSStackBlock");
		}

		public IntPtr ISA;
		
		public IntPtr GlobalHandle;
		
		public IntPtr LocalHandle;
		
		public IntPtr Descriptor;
		
		public IntPtr Invoke;
		
		public int Reserved;
		
		public BlockFlags Flags;
		
		public object Target
		{
			get
			{
				if (this.GlobalHandle != IntPtr.Zero)
				{
					return GCHandle.FromIntPtr(this.GlobalHandle).Target;
				}
				return GCHandle.FromIntPtr(this.LocalHandle).Target;
			}
		}

		public void Cleanup()
		{
			GCHandle.FromIntPtr(this.LocalHandle).Free();
		}
		
		public T GetDelegateForBlock<T>() where T : class
		{
			return (T)((object)ObjC.GetDelegateForBlock(this.Invoke, typeof(T)));
		}
		
		public void Setup(Delegate trampoline, Delegate userDelegate)
		{
			ISA = _classHandle;
			Invoke = Marshal.GetFunctionPointerForDelegate(trampoline);
			LocalHandle = (IntPtr)GCHandle.Alloc(userDelegate);
			GlobalHandle = IntPtr.Zero;
			Flags = (BlockFlags.BLOCK_HAS_COPY_DISPOSE | BlockFlags.BLOCK_HAS_DESCRIPTOR);
			//Descriptor = BlockLiteral.xamarin_get_block_descriptor();
		}
	}

	[Flags]
	public enum BlockFlags
	{
		BLOCK_REFCOUNT_MASK = 65535,
		BLOCK_NEEDS_FREE = 16777216,
		BLOCK_HAS_COPY_DISPOSE = 33554432,
		BLOCK_HAS_CTOR = 67108864,
		BLOCK_IS_GC = 134217728,
		BLOCK_IS_GLOBAL = 268435456,
		BLOCK_HAS_DESCRIPTOR = 536870912
	}
}
