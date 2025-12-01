+--------------------------------------------------------------------------------------------+
| GastoSmart — README de Usuario |
+--------------------------------------------------------------------------------------------+
| Resumen breve: |
| GastoSmart es una aplicación de escritorio (Windows Forms) para gestionar finanzas |
| personales: usuarios, categorías, transacciones, presupuestos y reportes. Los datos se |
| guardan en JSON para persistencia entre sesiones. |
+--------------------------------------------------------------------------------------------+
| 1) Qué encontrarás en este README |
| - Visión general del sistema |
| - Requisitos e instalación |
| - Cómo iniciar sesión |
| - Navegación y descripción de cada módulo |
| - Flujo de uso típico |
| - Persistencia de datos (archivos JSON) |
| - Sugerencias de uso, problemas comunes y cómo contribuir |
+--------------------------------------------------------------------------------------------+
| Requisitos mínimos (orientativo) |
| - Windows con .NET/Runtime compatible con el proyecto WinForms. |
| - Visual Studio (o compilador) para abrir/compilar el proyecto si trabajas con el código. |
| - Si solo usarás el ejecutable: doble clic en el .exe generado. |
| Nota: revisa el .csproj del repo para confirmar la versión exacta de .NET/Framework usada. |
+--------------------------------------------------------------------------------------------+
| Cómo ejecutar |
| 1. Abrir la solución/proyecto en Visual Studio. |
| 2. Compilar (Build → Rebuild Solution). |
| 3. Ejecutar (F5 o Start). |
| 4. Si tienes solo artefactos: coloca los archivos JSON (si existen) junto al ejecutable. |
+--------------------------------------------------------------------------------------------+
| Iniciar sesión (Gestión de Usuarios) |
| - El sistema presenta un formulario de Login. |
| - Las credenciales se validan mediante UsuarioService.Autenticar. |
| - Si el login es válido: AppServices.UsuarioActual se establece y en el menú aparecerá |
| “Bienvenid@, {Nombre}”. |
+--------------------------------------------------------------------------------------------+
| Menú principal |
| - Indicadores mostrados: |
| * Saldo Actual = ingresos - gastos. |
| * Presupuesto Mensual Configurado. |
| * Monto Gastado en el mes. |
| - Los valores se actualizan automáticamente cuando cierran formularios relevantes |
| (ej. FrmTransacciones, FrmPresupuestoGlobal). |
| - Botones principales: Transacciones, Categorías, Reportes, Presupuestos. |
+--------------------------------------------------------------------------------------------+
| Módulo de Categorías |
| Funcionalidad: |
| - CRUD completo (Crear, Leer, Editar, Eliminar / Activar-Desactivar). |
| - Cada categoría tiene: IdCategoria, IdUsuario, Nombre, Descripcion, Tipo (Ingreso/Gasto), |
| Activa (bool). |
| Validaciones: |
| - No se permiten nombres duplicados (CategoriaService.NombreExiste). |
| - No se permiten nombres vacíos. |
| Uso en la app: |
| - Solo las categorías activas se muestran al registrar transacciones. |
+--------------------------------------------------------------------------------------------+
| Módulo de Transacciones |
| Elementos de una transacción: Fecha, Tipo (Ingreso/Gasto), Monto, Descripción, Categoría. |
| Funcionalidades: |
| - Crear nuevas transacciones. |
| - Editar transacciones (se trabaja sobre una copia para permitir cancelar). |
| - Eliminar transacciones (con confirmación). |
| - Visualizar listado en DataGridView con columnas: Fecha, Tipo, Monto (formato moneda), |
| Categoría (se muestra el nombre) y Descripción. |
| Implementación: |
| - El grid usa una proyección LINQ para mostrar NombreCategoria y guarda la referencia |
| original para poder editar/eliminar correctamente. |
+--------------------------------------------------------------------------------------------+
