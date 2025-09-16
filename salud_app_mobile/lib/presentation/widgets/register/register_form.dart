import 'package:flutter/material.dart';
import '../../../domain/models/barrio.dart';
import '../../../domain/models/departamento.dart';
import '../../../domain/models/generos.dart';
import '../../../domain/models/municipio.dart';
import '../../../domain/models/religion.dart';
import '../../../domain/repositories/barrio_repository.dart';
import '../../../domain/repositories/departamento_repository.dart';
import '../../../domain/repositories/genero_repository.dart';
import '../../../domain/repositories/municipio_repository.dart';
import '../../../domain/repositories/religion_repository.dart';
import 'register_text_field.dart';
import 'register_date_fieldd.dart';
import 'register_droopdown.dart';
import 'register_button.dart';

class RegisterForm extends StatefulWidget {
  const RegisterForm({super.key});

  @override
  State<RegisterForm> createState() => _RegisterFormState();
}

class _RegisterFormState extends State<RegisterForm> {
  final primerNombreController = TextEditingController();
  final segundoNombreController = TextEditingController();
  final primerApellidoController = TextEditingController();
  final segundoApellidoController = TextEditingController();
  final cedulaController = TextEditingController();
  final fechaController = TextEditingController();
  final direccionController = TextEditingController();
  final barrioController = TextEditingController();
  final municipioController = TextEditingController();
  final departamentoController = TextEditingController();
  final correoController = TextEditingController();
  final ocupacionController = TextEditingController();
  final escolaridadController = TextEditingController();
  final hermanosController = TextEditingController();
  final inssController = TextEditingController();
  final telefonoController = TextEditingController();
  final passwordController = TextEditingController();

  String? genero;
  String? tipoUsuario;
  String? religion;
  String? estadoCivil;
  String? escolaridad;

  // variables para cargar los dropdowns
  final _departamentoRepo = DepartamentoRepository();
  final _municipioRepo = MunicipioRepository();
  final _barrioRepo = BarrioRepository();
  final _generoRepo = GeneroRepository();
  final _religionRepo = ReligionRepository();

  Departamento? departamentoSeleccionado;
  Municipio? municipioSeleccionado;
  Barrio? barrioSeleccionado;
  Generos? generoSeleccionado;
  Religion? religionSeleccionado;

  List<Departamento> departamentos = [];
  List<Municipio> municipios = [];
  List<Barrio> barrios = [];
  List<Generos> generos = [];
  List<Religion> religions = [];

  bool loadingDepartamentos = true;
  bool loadingMunicipios = false;
  bool loadingBarrios = false;
  bool loadingGeneros = false;
  bool loadingReligions = false;
  ////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////
  ///
  ///
  @override
  void initState() {
    super.initState();
    _loadDepartamentos();
    _loadGeneros();
    _loadReligions();
  }

  Future<void> _loadReligions() async {
    final data = await _religionRepo.getReligions();
    setState(() {
      religions = data;
      loadingReligions = false;
    });
  }

  Future<void> _loadGeneros() async {
    final data = await _generoRepo.getGeneros();
    setState(() {
      generos = data;
      loadingGeneros = false;
    });
  }

  Future<void> _loadDepartamentos() async {
    final data = await _departamentoRepo.getDepartamentos();
    setState(() {
      departamentos = data;
      loadingDepartamentos = false;
    });
  }

  Future<void> _loadMunicipios(int departamentoId) async {
    setState(() {
      loadingMunicipios = true;
      municipios = [];
      municipioSeleccionado = null;
      barrioSeleccionado = null;
    });
    final data = await _municipioRepo.getMunicipiosByDepartamento(
      departamentoId,
    );
    setState(() {
      municipios = data;
      loadingMunicipios = false;
    });
  }

  Future<void> _loadBarrios(int municipioId) async {
    setState(() {
      loadingBarrios = true;
      barrios = [];
      barrioSeleccionado = null;
    });
    final data = await _barrioRepo.getBarriosByMunicipio(municipioId);
    setState(() {
      barrios = data;
      loadingBarrios = false;
    });
  }

