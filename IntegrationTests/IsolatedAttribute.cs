using NUnit.Framework;
using System;
using NUnit.Framework.Interfaces;
using System.Transactions;

namespace IntegrationTests
{
    public class IsolatedAttribute : Attribute, ITestAction
    {
        public ActionTargets Targets => ActionTargets.Test;

        private TransactionScope _scope;

        public void AfterTest(ITest test)
        {
            if(_scope != null)
                _scope.Dispose();

            _scope = null;
        }

        public void BeforeTest(ITest test)
        {
            _scope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }
    }
}
