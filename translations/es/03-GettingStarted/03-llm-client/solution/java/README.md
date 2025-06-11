<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:18:51+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "es"
}
-->
# Calculator LLM Client

Una aplicación Java que demuestra cómo usar LangChain4j para conectarse a un servicio de calculadora MCP (Model Context Protocol) con integración de GitHub Models.

## Requisitos Previos

- Java 21 o superior
- Maven 3.6+ (o usa el wrapper de Maven incluido)
- Una cuenta de GitHub con acceso a GitHub Models
- Un servicio de calculadora MCP corriendo en `http://localhost:8080`

## Cómo Obtener el Token de GitHub

Esta aplicación utiliza GitHub Models, lo que requiere un token de acceso personal de GitHub. Sigue estos pasos para obtener tu token:

### 1. Accede a GitHub Models
1. Ve a [GitHub Models](https://github.com/marketplace/models)
2. Inicia sesión con tu cuenta de GitHub
3. Solicita acceso a GitHub Models si aún no lo tienes

### 2. Crea un Token de Acceso Personal
1. Ve a [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Haz clic en "Generate new token" → "Generate new token (classic)"
3. Ponle un nombre descriptivo al token (por ejemplo, "MCP Calculator Client")
4. Configura la expiración según necesites
5. Selecciona los siguientes alcances:
   - `repo` (si accedes a repositorios privados)
   - `user:email`
6. Haz clic en "Generate token"
7. **Importante**: Copia el token inmediatamente, ¡no podrás verlo de nuevo!

### 3. Configura la Variable de Entorno

#### En Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### En Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### En macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Configuración e Instalación

1. **Clona o navega al directorio del proyecto**

2. **Instala las dependencias**:
   ```cmd
   mvnw clean install
   ```
   O si tienes Maven instalado globalmente:
   ```cmd
   mvn clean install
   ```

3. **Configura la variable de entorno** (ver sección "Cómo Obtener el Token de GitHub" arriba)

4. **Inicia el Servicio MCP Calculator**:
   Asegúrate de que el servicio MCP calculator del capítulo 1 esté corriendo en `http://localhost:8080/sse`. Debe estar activo antes de iniciar el cliente.

## Ejecutando la Aplicación

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Qué Hace la Aplicación

La aplicación demuestra tres interacciones principales con el servicio de calculadora:

1. **Suma**: Calcula la suma de 24.5 y 17.3
2. **Raíz Cuadrada**: Calcula la raíz cuadrada de 144
3. **Ayuda**: Muestra las funciones disponibles de la calculadora

## Salida Esperada

Al ejecutarse correctamente, deberías ver una salida similar a:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Solución de Problemas

### Problemas Comunes

1. **"GITHUB_TOKEN environment variable not set"**
   - Asegúrate de haber configurado la variable `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Depuración

Para habilitar el registro de depuración, agrega el siguiente argumento JVM al ejecutar:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configuración

La aplicación está configurada para:
- Usar GitHub Models con el `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Usar un tiempo de espera de 60 segundos para las solicitudes
- Habilitar el registro de solicitudes/respuestas para depuración

## Dependencias

Dependencias clave usadas en este proyecto:
- **LangChain4j**: Para integración de IA y gestión de herramientas
- **LangChain4j MCP**: Para soporte de Model Context Protocol
- **LangChain4j GitHub Models**: Para integración con GitHub Models
- **Spring Boot**: Para el framework de la aplicación e inyección de dependencias

## Licencia

Este proyecto está licenciado bajo la Apache License 2.0 - consulta el archivo [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) para más detalles.

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.