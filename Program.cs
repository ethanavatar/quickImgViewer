using OpenCvSharp;

if (args.Length < 1) {
    Console.WriteLine("Usage: quickImgViewer <image>");
    return;
}

var imagePath = args[0];

try {
    if (!File.Exists(imagePath)) {
        Console.WriteLine($"File not found: {imagePath}");
        return;
    }
} catch (Exception e) {
    Console.Error.WriteLine(e.Message);
    return;
} 

using var src = new Mat(
    imagePath,
    ImreadModes.Color
);

try {
    using var window = new Window(
        "image",
        src,
        WindowFlags.Normal
        | WindowFlags.KeepRatio
    );

    window.Move(0, 0);
    window.Resize(src.Width, src.Height);

    Cv2.WaitKey();
    window.Close();
} catch (OpenCVException e) {
    Console.Error.WriteLine(e.Message);
}

