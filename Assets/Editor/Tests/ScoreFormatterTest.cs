using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using G2048.Tools;

public class ScoreFormatterTest {

    [Test]
    public void ScoreFormatterTest_Format_0()
    {
        Assert.AreEqual("0", ScoreFormatter.Format(0));
    }

    [Test]
    public void ScoreFormatterTest_Format_1()
    {
        Assert.AreEqual("1", ScoreFormatter.Format(1));
    }

    [Test]
    public void ScoreFormatterTest_Format_1_234()
    {
        Assert.AreEqual("1,234", ScoreFormatter.Format(1234));
    }

    [Test]
    public void ScoreFormatterTest_Format_1_234_567()
    {
        Assert.AreEqual("1,234,567", ScoreFormatter.Format(1234567));
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    //[UnityTest]
    //public IEnumerator ScoreFormatterTestWithEnumeratorPasses() {
    //    // Use the Assert class to test conditions.
    //    // yield to skip a frame
    //    yield return null;
    //}
}
