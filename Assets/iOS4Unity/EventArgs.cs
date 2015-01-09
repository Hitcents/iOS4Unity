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