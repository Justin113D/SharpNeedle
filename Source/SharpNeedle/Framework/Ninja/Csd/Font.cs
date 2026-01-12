namespace SharpNeedle.Framework.Ninja.Csd;

public class Font : List<CharacterMapping>, IBinarySerializable
{
    public void Read(BinaryObjectReader reader)
    {
        Clear();
        Capacity = reader.ReadInt32();
        AddRange(reader.ReadArrayOffset<CharacterMapping>(Capacity));
    }

    public void Write(BinaryObjectWriter writer)
    {
        writer.Write(Count);
        writer.WriteCollectionOffset(this);
    }
}