using System;
using UnityEngine;

namespace UnityPlatformer {
  //[RequireComponent (typeof (Character))]
  public class CharacterMonitor : ControllerMonitor {

    Character character;

    override public void Start() {
      base.Start ();
      character = GetComponent<Character> ();
      character.onStateChange += LogStateChanges;
    }
    override public  void OnGUI() {
      base.OnGUI ();
    }

    void LogStateChanges(States before, States after) {
      // this is a lot noisy, useful for debuging for nothing more...
      //Debug.LogFormat("state before: {0} / after: {1}", before, after);
    }

    override public void Update() {
      base.Update ();
      text += string.Format(
        "Area: {0}\n"+
        "State: {1}\n"+
        "Facing: {15} ForceAni: {12}\n"+
        "Ladder: {2} IsAboveTop {3} IsBelowBottom {4}\n" +
        "Liquid: {9}  IsBelowSurface {10} / {11}\n" +
        "Rope: {13} @ {14}\n" +
        "Platform: {5}\n" +
        "Jump: {6}\n" +
        "Velocity: {7} - {8}\n",
        character.area.ToString(),
        character.state.ToString(),
        character.ladder ? character.ladder.gameObject : null,
        character.ladder ? character.ladder.IsAboveTop(character, character.feet) : false,
        character.ladder ? character.ladder.IsBelowBottom(character, character.feet) : false,
        character.platform,
        character.lastJumpDistance,
        character.velocity.ToString("F4"), character.pc2d.collisions.velocity.ToString("F4"),
        character.liquid,
        character.liquid ? character.liquid.IsBelowSurface(character, 1.5f) : false,
        character.liquid ? character.liquid.DistanceToSurface(character, 1.5f) : -1,
        character.forceAnimation,
        character.rope, character.ropeIndex,
        character.faceDir
      );
    }
  }
}
