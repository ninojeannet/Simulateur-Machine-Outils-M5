using System;
using Unity.Collections;
using UnityEngine;

namespace Simulation
{
    [Serializable]
    public struct SimulationSettings
    {


        [SerializeField] private bool[,] heightmapArray;

        /// <summary>
        /// The generated height data from the the heightmap
        /// </summary>
        [SerializeField] private NativeArray<float> heightmapData;

        /// <summary>
        /// The width of the heightmap in pixels
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// The height of the heightmap in pixels
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// The height of the heightmap in pixels
        /// </summary>
        public int Amplitude { get; private set; }

        /// <summary>
        /// The generated height data from the the heightmap
        /// </summary>
        public NativeArray<float> HeightmapData
        {
            get => heightmapData;
            set => heightmapData = value;
        }


        /// <summary>
        /// SimulationSettings constructor. Creates HeightmapData from the heightmap
        /// </summary>
        /// <param name="heightmap">The black and white heightmap</param>
        /// <param name="amplitude">Height multiplier</param>
        /// <param name="heightOffset">Moves the sampling point up and down</param>
        public SimulationSettings( bool[,] heightmapArray,int size, int amplitude)
        {
            Amplitude = amplitude;
            Width = size;
            Height = size;
            this.heightmapArray = heightmapArray;
            heightmapData = new NativeArray<float>(Width * Height, Allocator.Persistent);
            SetHeightmap(heightmapArray);
        }

        /// <summary>
        /// Generates the HeightmapData from the heightmap
        /// </summary>
        /// <param name="heightmapArray">the True or False heightmap</param>
        private void SetHeightmap(bool[,] heightmapArray)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if(heightmapArray[x,y])
                    {
                        heightmapData[x + Width * y] = 1;
                    }
                    else
                    {
                        heightmapData[x + Width * y] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Disposes HeightmapData
        /// </summary>
        public void DisposeHeightmapData()
        {
            heightmapData.Dispose();
        }
    }
}