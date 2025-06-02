using System.Drawing;

namespace GTACommon.Serialization
{
    public class SerializableColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public SerializableColor() { }

        public SerializableColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public Color ToColor() => Color.FromArgb(A, R, G, B);
    }
}
