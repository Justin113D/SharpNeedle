namespace SharpNeedle.Framework.HedgehogEngine.Mirage.LightData;

public class LightIndexData : IBinarySerializable
{
    public uint[] LightIndices { get; set; } = [];
    public ushort[] VertexIndices { get; set; } = [];

    public void Read(BinaryObjectReader reader)
    {
        int lightsCount = reader.ReadInt32();
        reader.ReadOffset(() => LightIndices = reader.ReadArray<uint>(lightsCount));

        int verticesCount = reader.ReadInt32();
        reader.ReadOffset(() => VertexIndices = reader.ReadArray<ushort>(verticesCount));
    }

    public void Write(BinaryObjectWriter writer)
    {
        writer.Write(LightIndices.Length);
        writer.WriteArrayOffset(LightIndices);

        writer.Write(VertexIndices.Length);
        writer.WriteArrayOffset(VertexIndices);
    }
}
