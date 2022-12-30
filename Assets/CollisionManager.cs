using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{



}
    //private void CircleCollisionDetection()
    //{
    //    for (Circle circle : circles)
    //    {
    //        for (Circle oCircle : circles)
    //        {
    //            if (circle != oCircle)
    //            {
    //                double dx = Math.abs((double)circle.x - (double)oCircle.x);
    //                double dy = Math.abs((double)circle.y - (double)oCircle.y);
    //                float distance = (float)Math.sqrt(dx * dx + dy * dy);

    //                if (distance < circle.radius + circle.radius)
    //                {
    //                    float diferenceX = oCircle.x - circle.x;
    //                    float diferenceY = oCircle.y - circle.y;
    //                    circle.velx = -diferenceX / maxRadius;
    //                    circle.vely = -diferenceY / maxRadius;

    //                    Circle effect = new Circle((circle.x + oCircle.x) / 2, (circle.y + oCircle.y) / 2, 0, 0, 2, WIDTH);
    //                    effect.SetColor(Color.red);
    //                    effects.add(effect);

    //                }

    //            }
