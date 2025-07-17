<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd0fdbbbebbef2b6b179ceba21d82ed2",
  "translation_date": "2025-07-17T07:55:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "id"
}
-->
# Memulai dengan MCP

Selamat datang di langkah pertama Anda dengan Model Context Protocol (MCP)! Baik Anda baru mengenal MCP atau ingin memperdalam pemahaman, panduan ini akan membimbing Anda melalui proses pengaturan dan pengembangan yang penting. Anda akan menemukan bagaimana MCP memungkinkan integrasi mulus antara model AI dan aplikasi, serta belajar cara cepat menyiapkan lingkungan untuk membangun dan menguji solusi berbasis MCP.

> TLDR; Jika Anda membuat aplikasi AI, Anda tahu bahwa Anda bisa menambahkan alat dan sumber daya lain ke LLM (large language model), agar LLM menjadi lebih berpengetahuan. Namun jika Anda menempatkan alat dan sumber daya tersebut di server, kemampuan aplikasi dan server dapat digunakan oleh klien mana pun dengan/ tanpa LLM.

## Ikhtisar

Pelajaran ini memberikan panduan praktis tentang cara menyiapkan lingkungan MCP dan membangun aplikasi MCP pertama Anda. Anda akan belajar cara menyiapkan alat dan kerangka kerja yang diperlukan, membangun server MCP dasar, membuat aplikasi host, dan menguji implementasi Anda.

Model Context Protocol (MCP) adalah protokol terbuka yang menstandarisasi cara aplikasi menyediakan konteks ke LLM. Bayangkan MCP seperti port USB-C untuk aplikasi AI - menyediakan cara standar untuk menghubungkan model AI ke berbagai sumber data dan alat.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:

- Menyiapkan lingkungan pengembangan untuk MCP dalam C#, Java, Python, TypeScript, dan JavaScript
- Membangun dan menerapkan server MCP dasar dengan fitur kustom (sumber daya, prompt, dan alat)
- Membuat aplikasi host yang terhubung ke server MCP
- Menguji dan men-debug implementasi MCP

## Menyiapkan Lingkungan MCP Anda

Sebelum mulai bekerja dengan MCP, penting untuk menyiapkan lingkungan pengembangan dan memahami alur kerja dasar. Bagian ini akan membimbing Anda melalui langkah-langkah awal agar Anda dapat memulai dengan lancar menggunakan MCP.

### Prasyarat

Sebelum terjun ke pengembangan MCP, pastikan Anda memiliki:

- **Lingkungan Pengembangan**: Untuk bahasa pilihan Anda (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau editor kode modern lainnya
- **Manajer Paket**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **API Keys**: Untuk layanan AI yang akan Anda gunakan dalam aplikasi host

## Struktur Dasar Server MCP

Server MCP biasanya mencakup:

- **Konfigurasi Server**: Pengaturan port, autentikasi, dan pengaturan lainnya
- **Sumber Daya**: Data dan konteks yang tersedia untuk LLM
- **Alat**: Fungsi yang dapat dipanggil oleh model
- **Prompt**: Template untuk menghasilkan atau menyusun teks

Berikut contoh sederhana dalam TypeScript:

```typescript
import { Server, Tool, Resource } from "@modelcontextprotocol/typescript-server-sdk";

// Create a new MCP server
const server = new Server({
  port: 3000,
  name: "Example MCP Server",
  version: "1.0.0"
});

// Register a tool
server.registerTool({
  name: "calculator",
  description: "Performs basic calculations",
  parameters: {
    expression: {
      type: "string",
      description: "The math expression to evaluate"
    }
  },
  handler: async (params) => {
    const result = eval(params.expression);
    return { result };
  }
});

// Start the server
server.start();
```

Dalam kode di atas kita:

- Mengimpor kelas yang diperlukan dari MCP TypeScript SDK.
- Membuat dan mengonfigurasi instance server MCP baru.
- Mendaftarkan alat kustom (`calculator`) dengan fungsi handler.
- Memulai server untuk mendengarkan permintaan MCP yang masuk.

## Pengujian dan Debugging

Sebelum mulai menguji server MCP Anda, penting untuk memahami alat yang tersedia dan praktik terbaik untuk debugging. Pengujian yang efektif memastikan server Anda berperilaku sesuai harapan dan membantu Anda dengan cepat mengidentifikasi serta menyelesaikan masalah. Bagian berikut menguraikan pendekatan yang direkomendasikan untuk memvalidasi implementasi MCP Anda.

MCP menyediakan alat untuk membantu Anda menguji dan men-debug server:

- **Inspector tool**, antarmuka grafis ini memungkinkan Anda terhubung ke server dan menguji alat, prompt, dan sumber daya Anda.
- **curl**, Anda juga dapat terhubung ke server menggunakan alat baris perintah seperti curl atau klien lain yang dapat membuat dan menjalankan perintah HTTP.

### Menggunakan MCP Inspector

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) adalah alat pengujian visual yang membantu Anda:

