<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:04:10+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "id"
}
-->
# Layanan Kalkulator Dasar MCP

Layanan ini menyediakan operasi kalkulator dasar melalui Model Context Protocol (MCP). Dirancang sebagai contoh sederhana bagi pemula yang ingin mempelajari implementasi MCP.

Untuk informasi lebih lanjut, lihat [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Fitur

Layanan kalkulator ini menawarkan kemampuan berikut:

1. **Operasi Aritmatika Dasar**:
   - Penjumlahan dua angka
   - Pengurangan satu angka dari angka lainnya
   - Perkalian dua angka
   - Pembagian satu angka dengan angka lain (dengan pengecekan pembagian nol)

## Menggunakan `stdio` Tipe

## Konfigurasi

1. **Konfigurasikan Server MCP**:
   - Buka workspace Anda di VS Code.
   - Buat file `.vscode/mcp.json` di folder workspace Anda untuk mengonfigurasi server MCP. Contoh konfigurasi:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - Anda akan diminta memasukkan root repositori GitHub, yang dapat diambil dari perintah `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` dengan username Docker Hub Anda):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Setelah image selesai dibuat, mari unggah ke Docker Hub. Jalankan perintah berikut:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Gunakan Versi Dockerized

1. Di file `.vscode/mcp.json`, ganti konfigurasi server dengan yang berikut:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Melihat konfigurasi tersebut, Anda dapat melihat bahwa perintahnya adalah `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, dan seperti sebelumnya Anda dapat meminta layanan kalkulator untuk melakukan perhitungan matematika untuk Anda.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.