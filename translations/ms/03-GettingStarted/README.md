<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:13:19+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ms"
}
-->
## Memulakan  

Bahagian ini terdiri daripada beberapa pelajaran:

- **1 Pelayan pertama anda**, dalam pelajaran pertama ini, anda akan belajar cara mencipta pelayan pertama anda dan memeriksanya menggunakan alat pemeriksa, satu cara yang berguna untuk menguji dan menyahpepijat pelayan anda, [ke pelajaran](/03-GettingStarted/01-first-server/README.md)

- **2 Klien**, dalam pelajaran ini, anda akan belajar cara menulis klien yang boleh menyambung ke pelayan anda, [ke pelajaran](/03-GettingStarted/02-client/README.md)

- **3 Klien dengan LLM**, cara yang lebih baik untuk menulis klien adalah dengan menambah LLM supaya ia boleh "berunding" dengan pelayan anda tentang apa yang perlu dilakukan, [ke pelajaran](/03-GettingStarted/03-llm-client/README.md)

- **4 Menggunakan mod Agen GitHub Copilot pelayan dalam Visual Studio Code**. Di sini, kita melihat cara menjalankan MCP Server kita dari dalam Visual Studio Code, [ke pelajaran](/03-GettingStarted/04-vscode/README.md)

- **5 Menggunakan dari SSE (Server Sent Events)** SSE adalah standard untuk penstriman dari pelayan ke klien, membolehkan pelayan menghantar kemas kini masa nyata kepada klien melalui HTTP [ke pelajaran](/03-GettingStarted/05-sse-server/README.md)

- **6 Penstriman HTTP dengan MCP (Streamable HTTP)**. Pelajari tentang penstriman HTTP moden, notifikasi kemajuan, dan cara melaksanakan pelayan dan klien MCP yang boleh diskalakan dan masa nyata menggunakan Streamable HTTP. [ke pelajaran](/03-GettingStarted/06-http-streaming/README.md)

- **7 Menggunakan AI Toolkit untuk VSCode** untuk menggunakan dan menguji MCP Clients dan Servers anda [ke pelajaran](/03-GettingStarted/07-aitk/README.md)

- **8 Pengujian**. Di sini kita akan memberi tumpuan khusus kepada cara kita boleh menguji pelayan dan klien kita dengan pelbagai cara, [ke pelajaran](/03-GettingStarted/08-testing/README.md)

- **9 Penghantaran**. Bab ini akan melihat pelbagai cara untuk menghantar penyelesaian MCP anda, [ke pelajaran](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) adalah protokol terbuka yang menstandardkan cara aplikasi menyediakan konteks kepada LLM. Fikirkan MCP seperti port USB-C untuk aplikasi AI - ia menyediakan cara standard untuk menyambungkan model AI kepada pelbagai sumber data dan alat.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Menyediakan persekitaran pembangunan untuk MCP dalam C#, Java, Python, TypeScript, dan JavaScript
- Membina dan menghantar pelayan MCP asas dengan ciri tersuai (sumber, arahan, dan alat)
- Mencipta aplikasi hos yang menyambung ke pelayan MCP
- Menguji dan menyahpepijat pelaksanaan MCP
- Memahami cabaran penyediaan biasa dan penyelesaiannya
- Menyambungkan pelaksanaan MCP anda ke perkhidmatan LLM yang popular

## Menyediakan Persekitaran MCP Anda

Sebelum anda mula bekerja dengan MCP, penting untuk menyediakan persekitaran pembangunan anda dan memahami aliran kerja asas. Bahagian ini akan membimbing anda melalui langkah-langkah penyediaan awal untuk memastikan permulaan yang lancar dengan MCP.

### Prasyarat

Sebelum menyelami pembangunan MCP, pastikan anda mempunyai:

- **Persekitaran Pembangunan**: Untuk bahasa pilihan anda (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Penyunting**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau mana-mana penyunting kod moden
- **Pengurus Pakej**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **Kunci API**: Untuk mana-mana perkhidmatan AI yang anda rancangkan untuk digunakan dalam aplikasi hos anda


### SDK Rasmi

Dalam bab-bab yang akan datang anda akan melihat penyelesaian yang dibina menggunakan Python, TypeScript, Java dan .NET. Berikut adalah semua SDK rasmi yang disokong.

MCP menyediakan SDK rasmi untuk pelbagai bahasa:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Diselenggara bersama Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Diselenggara bersama Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Pelaksanaan rasmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Pelaksanaan rasmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Pelaksanaan rasmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Diselenggara bersama Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Pelaksanaan rasmi Rust

## Perkara Penting

- Menyediakan persekitaran pembangunan MCP adalah mudah dengan SDK khusus bahasa
- Membina pelayan MCP melibatkan penciptaan dan pendaftaran alat dengan skema yang jelas
- Klien MCP menyambung ke pelayan dan model untuk memanfaatkan keupayaan lanjutan
- Pengujian dan penyahpepijatan penting untuk pelaksanaan MCP yang boleh dipercayai
- Pilihan penghantaran merangkumi pembangunan tempatan hingga penyelesaian berasaskan awan

## Amalan

Kami mempunyai set sampel yang melengkapkan latihan yang akan anda lihat dalam semua bab di bahagian ini. Selain itu, setiap bab juga mempunyai latihan dan tugasan mereka sendiri

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Membina Agen menggunakan Model Context Protocol di Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Jauh dengan Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Apa seterusnya

Seterusnya: [Mencipta MCP Server pertama anda](./01-first-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.