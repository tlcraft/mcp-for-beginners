<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:13:11+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ms"
}
-->
## Memulakan  

Bahagian ini terdiri daripada beberapa pelajaran:

- **-1- Server pertama anda**, dalam pelajaran pertama ini, anda akan belajar cara mencipta server pertama anda dan memeriksanya dengan alat pemeriksa, cara yang berharga untuk menguji dan menyahpepijat server anda, [ke pelajaran](/03-GettingStarted/01-first-server/README.md)

- **-2- Klien**, dalam pelajaran ini, anda akan belajar cara menulis klien yang boleh berhubung dengan server anda, [ke pelajaran](/03-GettingStarted/02-client/README.md)

- **-3- Klien dengan LLM**, cara yang lebih baik untuk menulis klien adalah dengan menambah LLM supaya ia boleh "berunding" dengan server anda tentang apa yang perlu dilakukan, [ke pelajaran](/03-GettingStarted/03-llm-client/README.md)

- **-4- Menggunakan mod Agen GitHub Copilot server dalam Visual Studio Code**. Di sini, kita melihat cara menjalankan MCP Server dari dalam Visual Studio Code, [ke pelajaran](/03-GettingStarted/04-vscode/README.md)

- **-5- Menggunakan dari SSE (Server Sent Events)** SSE adalah standard untuk penstriman server-ke-klien, membolehkan server menolak kemas kini masa nyata kepada klien melalui HTTP [ke pelajaran](/03-GettingStarted/05-sse-server/README.md)

- **-6- Menggunakan AI Toolkit untuk VSCode** untuk menggunakan dan menguji MCP Klien dan Server anda [ke pelajaran](/03-GettingStarted/06-aitk/README.md)

- **-7- Pengujian**. Di sini kita akan memberi tumpuan terutamanya pada cara kita boleh menguji server dan klien kita dengan cara yang berbeza, [ke pelajaran](/03-GettingStarted/07-testing/README.md)

- **-8- Penggunaan**. Bab ini akan melihat cara berbeza untuk menggunakan penyelesaian MCP anda, [ke pelajaran](/03-GettingStarted/08-deployment/README.md)


Protokol Model Context (MCP) adalah protokol terbuka yang menyeragamkan cara aplikasi menyediakan konteks kepada LLMs. Fikirkan MCP seperti port USB-C untuk aplikasi AI - ia menyediakan cara standard untuk menghubungkan model AI ke pelbagai sumber data dan alat.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Menyediakan persekitaran pembangunan untuk MCP dalam C#, Java, Python, TypeScript, dan JavaScript
- Membina dan menggunakan server MCP asas dengan ciri tersuai (sumber, arahan, dan alat)
- Mencipta aplikasi hos yang berhubung ke server MCP
- Menguji dan menyahpepijat pelaksanaan MCP
- Memahami cabaran persediaan biasa dan penyelesaiannya
- Menyambungkan pelaksanaan MCP anda ke perkhidmatan LLM yang popular

## Menyediakan Persekitaran MCP Anda

Sebelum anda mula bekerja dengan MCP, adalah penting untuk menyediakan persekitaran pembangunan anda dan memahami aliran kerja asas. Bahagian ini akan membimbing anda melalui langkah-langkah persediaan awal untuk memastikan permulaan yang lancar dengan MCP.

### Prasyarat

Sebelum mendalami pembangunan MCP, pastikan anda mempunyai:

- **Persekitaran Pembangunan**: Untuk bahasa pilihan anda (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Penyunting**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau mana-mana penyunting kod moden
- **Pengurus Pakej**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **Kunci API**: Untuk mana-mana perkhidmatan AI yang anda rancang untuk digunakan dalam aplikasi hos anda


### SDK Rasmi

Dalam bab-bab yang akan datang, anda akan melihat penyelesaian yang dibina menggunakan Python, TypeScript, Java dan .NET. Berikut adalah semua SDK yang disokong secara rasmi.

MCP menyediakan SDK rasmi untuk pelbagai bahasa:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Diselenggara dengan kerjasama Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Diselenggara dengan kerjasama Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Pelaksanaan TypeScript rasmi
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Pelaksanaan Python rasmi
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Pelaksanaan Kotlin rasmi
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Diselenggara dengan kerjasama Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Pelaksanaan Rust rasmi

## Pengambilan Utama

- Menyediakan persekitaran pembangunan MCP adalah mudah dengan SDK khusus bahasa
- Membina server MCP melibatkan penciptaan dan pendaftaran alat dengan skema yang jelas
- Klien MCP berhubung ke server dan model untuk memanfaatkan keupayaan lanjutan
- Pengujian dan penyahpepijatan adalah penting untuk pelaksanaan MCP yang boleh dipercayai
- Pilihan penggunaan berkisar dari pembangunan tempatan hingga penyelesaian berasaskan awan

## Berlatih

Kami mempunyai set sampel yang melengkapkan latihan yang anda akan lihat dalam semua bab di bahagian ini. Selain itu, setiap bab juga mempunyai latihan dan tugasan masing-masing

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Repositori GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## Apa Seterusnya

Seterusnya: [Mencipta MCP Server pertama anda](/03-GettingStarted/01-first-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.