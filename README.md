# specflow-selenium-template

Plantilla de proyecto .NET con ramas main y dev, integración continua con GitHub Actions y configuración de pruebas automatizadas utilizando SpecFlow y Selenium Webdriver.

Este repositorio está configurado para facilitar la integración continua (CI) en tus proyectos .NET. Además, incluye un proyecto de SpecFlow para realizar pruebas automatizadas con BDD (Behavior Driven Development), de modo que puedes ejecutarlas como parte del flujo de trabajo de CI.

---

## 🗂️ Estructura de ramas

- **`main`**: Rama de **producción** (solo código estable y probado).
- **`dev`**: Rama de **integración** y **entorno de pruebas** automáticas.

---

## 🚀 Pasos iniciales

1. **Crear un nuevo repositorio en GitHub**.
2. Clonar el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/github-actions-dotnet-setup.git
   cd github-actions-dotnet-setup
   ```
3. Crear la rama `dev`:

   ```bash
   git checkout -b dev
   git push -u origin dev
   ```
## 🔐 Configurar protección de ramas (desde GitHub)

1. Ve a **Settings → Branches → Add rule**.
2. En **Branch name pattern**, escribe `dev` (y repite para `main`).
3. Activar las siguientes opciones para la rama `dev`:
   - ✅ **Require a pull request before merging**: Obliga que cualquier cambio en la rama `dev` pase por un pull request.
   - ✅ **Require status checks to pass before merging**: Asegura que los tests y compilación pasen antes de permitir el merge.
   - ✅ **Require branches to be up to date before merging**: Evita que se haga merge si la rama `dev` no está actualizada con la base.
   - ✅ **Include administrators** (opcional): Aplica las reglas de protección también a los administradores del repositorio.

4. Repite el proceso para la rama `main` con las mismas configuraciones.

### Eliminar ramas automáticamente después del merge

Para eliminar automáticamente las ramas después de que un Pull Request sea aprobado y fusionado, sigue estos pasos:

1. Ve a la sección **Settings → General** en tu repositorio.
2. Desplázate hacia abajo hasta la sección **Pull Requests**.
3. Marca la opción **Automatically delete head branches**.

> **Nota importante**: GitHub **solo eliminará la rama de origen** del Pull Request (es decir, la rama desde la cual se crea el PR). Si haces un Pull Request de `dev` a `main`, **la rama `dev` no se eliminará automáticamente**. Esta opción solo aplica a **ramas de características** o **hotfixes** (por ejemplo, `feature/login-page` o `bugfix/fix-authentication`), que son las ramas creadas específicamente para el PR y no las ramas principales como `dev` o `main`.

---

## ⚙️ GitHub Actions - CI para `dev` y `main`

Crea el archivo `.github/workflows/specflow-tests.yml` con el siguiente contenido:

```bash
name: SpecFlow Tests

on:
  pull_request:
    branches:
      - dev
      - main

jobs:
  test:
    runs-on: ubuntu-latest

    steps:
      # Paso 1: Checkout del código fuente
      - name: Checkout code
        uses: actions/checkout@v2

      # Paso 2: Configurar .NET
      - name: Set up .NET
        uses: actions/setup-dotnet@v2
        with:
          dotnet-version: '6.0'

      # Paso 3: Restaurar dependencias
      - name: Restore dependencies
        run: dotnet restore ./SpecFlowSelenium/SpecflowSelenium.csproj --configfile ./NuGet.Config

      # Paso 4: Compilar el proyecto
      - name: Build project
        run: dotnet build ./SpecFlowSelenium/SpecflowSelenium.csproj --configuration Release
        
      # Paso 5: Ejecutar tests de SpecFlow
      - name: Run SpecFlow Tests
        run: dotnet test ./SpecFlowSelenium/SpecflowSelenium.csproj --configuration Release --no-build --logger "trx"
```
          
## 🧪 Proyecto de SpecFlow

En esta plantilla de repositorio, se incluye un **proyecto de SpecFlow** que es el que se compila y se ejecutan los tests automatizados. SpecFlow es una herramienta de pruebas basada en BDD (Behavior Driven Development) que permite escribir pruebas en un lenguaje natural, facilitando la colaboración entre desarrolladores y stakeholders.

El flujo de integración continua está configurado para compilar y ejecutar los tests de este proyecto de SpecFlow, asegurando que las pruebas se ejecuten correctamente antes de permitir cualquier merge a las ramas `dev` o `main`.

## 📦 Próximos pasos

1. **Añadir SonarQube** para análisis estático de código: SonarQube permite detectar bugs, code smells y mejorar la calidad del código mediante análisis estático.
2. **Configurar despliegues automáticos** desde la rama `main`: Automate deployment processes to your environments.
3. **Añadir pruebas de rendimiento** usando **JMeter**: Configura pruebas de carga para garantizar que tu aplicación pueda manejar la cantidad esperada de tráfico.
4. **Documentar flujos de trabajo Git**: Describe los flujos de trabajo de Git en tu equipo, como ramas para features, hotfixes y merge de cambios.

---
