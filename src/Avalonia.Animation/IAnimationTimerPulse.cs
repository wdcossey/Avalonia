using System;

namespace Avalonia.Animation
{
    /// <summary>
    /// Interface for pulsing an <see cref="IAnimationTimer"/>.
    /// </summary>
    public interface IAnimationTimerPulse : IAnimationTimer
    {
        /// <summary>
        /// Pulses the animation timer.
        /// </summary>
        /// <param name="time">The elapsed time.</param>
        void Pulse(TimeSpan time);
    }
}
