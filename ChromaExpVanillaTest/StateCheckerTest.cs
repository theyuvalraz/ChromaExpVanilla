using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        public async Task Test_StateCheckerReturnsAction()
        {
            //create a class that implements the IKeyboardController and prints out the actions executed
            IKeyboardController keyboardController = new FakeKeboardController();
            IStateChecker checker = new CheckState();
            var returnedStateActions = await checker.States( keyboardController );
            returnedStateActions.Invoke();
            Assert.True(returnedStateActions.GetType() == typeof(Task<Action>));
        }

        [Test]
        public async Task Test_StateCheckerReturnsEnglish()
        {
            //create a class that implements the IKeyboardController and prints out the actions executed
            IKeyboardController keyboardController = new FakeKeboardController();
            IStateChecker checker = new CheckState();
            checker.KeyboardLayout = new FakeGetKeyboardLayout("en-US");
            var returnedStateActions = await checker.States(keyboardController);
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList().Where(x => x.Method.Name == "SetEng"))
            {
                Console.WriteLine(delegateItem.GetMethodInfo());
                Assert.True(delegateItem.GetMethodInfo().Name == "SetEng");
            }
        }
        [Test]
        public async Task Test_StateCheckerReturnsHebrew()
        {
            //create a class that implements the IKeyboardController and prints out the actions executed
            IKeyboardController keyboardController = new FakeKeboardController();
            IStateChecker checker = new CheckState();
            checker.KeyboardLayout = new FakeGetKeyboardLayout( "he-IL" );
            var returnedStateActions = await checker.States( keyboardController );
            returnedStateActions.Invoke();
            foreach (var delegateItem in returnedStateActions.GetInvocationList().Where( x => x.Method.Name == "SetHeb" ))
            {
                Console.WriteLine( delegateItem.GetMethodInfo() );
                Assert.True( delegateItem.GetMethodInfo().Name == "SetHeb" );
            }
        }
    }
}