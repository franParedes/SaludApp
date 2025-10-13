import '../../models/Utilidades/ocupacion.dart';
import '../../services/api_service_utilities.dart';

class OcupacionRepository {
  Future<List<Ocupacion>> getOcupaciones() async {
    final data = await ApiService.get("ObtenerOcupacionesDePacientes");
    return (data as List).map((e) => Ocupacion.fromJson(e)).toList();
  }
}
