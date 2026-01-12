namespace SharpNeedle.Framework.SonicTeam.DiEvent.Parameters;

public class VignetteParam : BaseParam
{
    public int Field00 { get; set; }
    public int Field04 { get; set; }
    public float Field08 { get; set; }
    public float Field0C { get; set; }
    public float Field10 { get; set; }
    public float Field14 { get; set; }
    public float Field18 { get; set; }
    public float Field1C { get; set; }
    public float Field20 { get; set; }
    public int Field24 { get; set; }
    public float Field28 { get; set; }
    public float Field2C { get; set; }
    public float Field30 { get; set; }
    public float Field34 { get; set; }
    public float Field38 { get; set; }
    public float Field3C { get; set; }
    public float Field40 { get; set; }
    public float Field44 { get; set; }
    public float Field48 { get; set; }
    public float Field4C { get; set; }
    public float Field50 { get; set; }
    public float Field54 { get; set; }
    public float Field58 { get; set; }
    public float Field5C { get; set; }
    public float Field60 { get; set; }
    public float Field64 { get; set; }
    public float Field68 { get; set; }
    public float Field6C { get; set; }
    public float Field70 { get; set; }
    public float Field74 { get; set; }
    public float Field78 { get; set; }
    public float Field7C { get; set; }
    public float Field80 { get; set; }
    public float Field84 { get; set; }
    public int Field88 { get; set; }
    public float Field8C { get; set; }
    public float Field90 { get; set; }
    public float Field94 { get; set; }
    public float Field98 { get; set; }
    public float Field9C { get; set; }
    public float FieldA0 { get; set; }
    public float FieldA4 { get; set; }
    public float FieldA8 { get; set; }
    public float FieldAC { get; set; }
    public float FieldB0 { get; set; }
    public float FieldB4 { get; set; }
    public float FieldB8 { get; set; }
    public float FieldBC { get; set; }
    public float FieldC0 { get; set; }
    public float FieldC4 { get; set; }
    public float[] ValuesTimeline { get; set; } = new float[32];

    public VignetteParam() { }
    public VignetteParam(BinaryObjectReader reader, GameType game)
    {
        Read(reader, game);
    }

    public override void Read(BinaryObjectReader reader, GameType game)
    {
        Field00 = reader.ReadInt32();
        Field04 = reader.ReadInt32();
        Field08 = reader.ReadSingle();
        Field0C = reader.ReadSingle();
        Field10 = reader.ReadSingle();
        Field14 = reader.ReadSingle();
        Field18 = reader.ReadSingle();
        Field1C = reader.ReadSingle();
        Field20 = reader.ReadSingle();
        Field24 = reader.ReadInt32();
        Field28 = reader.ReadSingle();
        Field2C = reader.ReadSingle();
        Field30 = reader.ReadSingle();
        Field34 = reader.ReadSingle();
        Field38 = reader.ReadSingle();
        Field3C = reader.ReadSingle();
        Field40 = reader.ReadSingle();
        Field44 = reader.ReadSingle();
        Field48 = reader.ReadSingle();
        Field4C = reader.ReadSingle();
        Field50 = reader.ReadSingle();
        Field54 = reader.ReadSingle();
        Field58 = reader.ReadSingle();
        Field5C = reader.ReadSingle();
        Field60 = reader.ReadSingle();
        Field64 = reader.ReadSingle();
        Field68 = reader.ReadSingle();
        Field6C = reader.ReadSingle();
        Field70 = reader.ReadSingle();
        Field74 = reader.ReadSingle();
        Field78 = reader.ReadSingle();
        Field7C = reader.ReadSingle();
        Field80 = reader.ReadSingle();
        Field84 = reader.ReadSingle();
        Field88 = reader.ReadInt32();
        Field8C = reader.ReadSingle();
        Field90 = reader.ReadSingle();
        Field94 = reader.ReadSingle();
        Field98 = reader.ReadSingle();
        Field9C = reader.ReadSingle();
        FieldA0 = reader.ReadSingle();
        FieldA4 = reader.ReadSingle();
        FieldA8 = reader.ReadSingle();
        FieldAC = reader.ReadSingle();
        FieldB0 = reader.ReadSingle();
        FieldB4 = reader.ReadSingle();
        FieldB8 = reader.ReadSingle();
        FieldBC = reader.ReadSingle();
        FieldC0 = reader.ReadSingle();
        FieldC4 = reader.ReadSingle();

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
        writer.Write(Field4C);
        writer.Write(Field50);
        writer.Write(Field54);
        writer.Write(Field58);
        writer.Write(Field5C);
        writer.Write(Field60);
        writer.Write(Field64);
        writer.Write(Field68);
        writer.Write(Field6C);
        writer.Write(Field70);
        writer.Write(Field74);
        writer.Write(Field78);
        writer.Write(Field7C);
        writer.Write(Field80);
        writer.Write(Field84);
        writer.Write(Field88);
        writer.Write(Field8C);
        writer.Write(Field90);
        writer.Write(Field94);
        writer.Write(Field98);
        writer.Write(Field9C);
        writer.Write(FieldA0);
        writer.Write(FieldA4);
        writer.Write(FieldA8);
        writer.Write(FieldAC);
        writer.Write(FieldB0);
        writer.Write(FieldB4);
        writer.Write(FieldB8);
        writer.Write(FieldBC);
        writer.Write(FieldC0);
        writer.Write(FieldC4);

        writer.WriteArrayFixedLength(ValuesTimeline, 32);
    }

    public override int GetTypeID(GameType game)
    {
        switch (game)
        {
            case GameType.Frontiers:
                return (int)FrontiersParams.Vignette;

            case GameType.ShadowGenerations:
                return (int)ShadowGensParams.Vignette;

            default:
                return 0;
        }
    }
}