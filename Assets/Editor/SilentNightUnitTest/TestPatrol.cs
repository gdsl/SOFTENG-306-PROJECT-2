using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NUnit.Framework;

public class TestPatrol
{
    /**
    * Test to check that the patrol AI is woken correctly
    */
    [Test]
    public void TestWoken()
    {
        // Instantiate prefabs
        GameObject patrolAI = GameObject.Instantiate(Resources.Load("Michael")) as GameObject;
        GameObject santa = GameObject.Instantiate(Resources.Load("QueryChan")) as GameObject;
        GameObject touchObject = patrolAI.transform.FindChild("SenseTouch").gameObject;
        Woken woken = touchObject.GetComponent<Woken>();

        // Test that they are not woken
        Assert.That(woken.woken == false);

        // Collision with santa and Michael
        woken.OnTriggerStay(santa.GetComponent<CapsuleCollider>()); // Unsure if this is proper practice as we have to make the ontrigger function public

        // Assert that they are woken
        Assert.That(woken.woken == true);
    }

    /**
    * Test to check that the patrol AI is woken correctly
    */
    [Test]
    public void TestSightStanding()
    {
        // Instantiate prefabs in certain positions
        GameObject patrolAI = GameObject.Instantiate(Resources.Load("Michael"), new Vector3(-5, 0, -7), Quaternion.Euler(0, 0, 0)) as GameObject;
        PersonSight personSight = patrolAI.GetComponent<PersonSight>();

        // Setup the sight
        personSight.Awake(); // Again unsure if this is ok, as we have to change this to public too

        // Assert that patrol AI cannot see santa
        Assert.That(personSight.santaInSight == false);

        // Instantiate santa infront of patrol AI
        GameObject santa = GameObject.Instantiate(Resources.Load("QueryChan"), new Vector3(-5, 0, -3), Quaternion.Euler(0, 0, 0)) as GameObject;

        // Create collision between santa and patrol AI
        personSight.OnTriggerStay(santa.GetComponent<CapsuleCollider>()); // Unsure if this is proper practice as we have to make the ontrigger function public

        // Assert that patrol AI has seen santa
        Assert.That(personSight.santaInSight == true);
    }
}