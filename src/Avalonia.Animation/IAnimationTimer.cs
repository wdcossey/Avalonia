using System;

namespace Avalonia.Animation
{
    /// <summary>
    /// Represents the global animation timer.
    /// </summary>
    public interface IAnimationTimer
    {
        /// <summary>
        /// Gets a value indicating whether <see cref="Tick"/> has any subscribers.
        /// </summary>
        bool HasSubscriptions { get; }

        /// <summary>
        /// Gets an observable which is fired when the clock ticks.
        /// </summary>
        /// <remarks>
        /// This observable is guaranteed to be fired on the UI thread.
        /// </remarks>
        IObservable<TimeSpan> Tick { get; }
    }
}
