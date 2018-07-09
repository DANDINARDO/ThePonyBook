using System;
using NUnit.Framework;

namespace ThePonyBookTest.Api.Base
{
    [SetUpFixture]
    public class SetUpClass
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            //AutoMapperFactory.CreateViewModelsMap();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
        }
    }

    [TestFixture]
    public abstract class BaseTestFixture
    {
        public abstract void SetupContext();
        public abstract void Act();
        public virtual void SetupHttpContext() { }
        public virtual void AssertException(Exception exc) { }
        public virtual void PostAct() { }
        public string BasePath { get; set; }

        [SetUp]
        public virtual void Initialize()
        {
            SetupHttpContext();
            SetupContext();

            try
            {
                Act();
            }
            catch (Exception exc)
            {
                AssertException(exc);
            }
            finally
            {
                PostAct();
            }
        }
    }
}
