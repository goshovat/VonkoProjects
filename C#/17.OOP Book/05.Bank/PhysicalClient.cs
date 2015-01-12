using System;

namespace Bank
{
    public class PhysicalClient : Client
    {
        public PhysicalClient(string name)
        {
            base.name = name;
        }
    }
}
