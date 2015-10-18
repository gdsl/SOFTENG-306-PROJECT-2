using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NUnit.Framework;

public class TestSleepWalker
{
    /**
    * Test to check that the sleepwalker is woken correctly
    */
    [Test]
    public void TestWoken()
    {
        GameObject SleepWalker = GameObject.Instantiate(Resources.Load("Victoria")) as GameObject;
        GameObject touchObject = SleepWalker.transform.FindChild("SenseTouch").gameObject;
        Woken woken = touchObject.GetComponent<Woken>();
        GameObject santa = GameObject.Instantiate(Resources.Load("QueryChan")) as GameObject;

        // Test that they are not woken
        Assert.That(woken.woken == false);

        // Collision with santa and Michael
        woken.OnTriggerStay(santa.GetComponent<CapsuleCollider>()); // Unsure if this is proper practice as we have to make the ontrigger function public

        // Assert that they are woken
        Assert.That(woken.woken == true);
    }
}