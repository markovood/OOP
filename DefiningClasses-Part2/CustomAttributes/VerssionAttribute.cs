namespace CustomAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        // structures, classes, interfaces, enumerations and methods
        public VersionAttribute(int major, int minor)
        {
            this.MajorVersion = major;
            this.MinorVersion = minor;
        }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.MajorVersion, this.MinorVersion);
        }
    }
}
