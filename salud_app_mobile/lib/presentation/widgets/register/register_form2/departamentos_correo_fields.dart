import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/departamento.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/drop_down_field_custom.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/text_field_custom.dart';

class DepartamentosCorreoFields extends StatelessWidget {
  final List<Departamento> departamentos;
  final bool loadingDepartamentos;
  final Departamento? departamentoSeleccionado;
  final Function(Departamento) onDepartamentoChanged;
  final TextEditingController correoController;

  const DepartamentosCorreoFields({
    super.key,
    required this.departamentos,
    required this.loadingDepartamentos,
    required this.departamentoSeleccionado,
    required this.onDepartamentoChanged,
    required this.correoController,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        TextFieldCustom(
            controller: correoController, 
            icono: Icons.email, 
            type: TextInputType.text, 
            texto: "Correo Electrónico"
        ),

        const SizedBox(height: 10),

        loadingDepartamentos
            ? const Center(child: CircularProgressIndicator())
            : DropdownFieldCustom(
                hintText: "Departamentos",
                items: departamentos.map((m) => m.nombre).toList(),
                selectedValue: departamentoSeleccionado?.nombre,
                icono: Icons.apartment,
                onChanged: (value) {
                  final dep = departamentos.firstWhere(
                    (m) => m.nombre == value,
                  );
                  if (dep.id != -1) onDepartamentoChanged(dep);
                },
              ),

        const SizedBox(height: 10),
      ],
    );
  }
}
