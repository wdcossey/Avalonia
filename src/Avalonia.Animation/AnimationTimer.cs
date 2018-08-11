// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using Avalonia.Reactive;

namespace Avalonia.Animation
{
    /// <summary>
    /// The default global animation timer.
    /// </summary>
    public class AnimationTimer : IAnimationTimer, IAnimationTimerPulse
    {
        TimerObservable _tick = new TimerObservable();

        /// <summary>
        /// The number of frames per second.
        /// </summary>
        public const int FramesPerSecond = 60;

        /// <summary>
        /// The time span of each frame.
        /// </summary>
        internal readonly TimeSpan FrameTick = TimeSpan.FromSeconds(1.0 / FramesPerSecond);

        /// <summary>
        /// Gets the instance of the global animation timer.
        /// </summary>
        public static IAnimationTimer Instance => AvaloniaLocator.Current.GetService<IAnimationTimer>();

        /// <inheritdoc/>
        public bool HasSubscriptions => _tick.HasSubscriptions;

        /// <inheritdoc/>
        public IObservable<TimeSpan> Tick => _tick;

        /// <inheritdoc/>
        void IAnimationTimerPulse.Pulse(TimeSpan time) => _tick.Pulse(time);

        private class TimerObservable : LightweightObservableBase<TimeSpan>
        {
            public bool HasSubscriptions { get; private set; }
            protected override void Initialize() => HasSubscriptions = true;
            protected override void Deinitialize() => HasSubscriptions = false;

            public void Pulse(TimeSpan time)
            {
                PublishNext(time);
            }
        }
    }
}
