import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/dialogs/dialog.dart';
import 'package:salud_app_mobile/presentation/widgets/register/accep_terms.dart';
import 'register_button.dart';
import 'register_date_field.dart';
import 'register_dropdown.dart';

class RegisterForm extends StatefulWidget {
  const RegisterForm({super.key});

  @override
  State<RegisterForm> createState() => _RegisterFormState();
}

class _RegisterFormState extends State<RegisterForm> {
  final TextEditingController nameController = TextEditingController();
  final TextEditingController emailController = TextEditingController();
  final TextEditingController addressController = TextEditingController();
  final TextEditingController cedulaController = TextEditingController();
  final TextEditingController phoneController = TextEditingController();
  final TextEditingController dobController = TextEditingController();

  String? selectedGender;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Card(
        elevation: 6,
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            children: [
              _buildTextField("Nombre", nameController),
              _buildTextField(
                "Correo",
                emailController,
                keyboardType: TextInputType.emailAddress,
              ),
              _buildTextField("Dirección", addressController),
              _buildTextField("Cédula (081 161616 1001M)", cedulaController),
              _buildTextField(
                "Teléfono",
                phoneController,
                keyboardType: TextInputType.phone,
              ),

              // Campo de fecha
              RegisterDateField(controller: dobController),

              const SizedBox(height: 16),

              // Dropdown de género
              RegisterDropdown(
                selectedGender: selectedGender,
                onChanged: (value) {
                  setState(() => selectedGender = value);
                },
              ),
              const AccepTerms(),
              const SizedBox(height: 2),

              // Botón
              RegisterButton(
                onPressed: () {
                  debugPrint("Nombre: ${nameController.text}");
                  debugPrint("Correo: ${emailController.text}");
                  debugPrint("Dirección: ${addressController.text}");
                  debugPrint("Cédula: ${cedulaController.text}");
                  debugPrint("Teléfono: ${phoneController.text}");
                  debugPrint("Fecha Nac: ${dobController.text}");
                  debugPrint("Género: $selectedGender");

                  if (nameController.text.isEmpty &&
                      emailController.text.isEmpty &&
                      addressController.text.isEmpty &&
                      cedulaController.text.isEmpty &&
                      phoneController.text.isEmpty) {
                    showMessageDialog(
                      context,
                      message: "Debes completar todos los campos",
                    );
                    return;
                  }

                  showMessageDialog(context, message: "registro exitoso");
                },
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildTextField(
    String label,
    TextEditingController controller, {
    TextInputType keyboardType = TextInputType.text,
  }) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 16.0),
      child: TextField(
        controller: controller,
        keyboardType: keyboardType,
        decoration: InputDecoration(
          labelText: label,
          border: const OutlineInputBorder(),
        ),
      ),
    );
  }
}
