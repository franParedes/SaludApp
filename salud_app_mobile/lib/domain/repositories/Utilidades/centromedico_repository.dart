import 'package:salud_app_mobile/domain/models/Utilidades/centrosmedicos.dart';
import '../../services/api_service_utilities.dart';

class CentromedicoRepository {
  Future<List<Centrosmedicos>> getCentrosmedicos() async {
    final data = await ApiService.get("ObtenerCentrosMedicos");
    return (data as List).map((e) => Centrosmedicos.fromJson(e)).toList();
  }

  Future<List<Centrosmedicos>> getCentrosMedicosPorDep(int departamento) async {
    final data = await ApiService.get("GetCentrosMedicosByDep/$departamento");
    return (data as List).map((e) => Centrosmedicos.fromJson(e)).toList();
  }
}
