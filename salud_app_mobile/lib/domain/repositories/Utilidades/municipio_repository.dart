import '../../models/Utilidades/municipio.dart';
import '../../services/api_service_utilities.dart';

class MunicipioRepository {
  Future<List<Municipio>> getMunicipiosByDepartamento(
    int departamentoId,
  ) async {
    final data = await ApiService.get("ObtenerMunicipios/$departamentoId");
    return (data as List).map((e) => Municipio.fromJson(e)).toList();
  }
}
