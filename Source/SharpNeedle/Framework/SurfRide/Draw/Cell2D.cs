namespace SharpNeedle.Framework.SurfRide.Draw;

using SharpNeedle.Structs;

public class Cell2D : ICell
{
    public Color<byte> MaterialColor { get; set; }
    public Color<byte> IlluminationColor { get; set; }
    public byte Field08 { get; set; }
    public byte Field09 { get; set; }
    public byte Field0A { get; set; }
    public byte Field0B { get; set; }
    public Vector2 Translation { get; set; }
    public Vector2 Scale { get; set; }
    public uint RotationZ { get; set; }

    public void Read(BinaryObjectReader reader, ChunkBinaryOptions options)
    {
        MaterialColor = reader.Read<Color<byte>>();
        IlluminationColor = reader.Read<Color<byte>>();
        Field08 = reader.ReadByte();
        Field09 = reader.ReadByte();
        Field0A = reader.ReadByte();
        Field0B = reader.ReadByte();
        Translation = reader.ReadVector2();
        if (options.Version >= 4)
        {
            reader.Align(16);
            Translation = reader.ReadVector2();
            reader.Align(16);
            Scale = reader.ReadVector2();
            RotationZ = reader.ReadUInt32();
            reader.Align(16);
        }
        else
        {
            Translation = reader.ReadVector2();
            Scale = reader.ReadVector2();
            RotationZ = reader.ReadUInt32();
        }
    }

    public void Write(BinaryObjectWriter writer, ChunkBinaryOptions options)
    {
        writer.Write(MaterialColor);
        writer.Write(IlluminationColor);
        writer.Write(Field08);
        writer.Write(Field09);
        writer.Write(Field0A);
        writer.Write(Field0B);
        if (options.Version >= 4)
        {
            writer.Align(16);
            writer.Write(Translation);
            writer.Align(16);
            writer.Write(Scale);
            writer.Write(RotationZ);
            writer.Align(16);
        }
        else
        {
            writer.Write(Translation);
            writer.Write(Scale);
            writer.Write(RotationZ);
        }
    }
}
