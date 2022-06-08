Console.WriteLine("Ingrese la ruta en donde desea trabajar: ");
string entrada = Console.ReadLine();
Console.Clear();

while (!Directory.Exists(entrada)) {
    Console.WriteLine("Directorio inválido. Ingrese uno válido");
    entrada = Console.ReadLine();
    Console.Clear();
}

List<string> ListadoArchivos = Directory.GetFiles(entrada, "*", SearchOption.AllDirectories).ToList();

StreamWriter sw = new StreamWriter("index.csv");
sw.WriteLine("Registro;Nombre de fichero;Extensión");

Console.WriteLine($"Archivos dentro de \"{entrada}\":");
for (int i = 1; i < ListadoArchivos.Count; i++) {
    Console.WriteLine(ListadoArchivos[i]);
    string[] archivoInfoAbsoluta = ListadoArchivos[i].Split('\\');
    string nombreArchivo = archivoInfoAbsoluta.Last().Split('.').First();
    string extensionArchivo = archivoInfoAbsoluta.Last().Split('.').Last();
    sw.WriteLine(i + ";" + nombreArchivo + ";" + extensionArchivo);
}

sw.Close();
