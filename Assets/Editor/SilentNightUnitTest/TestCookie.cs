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
    public void TestGetCookie()
    {
        GameObject gb = new GameObject("CookieText");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        st.text = "Cookie:";
        PlayerInventorySingle pi = new PlayerInventorySingle();
        pi.ResetCookie();
        pi.IncreaseCookieCount(); //check increase initially willl get 1 cookies
        Assert.That(pi.GetCookieCount() == 1);
        pi.IncreaseCookieCount(); //check increase again will +1 and not reset
        Assert.That(pi.GetCookieCount() == 2);
    }
}
