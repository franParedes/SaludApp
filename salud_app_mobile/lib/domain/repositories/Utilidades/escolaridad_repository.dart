import '../../models/Utilidades/escolaridad.dart';
import '../../services/api_service_utilities.dart';

class EscolaridadRepository {
  Future<List<Escolaridad>> getEscolaridad() async {
    final data = await ApiService.get("ObtenerEscolaridad");
    return (data as List).map((e) => Escolaridad.fromJson(e)).toList();
  }
}