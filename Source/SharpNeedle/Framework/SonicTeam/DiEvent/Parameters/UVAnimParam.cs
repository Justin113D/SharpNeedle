namespace SharpNeedle.Framework.SonicTeam.DiEvent.Parameters;

public class UVAnimParam : BaseParam
{
    public int Field00 { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Field44 { get; set; }
    public float Field48 { get; set; }
    public int Field4C { get; set; }
    public int Field50 { get; set; }

    public UVAnimParam() { }

    public UVAnimParam(BinaryObjectReader reader, GameType game)
    {
        Read(reader, game);
    }

    public override void Read(BinaryObjectReader reader, GameType game)
    {
        Field00 = reader.ReadInt32();
        Name = reader.ReadDiString(64);
        Field44 = reader.ReadInt32();
        Field48 = reader.ReadSingle();
        Field4C = reader.ReadInt32();
        Field50 = reader.ReadInt32();
    }

    public override void Write(BinaryObjectWriter writer, GameType game)
    {
        writer.Write(Field00);
        writer.WriteDiString(Name, 64);
        writer.Write(Field44);
        writer.Write(Field48);
        writer.Write(Field4C);
        writer.Write(Field50);
    }

    public override int GetTypeID(GameType game) { return (int)ParameterType.UVAnimation; }
}