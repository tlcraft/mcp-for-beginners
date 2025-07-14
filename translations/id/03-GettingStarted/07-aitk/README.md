<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:38:02+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "id"
}
-->
# Menggunakan server dari ekstensi AI Toolkit untuk Visual Studio Code

Saat Anda membangun agen AI, bukan hanya soal menghasilkan respons cerdas; tetapi juga memberikan kemampuan kepada agen Anda untuk mengambil tindakan. Di sinilah Model Context Protocol (MCP) berperan. MCP memudahkan agen untuk mengakses alat dan layanan eksternal dengan cara yang konsisten. Anggap saja seperti menghubungkan agen Anda ke kotak alat yang benar-benar bisa digunakan.

Misalnya, Anda menghubungkan agen ke server MCP kalkulator Anda. Tiba-tiba, agen Anda bisa melakukan operasi matematika hanya dengan menerima perintah seperti “Berapa 47 kali 89?”—tanpa perlu menulis logika secara manual atau membuat API khusus.

## Ikhtisar

Pelajaran ini membahas cara menghubungkan server MCP kalkulator ke agen menggunakan ekstensi [AI Toolkit](https://aka.ms/AIToolkit) di Visual Studio Code, sehingga agen Anda dapat melakukan operasi matematika seperti penjumlahan, pengurangan, perkalian, dan pembagian melalui bahasa alami.

AI Toolkit adalah ekstensi kuat untuk Visual Studio Code yang mempermudah pengembangan agen. AI Engineer dapat dengan mudah membangun aplikasi AI dengan mengembangkan dan menguji model AI generatif—baik secara lokal maupun di cloud. Ekstensi ini mendukung sebagian besar model generatif utama yang tersedia saat ini.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

## Tujuan Pembelajaran

Setelah menyelesaikan pelajaran ini, Anda akan dapat:

- Menggunakan server MCP melalui AI Toolkit.
- Mengonfigurasi konfigurasi agen agar dapat menemukan dan memanfaatkan alat yang disediakan oleh server MCP.
- Menggunakan alat MCP melalui bahasa alami.

## Pendekatan

Berikut cara kita akan melakukannya secara garis besar:

- Membuat agen dan mendefinisikan system prompt-nya.
- Membuat server MCP dengan alat kalkulator.
- Menghubungkan Agent Builder ke server MCP.
- Menguji pemanggilan alat agen melalui bahasa alami.

Bagus, sekarang setelah kita memahami alurnya, mari konfigurasikan agen AI untuk memanfaatkan alat eksternal melalui MCP, sehingga kemampuannya meningkat!

## Prasyarat

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit untuk Visual Studio Code](https://aka.ms/AIToolkit)

## Latihan: Menggunakan server

Dalam latihan ini, Anda akan membangun, menjalankan, dan meningkatkan agen AI dengan alat dari server MCP di dalam Visual Studio Code menggunakan AI Toolkit.

### -0- Langkah awal, tambahkan model OpenAI GPT-4o ke My Models

Latihan ini menggunakan model **GPT-4o**. Model ini harus ditambahkan ke **My Models** sebelum membuat agen.

![Screenshot antarmuka pemilihan model di ekstensi AI Toolkit Visual Studio Code. Judulnya "Find the right model for your AI Solution" dengan subtitle yang mengajak pengguna untuk menemukan, menguji, dan menerapkan model AI. Di bawahnya, di bagian “Popular Models,” terdapat enam kartu model: DeepSeek-R1 (hosted di GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kecil, Cepat), dan DeepSeek-R1 (hosted di Ollama). Setiap kartu memiliki opsi “Add” untuk menambahkan model atau “Try in Playground” untuk mencoba.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.id.png)

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
2. Di bagian **Catalog**, pilih **Models** untuk membuka **Model Catalog**. Memilih **Models** akan membuka **Model Catalog** di tab editor baru.
3. Di kolom pencarian **Model Catalog**, ketik **OpenAI GPT-4o**.
4. Klik **+ Add** untuk menambahkan model ke daftar **My Models** Anda. Pastikan Anda memilih model yang **Hosted by GitHub**.
5. Di **Activity Bar**, pastikan model **OpenAI GPT-4o** muncul dalam daftar.

### -1- Membuat agen

**Agent (Prompt) Builder** memungkinkan Anda membuat dan menyesuaikan agen AI Anda sendiri. Di bagian ini, Anda akan membuat agen baru dan menetapkan model untuk menjalankan percakapan.

![Screenshot antarmuka "Calculator Agent" di AI Toolkit Visual Studio Code. Panel kiri menunjukkan model yang dipilih adalah "OpenAI GPT-4o (via GitHub)." System prompt berbunyi "You are a professor in university teaching math," dan user prompt bertuliskan "Explain to me the Fourier equation in simple terms." Ada opsi untuk menambahkan tools, mengaktifkan MCP Server, dan memilih structured output. Tombol biru “Run” ada di bagian bawah. Panel kanan menampilkan "Get Started with Examples" dengan tiga contoh agen: Web Developer (dengan MCP Server), Second-Grade Simplifier, dan Dream Interpreter, masing-masing dengan deskripsi singkat fungsinya.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.id.png)

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
2. Di bagian **Tools**, pilih **Agent (Prompt) Builder**. Memilih **Agent (Prompt) Builder** akan membuka tab editor baru.
3. Klik tombol **+ New Agent**. Ekstensi akan membuka wizard setup melalui **Command Palette**.
4. Masukkan nama **Calculator Agent** dan tekan **Enter**.
5. Di **Agent (Prompt) Builder**, pada kolom **Model**, pilih model **OpenAI GPT-4o (via GitHub)**.

### -2- Membuat system prompt untuk agen

Setelah agen dibuat, saatnya mendefinisikan kepribadian dan tujuannya. Di bagian ini, Anda akan menggunakan fitur **Generate system prompt** untuk mendeskripsikan perilaku agen—dalam hal ini agen kalkulator—dan membiarkan model menulis system prompt untuk Anda.

![Screenshot antarmuka "Calculator Agent" di AI Toolkit Visual Studio Code dengan jendela modal berjudul "Generate a prompt." Modal menjelaskan bahwa template prompt dapat dibuat dengan membagikan detail dasar dan terdapat kotak teks dengan contoh system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Di bawah kotak teks ada tombol "Close" dan "Generate." Di latar belakang, sebagian konfigurasi agen terlihat, termasuk model yang dipilih "OpenAI GPT-4o (via GitHub)" dan kolom system serta user prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.id.png)

1. Pada bagian **Prompts**, klik tombol **Generate system prompt**. Tombol ini membuka prompt builder yang memanfaatkan AI untuk membuat system prompt agen.
2. Di jendela **Generate a prompt**, masukkan kalimat berikut: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klik tombol **Generate**. Notifikasi akan muncul di pojok kanan bawah yang mengonfirmasi bahwa system prompt sedang dibuat. Setelah selesai, prompt akan muncul di kolom **System prompt** pada **Agent (Prompt) Builder**.
4. Tinjau **System prompt** dan ubah jika perlu.

### -3- Membuat server MCP

Setelah Anda mendefinisikan system prompt agen—yang mengarahkan perilaku dan responsnya—saatnya melengkapi agen dengan kemampuan praktis. Di bagian ini, Anda akan membuat server MCP kalkulator dengan alat untuk melakukan operasi penjumlahan, pengurangan, perkalian, dan pembagian. Server ini memungkinkan agen Anda melakukan operasi matematika secara real-time berdasarkan perintah bahasa alami.

![Screenshot bagian bawah antarmuka Calculator Agent di AI Toolkit Visual Studio Code. Menampilkan menu yang dapat diperluas untuk “Tools” dan “Structure output,” serta dropdown “Choose output format” yang disetel ke “text.” Di sebelah kanan ada tombol “+ MCP Server” untuk menambahkan server Model Context Protocol. Di atas bagian Tools terdapat placeholder ikon gambar.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.id.png)

AI Toolkit dilengkapi dengan template untuk memudahkan pembuatan server MCP Anda sendiri. Kita akan menggunakan template Python untuk membuat server MCP kalkulator.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

1. Di bagian **Tools** pada **Agent (Prompt) Builder**, klik tombol **+ MCP Server**. Ekstensi akan membuka wizard setup melalui **Command Palette**.
2. Pilih **+ Add Server**.
3. Pilih **Create a New MCP Server**.
4. Pilih template **python-weather**.
5. Pilih **Default folder** untuk menyimpan template server MCP.
6. Masukkan nama server berikut: **Calculator**
7. Jendela Visual Studio Code baru akan terbuka. Pilih **Yes, I trust the authors**.
8. Gunakan terminal (**Terminal** > **New Terminal**) untuk membuat virtual environment: `python -m venv .venv`
9. Aktifkan virtual environment melalui terminal:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Instal dependensi melalui terminal: `pip install -e .[dev]`
11. Di tampilan **Explorer** pada **Activity Bar**, buka direktori **src** dan pilih **server.py** untuk membuka file di editor.
12. Ganti kode dalam file **server.py** dengan kode berikut dan simpan:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Menjalankan agen dengan server MCP kalkulator

Sekarang agen Anda sudah memiliki alat, saatnya menggunakannya! Di bagian ini, Anda akan mengirimkan perintah ke agen untuk menguji dan memvalidasi apakah agen menggunakan alat yang tepat dari server MCP kalkulator.

![Screenshot antarmuka Calculator Agent di AI Toolkit Visual Studio Code. Panel kiri, di bawah “Tools,” terdapat server MCP bernama local-server-calculator_server dengan empat alat tersedia: add, subtract, multiply, dan divide. Ada badge yang menunjukkan empat alat aktif. Di bawahnya ada bagian “Structure output” yang terlipat dan tombol biru “Run.” Panel kanan, di bawah “Model Response,” agen memanggil alat multiply dan subtract dengan input {"a": 3, "b": 25} dan {"a": 75, "b": 20} masing-masing. “Tool Response” akhir ditampilkan sebagai 75.0. Tombol “View Code” ada di bagian bawah.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.id.png)

Anda akan menjalankan server MCP kalkulator di mesin pengembangan lokal Anda melalui **Agent Builder** sebagai klien MCP.

1. Tekan `F5` untuk memulai debugging server MCP. **Agent (Prompt) Builder** akan terbuka di tab editor baru. Status server terlihat di terminal.
2. Di kolom **User prompt** pada **Agent (Prompt) Builder**, masukkan perintah berikut: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. Klik tombol **Run** untuk menghasilkan respons agen.
4. Tinjau output agen. Model seharusnya menyimpulkan bahwa Anda membayar **$55**.
5. Berikut rincian yang seharusnya terjadi:
    - Agen memilih alat **multiply** dan **subtract** untuk membantu perhitungan.
    - Nilai `a` dan `b` ditetapkan untuk alat **multiply**.
    - Nilai `a` dan `b` ditetapkan untuk alat **subtract**.
    - Respons dari masing-masing alat ditampilkan di **Tool Response**.
    - Output akhir dari model ditampilkan di **Model Response**.
6. Kirim perintah tambahan untuk menguji agen lebih lanjut. Anda dapat mengubah perintah yang ada di kolom **User prompt** dengan mengklik dan mengganti teksnya.
7. Setelah selesai menguji agen, Anda dapat menghentikan server melalui **terminal** dengan menekan **CTRL/CMD+C** untuk keluar.

## Tugas

Coba tambahkan entri alat tambahan ke file **server.py** Anda (misalnya: mengembalikan akar kuadrat dari sebuah angka). Kirim perintah tambahan yang mengharuskan agen menggunakan alat baru Anda (atau alat yang sudah ada). Pastikan untuk memulai ulang server agar alat baru dimuat.

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini adalah:

- Ekstensi AI Toolkit adalah klien yang hebat yang memungkinkan Anda menggunakan Server MCP dan alat-alatnya.
- Anda dapat menambahkan alat baru ke server MCP, memperluas kemampuan agen untuk memenuhi kebutuhan yang berkembang.
- AI Toolkit menyertakan template (misalnya template server MCP Python) untuk mempermudah pembuatan alat kustom.

## Sumber Daya Tambahan

- [Dokumentasi AI Toolkit](https://aka.ms/AIToolkit/doc)

## Selanjutnya
- Selanjutnya: [Testing & Debugging](../08-testing/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.