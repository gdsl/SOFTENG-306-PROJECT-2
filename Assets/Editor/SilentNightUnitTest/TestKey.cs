using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TestKey {

    /**
     * Test to see when a key is added it will be in inventory
     */
    [Test]
    public void getKey()
    {
        PlayerInventorySingle pi = new PlayerInventorySingle();
        pi.gotKey(1);
        Assert.That(pi.hasKey(1));//check after getting key inventory updates
    }

    /**
     * Test to see when a key is no in inventory, inventory will say it dont have it
     */
    [Test]
    public void checkNoKey()
    {
        PlayerInventorySingle pi = new PlayerInventorySingle();
        Assert.That(pi.hasKey(2) == false);//check dont have key will say inventory dont have
    }
}
