using System;
using System.Linq;
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
            var returnedStateActions = checker.States(keyboardController);
            returnedStateActions.Invoke();
            Assert.True(returnedStateActions.GetType() == typeof(Action));
        }

        [Test]
        public void Test_StateCheckerReturnsEnglish()
        {
            //create a class that implements the IKeyboardController and prints out the actions executed
            IKeyboardController keyboardController = new FakeKeboardController();
            IStateChecker checker = new CheckState();
            checker.KeyboardLayout = new FakeGetKeyboardLayout("en-US");
            var returnedStateActions = checker.States(keyboardController);
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList().Where(x => x.Method.Name == "SetEng"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "SetEng");
            }
        }
    }
}