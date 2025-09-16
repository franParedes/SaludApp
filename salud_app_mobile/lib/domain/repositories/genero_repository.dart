import '../models/generos.dart';
import '../services/api_service_utilities.dart';

class GeneroRepository {
  Future<List<Generos>> getGeneros() async {
    final data = await ApiService.get("ObtenerGeneros");
    return (data as List).map((e) => Generos.fromJson(e)).toList();
  }
}
