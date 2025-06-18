<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:43:10+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "es"
}
-->
# Demo de Streaming HTTP de Calculadora

Este proyecto demuestra el streaming HTTP usando Server-Sent Events (SSE) con Spring Boot WebFlux. Consta de dos aplicaciones:

- **Calculator Server**: Un servicio web reactivo que realiza cálculos y transmite resultados usando SSE
- **Calculator Client**: Una aplicación cliente que consume el endpoint de streaming

## Requisitos Previos

- Java 17 o superior
- Maven 3.6 o superior

## Estructura del Proyecto

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## Cómo Funciona

1. El **Calculator Server** expone un endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Consume la respuesta en streaming
   - Imprime cada evento en la consola

## Ejecutando las Aplicaciones

### Opción 1: Usando Maven (Recomendado)

#### 1. Iniciar el Calculator Server

Abre una terminal y navega al directorio del servidor:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

El servidor arrancará en `http://localhost:8080`

Deberías ver una salida similar a:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Ejecutar el Calculator Client

Abre una **nueva terminal** y navega al directorio del cliente:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

El cliente se conectará al servidor, realizará el cálculo y mostrará los resultados en streaming.

### Opción 2: Usar Java directamente

#### 1. Compilar y ejecutar el servidor:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Compilar y ejecutar el cliente:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Probar el Servidor Manualmente

También puedes probar el servidor usando un navegador web o curl:

### Usando un navegador web:
Visita: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Usando curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Salida Esperada

Al ejecutar el cliente, deberías ver una salida en streaming similar a:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Operaciones Soportadas

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Retorna Server-Sent Events con el progreso del cálculo y el resultado

**Ejemplo de Solicitud:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Ejemplo de Respuesta:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Solución de Problemas

### Problemas Comunes

1. **Puerto 8080 ya está en uso**
   - Detén cualquier otra aplicación que esté usando el puerto 8080
   - O cambia el puerto del servidor en `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` si se está ejecutando como proceso en segundo plano

## Tecnología Utilizada

- **Spring Boot 3.3.1** - Framework de aplicación
- **Spring WebFlux** - Framework web reactivo
- **Project Reactor** - Biblioteca de streams reactivos
- **Netty** - Servidor I/O no bloqueante
- **Maven** - Herramienta de construcción
- **Java 17+** - Lenguaje de programación

## Próximos Pasos

Intenta modificar el código para:
- Añadir más operaciones matemáticas
- Incluir manejo de errores para operaciones inválidas
- Agregar registro de solicitudes/respuestas
- Implementar autenticación
- Añadir pruebas unitarias

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.