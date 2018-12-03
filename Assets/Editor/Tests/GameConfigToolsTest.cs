using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using G2048.Tools;

using CA = NUnit.Framework.CollectionAssert;
public class GameConfigToolsTest
{

    [Test]
    public void CreateRange_Test1()
    {
        CA.AreEqual(new ulong[] { 2 }, GameConfigTools.CreateRange(1));
    }

    [Test]
    public void CreateRange_Test2()
    {
        CA.AreEqual(new ulong[] { 2, 2, 4 }, GameConfigTools.CreateRange(2));
    }

    [Test]
    public void CreateRange_Test3()
    {
        CA.AreEqual(new ulong[] { 2, 2, 2, 2, 4, 4, 8 }, GameConfigTools.CreateRange(3));
    }
    //// A UnityTest behaves like a coroutine in PlayMode
    //// and allows you to yield null to skip a frame in EditMode
    //[UnityTest]
    //public IEnumerator iOSWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // yield to skip a frame
    //    yield return null;
    //}
}
