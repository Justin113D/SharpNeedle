namespace SharpNeedle.Framework.SonicTeam;

using SharpNeedle.Framework.BINA;

[NeedleResource("st/gismoconfig", @"\.(orc|gism)$")]
public class GismoConfig : BinaryResource
{
    public new static readonly uint Signature = BinaryHelper.MakeSignature<uint>("GISM");
    public new uint Version { get; set; } // Guessed
    public List<ObjectData> Objects { get; set; } = [];

    public override void Read(BinaryObjectReader reader)
    {
        if (base.Version.IsV1)
        {
            reader.EnsureSignatureNative(Signature);
        }
        else
        {
            reader.ReadOffset(() =>
                reader.EnsureSignatureNative(Signature));
        }

        Version = reader.ReadUInt32();

        int objectCount = reader.ReadInt32();
        Objects.AddRange(reader.ReadObjectArrayOffset<ObjectData, bool>(base.Version.IsV1, objectCount));
    }

    public override void Write(BinaryObjectWriter writer)
    {
        if (base.Version.IsV1)
        {
            writer.WriteNative(Signature);
        }
        else
        {
            writer.WriteOffset(() =>
                writer.WriteNative(Signature));
        }

        writer.Write(Version);

        writer.Write(Objects.Count);
        writer.WriteObjectCollectionOffset(base.Version.IsV1, Objects);
    }

    public class ObjectData : IBinarySerializable<bool>
    {
        public string? Name { get; set; } // Model name in Sonic Colors Variant

        // Only used in Lost World variant
        public string? ModelName { get; set; }
        public string? SkeletonName { get; set; }
        public ShapeType ShapeType { get; set; }
        public bool IsMotionOn { get; set; }
        public bool IsProgramMotionOn { get; set; }
        public float CollisionRadius { get; set; }
        public float CollisionHeight { get; set; }
        public Vector3 Size { get; set; } // Only used in Colors
        public MotionData Motion { get; set; } = new();
        public ProgramMotionData ProgramMotion { get; set; } = new();

        // Only used in Colors variant (Maybe related to breaking? Could have overlap with collision fields from Lost World)
        public string? ParticleName { get; set; }
        public string? SoundCueName { get; set; }
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public short Field08 { get; set; }
        public short Field0A { get; set; }
        public short Field0C { get; set; }
        public byte Field0F { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public float Field28 { get; set; }
        public int Field38 { get; set; }

        public void Read(BinaryObjectReader reader, bool isV1)
        {
            if (isV1)
            {
                Field00 = reader.ReadInt32();
                Field04 = reader.ReadInt32();
                Field08 = reader.ReadInt16();
                Field0A = reader.ReadInt16();
                Field0C = reader.ReadInt16();

                ShapeType = (ShapeType)reader.ReadByte();

                Field0F = reader.ReadByte();
                Field10 = reader.ReadInt32();
                Field14 = reader.ReadInt32();
                Field18 = reader.ReadInt32();
                Field1C = reader.ReadInt32();
                Field20 = reader.ReadSingle();
                Field24 = reader.ReadSingle();
                Field28 = reader.ReadSingle();

                Size = reader.ReadVector3(); // TODO: Unpack reading all 3 float values at once into individual reads based on ShapeType

                Field38 = reader.ReadInt32();
            }

            Name = reader.ReadStringOffset();

            if (isV1)
            {
                ParticleName = reader.ReadStringOffset();
                SoundCueName = reader.ReadStringOffset();
            }
            else
            {
                ModelName = reader.ReadStringOffset();
                SkeletonName = reader.ReadStringOffset();
                ShapeType = reader.Read<ShapeType>();
                CollisionRadius = reader.ReadSingle();
                CollisionHeight = reader.ReadSingle();

                IsMotionOn = Convert.ToBoolean(reader.ReadInt32());
                Motion = reader.ReadObjectOffset<MotionData>();

                IsProgramMotionOn = Convert.ToBoolean(reader.ReadInt32());
                ProgramMotion = reader.ReadObjectOffset<ProgramMotionData>();
            }
        }

        public void Write(BinaryObjectWriter writer, bool isV1)
        {

            if (isV1)
            {
                writer.Write(Field00);
                writer.Write(Field04);
                writer.Write(Field08);
                writer.Write(Field0A);
                writer.Write(Field0C);

                writer.Write((byte)ShapeType);

                writer.Write(Field0F);
                writer.Write(Field10);
                writer.Write(Field14);
                writer.Write(Field18);
                writer.Write(Field1C);
                writer.Write(Field20);
                writer.Write(Field24);
                writer.Write(Field28);

                writer.Write(Size); // TODO: Unpack writing all 3 float values at once into individual reads based on ShapeType

                writer.Write(Field38);
            }

            writer.WriteStringOffset(StringBinaryFormat.NullTerminated, Name);
            writer.WriteStringOffset(StringBinaryFormat.NullTerminated, ModelName);
            writer.WriteStringOffset(StringBinaryFormat.NullTerminated, SkeletonName);

            if (!isV1)
            {
                writer.Write(ShapeType);
                writer.Write(CollisionRadius);
                writer.Write(CollisionHeight);

                writer.Write(Convert.ToInt32(IsMotionOn));
                writer.WriteObjectOffset(Motion);

                writer.Write(Convert.ToInt32(IsProgramMotionOn));
                writer.WriteObjectOffset(ProgramMotion);
            }
        }
    }

    public class MotionData : IBinarySerializable
    {
        public string? AnimationName { get; set; }
        public PlayPolicy PlayPolicy { get; set; }

        public void Read(BinaryObjectReader reader)
        {
            PlayPolicy = reader.Read<PlayPolicy>();
            AnimationName = reader.ReadStringOffset();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.Write(PlayPolicy);
            writer.WriteStringOffset(StringBinaryFormat.NullTerminated, AnimationName);
        }
    }

    public class ProgramMotionData : IBinarySerializable
    {
        public MotionType MotionType { get; set; }
        public int Field00 { get; set; }
        public float Power { get; set; }
        public float SpeedScale { get; set; }
        public float Time { get; set; }
        public Vector3 Axis { get; set; }

        public void Read(BinaryObjectReader reader)
        {
            Field00 = reader.ReadInt32();

            MotionType = reader.Read<MotionType>();

            Axis = reader.ReadVector3();

            Power = reader.ReadSingle();
            SpeedScale = reader.ReadSingle();
            Time = reader.ReadSingle();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.Write(Field00);

            writer.Write(MotionType);

            writer.Write(Axis);

            writer.Write(Power);
            writer.Write(SpeedScale);
            writer.Write(Time);
        }
    }
}

public enum ShapeType : int
{
    Sphere = 1,
    Capsule,
    Box = 4 // Unused in Lost World
}

public enum PlayPolicy : int
{

}

public enum MotionType : int
{
    Swing,
    Rotate
}