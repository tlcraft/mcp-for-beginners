<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:48:41+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "id"
}
-->
# Calculator HTTP Streaming Demo

Proyek ini menunjukkan HTTP streaming menggunakan Server-Sent Events (SSE) dengan Spring Boot WebFlux. Terdiri dari dua aplikasi:

- **Calculator Server**: Layanan web reaktif yang melakukan perhitungan dan mengalirkan hasil menggunakan SSE
- **Calculator Client**: Aplikasi klien yang mengonsumsi endpoint streaming

## Prasyarat

- Java 17 atau lebih baru
- Maven 3.6 atau lebih baru

## Struktur Proyek

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

## Cara Kerja

1. **Calculator Server** membuka endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Mengonsumsi respons streaming
   - Mencetak setiap event ke konsol

## Menjalankan Aplikasi

### Opsi 1: Menggunakan Maven (Direkomendasikan)

#### 1. Mulai Calculator Server

Buka terminal dan masuk ke direktori server:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Server akan berjalan di `http://localhost:8080`

Anda akan melihat output seperti:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Jalankan Calculator Client

Buka **terminal baru** dan masuk ke direktori client:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Client akan terhubung ke server, melakukan perhitungan, dan menampilkan hasil streaming.

### Opsi 2: Menggunakan Java langsung

#### 1. Kompilasi dan jalankan server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Kompilasi dan jalankan client:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Menguji Server Secara Manual

Anda juga bisa menguji server menggunakan browser atau curl:

### Menggunakan browser:
Kunjungi: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Menggunakan curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Output yang Diharapkan

Saat menjalankan client, Anda akan melihat output streaming seperti:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Operasi yang Didukung

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
- Mengembalikan Server-Sent Events dengan progres perhitungan dan hasil

**Contoh Permintaan:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Contoh Respons:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Pemecahan Masalah

### Masalah Umum

1. **Port 8080 sudah digunakan**
   - Hentikan aplikasi lain yang menggunakan port 8080
   - Atau ubah port server di `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` jika menjalankan sebagai proses latar belakang

## Teknologi yang Digunakan

- **Spring Boot 3.3.1** - Framework aplikasi
- **Spring WebFlux** - Framework web reaktif
- **Project Reactor** - Library reactive streams
- **Netty** - Server I/O non-blocking
- **Maven** - Alat build
- **Java 17+** - Bahasa pemrograman

## Langkah Selanjutnya

Cobalah memodifikasi kode untuk:
- Menambahkan operasi matematika lainnya
- Menyertakan penanganan error untuk operasi tidak valid
- Menambahkan logging permintaan/respons
- Mengimplementasikan autentikasi
- Menambahkan unit test

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.