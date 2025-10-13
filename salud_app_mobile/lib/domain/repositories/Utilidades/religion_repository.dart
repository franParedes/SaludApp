import '../../models/Utilidades/religion.dart';
import '../../services/api_service_utilities.dart';

class ReligionRepository {
  Future<List<Religion>> getReligions() async {
    final data = await ApiService.get("ObtenerReligiones");
    return (data as List).map((e) => Religion.fromJson(e)).toList();
  }
}
