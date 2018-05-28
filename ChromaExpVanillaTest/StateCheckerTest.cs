using System;
using System.Linq;
using ChromaExpVanilla;
using ChromaExpVanillaTest.FakeClassesForTests;
using NUnit.Framework;

namespace ChromaExpVanillaTest
{
    [TestFixture]
    public class StateCheckerTest
    {
        [TestCase("he-IL", "SetHeb")]
        [TestCase("en-US", "SetEng")]
        public void Test_StateCheckerReturnsCorrectLanguage(string inputLanguage, string expectedResult)
        {
            var checker = new CheckState
            {
                KeyboardLayout = new FakeGetKeyboardLayout(inputLanguage),
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            Assert.IsTrue(returnedStateActions.GetInvocationList().Any(x => x.Method.Name == expectedResult));
        }

        [TestCase(false, "CapsLockOff")]
        [TestCase(true, "CapsLockOn")]
        [TestCase(null, "CapsLockOff")]
        public void Test_StateCheckerReturnsCorrectCapsLockState(bool CapsLockState, string expectedResult)
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked {IsCapsLocked = CapsLockState},
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            Assert.IsTrue(returnedStateActions.GetInvocationList().Any(x => x.Method.Name == expectedResult));
        }

        [TestCase(false, "NumLockOff")]
        [TestCase(true, "NumLockOn")]
        [TestCase(null, "NumLockOff")]
        public void Test_StateCheckerReturnsCorrectNumLockState(bool NumLockState, string expectedResult)
        {
            var checker = new CheckState
            {
                IsLocked = new FakeGetIsLocked {IsNumLocked = NumLockState},
                Control = new FakeKeboardController()
            };
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            Assert.IsTrue(returnedStateActions.GetInvocationList().Any(x => x.Method.Name == expectedResult));
        }

        [Test]
        public void Test_StateCheckerReturnsAction()
        {
            var checker = new CheckState {Control = new FakeKeboardController()};
            var returnedStateActions = checker.States();
            returnedStateActions.Invoke();
            Assert.True(returnedStateActions.GetType() == typeof(Action));
        }

        //[TestCase(false, "")]
        //[TestCase(true, "")]
        //public void Test_StateCheckerReturnsCorrectBaseFlagState(bool FlagState, string expectedResult)
        //{
        //    var checker = new CheckState
        //    {
        //        Control = new FakeKeboardController()
        //        ,BaseNeeded = FlagState
        //    };
        //    var returnedStateActions = checker.States();
        //    returnedStateActions.Invoke();
        //    Assert.IsTrue(returnedStateActions.GetInvocationList().Any(x => x.Method.Name == expectedResult));
        //}
    }
}