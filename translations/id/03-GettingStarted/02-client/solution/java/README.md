<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:14:06+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "id"
}
-->
# MCP Java Client - Demo Kalkulator

Proyek ini menunjukkan cara membuat client Java yang terhubung dan berinteraksi dengan server MCP (Model Context Protocol). Dalam contoh ini, kita akan terhubung ke server kalkulator dari Bab 01 dan melakukan berbagai operasi matematika.

## Prasyarat

Sebelum menjalankan client ini, Anda perlu:

1. **Jalankan Server Kalkulator** dari Bab 01:
   - Arahkan ke direktori server kalkulator: `03-GettingStarted/01-first-server/solution/java/`
   - Bangun dan jalankan server kalkulator:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Server harus berjalan di `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` adalah aplikasi Java yang menunjukkan cara untuk:
- Terhubung ke server MCP menggunakan transport Server-Sent Events (SSE)
- Menampilkan daftar alat yang tersedia dari server
- Memanggil berbagai fungsi kalkulator secara remote
- Menangani respons dan menampilkan hasil

## Cara Kerja

Client menggunakan framework Spring AI MCP untuk:

1. **Membangun Koneksi**: Membuat transport client WebFlux SSE untuk terhubung ke server kalkulator
2. **Inisialisasi Client**: Mengatur client MCP dan membangun koneksi
3. **Menemukan Alat**: Menampilkan semua operasi kalkulator yang tersedia
4. **Menjalankan Operasi**: Memanggil berbagai fungsi matematika dengan data contoh
5. **Menampilkan Hasil**: Menunjukkan hasil dari setiap perhitungan

## Struktur Proyek

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Dependensi Utama

Proyek ini menggunakan dependensi utama berikut:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Dependensi ini menyediakan:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - transport SSE untuk komunikasi berbasis web
- Skema protokol MCP dan tipe request/response

## Membangun Proyek

Bangun proyek menggunakan Maven wrapper:

```cmd
.\mvnw clean install
```

## Menjalankan Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Catatan**: Pastikan server kalkulator berjalan di `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Daftar Alat** - Menampilkan semua operasi kalkulator yang tersedia
3. **Melakukan Perhitungan**:
   - Penjumlahan: 5 + 3 = 8
   - Pengurangan: 10 - 4 = 6
   - Perkalian: 6 × 7 = 42
   - Pembagian: 20 ÷ 4 = 5
   - Perpangkatan: 2^8 = 256
   - Akar Kuadrat: √16 = 4
   - Nilai Mutlak: |-5.5| = 5.5
   - Bantuan: Menampilkan operasi yang tersedia

## Hasil yang Diharapkan

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Catatan**: Anda mungkin melihat peringatan Maven tentang thread yang masih berjalan di akhir - ini normal untuk aplikasi reaktif dan bukan tanda kesalahan.

## Memahami Kode

### 1. Pengaturan Transport
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Ini membuat transport SSE (Server-Sent Events) yang terhubung ke server kalkulator.

### 2. Pembuatan Client
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Membuat client MCP sinkron dan menginisialisasi koneksi.

### 3. Memanggil Alat
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Memanggil alat "add" dengan parameter a=5.0 dan b=3.0.

## Pemecahan Masalah

### Server Tidak Berjalan
Jika Anda mendapat error koneksi, pastikan server kalkulator dari Bab 01 sudah berjalan:
```
Error: Connection refused
```
**Solusi**: Jalankan server kalkulator terlebih dahulu.

### Port Sudah Digunakan
Jika port 8080 sedang digunakan:
```
Error: Address already in use
```
**Solusi**: Hentikan aplikasi lain yang menggunakan port 8080 atau ubah server agar menggunakan port berbeda.

### Error Saat Build
Jika Anda mengalami error saat build:
```cmd
.\mvnw clean install -DskipTests
```

## Pelajari Lebih Lanjut

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi yang penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.