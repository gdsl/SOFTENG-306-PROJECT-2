#pragma strict

var impact : AudioClip;
function OnCollisionEnter (collision: Collision) {
    if (collision.relativeVelocity.magnitude > 2) {
        GetComponent.<AudioSource>().PlayOneShot(impact, 1f);
    }
    }