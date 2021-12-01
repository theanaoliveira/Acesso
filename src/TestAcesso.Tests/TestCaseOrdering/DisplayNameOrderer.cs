﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TestAcesso.Tests.TestCaseOrdering
{
    public class DisplayNameOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            return testCollections.OrderBy(collection => collection.DisplayName);
        }
    }
}
