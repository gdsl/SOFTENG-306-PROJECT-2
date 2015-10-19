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
    public void TestBoundryOneStarLevelOne()
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
    public void TestOneStarLevelOne()
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
    public void TestBoundryTwoStarLevelOne()
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
    public void TestTwostarLevelOne()
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
    public void TestBoundryThreeStarLevelOne()
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
    public void TestThreeStarLevelOne()
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

    //Level two
    /**
     * Test to see if score is 1500 it is still 1 star for level 2
     */
    [Test]
    public void TestBoundryOneStarLevelTwo()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 3000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 200";
        ct.text = "Cookie: 3";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 0f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(1500, le.getScore());
        Assert.AreEqual(1, le.getStar());
    }

    /**
     * Test to see if score is less than 1500 it is 1 star for level 2
     */
    [Test]
    public void TestOneStarLevelTwo()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 3000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 200";
        ct.text = "Cookie: 2";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 0f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(1000, le.getScore());
        Assert.AreEqual(1, le.getStar());
    }

    /**
    * Test to see if score is 3000 it is still 2 star for level 2
    */
    [Test]
    public void TestBoundryTwoStarLevelTwo()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 3000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 100";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 0f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(3000, le.getScore());
        Assert.AreEqual(2, le.getStar());
    }

    /**
     * Test to see if score is 1500-3000 (exclusive) it is 2 star for level 2
     */
    [Test]
    public void TestTwostarLevelTwo()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 3000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 110";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(2700, le.getScore());
        Assert.AreEqual(2, le.getStar());
    }

    /**
   * Test to see if score is 3001 it is still 3 star for level 2
   */
    [Test]
    public void TestBoundryThreeStarLevelTwo()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 3000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 50";
        ct.text = "Cookie: 0";
        suspicionSlider.maxValue = 5000f;
        suspicionSlider.value = 2998f;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(3001, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }

    /**
     * Test to see if score is >3001 (exclusive) it is 3 star for level 2
     */
    [Test]
    public void TestThreeStarLevelTwo()
    {
        LevelEnd le = new LevelEnd();
        le.threeStarScore = 3000;
        GameObject gb = new GameObject("stest");
        GameObject gb2 = new GameObject("ctest");
        UnityEngine.UI.Text st = gb.AddComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text ct = gb2.AddComponent<UnityEngine.UI.Text>();
        Slider suspicionSlider = gb.AddComponent<Slider>();
        st.text = "Time: 50";
        ct.text = "Cookie: 0";
        suspicionSlider.value = 0;
        le.cookieText = ct;
        le.timeText = st;
        le.suspicionSlider = suspicionSlider;
        le.CalculateScore();
        Assert.AreEqual(4500, le.getScore());
        Assert.AreEqual(3, le.getStar());
    }
}
