namespace SharpNeedle.Framework.Ninja.Csd;

using SharpNeedle.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct CastInfo : IBinarySerializable
{
    public uint HideFlag;
    public Vector2 Translation;
    public float Rotation;
    public Vector2 Scale;
    public float SpriteIndex;
    public Color<byte> Color;
    public Color<byte> GradientTopLeft;
    public Color<byte> GradientBottomLeft;
    public Color<byte> GradientTopRight;
    public Color<byte> GradientBottomRight;
    public uint UserData0;
    public uint UserData1;
    public uint UserData2;

    public void Read(BinaryObjectReader reader)
    {
        HideFlag = reader.ReadUInt32();
        Translation = reader.ReadVector2();
        Rotation = reader.ReadSingle();
        Scale = reader.ReadVector2();
        SpriteIndex = reader.ReadSingle();

        // Colours are handled as uints for endianness
        Unsafe.As<Color<byte>, uint>(ref Color) = reader.ReadUInt32();
        Unsafe.As<Color<byte>, uint>(ref GradientTopLeft) = reader.ReadUInt32();
        Unsafe.As<Color<byte>, uint>(ref GradientBottomLeft) = reader.ReadUInt32();
        Unsafe.As<Color<byte>, uint>(ref GradientTopRight) = reader.ReadUInt32();
        Unsafe.As<Color<byte>, uint>(ref GradientBottomRight) = reader.ReadUInt32();

        UserData0 = reader.ReadUInt32();
        UserData1 = reader.ReadUInt32();
        UserData2 = reader.ReadUInt32();
    }

    public void Write(BinaryObjectWriter writer)
    {
        writer.Write(HideFlag);
        writer.Write(Translation);
        writer.Write(Rotation);
        writer.Write(Scale);
        writer.Write(SpriteIndex);

        // Colours are handled as uints for endianness
        writer.Write(Unsafe.As<Color<byte>, uint>(ref Color));
        writer.Write(Unsafe.As<Color<byte>, uint>(ref GradientTopLeft));
        writer.Write(Unsafe.As<Color<byte>, uint>(ref GradientBottomLeft));
        writer.Write(Unsafe.As<Color<byte>, uint>(ref GradientTopRight));
        writer.Write(Unsafe.As<Color<byte>, uint>(ref GradientBottomRight));

        writer.Write(UserData0);
        writer.Write(UserData1);
        writer.Write(UserData2);
    }
}