1. **Menemukan Kemampuan Server**: Mendeteksi secara otomatis sumber daya, alat, dan prompt yang tersedia
2. **Mengujicoba Eksekusi Alat**: Mencoba parameter berbeda dan melihat respons secara real-time
3. **Melihat Metadata Server**: Memeriksa info server, skema, dan konfigurasi

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

Saat Anda menjalankan perintah di atas, MCP Inspector akan membuka antarmuka web lokal di browser Anda. Anda akan melihat dashboard yang menampilkan server MCP yang terdaftar, alat, sumber daya, dan prompt yang tersedia. Antarmuka ini memungkinkan Anda menguji eksekusi alat secara interaktif, memeriksa metadata server, dan melihat respons secara real-time, sehingga memudahkan validasi dan debugging implementasi server MCP Anda.

Berikut tangkapan layar tampilannya:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.id.png)

## Masalah Umum Saat Pengaturan dan Solusinya

| Masalah | Solusi yang Mungkin |
|---------|---------------------|
| Koneksi ditolak | Periksa apakah server berjalan dan port sudah benar |
| Kesalahan eksekusi alat | Tinjau validasi parameter dan penanganan kesalahan |
| Gagal autentikasi | Verifikasi API key dan izin akses |
| Kesalahan validasi skema | Pastikan parameter sesuai dengan skema yang ditentukan |
| Server tidak mulai | Periksa konflik port atau dependensi yang hilang |
| Kesalahan CORS | Konfigurasikan header CORS yang tepat untuk permintaan lintas asal |
| Masalah autentikasi | Verifikasi keabsahan token dan izin akses |

## Pengembangan Lokal

Untuk pengembangan dan pengujian lokal, Anda dapat menjalankan server MCP langsung di mesin Anda:

1. **Mulai proses server**: Jalankan aplikasi server MCP Anda
2. **Konfigurasi jaringan**: Pastikan server dapat diakses pada port yang diharapkan
3. **Hubungkan klien**: Gunakan URL koneksi lokal seperti `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Membangun Server MCP Pertama Anda

Kita sudah membahas [Konsep Inti](/01-CoreConcepts/README.md) pada pelajaran sebelumnya, sekarang saatnya menerapkan pengetahuan tersebut.

### Apa yang Bisa Dilakukan Server

Sebelum mulai menulis kode, mari kita ingat kembali apa yang bisa dilakukan server:

Server MCP dapat misalnya:

- Mengakses file lokal dan basis data
- Terhubung ke API jarak jauh
- Melakukan perhitungan
- Terintegrasi dengan alat dan layanan lain
- Menyediakan antarmuka pengguna untuk interaksi

Bagus, sekarang kita tahu apa yang bisa dilakukan, mari mulai coding.

## Latihan: Membuat Server

Untuk membuat server, Anda perlu mengikuti langkah-langkah berikut:

- Instal MCP SDK.
- Buat proyek dan atur struktur proyek.
- Tulis kode server.
- Uji server.

### -1- Instal SDK

Ini sedikit berbeda tergantung runtime yang Anda pilih, jadi pilih salah satu runtime di bawah ini:

> [!NOTE]
> Untuk Python, kita akan membuat struktur proyek terlebih dahulu lalu menginstal dependensi.

### TypeScript

```sh
npm install @modelcontextprotocol/sdk zod
npm install -D @types/node typescript
```

### Python

```sh
# Create project dir
mkdir calculator-server
cd calculator-server
# Open the folder in Visual Studio Code - Skip this if you are using a different IDE
code .
```

### .NET

```sh
dotnet new console -n McpCalculatorServer
cd McpCalculatorServer
```

### Java

Untuk Java, buat proyek Spring Boot:

```bash
curl https://start.spring.io/starter.zip \
  -d dependencies=web \
  -d javaVersion=21 \
  -d type=maven-project \
  -d groupId=com.example \
  -d artifactId=calculator-server \
  -d name=McpServer \
  -d packageName=com.microsoft.mcp.sample.server \
  -o calculator-server.zip
