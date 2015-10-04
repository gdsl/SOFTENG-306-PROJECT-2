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
        PlayerInventory pi = new PlayerInventory();
        pi.gotKey(1);
        Assert.That(pi.hasKey(1));//check after getting key inventory updates
    }

    /**
     * Test to see when a key is no in inventory, inventory will say it dont have it
     */
    [Test]
    public void checkNoKey()
    {
        PlayerInventory pi = new PlayerInventory();
        Assert.That(pi.hasKey(2) == false);//check dont have key will say inventory dont have
    }
}
