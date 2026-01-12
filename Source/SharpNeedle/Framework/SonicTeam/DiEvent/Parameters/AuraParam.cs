namespace SharpNeedle.Framework.SonicTeam.DiEvent.Parameters;

public class AuraParam : BaseParam
{
    public int Field00 { get; set; }
    public int Field04 { get; set; }
    public int Field08 { get; set; }
    public int Field0C { get; set; }
    public float Field10 { get; set; }
    public float Field14 { get; set; }
    public float Field18 { get; set; }
    public float Field1C { get; set; }
    public float Field20 { get; set; }
    public int Field24 { get; set; }
    public int Field28 { get; set; }
    public int Field2C { get; set; }
    public int Field30 { get; set; }
    public float Field34 { get; set; }
    public float Field38 { get; set; }
    public float Field3C { get; set; }
    public float Field40 { get; set; }
    public float Field44 { get; set; }
    public int Field48 { get; set; }
    public float[] ValuesTimeline { get; set; } = new float[32];

    public AuraParam() { }
    public AuraParam(BinaryObjectReader reader, GameType game)
    {
        Read(reader, game);
    }

    public override void Read(BinaryObjectReader reader, GameType game)
    {
        Field00 = reader.ReadInt32();
        Field04 = reader.ReadInt32();
        Field08 = reader.ReadInt32();
        Field0C = reader.ReadInt32();
        Field10 = reader.ReadSingle();
        Field14 = reader.ReadSingle();
        Field18 = reader.ReadSingle();
        Field1C = reader.ReadSingle();
        Field20 = reader.ReadSingle();
        Field24 = reader.ReadInt32();
        Field28 = reader.ReadInt32();
        Field2C = reader.ReadInt32();
        Field30 = reader.ReadInt32();
        Field34 = reader.ReadSingle();
        Field38 = reader.ReadSingle();
        Field3C = reader.ReadSingle();
        Field40 = reader.ReadSingle();
        Field44 = reader.ReadSingle();
        Field48 = reader.ReadInt32();
        reader.ReadArray<float>(32, ValuesTimeline);
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
        writer.Write(Field24);
        writer.Write(Field28);
        writer.Write(Field2C);
        writer.Write(Field30);
        writer.Write(Field34);
        writer.Write(Field38);
        writer.Write(Field3C);
        writer.Write(Field40);
        writer.Write(Field44);
        writer.Write(Field48);
        writer.WriteArrayFixedLength(ValuesTimeline, 32);
    }

    public override int GetTypeID(GameType game)
    {
        switch (game)
        {
            case GameType.Frontiers:
                return (int)FrontiersParams.Aura;

            case GameType.ShadowGenerations:
                return 0;

            default:
                return 0;
        }
    }
}