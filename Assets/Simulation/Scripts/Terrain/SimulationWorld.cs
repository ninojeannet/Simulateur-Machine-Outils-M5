using Unity.Mathematics;
using UnityEngine;
using Unity.Collections;


namespace Simulation
{
    /// <summary>
    /// A SimulationWorld generated from a heightmap
    /// </summary>
    public class SimulationWorld : World
    {
        /// <summary>
        /// The heightmap simulation generation settings
        /// </summary>
        [SerializeField] private SimulationSettings simulationSettings;

        /// <summary>
        /// The heightmap simulation generation settings
        /// </summary>
        public SimulationSettings SimulationSettings => simulationSettings;

        private void Awake()
        {
            int heightMapSize = CubeSize + 2; // +2 because the heighmap needs a "border" of one pixel empty to show the walls
            int amplitude = CubeSize;

            if (PlayerPrefs.HasKey("cubeSize"))
            {
                heightMapSize = PlayerPrefs.GetInt("cubeSize");
                heightMapSize += 2;
                amplitude = PlayerPrefs.GetInt("cubeSize");
                //Debug.Log("Data loaded successfully");
            }
            else
            {
                Debug.Log("Data was not loaded successfully, default values are used");
            }


           bool[,] heightmapArray = new bool[heightMapSize, heightMapSize];
            //Generate the 2D array representing the heighmap
            // True => material
            // False => nothing
            for (int x = 0; x < heightMapSize; x++)
            {
                for (int y = 0; y < heightMapSize; y++)
                {
                    if (x == 0 || y == 0 || x == heightMapSize - 1 || y == heightMapSize - 1)
                        heightmapArray[x, y] = false;
                    else
                        heightmapArray[x, y] = true;
                }
            }

            simulationSettings = new SimulationSettings(heightmapArray, heightMapSize, amplitude);            
        }

        protected override void Start()
        {
            base.Start();
            CreateHeightmap();
        }

        private void OnDestroy()
        {
            SimulationSettings.DisposeHeightmapData();
        }

        /// <summary>
        /// Creates the heightmap and instantiates the chunks.
        /// </summary>
        private void CreateHeightmap()
        {
            int chunkCountX = Mathf.CeilToInt((float) (simulationSettings.Width - 1) / ChunkSize);
            int chunkCountZ = Mathf.CeilToInt((float) (simulationSettings.Height - 1) / ChunkSize);
            int chunkCountY = Mathf.CeilToInt(simulationSettings.Amplitude / ChunkSize);

            for (int x = 0; x < chunkCountX; x++)
            {
                for (int y = 0; y < chunkCountY; y++)
                {
                    for (int z = 0; z < chunkCountZ; z++)
                    {
                        CreateChunk(new int3(x, y, z));
                    }
                }
            }
        }

        /// <summary>
        /// Instantiates a chunk to the specified coordinate
        /// </summary>
        /// <param name="chunkCoordinate">The chunk's coordinate</param>
        /// <returns>The instantiated chunk</returns>
        private SimulationChunk CreateChunk(int3 chunkCoordinate)
        {
            SimulationChunk chunk = Instantiate(ChunkPrefab, (chunkCoordinate * ChunkSize).ToVectorInt(), Quaternion.identity).GetComponent<SimulationChunk>();
            chunk.name = $"Chunk_{chunkCoordinate.x}_{chunkCoordinate.y}_{chunkCoordinate.z}";
            chunk.World = this;
            chunk.Initialize(ChunkSize, Isolevel, chunkCoordinate,CubeSize);
            Chunks.Add(chunkCoordinate, chunk);

            return chunk;
        }
    }
}