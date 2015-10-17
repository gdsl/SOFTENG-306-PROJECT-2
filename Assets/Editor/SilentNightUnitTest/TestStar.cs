using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NUnit.Framework;

public class TestStar
{
    /**
     * Test to see if score is 2500 it is still 1 star for level 1
     */
    [Test]
    public void testBoundryOneStarLevelOne()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 100";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 1000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2500, le.getScore());
        Assert.AreEqual(1, le.getStar());
    }

    /**
     * Test to see if score is less than 2500 it is 1 star for level 1
     */
    [Test]
    public void testOneStarLevelOne()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 120";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 0f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2400, le.getScore());
        Assert.AreEqual(1, le.getStar());
    }

    /**
    * Test to see if score is 5000 it is still 2 star for level 1
    */
    [Test]
    public void testBoundryTwoStarLevelOne()
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
        suspicionSlider.value = 2000f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(5000, le.getScore());
        Assert.AreEqual(2, le.getStar());
    }

    /**
     * Test to see if score is 2500-5000 (exclusive) it is 2 star for level 1
     */
    [Test]
    public void testTwostarLevelOne()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 100";
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
   * Test to see if score is 5001 it is still 3 star for level 1
   */
    [Test]
    public void testBoundryThreeStarLevelOne()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 30";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 198f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(5001, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }

    /**
     * Test to see if score is >5001 (exclusive) it is 3 star for level 1
     */
    [Test]
    public void testThreeStarLevelOne()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 5000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 10";
        ct.text = "Cookie: 1";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(6200, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }
}
