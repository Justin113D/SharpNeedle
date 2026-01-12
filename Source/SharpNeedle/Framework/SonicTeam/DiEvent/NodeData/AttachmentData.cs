namespace SharpNeedle.Framework.SonicTeam.DiEvent.NodeData;

public class AttachmentData : BaseNodeData
{
    public int Field00 { get; set; }
    public string NodeName { get; set; } = string.Empty;
    public int Field44 { get; set; }
    public int Field48 { get; set; }
    public int Field4C { get; set; }

    public AttachmentData() { }
    public AttachmentData(BinaryObjectReader reader, GameType game)
    {
        Read(reader, game);
    }

    public override void Read(BinaryObjectReader reader, GameType game)
    {
        Field00 = reader.ReadInt32();
        NodeName = reader.ReadDiString(64);
        Field44 = reader.ReadInt32();
        Field48 = reader.ReadInt32();
        Field4C = reader.ReadInt32();
    }

    public override void Write(BinaryObjectWriter writer, GameType game)
    {
        writer.Write(Field00);
        writer.WriteDiString(NodeName, 64);
        writer.Write(Field44);
        writer.Write(Field48);
        writer.Write(Field4C);
    }
}