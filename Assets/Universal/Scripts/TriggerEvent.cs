using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    public string[] triggerTags;

    [Space(20)]
    public UnityEvent onTriggerEnterEvent;
    public UnityEvent onTriggerStayEvent;
    public UnityEvent onTriggerExitEvent;

    

    private void Trigger(Collider _other, UnityEvent _event)
    {
        for (int i = 0; i < triggerTags.Length; i++)
        {
            if (ObjectX.DoesTagExist(triggerTags[i]))
            {
                if (_other.CompareTag(triggerTags[i]))
                    _event.Invoke();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Trigger(other, onTriggerEnterEvent);
    }

    public void OnTriggerStay(Collider other)
    {
        Trigger(other, onTriggerStayEvent);
    }

    public void OnTriggerExit(Collider other)
    {
        Trigger(other, onTriggerExitEvent);
    }
}
