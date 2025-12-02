# GastoSmart — Manual de usuario

## 1. Descripción general

GastoSmart es una aplicación de escritorio (Windows Forms) para gestionar finanzas personales:  
usuarios, categorías, transacciones, presupuestos y reportes.

Los datos se guardan en archivos **JSON** para mantener la información entre sesiones.

---

## 2. Qué encontrarás en este README

- Visión general del sistema  
- Requisitos e instalación  
- Cómo iniciar sesión  
- Navegación y descripción de cada módulo  
- Flujo de uso típico  
- Persistencia de datos (archivos JSON)  
- Sugerencias de uso, problemas comunes y cómo contribuir  

---

## 3. Requisitos mínimos (orientativo)

- Sistema operativo Windows con **.NET / Runtime** compatible con el proyecto WinForms.  
- **Visual Studio** (o compilador equivalente) para abrir/compilar el proyecto si trabajas con el código.  
- Si solo usarás el ejecutable: basta con hacer doble clic en el `.exe` generado.

> Nota: revisa el archivo `.csproj` del repositorio para confirmar la versión exacta de .NET/Framework utilizada.

---

## 4. Cómo ejecutar la aplicación

1. Abrir la solución/proyecto en **Visual Studio**.  
2. Compilar: `Build → Rebuild Solution`.  
3. Ejecutar: tecla **F5** o botón **Start**.  
4. Si solo tienes los artefactos compilados: coloca los archivos JSON (si existen) en la misma carpeta que el ejecutable.

---

## 5. Inicio de sesión (Gestión de usuarios)

Al iniciar, el sistema muestra un formulario de **Login**.

- Las credenciales se validan mediante `UsuarioService.Autenticar`.  
- Si el login es válido:
  - Se establece `AppServices.UsuarioActual`.  
  - En el menú principal aparecerá el mensaje:  
    `Bienvenid@, {Nombre}`.

Sin un usuario autenticado no se puede acceder al resto de módulos.

---

## 6. Menú principal

En el menú principal se muestran indicadores clave:

- **Saldo actual** = ingresos − gastos.  
- **Presupuesto mensual configurado**.  
- **Monto gastado en el mes**.

Los valores se actualizan automáticamente cuando se cierran formularios relevantes, por ejemplo:

- `FrmTransacciones`  
- `FrmPresupuestoGlobal`

Botones principales del menú:

- **Transacciones**  
- **Categorías**  
- **Reportes**  
- **Presupuestos**

---

## 7. Módulo de categorías

### Funcionalidad

- CRUD completo:
  - Crear  
  - Leer  
  - Editar  
  - Eliminar / Activar / Desactivar  

Cada categoría incluye:

- `IdCategoria`  
- `IdUsuario`  
- `Nombre`  
- `Descripcion`  
- `Tipo` (Ingreso / Gasto)  
- `Activa` (bool)

### Validaciones

- No se permiten nombres duplicados  
  (validación por `CategoriaService.NombreExiste`).  
- No se permiten nombres vacíos.

### Uso dentro de la aplicación

- Solo las **categorías activas** se muestran al registrar transacciones.

---

## 8. Módulo de transacciones

### Elementos de una transacción

- Fecha  
- Tipo (Ingreso / Gasto)  
- Monto  
- Descripción  
- Categoría

### Funcionalidades

- Crear nuevas transacciones.  
- Editar transacciones (se trabaja sobre una copia para permitir cancelar cambios).  
- Eliminar transacciones (con confirmación).  
- Visualizar el listado en un `DataGridView` con las columnas:
  - Fecha  
  - Tipo  
  - Monto (en formato moneda)  
  - Categoría (se muestra el nombre)  
  - Descripción  

### Implementación (detalle técnico)

- El grid utiliza una proyección LINQ para mostrar `NombreCategoria` y mantener internamente la referencia original a la transacción, de forma que se pueda editar o eliminar correctamente.

---

## 9. Presupuesto global

Configuraciones disponibles:

- Monto mensual  
- Umbral mensual de alerta (%)  
- Umbral diario de alerta (%)

Antes de aceptar un gasto, se ejecuta:

```csharp
ValidarGasto(Transaccion)
