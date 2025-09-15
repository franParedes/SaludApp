import 'package:flutter/material.dart';
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

  String? genero;
  String? tipoUsuario;
  String? religion;
  String? estadoCivil;

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
                child: RegisterDropdown(
                  label: "Género",
                  selectedValue: genero,
                  items: ["Masculino", "Femenino", "Otro"],
                  onChanged: (val) => setState(() => genero = val),
                ),
              ),
            ],
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
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Barrio",
                  controller: barrioController,
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterTextField(
                  label: "Municipio",
                  controller: municipioController,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Departamento - Correo
          Row(
            children: [
              Expanded(
                child: RegisterTextField(
                  label: "Departamento",
                  controller: departamentoController,
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

          // Tipo usuario - Religión
          Row(
            children: [
              Expanded(
                child: RegisterDropdown(
                  label: "Tipo de usuario",
                  selectedValue: tipoUsuario,
                  items: ["Paciente", "Doctor", "Admin"],
                  onChanged: (val) => setState(() => tipoUsuario = val),
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterDropdown(
                  label: "Religión",
                  selectedValue: religion,
                  items: ["Católica", "Evangélica", "Otra"],
                  onChanged: (val) => setState(() => religion = val),
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
                child: RegisterTextField(
                  label: "Escolaridad",
                  controller: escolaridadController,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),

          // Estado civil - Escolaridad repetida
          Row(
            children: [
              Expanded(
                child: RegisterDropdown(
                  label: "Estado civil",
                  selectedValue: estadoCivil,
                  items: ["Soltero", "Casado", "Divorciado", "Viudo"],
                  onChanged: (val) => setState(() => estadoCivil = val),
                ),
              ),
              const SizedBox(width: 10),
              Expanded(
                child: RegisterTextField(
                  label: "Escolaridad",
                  controller: escolaridadController,
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
              debugPrint("Nombre: ${primerApellidoController.text}");
            },
          ),
        ],
      ),
    );
  }
}
