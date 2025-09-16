import '../models/departamento.dart';
import '../services/api_service_utilities.dart';

class DepartamentoRepository {
  Future<List<Departamento>> getDepartamentos() async {
    final data = await ApiService.get("ObtenerDepartamentos");
    return (data as List).map((e) => Departamento.fromJson(e)).toList();
  }
}
