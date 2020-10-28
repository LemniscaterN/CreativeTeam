namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;

    public class ColorDiscrimination : MonoBehaviour//ルービックキューブ面の1マスずつの色識別
    {
        public Texture2D texture;
        // Use this for initialization
        public int Color_discrimination(/*Texture2D texture*/)
        {
            Mat mat = Unity.TextureToMat(this.texture);
            Mat changedMat = new Mat();
            int hue, sat, val;
            int[] color_number = new int[6];
            int max, most_color;

            Cv2.CvtColor(mat, changedMat, ColorConversionCodes.BGR2HSV);//RGB→HSV

            for (int y = 0; y < mat.Height; y++)
            {
                for (int x = 0; x < mat.Width; x++)
                {
                    hue = changedMat.At<Vec3b>(y, x)[0];
                    sat = changedMat.At<Vec3b>(y, x)[1];
                    val = changedMat.At<Vec3b>(y, x)[2];

                    if ((hue < 1 || 150 <= hue) && 100 < sat && 100 < val)//red
                    {
                        color_number[1]++;
                    }
                    else if ((1 <= hue && hue < 23) && 100 < sat && 100 < val)//orange
                    {
                        color_number[3]++;
                    }
                    else if ((23 <= hue && hue < 45) && 100 < sat && 100 < val)//yellow
                    {
                        color_number[5]++;
                    }
                    else if ((45 <= hue && hue < 90) && 100 < sat && 100 < val)//green
                    {
                        color_number[0]++;
                    }
                    else if ((90 <= hue && hue < 150) && 100 < sat && 100 < val)//blue
                    {
                        color_number[2]++;
                    }
                    else if ((0 < sat && sat < 50) && (127 < val && val < 251))//white
                    {
                        color_number[4]++;
                    }
                }

            }

            max = color_number[0];
            most_color = 0;
            for (int i = 1; i < 6; i++)
            {
                if (max < color_number[i])
                {
                    max = color_number[i];
                    most_color = i;
                }
            }

            return most_color;
        }

    }
}
