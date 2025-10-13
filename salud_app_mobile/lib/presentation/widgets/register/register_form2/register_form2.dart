import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:salud_app_mobile/domain/models/Usuarios/paciente.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/barrio.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/departamento.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/escolaridad.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/estadoCivil.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/generos.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/municipio.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/ocupacion.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/religion.dart';
import 'package:salud_app_mobile/domain/repositories/Usuarios/paciente_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/barrio_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/departamento_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/escolaridad_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/estado_civil_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/genero_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/municipio_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/ocupacion_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/religion_repository.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_buttom.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/BarrioMunicipiosFields.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/cant_herm_inss_fields.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/cedula_genero_fields.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/date_field_custom.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/departamentos_correo_fields.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/estado_religion_fields.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/nombres_fields_texts.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/ocupacion_escolariad_fields.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/text_field_custom.dart';

class RegisterForm2 extends StatefulWidget {
  const RegisterForm2({super.key});

  @override
  State<RegisterForm2> createState() => _RegisterForm2State();
}

class _RegisterForm2State extends State<RegisterForm2> {
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
  final estadoCivilController = TextEditingController();
  final hermanosController = TextEditingController();
  final inssController = TextEditingController();
  final telefonoController = TextEditingController();
  final passwordController = TextEditingController();

  int genero = 1;
  int tipoUsuario = 1;
  int religion = 1;
  int ocupacion = 1;
  int edad = 1;
  int estadoCivil = 1;
  int escolaridad = 1;

  DateTime fechaNacimientoDate = DateTime.now();

  // variables para cargar los dropdowns
  final _departamentoRepo = DepartamentoRepository();
  final _municipioRepo = MunicipioRepository();
  final _barrioRepo = BarrioRepository();
  final _generoRepo = GeneroRepository();
  final _religionRepo = ReligionRepository();
  final _ocupacionRepo = OcupacionRepository();
  final _escolaridad = EscolaridadRepository();
  final _estadoCivil = EstadoCivilRepository();

  Departamento? departamentoSeleccionado;
  Municipio? municipioSeleccionado;
  Barrio? barrioSeleccionado;
  Generos? generoSeleccionado;
  Religion? religionSeleccionado;
  Ocupacion? ocupacionSeleccionado;
  Escolaridad? escolaridadSeleccionada;
  Estadocivil? estadoCivilSeleccionado;

  List<Departamento> departamentos = [];
  List<Municipio> municipios = [];
  List<Barrio> barrios = [];
  List<Generos> generos = [];
  List<Religion> religions = [];
  List<Ocupacion> ocupaciones = [];
  List<Escolaridad> escolaridads = [];
  List<Estadocivil> estadoCivils = [];

  bool loadingDepartamentos = false;
  bool loadingMunicipios = false;
  bool loadingBarrios = false;
  bool loadingGeneros = false;
  bool loadingReligions = false;
  bool loadingOcupaciones = false;
  bool loadingEscolaridad = false;
  bool loadingEstadoCivil = false;

  @override
  void initState() {
    super.initState();
    _loadAllData();
  }

  Future<void> _loadAllData() async {
    setState(() {
      loadingDepartamentos = true;
      loadingGeneros = true;
      loadingReligions = true;
      loadingOcupaciones = true;
      loadingEscolaridad = true;
      loadingEstadoCivil = true;
    });

    final results = await Future.wait([
      _departamentoRepo.getDepartamentos(),
      _generoRepo.getGeneros(),
      _religionRepo.getReligions(),
      _ocupacionRepo.getOcupaciones(),
      _escolaridad.getEscolaridad(),
      _estadoCivil.getEstadosCiviles(),
    ]);

    setState(() {
      departamentos = results[0] as List<Departamento>;
      generos = results[1] as List<Generos>;
      religions = results[2] as List<Religion>;
      ocupaciones = results[3] as List<Ocupacion>;
      escolaridads = results[4] as List<Escolaridad>;
      estadoCivils = results[5] as List<Estadocivil>;

      loadingDepartamentos = false;
      loadingGeneros = false;
      loadingReligions = false;
      loadingOcupaciones = false;
      loadingEscolaridad = false;
      loadingEstadoCivil = false;
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
          NombresFieldsText(
            primerNombreController: primerNombreController,
            segundoNombreController: segundoNombreController,
            primerApellidoController: primerApellidoController,
            segundoApellidoController: segundoApellidoController,
          ),

          CedulaGeneroFields(
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

          TextFieldCustom(
            controller: passwordController,
            icono: Icons.password,
            type: TextInputType.text,
            texto: "Ingrese su constraseña",
          ),
          const SizedBox(height: 10),

          DateFieldCustom(
            controller: fechaController,
            hintText: "Fecha de nacimiento",
            icono: Icons.cake_outlined,
          ),
          const SizedBox(height: 10),

          TextFieldCustom(
            controller: direccionController,
            icono: Icons.password,
            type: TextInputType.text,
            texto: "Dirección",
          ),

          const SizedBox(height: 10),

          DepartamentosCorreoFields(
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

          BarrioMunicipiosFields(
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

          EstadosReligiones(
            estadoCivil: estadoCivils,
            loadingEstadoCivil: loadingEstadoCivil,
            estadoCivilSeleccionado: estadoCivilSeleccionado,
            onEstadoCivilChanged: (estCiv) {
              setState(() {
                estadoCivilSeleccionado = estCiv;
                estadoCivil = estCiv.id;
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

          OcupacionEscolariadFields(
            ocupaciones: ocupaciones,
            loadingOcupaciones: loadingOcupaciones,
            ocupacionSeleccionado: ocupacionSeleccionado,
            onOcupacionChanged: (ocup) {
              setState(() {
                ocupacionSeleccionado = ocup;
                ocupacion = ocup.id;
              });
            },

            escolaridad: escolaridads,
            loadingEscolaridad: loadingEscolaridad,
            escolaridadSeleccionado: escolaridadSeleccionada,
            onEscolaridadChanged: (escl) {
              setState(() {
                escolaridadSeleccionada = escl;
                escolaridad = escl.id;
              });
            },
          ),
          const SizedBox(height: 10),

          CantHermInssFields(
            hermanosController: hermanosController,
            inssController: inssController,
          ),

          const SizedBox(height: 10),

          TextFieldCustom(
            controller: telefonoController,
            icono: Icons.phone,
            type: TextInputType.phone,
            texto: "Telefono",
          ),

          const SizedBox(height: 10),

          RegisterButtom(
            onRegister: () async {
              return await sendPacienteToApi();
            },
          ),
        ],
      ),
    );
  }

  int calcularEdad(DateTime fechaNac) {
    DateTime hoy = DateTime.now();
    int edad = hoy.year - fechaNac.year;
    if (hoy.month < fechaNac.month ||
        (hoy.month == fechaNac.month && hoy.day < fechaNac.day)) {
      edad--;
    }
    return edad;
  }

  Future<bool> sendPacienteToApi() async {
    final paciente = Paciente(
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
      numeroInss: inssController.text,
      ocupacion: ocupacion,
      escolaridad: escolaridad,
      religion: religion,
      edad: edad,
      estadoCivil: estadoCivil,
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