```

Ekstrak file zip:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

Tambahkan konfigurasi lengkap berikut ke file *pom.xml* Anda:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project xmlns="http://maven.apache.org/POM/4.0.0"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xsi:schemaLocation="http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd">
    <modelVersion>4.0.0</modelVersion>
    
    <!-- Spring Boot parent for dependency management -->
    <parent>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-parent</artifactId>
        <version>3.5.0</version>
        <relativePath />
    </parent>

    <!-- Project coordinates -->
    <groupId>com.example</groupId>
    <artifactId>calculator-server</artifactId>
    <version>0.0.1-SNAPSHOT</version>
    <name>Calculator Server</name>
    <description>Basic calculator MCP service for beginners</description>

    <!-- Properties -->
    <properties>
        <java.version>21</java.version>
        <maven.compiler.source>21</maven.compiler.source>
        <maven.compiler.target>21</maven.compiler.target>
    </properties>

    <!-- Spring AI BOM for version management -->
    <dependencyManagement>
        <dependencies>
            <dependency>
                <groupId>org.springframework.ai</groupId>
                <artifactId>spring-ai-bom</artifactId>
                <version>1.0.0-SNAPSHOT</version>
                <type>pom</type>
                <scope>import</scope>
            </dependency>
        </dependencies>
    </dependencyManagement>

    <!-- Dependencies -->
    <dependencies>
        <dependency>
            <groupId>org.springframework.ai</groupId>
            <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
        </dependency>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-actuator</artifactId>
        </dependency>
        <dependency>
         <groupId>org.springframework.boot</groupId>
         <artifactId>spring-boot-starter-test</artifactId>
         <scope>test</scope>
      </dependency>
    </dependencies>

    <!-- Build configuration -->
    <build>
        <plugins>
            <plugin>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-maven-plugin</artifactId>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <configuration>
                    <release>21</release>
                </configuration>
            </plugin>
        </plugins>
    </build>

    <!-- Repositories for Spring AI snapshots -->
    <repositories>
        <repository>
            <id>spring-milestones</id>
            <name>Spring Milestones</name>
            <url>https://repo.spring.io/milestone</url>
            <snapshots>
                <enabled>false</enabled>
            </snapshots>
        </repository>
        <repository>
            <id>spring-snapshots</id>
            <name>Spring Snapshots</name>
            <url>https://repo.spring.io/snapshot</url>
            <releases>
                <enabled>false</enabled>
            </releases>
        </repository>
    </repositories>
</project>
```

### TypeScript

```sh
mkdir src
npm install -y
```

### Python

```sh
# Create a virtual env and install dependencies
python -m venv venv
venv\Scripts\activate
pip install "mcp[cli]"
```

### Java

```bash
cd calculator-server
./mvnw clean install -DskipTests
```

### TypeScript

Buat *package.json* dengan isi berikut:

```json
{
   "type": "module",
   "bin": {
     "weather": "./build/index.js"
   },
   "scripts": {
     "build": "tsc && node build/index.js"
   },
   "files": [
     "build"
   ]
}
```

Buat *tsconfig.json* dengan isi berikut:

