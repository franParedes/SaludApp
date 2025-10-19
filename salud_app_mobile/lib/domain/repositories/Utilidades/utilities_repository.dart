import 'package:salud_app_mobile/domain/models/Utilidades/centrosmedicos.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/examenes_disponibles.dart';
import 'package:salud_app_mobile/domain/services/api_service_utilities.dart';

class UtilitiesRepository {
  Future<List<ExamenesDisponibles>> getExamenesDisponibles() async {
    final data = await ApiService.get("GetExamenesDisponiblesLab");
    return (data as List).map((e) => ExamenesDisponibles.fromJson(e)).toList();
  }

  Future<List<Centrosmedicos>> getCentrosMedicosByDep(
    int departamentoId,
  ) async {
    final data = await ApiService.get("GetCentrosMedicosByDep/$departamentoId");
    return (data as List).map((e) => Centrosmedicos.fromJson(e)).toList();
  }
}
