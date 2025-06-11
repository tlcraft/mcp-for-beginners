<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:28:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "es"
}
-->
# Servicio Básico de Calculadora MCP

Este servicio proporciona operaciones básicas de calculadora a través del Protocolo de Contexto de Modelo (MCP) usando Spring Boot con transporte WebFlux. Está diseñado como un ejemplo sencillo para principiantes que aprenden sobre implementaciones MCP.

Para más información, consulta la documentación de referencia [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html).


## Uso del Servicio

El servicio expone los siguientes endpoints API a través del protocolo MCP:

- `add(a, b)`: Sumar dos números
- `subtract(a, b)`: Restar el segundo número del primero
- `multiply(a, b)`: Multiplicar dos números
- `divide(a, b)`: Dividir el primer número por el segundo (con verificación de cero)
- `power(base, exponent)`: Calcular la potencia de un número
- `squareRoot(number)`: Calcular la raíz cuadrada (con verificación de números negativos)
- `modulus(a, b)`: Calcular el resto de una división
- `absolute(number)`: Calcular el valor absoluto

## Dependencias

El proyecto requiere las siguientes dependencias clave:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Compilar el Proyecto

Compila el proyecto usando Maven:
```bash
./mvnw clean install -DskipTests
```

## Ejecutar el Servidor

### Usando Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Usando MCP Inspector

El MCP Inspector es una herramienta útil para interactuar con servicios MCP. Para usarlo con este servicio de calculadora:

1. **Instala y ejecuta MCP Inspector** en una nueva ventana de terminal:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Accede a la interfaz web** haciendo clic en la URL que muestra la aplicación (normalmente http://localhost:6274)

3. **Configura la conexión**:
   - Establece el tipo de transporte a "SSE"
   - Establece la URL al endpoint SSE de tu servidor en ejecución: `http://localhost:8080/sse`
   - Haz clic en "Connect"

4. **Usa las herramientas**:
   - Haz clic en "List Tools" para ver las operaciones de calculadora disponibles
   - Selecciona una herramienta y haz clic en "Run Tool" para ejecutar una operación

![Captura de pantalla de MCP Inspector](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.es.png)

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por un humano. No nos hacemos responsables de ningún malentendido o interpretación errónea derivada del uso de esta traducción.