import 'package:salud_app_mobile/domain/models/Utilidades/especialidades.dart';
import '../../services/api_service_utilities.dart';

class EspecialidadRepository {
  Future<List<Especialidades>> getEspecialidades() async {
    final data = await ApiService.get("ObtenerEspecialidadesMedicas");
    return (data as List).map((e) => Especialidades.fromJson(e)).toList();
  }
}
