using System;

public class ActionHandler<T>
{
    public void Subscribe(ref Action<T> eventHandler, Action<T> method)
    {
        eventHandler += method;
    }

    public void Unsubscribe(ref Action<T> eventHandler, Action<T> method)
    {
        eventHandler -= method;
    }
}