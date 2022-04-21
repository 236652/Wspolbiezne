using System;

namespace Dane
{
    public abstract class DaneAbstractApi
    {
        public static DaneAbstractApi createApi()
        {
            return new DaneApi();
        }
    }

    internal class DaneApi : DaneAbstractApi
    {

    }
}