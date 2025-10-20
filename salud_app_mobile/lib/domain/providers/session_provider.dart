import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Autenticacion/auth.dart';

// 1. La clase extiende ChangeNotifier. Esto le da la habilidad de "notificar" a los widgets que la escuchan.
class SessionProvider extends ChangeNotifier {
  // 2. Hacemos el objeto Auth privado y lo exponemos a través de un getter.
  // Empieza como nulo porque al inicio no hay sesión iniciada.
  Auth? _auth;

  Auth? get auth => _auth;

  // 3. Este es el método que llamaremos desde el LoginButton.
  void login(Auth authData) {
    _auth = authData;
    // 4. Esta es la línea mágica. Notifica a todos los widgets que están "escuchando"
    // a este provider que los datos han cambiado, para que se reconstruyan y muestren la nueva información.
    notifyListeners();
  }

  // 5. Un método para cerrar sesión.
  void logout() {
    _auth = null;
    notifyListeners();
  }
}