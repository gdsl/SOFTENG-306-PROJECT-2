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
        Assert.AreEqual(5000,le.getScore());
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
        Assert.AreEqual(5500, le.getScore());
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
        Assert.AreEqual(4940, le.getScore());
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
        suspicionSlider.value = 1f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(4999, le.getScore());
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
        Assert.AreEqual(0, le.getScore());
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
        Assert.AreEqual(0, le.getScore());
    }

    /**
     * Test combination of the effect of all 3 factor (time cookie slider) on score
     */
    [Test]
    public void testCombineFactors()
    {
        LevelEnd le = new LevelEnd();
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
        Assert.AreEqual(3400, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }

    /**
     * Test under max slider increment values effect on score should the slider value
     */
    [Test]
    public void testSliderUnderMax()
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
        suspicionSlider.value = 3000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2000, le.getScore());
    }

    /**
     * Test to see if score is 2000 it is still 1 star
     */
    [Test]
    public void testBoundryOneStar()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 3000";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2000, le.getScore());
        Assert.AreEqual(1, le.getStar());
    }

    /**
     * Test to see if score is less than 2000 it is 1 star
     */
    [Test]
    public void testOneStar()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 4000";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(1000, le.getScore());
        Assert.AreEqual(1, le.getStar());
    }

    /**
    * Test to see if score is 3000 it is still 2 star
    */
    [Test]
    public void testBoundryTwoStar()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 2000";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(3000, le.getScore());
        Assert.AreEqual(2, le.getStar());
    }

    /**
     * Test to see if score is 2000-3000 (exclusive) it is 2 star
     */
    [Test]
    public void testTwostar()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 2500";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2500, le.getScore());
        Assert.AreEqual(2, le.getStar());
    }

    /**
   * Test to see if score is 3001 it is still 3 star
   */
    [Test]
    public void testBoundryThreeStar()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 1999";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(3001, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }

    /**
     * Test to see if score is >3000 (exclusive) it is 3 star
     */
    [Test]
    public void testThreeStar()
    {
        LevelEnd le = new LevelEnd();
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 1000";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(4000, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }
}
