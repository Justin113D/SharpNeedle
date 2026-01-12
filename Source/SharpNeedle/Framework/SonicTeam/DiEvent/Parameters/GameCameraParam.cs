namespace SharpNeedle.Framework.SonicTeam.DiEvent.Parameters;

public class GameCameraParam : BaseParam
{
    public int Field00 { get; set; }
    public int Field04 { get; set; }
    public int Field08 { get; set; }
    public int Field0C { get; set; }
    public float Field10 { get; set; }
    public float Field14 { get; set; }
    public float Field18 { get; set; }
    public int Field1C { get; set; }
    public int Field20 { get; set; }
    public int Field24 { get; set; }
    public float Field28 { get; set; }
    public float Field2C { get; set; }
    public float Field30 { get; set; }
    public int Field34 { get; set; }
    public int Field38 { get; set; }
    public int Field3C { get; set; }
    public int Field40 { get; set; }
    public float Field44 { get; set; }
    public int Field48 { get; set; }
    public int Field4C { get; set; }
    public float NearCullingPlane { get; set; }
    public float FarCullingPlane { get; set; }
    public float Field58 { get; set; }
    public int Field5C { get; set; }
    public int Field60 { get; set; }
    public int Field64 { get; set; }

    public GameCameraParam() { }
    public GameCameraParam(BinaryObjectReader reader, GameType game)
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
        Field1C = reader.ReadInt32();
        Field20 = reader.ReadInt32();
        Field24 = reader.ReadInt32();
        Field28 = reader.ReadSingle();
        Field2C = reader.ReadSingle();
        Field30 = reader.ReadSingle();
        Field34 = reader.ReadInt32();
        Field38 = reader.ReadInt32();
        Field3C = reader.ReadInt32();
        Field40 = reader.ReadInt32();
        Field44 = reader.ReadSingle();
        Field48 = reader.ReadInt32();
        Field4C = reader.ReadInt32();
        NearCullingPlane = reader.ReadSingle();
        FarCullingPlane = reader.ReadSingle();
        Field58 = reader.ReadSingle();
        Field5C = reader.ReadInt32();
        Field60 = reader.ReadInt32();
        Field64 = reader.ReadInt32();
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
        writer.Write(NearCullingPlane);
        writer.Write(FarCullingPlane);
        writer.Write(Field58);
        writer.Write(Field5C);
        writer.Write(Field60);
        writer.Write(Field64);
    }

    public override int GetTypeID(GameType game) { return (int)ParameterType.GameCamera; }
}