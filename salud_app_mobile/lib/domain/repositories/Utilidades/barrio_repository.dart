import '../../models/Utilidades/barrio.dart';
import '../../services/api_service_utilities.dart';

class BarrioRepository {
  Future<List<Barrio>> getBarriosByMunicipio(int municipioId) async {
    final data = await ApiService.get("ObtenerBarrios/$municipioId");
    return (data as List).map((e) => Barrio.fromJson(e)).toList();
  }
}