```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "Node16",
    "moduleResolution": "Node16",
    "outDir": "./build",
    "rootDir": "./src",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true,
    "forceConsistentCasingInFileNames": true
  },
  "include": ["src/**/*"],
  "exclude": ["node_modules"]
}
```

### Python

Buat file *server.py*
```sh
touch server.py
```

### .NET

Instal paket NuGet yang diperlukan:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Untuk proyek Java Spring Boot, struktur proyek dibuat secara otomatis.

### TypeScript

Buat file *index.ts* dan tambahkan kode berikut:

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
 
// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});
```

Sekarang Anda sudah punya server, tapi belum banyak fungsi, mari kita perbaiki.

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")
```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

// add features
```

### Java

Untuk Java, buat komponen inti server. Pertama, modifikasi kelas aplikasi utama:

*src/main/java/com/microsoft/mcp/sample/server/McpServerApplication.java*:

```java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

Buat layanan kalkulator *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

```java
package com.microsoft.mcp.sample.server.service;

import org.springframework.ai.tool.annotation.Tool;
import org.springframework.stereotype.Service;

/**
 * Service for basic calculator operations.
 * This service provides simple calculator functionality through MCP.
 */
@Service
public class CalculatorService {

    /**
     * Add two numbers
     * @param a The first number
     * @param b The second number
     * @return The sum of the two numbers
     */
    @Tool(description = "Add two numbers together")
    public String add(double a, double b) {
        double result = a + b;
        return formatResult(a, "+", b, result);
    }

    /**
     * Subtract one number from another
     * @param a The number to subtract from
     * @param b The number to subtract
     * @return The result of the subtraction
     */
    @Tool(description = "Subtract the second number from the first number")
    public String subtract(double a, double b) {
        double result = a - b;
        return formatResult(a, "-", b, result);
    }

    /**
     * Multiply two numbers
     * @param a The first number
     * @param b The second number
     * @return The product of the two numbers
     */
    @Tool(description = "Multiply two numbers together")
    public String multiply(double a, double b) {
        double result = a * b;
        return formatResult(a, "*", b, result);
    }

    /**
     * Divide one number by another
     * @param a The numerator
     * @param b The denominator
     * @return The result of the division
     */
    @Tool(description = "Divide the first number by the second number")
    public String divide(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a / b;
        return formatResult(a, "/", b, result);
    }

    /**
     * Calculate the power of a number
     * @param base The base number
     * @param exponent The exponent
     * @return The result of raising the base to the exponent
     */
    @Tool(description = "Calculate the power of a number (base raised to an exponent)")
    public String power(double base, double exponent) {
        double result = Math.pow(base, exponent);
        return formatResult(base, "^", exponent, result);
    }

    /**
     * Calculate the square root of a number
     * @param number The number to find the square root of
     * @return The square root of the number
     */
    @Tool(description = "Calculate the square root of a number")
    public String squareRoot(double number) {
        if (number < 0) {
            return "Error: Cannot calculate square root of a negative number";
        }
        double result = Math.sqrt(number);
        return String.format("√%.2f = %.2f", number, result);
    }

    /**
     * Calculate the modulus (remainder) of division
     * @param a The dividend
     * @param b The divisor
     * @return The remainder of the division
     */
    @Tool(description = "Calculate the remainder when one number is divided by another")
    public String modulus(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a % b;
        return formatResult(a, "%", b, result);
    }

    /**
     * Calculate the absolute value of a number
     * @param number The number to find the absolute value of
     * @return The absolute value of the number
     */
    @Tool(description = "Calculate the absolute value of a number")
    public String absolute(double number) {
        double result = Math.abs(number);
        return String.format("|%.2f| = %.2f", number, result);
    }

    /**
     * Get help about available calculator operations
     * @return Information about available operations
     */
    @Tool(description = "Get help about available calculator operations")
    public String help() {
        return "Basic Calculator MCP Service\n\n" +
               "Available operations:\n" +
               "1. add(a, b) - Adds two numbers\n" +
               "2. subtract(a, b) - Subtracts the second number from the first\n" +
               "3. multiply(a, b) - Multiplies two numbers\n" +
               "4. divide(a, b) - Divides the first number by the second\n" +
               "5. power(base, exponent) - Raises a number to a power\n" +
               "6. squareRoot(number) - Calculates the square root\n" + 
               "7. modulus(a, b) - Calculates the remainder of division\n" +
               "8. absolute(number) - Calculates the absolute value\n\n" +
               "Example usage: add(5, 3) will return 5 + 3 = 8";
    }

    /**
     * Format the result of a calculation
     */
    private String formatResult(double a, String operator, double b, double result) {
        return String.format("%.2f %s %.2f = %.2f", a, operator, b, result);
    }
}
```

