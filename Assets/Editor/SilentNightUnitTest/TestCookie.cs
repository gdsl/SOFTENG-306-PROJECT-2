using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NUnit.Framework;

public class TestCookie
{

    /**
     * Test to see when a cookie count increase is increase by 1
     */
    [Test]
    public void getCookie()
    {
        PlayerInventory pi = new PlayerInventory();
        pi.IncreaseCookieCount(); //check increase initially willl get 1 cookies
        Assert.That(pi.getCookieCount() == 1);
        pi.IncreaseCookieCount(); //check increase again will +1 and not reset
        Assert.That(pi.getCookieCount() == 2);
    }
}
