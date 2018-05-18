using System;
using System.Linq;
using System.Reflection;
using ChromaExpVanilla;
using ChromaExpVanillaTest.FakeClassesForTests;
using NUnit.Framework;

namespace ChromaExpVanillaTest
{
    [TestFixture]
    public class StateCheckerTest
    {
        [Test]
        public void Test_CapsLockIsOff()
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked {IsCapsLocked = false},
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList()
                .Where(x => x.Method.Name == "CapsLockOff"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "CapsLockOff");
            }
        }

        [Test]
        public void Test_CapsLockIsOn()
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked {IsCapsLocked = true},
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList()
                .Where(x => x.Method.Name == "CapsLockOn"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "CapsLockOn");
            }
        }

        [Test]
        public void Test_NumLockIsOff()
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked {IsCapsLocked = false},
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList()
                .Where(x => x.Method.Name == "NumLockOff"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "NumLockOff");
            }
        }

        [Test]
        public void Test_NumLockIsOn()
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked {IsCapsLocked = true},
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList()
                .Where(x => x.Method.Name == "NumLockOn"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "NumLockOn");
            }
        }

        [Test]
        public void Test_NumLockNotSet()
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked(),
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
        }

        [Test]
        public void Test_StateCheckerReturnsAction()
        {
            var checker = new CheckState {Control = new FakeKeboardController()};
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            Assert.True(returnedStateActions.GetType() == typeof(Action));
        }

        [Test]
        public void Test_StateCheckerReturnsEnglish()
        {
            var checker = new CheckState
            {
                KeyboardLayout = new FakeGetKeyboardLayout("en-US"),
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList().Where(x => x.Method.Name == "SetEng"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "SetEng");
            }
        }

        [Test]
        public void Test_StateCheckerReturnsHebrew()
        {
            var checker = new CheckState
            {
                KeyboardLayout = new FakeGetKeyboardLayout("he-IL"),
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList().Where(x => x.Method.Name == "SetHeb"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "SetHeb");
            }
        }
    }
}