namespace SharpNeedle.Framework.SonicTeam.DiEvent.Parameters;

public class TimeParam : BaseParam
{
    public uint Field00 { get; set; }
    public uint Field04 { get; set; }
    public uint Field08 { get; set; }
    public uint Field0C { get; set; }
    public uint Field10 { get; set; }
    public uint Field14 { get; set; }
    public uint Field18 { get; set; }
    public uint Field1C { get; set; }
    public uint Field20 { get; set; }
    public float[] DataCurve { get; set; } = new float[32];

    public TimeParam() { }
    public TimeParam(BinaryObjectReader reader, GameType game)
    {
        Read(reader, game);
    }

    public override void Read(BinaryObjectReader reader, GameType game)
    {
        Field00 = reader.ReadUInt32();
        Field04 = reader.ReadUInt32();
        Field08 = reader.ReadUInt32();
        Field0C = reader.ReadUInt32();
        Field10 = reader.ReadUInt32();
        Field14 = reader.ReadUInt32();
        Field18 = reader.ReadUInt32();
        Field1C = reader.ReadUInt32();
        Field20 = reader.ReadUInt32();
        reader.ReadArray<float>(32, DataCurve);
    }

    public override void Write(BinaryObjectWriter writer, GameType game)
    {
        writer.Write(Field00);
        writer.Write(Field04);
        writer.Write(Field08);
        writer.Write(Field0C);
        writer.Write(Field10);
        writer.Write(Field14);
        writer.Write(Field18);
        writer.Write(Field1C);
        writer.Write(Field20);
        writer.WriteArrayFixedLength(DataCurve, 32);
    }

    public override int GetTypeID(GameType game)
    {
        switch (game)
        {
            case GameType.Frontiers:
                return (int)FrontiersParams.Time;

            default:
                return 0;
        }
    }
}