namespace SharpNeedle.Framework.SonicTeam.DiEvent.Parameters;

public class SonicCameraParam : BaseParam
{
    public uint Flags { get; set; }
    public uint Field04 { get; set; }
    public uint Field08 { get; set; }
    public uint Field0C { get; set; }
    public Vector3 Field10 { get; set; }
    public uint Field1C { get; set; }
    public uint Field20 { get; set; }
    public uint Field24 { get; set; }
    public Vector3 Field28 { get; set; }
    public byte[] UnknownData { get; set; } = new byte[268];

    public SonicCameraParam() { }
    public SonicCameraParam(BinaryObjectReader reader, GameType game)
    {
        Read(reader, game);
    }

    public override void Read(BinaryObjectReader reader, GameType game)
    {
        Flags = reader.ReadUInt32();
        Field04 = reader.ReadUInt32();
        Field08 = reader.ReadUInt32();
        Field0C = reader.ReadUInt32();
        Field10 = reader.ReadVector3();
        Field1C = reader.ReadUInt32();
        Field20 = reader.ReadUInt32();
        Field24 = reader.ReadUInt32();
        Field28 = reader.ReadVector3();
        reader.ReadArray<byte>(268, UnknownData);
    }

    public override void Write(BinaryObjectWriter writer, GameType game)
    {
        writer.Write(Flags);
        writer.Write(Field04);
        writer.Write(Field08);
        writer.Write(Field0C);
        writer.Write(Field10);
        writer.Write(Field1C);
        writer.Write(Field20);
        writer.Write(Field24);
        writer.Write(Field28);
        writer.WriteArrayFixedLength(UnknownData, 268);
    }

    public override int GetTypeID(GameType game) { return (int)ParameterType.SonicCamera; }
}