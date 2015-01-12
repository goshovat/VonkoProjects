using System;
using System.Collections.Generic;

namespace Bank
{
    public class CompanyClient : Client
    {
        private string activity;

        public CompanyClient(string name, string activity)
        {
            base.name = name;
            this.activity = activity;
        }

        public string Activity
        {
            get { return this.activity; }
        }
    }
}
