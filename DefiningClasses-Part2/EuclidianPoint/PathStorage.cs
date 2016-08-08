namespace EuclidianPoint
{
    using System.IO;
    using CustomAttributes;

    [Version(1, 0)]
    public static class PathStorage
    {
        // Create a static class PathStorage with static methods to save and load paths from a text file.
        public static void SavePath(Path somePath, string filePath)
        {
            var writer = new StreamWriter(filePath);
            using (writer)
            {
                writer.WriteLine(somePath);
            }
        }

        public static Path LoadPath(string filePath)
        {
            Path path = new Path();
            var reader = new StreamReader(filePath);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var point = Point3D.Parse(line);
                    path.AddPoint(point);

                    line = reader.ReadLine();
                }
            }

            return path;
        }
    }
}