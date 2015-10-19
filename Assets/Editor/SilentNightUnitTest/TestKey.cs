using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TestKey {

    /**
     * Test to see when a key is added it will be in inventory
     */
    [Test]
    public void TestGetKey()
    {
        PlayerInventorySingle pi = new PlayerInventorySingle();
        pi.GotKey(1);
        Assert.That(pi.HasKey(1));//check after getting key inventory updates
    }

    /**
     * Test to see when a key is no in inventory, inventory will say it dont have it
     */
    [Test]
    public void TestCheckNoKey()
    {
        PlayerInventorySingle pi = new PlayerInventorySingle();
        Assert.That(pi.HasKey(2) == false);//check dont have key will say inventory dont have
    }
}