**Komponen opsional untuk layanan siap produksi:**

Buat konfigurasi startup *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

```java
package com.microsoft.mcp.sample.server.config;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class StartupConfig {
    
    @Bean
    public CommandLineRunner startupInfo() {
        return args -> {
            System.out.println("\n" + "=".repeat(60));
            System.out.println("Calculator MCP Server is starting...");
            System.out.println("SSE endpoint: http://localhost:8080/sse");
            System.out.println("Health check: http://localhost:8080/actuator/health");
            System.out.println("=".repeat(60) + "\n");
        };
    }
}
```

Buat controller kesehatan *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

```java
package com.microsoft.mcp.sample.server.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

@RestController
public class HealthController {
    
    @GetMapping("/health")
    public ResponseEntity<Map<String, Object>> healthCheck() {
        Map<String, Object> response = new HashMap<>();
        response.put("status", "UP");
        response.put("timestamp", LocalDateTime.now().toString());
        response.put("service", "Calculator MCP Server");
        return ResponseEntity.ok(response);
    }
}
```

Buat penangkap pengecualian *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

```java
package com.microsoft.mcp.sample.server.exception;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

@RestControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(IllegalArgumentException.class)
    public ResponseEntity<ErrorResponse> handleIllegalArgumentException(IllegalArgumentException ex) {
        ErrorResponse error = new ErrorResponse(
            "Invalid_Input", 
            "Invalid input parameter: " + ex.getMessage());
        return new ResponseEntity<>(error, HttpStatus.BAD_REQUEST);
    }

    public static class ErrorResponse {
        private String code;
        private String message;

        public ErrorResponse(String code, String message) {
            this.code = code;
            this.message = message;
        }

        // Getters
        public String getCode() { return code; }
        public String getMessage() { return message; }
    }
}
```

Buat banner kustom *src/main/resources/banner.txt*:

```text
_____      _            _       _             
 / ____|    | |          | |     | |            
| |     __ _| | ___ _   _| | __ _| |_ ___  _ __ 
| |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
| |___| (_| | | (__| |_| | | (_| | || (_) | |   
 \_____\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                                
Calculator MCP Server v1.0
Spring Boot MCP Application
```

</details>

### -5- Menambahkan alat dan sumber daya

Tambahkan alat dan sumber daya dengan menambahkan kode berikut:

### TypeScript

```typescript
  server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);
```

Alat Anda menerima parameter `a` dan `b` dan menjalankan fungsi yang menghasilkan respons dalam bentuk:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

Sumber daya Anda diakses melalui string "greeting" dan menerima parameter `name` serta menghasilkan respons serupa dengan alat:

```typescript
{
  uri: "<href>",
  text: "a text"
}
```

### Python

```python
# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"
```

Dalam kode di atas kita telah:

- Mendefinisikan alat `add` yang menerima parameter `a` dan `p`, keduanya integer.
- Membuat sumber daya bernama `greeting` yang menerima parameter `name`.

### .NET

Tambahkan ini ke file Program.cs Anda:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Alat sudah dibuat pada langkah sebelumnya.

### -6 Kode akhir

Mari tambahkan kode terakhir yang diperlukan agar server dapat mulai berjalan:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

Berikut kode lengkapnya:

