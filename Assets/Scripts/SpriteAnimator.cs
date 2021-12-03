using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator
{
  SpriteRenderer spirteRenderer;
  List<Sprite> frames;

  float frameRate;

  int currentFrame; 
  float timer;

  public SpriteAnimator(List<Sprite> frames, SpriteRenderer spirteRenderer, float frameRate = 0.16f)
  {
      this.frames = frames;
      this.spirteRenderer = spirteRenderer;
      this.frameRate = frameRate;
  }

  public void Start() {
      
          currentFrame = 0;
          timer = 0;
          spirteRenderer.sprite = frames[0];
  }

  public void HandleUpdate() {
      
          timer += Time.deltaTime;
          if(timer > frameRate)
          {
            currentFrame = (currentFrame + 1) % frames.Count;
            spirteRenderer.sprite = frames[currentFrame];
            timer -= frameRate;
          }
  }

  public List<Sprite> Frames {
      get { return frames ;}
  }
}
