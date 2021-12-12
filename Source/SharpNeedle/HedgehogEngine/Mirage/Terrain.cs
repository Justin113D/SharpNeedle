﻿namespace SharpNeedle.HedgehogEngine.Mirage;

[BinaryResource("hh/terrain", @"\.terrain$")]
public class Terrain : SampleChunkResource
{
    public List<GroupInfo> Groups { get; set; }

    public override void Read(BinaryObjectReader reader)
    {
        Groups = reader.ReadObject<BinaryList<BinaryPointer<GroupInfo>>>().Unwind();
    }

    public override void Write(BinaryObjectWriter writer)
    {
        writer.Write(Groups.Count);
        writer.WriteOffset(() => 
        {
            foreach (var group in Groups)
                writer.WriteObjectOffset(group);
        });
    }

    public class GroupInfo : IBinarySerializable
    {
        public string Name { get; set;}
        public Sphere Bounds { get; set; }
        public uint FolderSize { get; set; }
        public int SubSetID { get; set; }
        public List<Sphere> Instances { get; set; }

        public void Read(BinaryObjectReader reader)
        {
            Bounds = reader.ReadValueOffset<Sphere>();
            Name = reader.ReadStringOffset();
            FolderSize = reader.Read<uint>();
            
            reader.Read(out int instancesCount);
            Instances = new List<Sphere>(instancesCount);
            reader.ReadOffset(() => 
            {
                for (int i = 0; i < instancesCount; i++)
                    Instances.Add(reader.ReadValueOffset<Sphere>());
            });

            SubSetID = reader.Read<int>();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteValueOffset(Bounds);
            writer.WriteStringOffset(StringBinaryFormat.NullTerminated, Name);
            writer.Write(FolderSize);
            writer.Write(Instances.Count);
            writer.WriteOffset(() =>
            {
                foreach (var instance in Instances)
                    writer.WriteValueOffset(instance);
            });
        }

        public override string ToString()
        {
            return $"{Name}:{SubSetID}";
        }
    }
}