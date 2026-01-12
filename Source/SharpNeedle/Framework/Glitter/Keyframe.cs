namespace SharpNeedle.Framework.Glitter;

public class Keyframe : IBinarySerializable
{
    public enum EInterpolationType : int
    {
        Linear = 1,
        Hermite
    };

    public int Frame { get; set; }
    public float Value { get; set; }
    public float In { get; set; }
    public float Out { get; set; }
    public float Random { get; set; }
    public EInterpolationType InterpolationType { get; set; }

    public void Read(BinaryObjectReader reader)
    {
        Frame = reader.ReadInt32();
        Value = reader.ReadSingle();

        InterpolationType = reader.Read<EInterpolationType>();

        In = reader.ReadSingle();
        Out = reader.ReadSingle();

        Random = reader.ReadSingle();
    }

    public void Write(BinaryObjectWriter writer)
    {
        writer.Write(Frame);
        writer.Write(Value);

        writer.Write(InterpolationType);

        writer.Write(In);
        writer.Write(Out);

        writer.Write(Random);
    }
}
