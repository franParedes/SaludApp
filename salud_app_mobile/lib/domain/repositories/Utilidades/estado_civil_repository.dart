import 'package:salud_app_mobile/domain/models/Utilidades/estadoCivil.dart';
import 'package:salud_app_mobile/domain/services/api_service_utilities.dart';

class EstadoCivilRepository {
  Future<List<Estadocivil>> getEstadosCiviles() async {
    final data = await ApiService.get("ObtenerEstadosCiviles");
    return (data as List).map((e) => Estadocivil.fromJson(e)).toList();
  }
}
