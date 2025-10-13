class ApiConfig {
  // Ambiente de desarrollo (emulador Android)
  static const String baseEmulador = "https://10.0.2.2:7239/api";

  // Ambbiente para dispositivo físico
  static const String baseFisico = "https://192.168.0.12:7239/api";

  // Ambiente para pruebas en red local (Wi-Fi)
  static const String baseLocal = "https://192.168.0.12:7239/api";

  // Ambiente de producción (por ejemplo un dominio real)
  static const String baseProd = "https://api.saludapp.com/api";

  // Selecciona la base actual
  static const String currentBase = baseEmulador;
}
