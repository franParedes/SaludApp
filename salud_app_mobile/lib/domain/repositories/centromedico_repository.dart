import 'package:salud_app_mobile/domain/models/centrosmedicos.dart';
import '../services/api_service_utilities.dart';

class CentromedicoRepository {
  Future<List<Centrosmedicos>> getCentrosmedicos() async {
    final data = await ApiService.get("ObtenerCentrosMedicos");
    return (data as List).map((e) => Centrosmedicos.fromJson(e)).toList();
  }
}
