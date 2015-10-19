using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NUnit.Framework;

public class TestScore
{

    /**
     * Test to if the base score is 5000
     */
    [Test]
    public void testBaseScore()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st =gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct =gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 0";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText=ct;
        le.timeText=st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(6000,le.getScore());
    }

    /**
     * Test to see if the get a cookie increase point by 500
     */
    [Test]
    public void testCookieScore()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 0";
        ct.text = "Cookie: 1";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(6500, le.getScore());
    }

    /**
     * Test to see if the time decrease score by its amount
     */
    [Test]
    public void testTimeScore()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 60";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(4200, le.getScore());
    }

    /**
    * Test base slider increment values
    */
    [Test]
    public void testSlider()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 0";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 2f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(5999, le.getScore());
    }

    /**
    * Test max slider increment values effect on score
    */
    [Test]
    public void testSliderMax()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 0";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 5000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(3500, le.getScore());
    }

    /**
     * Test over max slider increment values effect on score should be cap by max
     */
    [Test]
    public void testSliderOverMax()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 0";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 6000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(3500, le.getScore());
    }

    /**
     * Test combination of the effect of all 3 factor (time cookie slider) on score
     */
    [Test]
    public void testCombineFactors()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 100";
        ct.text = "Cookie: 1";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 2000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2500, le.getScore());
    }

    /**
     * Test under max slider increment values effect on score should the slider value
     */
    [Test]
    public void testSliderUnderMax()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 0";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 3000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(4500, le.getScore());
    }
}
