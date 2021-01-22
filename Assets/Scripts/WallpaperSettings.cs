using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostPolygon.uLiveWallpaper
{
    public class WallpaperSettings : MonoBehaviour
    {
        public GameObject lightObject;

        Color Ocean_blue = new Color32(40, 150, 255, 255);
        Color Emerald = new Color32(60, 220, 50, 255);
        Color Iris = new Color32(100, 0, 240, 255);
        Color Sky = new Color32(30, 240, 200, 255);
        Color Candy = new Color32(240, 60, 60, 255);
        Color Valentines = new Color32(255, 140, 255, 255);
        Color Pineapple = new Color32(230, 240, 30, 255);
        Color Apricot = new Color32(220 ,90 ,40, 255);
        Color Crystal = new Color32(245, 245, 245, 255);
        Color Midnight = new Color32(10, 10, 10, 255);

        private void OnEnable()
        {
            LiveWallpaper.PreferenceChanged += LiveWallpaperOnPreferenceChanged;
        }

        private void OnDisable()
        {
            LiveWallpaper.PreferenceChanged -= LiveWallpaperOnPreferenceChanged;
        }

        private void LiveWallpaperOnPreferenceChanged(string key)
        {
            //Change color of lighting
            if (key == "general_light_color")
            {
                string color = LiveWallpaper.Preferences.GetString("general_light_color", "0");
                if (color.Equals("0")) lightObject.GetComponent<Light>().color = Ocean_blue;
                if (color.Equals("1")) lightObject.GetComponent<Light>().color = Emerald;
                if (color.Equals("2")) lightObject.GetComponent<Light>().color = Iris;
                if (color.Equals("3")) lightObject.GetComponent<Light>().color = Sky;
                if (color.Equals("4")) lightObject.GetComponent<Light>().color = Candy;
                if (color.Equals("5")) lightObject.GetComponent<Light>().color = Valentines;
                if (color.Equals("6")) lightObject.GetComponent<Light>().color = Pineapple;
                if (color.Equals("7")) lightObject.GetComponent<Light>().color = Apricot;
                if (color.Equals("8")) lightObject.GetComponent<Light>().color = Crystal;
                if (color.Equals("9")) lightObject.GetComponent<Light>().color = Midnight;
            }

            //Change day/night cycle
            if (key == "general_light_cycle")
            {
                string cycle = LiveWallpaper.Preferences.GetString("general_light_cycle", "0");
                if (cycle.Equals("0")) lightObject.GetComponent<ChangeLight>().ChangeCycleOption("0");
                if (cycle.Equals("1")) lightObject.GetComponent<ChangeLight>().ChangeCycleOption("1");
                if (cycle.Equals("2")) lightObject.GetComponent<ChangeLight>().ChangeCycleOption("2");
            }
        }
    }
}