```typescript
// index.ts
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

# Main execution block - this is required to run the server
if __name__ == "__main__":
    mcp.run()
```

### .NET

Buat file Program.cs dengan isi berikut:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Kelas aplikasi utama lengkap Anda harus terlihat seperti ini:

```java
// McpServerApplication.java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

### -7- Uji server

Mulai server dengan perintah berikut:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> Untuk menggunakan MCP Inspector, gunakan `mcp dev server.py` yang secara otomatis meluncurkan Inspector dan menyediakan token sesi proxy yang diperlukan. Jika menggunakan `mcp run server.py`, Anda harus memulai Inspector secara manual dan mengonfigurasi koneksi.

### .NET

Pastikan Anda berada di direktori proyek:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- Jalankan menggunakan inspector

Inspector adalah alat hebat yang dapat memulai server Anda dan memungkinkan Anda berinteraksi dengannya sehingga Anda dapat menguji apakah server berjalan dengan baik. Mari kita mulai:

> [!NOTE]
> tampilan di bidang "command" mungkin berbeda karena berisi perintah untuk menjalankan server dengan runtime spesifik Anda.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

atau tambahkan ke *package.json* Anda seperti ini: `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` lalu jalankan `npm run inspect`

Python membungkus alat Node.js bernama inspector. Anda bisa memanggil alat tersebut seperti ini:

```sh
mcp dev server.py
```

Namun, alat ini tidak mengimplementasikan semua metode yang tersedia, jadi disarankan menjalankan alat Node.js langsung seperti di bawah ini:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```  
Jika Anda menggunakan alat atau IDE yang memungkinkan konfigurasi perintah dan argumen untuk menjalankan skrip,  
pastikan mengatur `python` di bidang `Command` dan `server.py` sebagai `Arguments`. Ini memastikan skrip berjalan dengan benar.

### .NET

Pastikan Anda berada di direktori proyek:

```sh
cd McpCalculatorServer
npx @modelcontextprotocol/inspector dotnet run
```

### Java

Pastikan server kalkulator Anda berjalan  
Kemudian jalankan inspector:

```cmd
npx @modelcontextprotocol/inspector
```

Di antarmuka web inspector:

1. Pilih "SSE" sebagai tipe transportasi
2. Atur URL ke: `http://localhost:8080/sse`
3. Klik "Connect"

![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.id.png)

**Anda sekarang terhubung ke server**  
**Bagian pengujian server Java selesai sekarang**

Bagian berikutnya membahas interaksi dengan server.

Anda akan melihat antarmuka pengguna berikut:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.id.png)

1. Hubungkan ke server dengan memilih tombol Connect  
   Setelah terhubung, Anda akan melihat tampilan berikut:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.id.png)

2. Pilih "Tools" dan "listTools", Anda akan melihat "Add" muncul, pilih "Add" dan isi nilai parameter.

   Anda akan melihat respons berikut, yaitu hasil dari alat "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.id.png)

Selamat, Anda berhasil membuat dan menjalankan server pertama Anda!

### SDK Resmi

MCP menyediakan SDK resmi untuk berbagai bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Dipelihara bekerja sama dengan Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Dipelihara bekerja sama dengan Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi resmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi resmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi resmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Dipelihara bekerja sama dengan Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi resmi Rust

## Poin Penting

- Menyiapkan lingkungan pengembangan MCP mudah dengan SDK khusus bahasa
- Membangun server MCP melibatkan pembuatan dan pendaftaran tools dengan skema yang jelas
- Pengujian dan debugging penting untuk implementasi MCP yang andal

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tugas

Buat server MCP sederhana dengan tool pilihan Anda:

1. Implementasikan tool dalam bahasa favorit Anda (.NET, Java, Python, atau JavaScript).
2. Tentukan parameter input dan nilai kembalian.
3. Jalankan alat inspector untuk memastikan server berjalan sesuai harapan.
4. Uji implementasi dengan berbagai input.

## Solusi

[Solution](./solution/README.md)

## Sumber Tambahan

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Selanjutnya

Selanjutnya: [Getting Started with MCP Clients](../02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.