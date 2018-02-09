using NUnit.Framework;
using System;
using NUnit.Framework.Interfaces;
using System.Transactions;

namespace IntegrationTests
{
    /// <summary>
    /// To make sure that each Test is run in new transaction
    /// Once the test is completed, we simply dispose the TransactionScope
    /// This makes sure that data changed by one test doesn't affect the other one
    /// And each test gets 'kinda' fresh database
    /// </summary>
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
