﻿using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace Model
{
    public class DataStore
    {
        private readonly LogicApi _spheresApi;
        private readonly int _width;
        private readonly int _height;

        public DataStore(int width, int height)
        {
            _width = width;
            _height = height;
            _spheresApi = LogicApi.Initialize(width, height);
        }

        public List<Object> GetSpheres()
        {
            List<Object> spheres = new List<Object>();
            foreach (object sphere in _spheresApi.GetAllSpheres())
            {
                spheres.Add(sphere);
            }
            return spheres;
        }

        public void CreateSpheres(int amount)
        {
            _spheresApi.CreateSpheres(amount);
        }
    }
 }