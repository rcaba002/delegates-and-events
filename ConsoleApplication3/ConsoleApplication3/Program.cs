//Events are user actions such as key press, clicks, mouse movements, etc., or some occurrence such as system generated notifications
/*The events are declared and raised in a class and associated with the event handlers using delegates within the same class or some other class. The class containing the event is used to publish the event. This is called the publisher class. Some other class that accepts this event is called the subscriber class. Events use the publisher-subscriber model.
A publisher is an object that contains the definition of the event and the delegate. The event-delegate association is also defined in this object. A publisher class object invokes the event and it is notified to other objects.
A subscriber is an object that accepts the event and provides an event handler. The delegate in the publisher class invokes the method (event handler) of the subscriber class.*/
using System;
namespace SimpleEvent
{
    using System;
    public class EventTest
    {
        private int value;
        public delegate void NumManipulationHandler();
        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Event fired!");
            }
        }
        public EventTest(int n)
        {
            SetValue(n);
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            EventTest e = new EventTest(5);
            e.SetValue(7);
            e.SetValue(11);
            Console.ReadKey();
        }
    }
}