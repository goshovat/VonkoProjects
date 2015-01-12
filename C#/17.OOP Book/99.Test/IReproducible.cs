using System;
using System.Collections.Generic;

namespace Test
{
    public interface IReproducible<T> where T:Kitty
    {
        T[] Reproduce(T mate);
    }
}
