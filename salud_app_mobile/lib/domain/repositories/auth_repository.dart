import 'package:salud_app_mobile/domain/models/auth.dart';
import '../services/api_service_auth.dart';

class AuthRepository {
  Future<Auth> userVerification(String correo, String password) async {
    final data = await ApiServiceAuth.get(
      "VerificarCredenciales/$correo/$password",
    );
    return Auth.fromJson(data);
  }
}
