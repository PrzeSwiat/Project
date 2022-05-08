using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace Model
{
    internal class DataStore
    {
        private readonly ShapesDataApi _spheresApi;
        private readonly int _width;
        private readonly int _height;

        internal DataStore(int width, int height)
        {
            _width = width;
            _height = height;
            _spheresApi = ShapesDataApi.Initialize(width, height);
        }

        internal List<ShapesDataApi.SpheresAPI> GetSpheres()
        {
            return _spheresApi.GetAllSpheres();
        }

        internal void CreateSpheres(int amount)
        {
            _spheresApi.CreateSpheres(amount);
        }

        internal void TickSpheres()
        {
            _spheresApi.TickSpheres();
        }
    }
 }