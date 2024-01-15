using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{

}

public class MyEvent : Event
{
    int i; 
}

public class PlayerInteract : Event
{
   public  Vector3 interactionPosition;
   public float interactionDistance;
}

public class PlaySound : Event
{
    public int index; 
    
}

public class EventDispatcher
{
    private static EventDispatcher _instance = null;
    private EventDispatcher() 
    { 
    }
    public static EventDispatcher Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventDispatcher();
            }
            return _instance;
        }
    }

    public delegate void EventDelegate<T>(T d) where T : Event;

    private Dictionary<System.Type, System.Delegate> m_eventDelegates =
        new Dictionary<System.Type, System.Delegate>();

    public void _AddListener<T>(EventDelegate<T> listener) where T : Event
    {
        System.Type eventType = typeof(T);
        System.Delegate del;

        if (m_eventDelegates.TryGetValue(eventType, out del))
        {
            del = System.Delegate.Combine(del, listener);
            m_eventDelegates.Add(typeof(T), del);
        }
        else
        {
            m_eventDelegates.Add(typeof(T), listener);
        }
    }

    //Register to Listen to an Event 
    public static void AddListener<T>(EventDelegate<T> listener) where T : Event
    {
        Instance._AddListener<T>(listener);
    }

    private void _RemoveListener<T>(EventDelegate<T> listener) where T: Event
    {
        System.Delegate del;
        if(m_eventDelegates.TryGetValue(typeof(T), out del))
        {
            System.Delegate newDel = System.Delegate.Remove(del, listener);
            if (newDel == null)
            {
                m_eventDelegates.Remove(typeof(T)); 
            }
            else
            {
                m_eventDelegates.Add(typeof(T), newDel);
            }
        }
    }

    public static void RemoveListener<T>(EventDelegate<T> listener) where T : Event
    {
        Instance._RemoveListener<T>(listener);
    }

    private void _Raise<T>(T evtData) where T : Event
    {
        System.Delegate del;
        if (m_eventDelegates.TryGetValue(typeof(T), out del))
        {
            EventDelegate<T>callback = del as EventDelegate<T>;
            if (callback != null)
            {
                callback(evtData);
            }
        }
    }

    //Trigger an Event
    public static void Raise <T>(T evtData) where T : Event
    {
        Instance._Raise(evtData);
    }
}
