﻿namespace SharpNeedle.Framework.HedgehogEngine.Needle.Shader.Variable;

public struct ConstantBuffer : IBinarySerializable
{
    private string? _name;

    public int Unknown1 { get; set; }

    public int Size { get; set; }

    public int ID { get; set; }

    public string Name
    {
        readonly get => _name ?? string.Empty;
        set => _name = value;
    }

    public void Read(BinaryObjectReader reader)
    {
        Unknown1 = reader.ReadInt32();
        Size = reader.ReadInt32();
        ID = reader.ReadInt32();
        Name = reader.ReadString(StringBinaryFormat.NullTerminated);
        reader.Align(4);
    }

    public void Write(BinaryObjectWriter writer)
    {
        writer.WriteInt32(Unknown1);
        writer.WriteInt32(Size);
        writer.WriteInt32(ID);
        writer.WriteString(StringBinaryFormat.NullTerminated, Name);
        writer.Align(4);
    }

    public override string ToString()
    {
        return Name;
    }
}