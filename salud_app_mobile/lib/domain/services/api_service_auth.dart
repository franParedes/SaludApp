import 'dart:async';
import 'dart:convert';
import 'dart:io';
import 'package:salud_app_mobile/domain/services/api_config.dart';

class ApiServiceAuth {
  // para emulador
  static const String baseUrl = "${ApiConfig.currentBase}/Auth";
  
  static Future<dynamic> get(String endpoint) async {
    try {
      var client = HttpClient()
        ..badCertificateCallback = (cert, host, port) =>
            true; //solo pruebas

      final url = "$baseUrl/$endpoint";
      print("➡️ Haciendo GET a: $url"); // 🔍 log de la URL

      var request = await client.getUrl(Uri.parse(url));
      var response = await request.close().timeout(
        const Duration(seconds: 5),
        onTimeout: () {
          throw TimeoutException("Tiempo de espera agotado");
        },
      );

      print("⬅️ Status code: ${response.statusCode}"); // 🔍 log del status code

      final responseBody = await response.transform(utf8.decoder).join();
      print("📦 Response body: $responseBody"); // 🔍 log del body

      if (response.statusCode == 200) {
        return jsonDecode(responseBody);
      } else {
        throw Exception("Error: ${response.statusCode}");
      }
    } catch (e) {
      print("❌ Error en ApiService: $e");
      rethrow;
    }
  }
}
