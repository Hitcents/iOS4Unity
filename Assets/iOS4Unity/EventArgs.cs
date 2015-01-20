using System;

public class EventArgs<T> : EventArgs
{
	public T Value;
}

public class EventArgs<T1, T2> : EventArgs
{
	public T1 Value1;
	public T2 Value2;
}

#if !XAMARIN
namespace System
{
	public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
}
#endif