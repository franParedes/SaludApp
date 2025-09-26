import 'package:salud_app_mobile/domain/models/tipocita.dart';
import '../services/api_service_utilities.dart';

class TipocitaRepository {
  Future<List<Tipocita>> getTipocitas() async {
    final data = await ApiService.get("ObtenerTipoDeCita");
    return (data as List).map((e) => Tipocita.fromJson(e)).toList();
  }
}
