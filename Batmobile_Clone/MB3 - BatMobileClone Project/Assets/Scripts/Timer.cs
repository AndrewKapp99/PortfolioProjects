// Written By Joshua Jandrell
using System;
using UnityEngine;

namespace Pattern.Utility
{
    // A simple class that can be used as a timer or as a counter, depending on the application
    public class Timer
    {
        public float Period { get; protected set; } // the time taken for the timer to finish.
        public float TimeLeft { get; protected set; }
        protected bool repeat = true;

        public delegate void TimerEnd();
        public event TimerEnd OnTimerEnd;

        // constructors
        public Timer(float _period = 1, bool _repeat = true)
        {
            Set(_period, _repeat);
        }


        // Timekeeping 
        // =======================================================================
        // public tick method - to be called in update loop of a monbehaviour (using detal time)
        public void Tick()
        {
            Tick(Time.deltaTime);
        }
        public void Tick(float deltaTime) // overload, allows for custom time interval
        {
            TimeLeft -= deltaTime;
            if (TimeLeft <= 0)
            {
                TimeUp();
            }
        }
        // portected control methods
        protected void TimeUp()
        {
            if (repeat) { Reset(); }
            OnTimerEnd?.Invoke();
        }
        // =======================================================================

        // Public control methods
        // =======================================================================
        // Reset timer once it has finished - more accurate in the long term if timer is repeting
        protected void Reset() { TimeLeft += Period; }         
       
        // Set overloads -> these funtions set the timer to a new period 
        public void Set() { TimeLeft = Period; }
        public void Set(float newPeriod)                    // Set timer period to new parameter
        {
            Period = newPeriod;
            Set();
        }
        public void Set(float newPeriod, bool _repeat)
        {
            repeat = _repeat;
            Set(newPeriod);
        }
        public void ForceTimeUp() { TimeUp(); }

        // =======================================================================

        // Public information methods
        // =======================================================================
        public float TimePassed()
        {
            float timePassed = Period - TimeLeft;
            if (timePassed > 0)
                return timePassed;
            else return 0;
        }
        public float ProportionLeft() { return TimeLeft / Period; }
        public float ProportionPassed() { return TimePassed() / Period; }
        public float PercentLeft() { return ProportionLeft() * 100f; }
        public float PercentPassed() { return ProportionPassed() * 100f; }
        // =======================================================================
    }
}

