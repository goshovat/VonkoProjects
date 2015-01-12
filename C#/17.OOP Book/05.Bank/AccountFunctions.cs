using System;

namespace Bank
{
    public interface AccountFunctions
    {
        double CalculateInterest(int months);

        void Import(double sum);
    }
}
