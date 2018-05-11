using System;
using System.Reflection;
using ChromaExpVanilla;
using ChromaExpVanillaTest.FakeClassesForTests;
using Interfacer.Interfaces;
using NUnit;
using NUnit.Framework;

namespace ChromaExpVanillaTest
{
    [TestFixture]
    public class StateCheckerTest
    {
        [Test]
        public void Test_StateCheckerReturnsAction()
        {
            //create a class that implements the IKeyboardController and prints out the actions executed
            IKeyboardController keyboardController = new FakeKeboardController();
            IStateChecker checker = new CheckState();
            Action ReturnedStateActions = checker.States(keyboardController);
            ReturnedStateActions.Invoke();
            Assert.True(ReturnedStateActions.GetType() == typeof(Action));
        }
    }
}