  ///
  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      padding: const EdgeInsets.all(16),
      child: Column(
        children: [
          // Primer nombre - Segundo nombre
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Primer nombre",
                  controller: primerNombreController,
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterTextField(
                  label: "Segundo nombre",
                  controller: segundoNombreController,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Primer apellido - Segundo apellido
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Primer apellido",
                  controller: primerApellidoController,
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterTextField(
                  label: "Segundo apellido",
                  controller: segundoApellidoController,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Cédula - Género
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Cédula",
                  controller: cedulaController,
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: loadingGeneros
                    ? const CircularProgressIndicator()
                    : RegisterDropdown(
                        label: "Género",
                        selectedValue: generoSeleccionado?.nombre,
                        items: generos.map((g) => g.nombre).toList(),
                        onChanged: (value) {
                          final gen = generos.firstWhere(
                            (g) => g.nombre == value,
                            orElse: () => Generos(
                              id: -1,
                              nombre: '',
                            ), // ❌ valor por defecto válido
                          );
                          if (gen.id != -1) {
                            // solo si encontramos uno real
                            setState(() {
                              generoSeleccionado = gen;
                            });
                          }
                        },
                      ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Contraseña
          RegisterTextField(
            label: "Ingrese su contraseña",
            controller: passwordController,
          ),
          const SizedBox(height: 10),

          // Fecha nacimiento
          RegisterDateField(
            label: "Fecha nacimiento",
            controller: fechaController,
          ),
          const SizedBox(height: 10),

          // Dirección
          RegisterTextField(
            label: "Dirección",
            controller: direccionController,
          ),
          const SizedBox(height: 10),

          // Barrio - Municipio
          // Barrio - Municipio con Dropdowns
          // Barrio - Municipio con Dropdowns
          Row(
            children: [
              Expanded(
                child: loadingBarrios
                    ? const CircularProgressIndicator()
                    : RegisterDropdown(
                        label: "Barrio",
                        selectedValue: barrioSeleccionado?.nombre,
                        items: barrios.map((b) => b.nombre).toList(),
                        onChanged: (value) {
                          final bar = barrios.firstWhere(
                            (b) => b.nombre == value,
                            orElse: () => Barrio(
                              id: -1,
                              nombre: '',
                              municipioId: 0,
                            ), // ❌ valor por defecto válido
                          );
                          if (bar.id != -1) {
                            // solo si encontramos uno real
                            setState(() {
                              barrioSeleccionado = bar;
                              barrioController.text = bar.nombre;
                            });
                          }
                        },
                      ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: loadingMunicipios
                    ? const CircularProgressIndicator()
                    : // Dropdown Municipio
                      Expanded(
                        child: loadingMunicipios
                            ? const CircularProgressIndicator()
                            : RegisterDropdown(
                                label: "Municipio",
                                selectedValue: municipioSeleccionado?.nombre,
                                items: municipios.map((m) => m.nombre).toList(),
                                onChanged: (value) {
                                  final mun = municipios.firstWhere(
                                    (m) => m.nombre == value,
                                    orElse: () => municipios
                                        .first, // evita errores si no encuentra
                                  );
                                  setState(() {
                                    municipioSeleccionado = mun;
                                    barrioSeleccionado = null;
                                    municipioController.text = mun.nombre;
                                  });
                                  _loadBarrios(mun.id);
                                },
                              ),
                      ),
              ),
            ],
          ),

          const SizedBox(height: 10),

          // Departamento - Correo
          Row(
            children: [
              Expanded(
                child: // 🔹 Dropdown Departamento
                loadingDepartamentos
                    ? const CircularProgressIndicator()
                    : RegisterDropdown(
                        label: "Departamento",
                        selectedValue: departamentoSeleccionado?.nombre,
                        items: departamentos.map((d) => d.nombre).toList(),
                        onChanged: (value) {
                          final dep = departamentos.firstWhere(
                            (d) => d.nombre == value,
                          );
                          setState(() {
                            departamentoSeleccionado = dep;
                            departamentoController.text = dep.nombre;
                          });
                          _loadMunicipios(dep.id);
                        },
                      ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterTextField(
                  label: "Correo",
                  controller: correoController,
                  keyboardType: TextInputType.emailAddress,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Estado civil - Religión
          Row(
            children: [
              Expanded(
                child: RegisterDropdown(
                  label: "Estado civil",
                  selectedValue: estadoCivil,
                  items: [
                    "Soltero",
                    "Casado",
                    "Divorciado",
                    "Viudo",
                    "Union libre",
                  ],
                  onChanged: (val) => setState(() => estadoCivil = val),
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: loadingReligions
                    ? const CircularProgressIndicator()
                    : RegisterDropdown(
                        label: "Religión",
                        selectedValue: religionSeleccionado?.nombre,
                        items: religions.map((r) => r.nombre).toList(),
                        onChanged: (value) {
                          final rel = religions.firstWhere(
                            (r) => r.nombre == value,
                            orElse: () => Religion(
                              id: -1,
                              nombre: '',
                            ), // ❌ valor por defecto válido
                          );
                          if (rel.id != -1) {
                            // solo si encontramos uno real
                            setState(() {
                              religionSeleccionado = rel;
                            });
                          }
                        },
                      ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Ocupación - Escolaridad
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Ocupación",
                  controller: ocupacionController,
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterDropdown(
                  label: "Escolaridad",
                  selectedValue: escolaridad,
                  items: ["No tiene", "Primaria", "Secundaria", "Universidad"],
                  onChanged: (val) => setState(() => escolaridad = val),
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Cantidad de hermanos - N° INSS
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Cantidad de hermanos",
                  controller: hermanosController,
                  keyboardType: TextInputType.number,
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterTextField(
                  label: "N° INSS",
                  controller: inssController,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Teléfonos
          RegisterTextField(
            label: "Teléfonos",
            controller: telefonoController,
            keyboardType: TextInputType.phone,
          ),

          const SizedBox(height: 10),
          // Botón
          RegisterButton(
            onPressed: () {
              // Depuración para ver los datos que se enviarán a la API
              debugPrint("Primer Nombre: ${primerNombreController.text}");
              debugPrint("Segundo Nombre: ${segundoNombreController.text}");
              debugPrint("Primer Apellido: ${primerApellidoController.text}");
              debugPrint("Segundo Apellido: ${segundoApellidoController.text}");
              debugPrint("Cédula: ${cedulaController.text}");
              debugPrint("Fecha: ${fechaController.text}");
              debugPrint("Dirección: ${direccionController.text}");
              debugPrint("Barrio: ${barrioController.text}");
              debugPrint("Municipio: ${municipioController.text}");
              debugPrint("Departamento: ${departamentoController.text}");
              debugPrint("Correo: ${correoController.text}");
              debugPrint("Ocupación: ${ocupacionController.text}");
              debugPrint("Escolaridad: ${escolaridadController.text}");
              debugPrint("Hermanos: ${hermanosController.text}");
              debugPrint("INSS: ${inssController.text}");
              debugPrint("Teléfono: ${telefonoController.text}");
              debugPrint("Género: $genero");
              debugPrint("Tipo de Usuario: $tipoUsuario");
              debugPrint("Religión: $religion");
              debugPrint("Estado Civil: $estadoCivil");

              // Enviar datos a la API
            },
          ),
        ],
      ),
    );
  }
}
