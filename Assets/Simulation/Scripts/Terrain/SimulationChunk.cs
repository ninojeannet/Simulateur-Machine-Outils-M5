using Unity.Jobs;
using Unity.Mathematics;

namespace Simulation
{
    /// <summary>
    /// A chunk that is generated from a heightmap
    /// </summary>
    public class SimulationChunk : Chunk
    {
        /// <summary>
        /// The SimulationWorld that owns this chunk
        /// </summary>
        public SimulationWorld World { get; set; }

        /// <summary>
        /// Starts the density calculation
        /// </summary>
        public override void StartDensityCalculation()
        {
            int3 worldPosition = Coordinate * ChunkSize;

            var job = new SimulationDensityCalculationJob
            {
                Densities = Densities,
                heightmapData = World.SimulationSettings.HeightmapData,
                offset = worldPosition,
                chunkSize = ChunkSize + 1, // +1 because chunkSize is the amount of "voxels", and that +1 is the amount of density points
                heightmapWidth = World.SimulationSettings.Width,
                heightmapHeight = World.SimulationSettings.Height,
                amplitude = World.SimulationSettings.Amplitude,
            };

            DensityJobHandle = job.Schedule(Densities.Length, 256);
        }
    }
}