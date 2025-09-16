import 'package:flutter/material.dart';
import '../../../../domain/models/departamento.dart';
import '../register_text_field.dart';
import '../register_droopdown.dart';

class DepartamentoCorreoField extends StatelessWidget {
  final List<Departamento> departamentos;
  final bool loadingDepartamentos;
  final Departamento? departamentoSeleccionado;
  final Function(Departamento) onDepartamentoChanged;
  final TextEditingController correoController;

  const DepartamentoCorreoField({
    super.key,
    required this.departamentos,
    required this.loadingDepartamentos,
    required this.departamentoSeleccionado,
    required this.onDepartamentoChanged,
    required this.correoController,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: loadingDepartamentos
              ? const CircularProgressIndicator()
              : RegisterDropdown(
                  label: "Departamento",
                  selectedValue: departamentoSeleccionado?.nombre,
                  items: departamentos.map((d) => d.nombre).toList(),
                  onChanged: (value) {
                    final dep = departamentos.firstWhere(
                      (d) => d.nombre == value,
                    );
                    onDepartamentoChanged(dep);
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
    );
  }
}
