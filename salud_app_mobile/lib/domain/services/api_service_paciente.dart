import 'dart:convert';
import 'dart:io';

class ApiServicePaciente {
  // para emulador
  // static const String baseUrl = "https://10.0.2.2:7239/api";
   static const String baseUrl = "https://192.168.12.31:7239/api/Auth";

  // para dispositivo físico
  //static const String baseUrl = "https://192.168.0.12:7239/api";

  static Future<dynamic> post(
    String endpoint,
    Map<String, dynamic> data,
  ) async {
    try {
      var client = HttpClient()
        ..badCertificateCallback = (cert, host, port) =>
            true; // ⚠️ solo pruebas

      final url = "$baseUrl/$endpoint";
      print("➡️ POST: $url");
      print("📤 Body: ${jsonEncode(data)}");

      var request = await client.postUrl(Uri.parse(url));
      request.headers.contentType = ContentType.json;
      request.write(jsonEncode(data));

      var response = await request.close();

      final responseBody = await response.transform(utf8.decoder).join();
      print("⬅️ Status code: ${response.statusCode}");
      print("📦 Response: $responseBody");

      if (response.statusCode == 200 || response.statusCode == 201) {
        return jsonDecode(responseBody);
      } else {
        throw Exception("Error POST: ${response.statusCode} - $responseBody");
      }
    } catch (e) {
      print("❌ Error en ApiService POST: $e");
      rethrow;
    }
  }
}
