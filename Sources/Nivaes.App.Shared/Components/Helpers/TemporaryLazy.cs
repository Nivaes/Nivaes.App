namespace Nivaes.App
{
    using System;

    public class TemporaryLazy<T>
    {
        private readonly Func<T> mFactory;
        private readonly TimeSpan mLifetime;
        private readonly object mValueLock;

        private T? mValue;
        private DateTime mCreationTime ;

        public TemporaryLazy(Func<T> factory, TimeSpan lifetime)
        {
            mFactory = factory;
            mLifetime = lifetime;
            mValueLock = new object();
        }

        public bool HasValue
        {
            get
            {
                lock (mValueLock)
                {
                    return !(object.Equals(mValue, default(T)) && mCreationTime.Add(mLifetime) > DateTime.UtcNow);
                }
            }
        }

        public T? Value
        {
            get
            {
                lock (mValueLock)
                {
                    if (object.Equals(mValue, default(T)) || mCreationTime.Add(mLifetime) > DateTime.UtcNow)
                    {
                        mValue = mFactory();
                        mCreationTime = DateTime.UtcNow;
                    }

                    return mValue;
                }
            }
        }
    }
}
