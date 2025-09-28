import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form/apellidos_field.dart';
import '../../../domain/models/barrio.dart';
import '../../../domain/models/departamento.dart';
import '../../../domain/models/generos.dart';
import '../../../domain/models/municipio.dart';
import '../../../domain/models/ocupacion.dart';
import '../../../domain/models/paciente.dart';
import '../../../domain/models/religion.dart';
import '../../../domain/repositories/barrio_repository.dart';
import '../../../domain/repositories/departamento_repository.dart';
import '../../../domain/repositories/genero_repository.dart';
import '../../../domain/repositories/municipio_repository.dart';
import '../../../domain/repositories/ocupacion_repository.dart';
import '../../../domain/repositories/paciente_repository.dart';
import '../../../domain/repositories/religion_repository.dart';
import '../dialogs/dialog.dart';
import 'register_form/barrio_municipio_field.dart';
import 'register_form/cantidadhermanos_inss_field.dart';
import 'register_form/cedula_genero_field.dart';
import 'register_form/departamento_correo_field.dart';
import 'register_form/estadoc_religion_field.dart';
import 'register_form/nombres_field.dart';
import 'register_form/ocupacion_escolaridad_field.dart';
import 'register_text_field.dart';
import 'register_date_fieldd.dart';
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

  int genero = 1;
  int tipoUsuario = 1;
  int religion = 1;
  int ocupacion = 1;
  int edad = 1;
  String? estadoCivil;
  String? escolaridad;

  DateTime fechaNacimientoDate = DateTime.now();

  // variables para cargar los dropdowns
  final _departamentoRepo = DepartamentoRepository();
  final _municipioRepo = MunicipioRepository();
  final _barrioRepo = BarrioRepository();
  final _generoRepo = GeneroRepository();
  final _religionRepo = ReligionRepository();
  final _ocupacionRepo = OcupacionRepository();

  Departamento? departamentoSeleccionado;
  Municipio? municipioSeleccionado;
  Barrio? barrioSeleccionado;
  Generos? generoSeleccionado;
  Religion? religionSeleccionado;
  Ocupacion? ocupacionSeleccionado;

  List<Departamento> departamentos = [];
  List<Municipio> municipios = [];
  List<Barrio> barrios = [];
  List<Generos> generos = [];
  List<Religion> religions = [];
  List<Ocupacion> ocupaciones = [];

  bool loadingDepartamentos = true;
  bool loadingMunicipios = false;
  bool loadingBarrios = false;
  bool loadingGeneros = false;
  bool loadingReligions = false;
  bool loadingOcupaciones = false;

  @override
  void initState() {
    super.initState();
    _loadDepartamentos();
    _loadGeneros();
    _loadReligions();
    _loadOcupaciones();
  }

  Future<void> _loadOcupaciones() async {
    final data = await _ocupacionRepo.getOcupaciones();
    setState(() {
      ocupaciones = data;
      loadingOcupaciones = false;
    });
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

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      padding: const EdgeInsets.all(16),
      child: Column(
        children: [
          // Primer nombre - Segundo nombre
          NombresFields(
            primerNombreController: primerNombreController,
            segundoNombreController: segundoNombreController,
          ),
          const SizedBox(height: 10),

          // Primer apellido - Segundo apellido
          ApellidosFields(
            primerApellidoController: primerApellidoController,
            segundoApellidoController: segundoApellidoController,
          ),
          const SizedBox(height: 10),

          // Cédula - Género
          CedulaGeneroField(
            cedulaController: cedulaController,
            generos: generos,
            generoSeleccionado: generoSeleccionado,
            loadingGeneros: loadingGeneros,
            onGeneroChanged: (gen) {
              setState(() {
                generoSeleccionado = gen;
                genero = gen.id;
              });
            },
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
          BarrioMunicipioField(
            barrios: barrios,
            municipios: municipios,
            loadingBarrios: loadingBarrios,
            loadingMunicipios: loadingMunicipios,
            barrioSeleccionado: barrioSeleccionado,
            municipioSeleccionado: municipioSeleccionado,
            onBarrioChanged: (bar) {
              setState(() {
                barrioSeleccionado = bar;
                barrioController.text = bar.id.toString();
              });
            },
            onMunicipioChanged: (mun) {
              setState(() {
                municipioSeleccionado = mun;
                barrioSeleccionado = null;
                municipioController.text = mun.id.toString();
                _loadBarrios(mun.id);
              });
            },
          ),
          const SizedBox(height: 10),

          // Departamento - Correo
          DepartamentoCorreoField(
            departamentos: departamentos,
            loadingDepartamentos: loadingDepartamentos,
            departamentoSeleccionado: departamentoSeleccionado,
            onDepartamentoChanged: (dep) {
              setState(() {
                departamentoSeleccionado = dep;
                departamentoController.text = dep.id.toString();
              });
              _loadMunicipios(dep.id);
            },
            correoController: correoController,
          ),
          const SizedBox(height: 10),

          // Estado civil - Religión
          EstadoReligionField(
            estadoCivil: estadoCivil,
            onEstadoCivilChanged: (val) {
              setState(() {
                estadoCivil = val;
              });
            },
            religions: religions,
            loadingReligions: loadingReligions,
            religionSeleccionado: religionSeleccionado,
            onReligionChanged: (rel) {
              setState(() {
                religionSeleccionado = rel;
                religion = rel.id;
              });
            },
          ),
          const SizedBox(height: 10),

          // Ocupación - Escolaridad - Religión
          OcupacionEscolaridadField(
            ocupaciones: ocupaciones,
            loadingOcupaciones: loadingOcupaciones,
            ocupacionSeleccionado: ocupacionSeleccionado,
            onOcupacionChanged: (ocup) {
              setState(() {
                ocupacionSeleccionado = ocup;
                ocupacion = ocup.id;
              });
            },
            escolaridad: escolaridad,
            onEscolaridadChanged: (val) {
              setState(() {
                escolaridad = val;
              });
            },
          ),
          const SizedBox(height: 10),

          // Cantidad de hermanos - N° INSS
          HermanosInssField(
            hermanosController: hermanosController,
            inssController: inssController,
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
            onPressed: () async {
              final exito = await sendPacienteToApi();

              await showMessageDialog(
                context,
                title: exito ? "Éxito" : "Error",
                message: exito
                    ? "Usuario creado correctamente"
                    : "Hubo un error al crear el usuario. Intenta de nuevo.",
              );

              if (exito) {
                Navigator.of(
                  context,
                ).pop(); // 🔹 Solo vuelves atrás si se creó bien
              }
            },
          ),
        ],
      ),
    );
  }

  // Función para calcular edad
  int calcularEdad(DateTime fechaNac) {
    DateTime hoy = DateTime.now();
    int edad = hoy.year - fechaNac.year;
    if (hoy.month < fechaNac.month ||
        (hoy.month == fechaNac.month && hoy.day < fechaNac.day)) {
      edad--;
    }
    return edad;
  }

  // FUNCION PARA ENVIAR DATOS A LA API
  Future<bool> sendPacienteToApi() async {
    final paciente = Paciente(
      generalInfo: GeneralInfo(
        cedula: cedulaController.text,
        primerNombre: primerNombreController.text,
        segundoNombre: segundoNombreController.text,
        primerApellido: primerApellidoController.text,
        segundoApellido: segundoApellidoController.text,
        correo: correoController.text,
        contrasenya: passwordController.text,
        genero: genero,
        fechaNacimiento: DateFormat("yyyy-MM-dd").format(fechaNacimientoDate),
        tipoUsuario: tipoUsuario,
      ),
      numeroInss: inssController.text,
      ocupacion: ocupacion,
      escolaridad: escolaridad.toString(),
      religion: religion,
      edad: edad,
      estadoCivil: estadoCivil.toString(),
      cantidadHermanos: int.tryParse(hermanosController.text) ?? 0,
      telefonos: [
        Telefono(
          telefono: int.tryParse(telefonoController.text) ?? 0,
          compania: 1,
        ),
      ],
      direcciones: [
        Direccion(
          departamento: int.tryParse(departamentoController.text) ?? 0,
          municipio: int.tryParse(municipioController.text) ?? 0,
          barrio: int.tryParse(barrioController.text) ?? 0,
          direccion: direccionController.text,
        ),
      ],
    );

    final repo = PacienteRepository();
    final exito = await repo.crearPaciente(paciente);

    if (exito) {
      debugPrint("✅ Paciente creado correctamente");
    } else {
      debugPrint("❌ Error al crear el paciente");
    }

    return exito;
  }
}
