import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';

class ApiServiceCita {
  // para emulador
  // static const String baseUrl = "https://10.0.2.2:7239/api";
  static const String baseUrl = "https://https://192.168.12.31/api";
  // para dispositivo físico
  // static const String baseUrl = "https://192.168.0.12:7239/api";

  static Future<dynamic> post(
    String endpoint,
    Map<String, dynamic> data,
  ) async {
    try {
      var client = HttpClient()
        ..badCertificateCallback = (cert, host, port) =>
            true; // ⚠️ solo para pruebas

      final url = "$baseUrl/$endpoint";
      print("➡️ POST: $url");
      debugPrint("📤 Body: ${jsonEncode(data)}");
      //debugPrint(jsonEncode(cita.toJson()), wrapWidth: 1024);

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
      print("❌ Error en ApiServiceCita POST: $e");
      rethrow;
    }
  }
}
