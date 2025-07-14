<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-13T17:37:24+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ms"
}
-->
### -2- Buat projek

Sekarang anda telah memasang SDK, mari kita buat projek seterusnya:

### -3- Buat fail projek

### -4- Buat kod server

### -5- Menambah alat dan sumber

Tambah alat dan sumber dengan menambah kod berikut:

### -6 Kod akhir

Mari kita tambah kod terakhir yang diperlukan supaya server boleh dimulakan:

### -7- Uji server

Mulakan server dengan arahan berikut:

### -8- Jalankan menggunakan inspector

Inspector adalah alat hebat yang boleh memulakan server anda dan membolehkan anda berinteraksi dengannya supaya anda boleh menguji fungsinya. Mari kita mulakan:
> [!NOTE]
> ia mungkin kelihatan berbeza dalam medan "command" kerana ia mengandungi arahan untuk menjalankan pelayan dengan runtime khusus anda/
Anda sepatutnya melihat antara muka pengguna berikut:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png)

1. Sambungkan ke pelayan dengan memilih butang Connect  
   Setelah anda bersambung ke pelayan, anda sepatutnya melihat yang berikut:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ms.png)

1. Pilih "Tools" dan "listTools", anda akan melihat "Add" muncul, pilih "Add" dan isi nilai parameter.

   Anda akan melihat respons berikut, iaitu hasil daripada alat "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ms.png)

Tahniah, anda telah berjaya mencipta dan menjalankan pelayan pertama anda!

### SDK Rasmi

MCP menyediakan SDK rasmi untuk pelbagai bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Diselenggara bersama Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Diselenggara bersama Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi rasmi TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi rasmi Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi rasmi Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Diselenggara bersama Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi rasmi Rust  

## Perkara Penting

- Menyediakan persekitaran pembangunan MCP adalah mudah dengan SDK khusus bahasa  
- Membina pelayan MCP melibatkan penciptaan dan pendaftaran alat dengan skema yang jelas  
- Ujian dan penyahpepijatan penting untuk pelaksanaan MCP yang boleh dipercayai  

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Tugasan

Cipta pelayan MCP ringkas dengan alat pilihan anda:

1. Laksanakan alat tersebut dalam bahasa pilihan anda (.NET, Java, Python, atau JavaScript).  
2. Tentukan parameter input dan nilai pulangan.  
3. Jalankan alat inspector untuk memastikan pelayan berfungsi seperti yang diingini.  
4. Uji pelaksanaan dengan pelbagai input.  

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Sumber Tambahan

- [Membina Ejen menggunakan Model Context Protocol di Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP Jauh dengan Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [Ejen MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Apa seterusnya

Seterusnya: [Memulakan dengan Klien MCP](../02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.