<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:24:45+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "id"
}
-->
# Menggunakan server dari ekstensi AI Toolkit untuk Visual Studio Code

Saat Anda membangun agen AI, bukan hanya soal menghasilkan respons cerdas; tetapi juga memberikan kemampuan kepada agen Anda untuk mengambil tindakan. Di sinilah Model Context Protocol (MCP) berperan. MCP memudahkan agen untuk mengakses alat dan layanan eksternal secara konsisten. Bayangkan seperti menghubungkan agen Anda ke kotak peralatan yang benar-benar bisa digunakan.

Misalnya, Anda menghubungkan agen ke server MCP kalkulator Anda. Tiba-tiba, agen Anda bisa melakukan operasi matematika hanya dengan menerima perintah seperti “Berapa 47 kali 89?”—tanpa perlu menulis logika khusus atau membuat API kustom.

## Ikhtisar

Pelajaran ini membahas cara menghubungkan server MCP kalkulator ke agen dengan ekstensi [AI Toolkit](https://aka.ms/AIToolkit) di Visual Studio Code, memungkinkan agen Anda melakukan operasi matematika seperti penjumlahan, pengurangan, perkalian, dan pembagian melalui bahasa alami.

AI Toolkit adalah ekstensi kuat untuk Visual Studio Code yang mempermudah pengembangan agen. AI Engineer dapat dengan mudah membangun aplikasi AI dengan mengembangkan dan menguji model AI generatif—baik secara lokal maupun di cloud. Ekstensi ini mendukung sebagian besar model generatif utama yang tersedia saat ini.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Menggunakan server MCP melalui AI Toolkit.
- Mengonfigurasi konfigurasi agen agar dapat menemukan dan memanfaatkan alat yang disediakan oleh server MCP.
- Menggunakan alat MCP melalui bahasa alami.

## Pendekatan

Berikut cara pendekatan yang perlu kita lakukan secara garis besar:

- Membuat agen dan mendefinisikan system prompt-nya.
- Membuat server MCP dengan alat kalkulator.
- Menghubungkan Agent Builder ke server MCP.
- Menguji pemanggilan alat agen melalui bahasa alami.

Bagus, sekarang setelah kita memahami alurnya, mari konfigurasikan agen AI untuk memanfaatkan alat eksternal melalui MCP, meningkatkan kemampuannya!

## Prasyarat

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit untuk Visual Studio Code](https://aka.ms/AIToolkit)

## Latihan: Menggunakan server

Dalam latihan ini, Anda akan membangun, menjalankan, dan meningkatkan agen AI dengan alat dari server MCP di dalam Visual Studio Code menggunakan AI Toolkit.

### -0- Langkah awal, tambahkan model OpenAI GPT-4o ke My Models

Latihan ini menggunakan model **GPT-4o**. Model harus ditambahkan ke **My Models** sebelum membuat agen.

![Screenshot dari antarmuka pemilihan model di ekstensi AI Toolkit Visual Studio Code. Judulnya “Find the right model for your AI Solution” dengan subjudul yang mendorong pengguna untuk menemukan, menguji, dan menerapkan model AI. Di bawahnya, pada bagian “Popular Models,” terdapat enam kartu model: DeepSeek-R1 (dihosting GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kecil, Cepat), dan DeepSeek-R1 (dihosting Ollama). Setiap kartu menyertakan opsi “Add” model atau “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.id.png)

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
1. Di bagian **Catalog**, pilih **Models** untuk membuka **Model Catalog**. Memilih **Models** akan membuka **Model Catalog** di tab editor baru.
1. Di bar pencarian **Model Catalog**, ketik **OpenAI GPT-4o**.
1. Klik **+ Add** untuk menambahkan model ke daftar **My Models** Anda. Pastikan Anda memilih model yang **Hosted by GitHub**.
1. Di **Activity Bar**, pastikan model **OpenAI GPT-4o** muncul di daftar.

### -1- Membuat agen

**Agent (Prompt) Builder** memungkinkan Anda membuat dan menyesuaikan agen AI Anda sendiri. Pada bagian ini, Anda akan membuat agen baru dan menetapkan model untuk menjalankan percakapan.

![Screenshot antarmuka "Calculator Agent" builder di ekstensi AI Toolkit untuk Visual Studio Code. Panel kiri menunjukkan model yang dipilih "OpenAI GPT-4o (via GitHub)." System prompt bertuliskan "You are a professor in university teaching math," dan user prompt "Explain to me the Fourier equation in simple terms." Ada opsi untuk menambahkan alat, mengaktifkan MCP Server, dan memilih output terstruktur. Tombol biru “Run” di bagian bawah. Panel kanan menampilkan “Get Started with Examples,” dengan tiga agen contoh: Web Developer (dengan MCP Server, Second-Grade Simplifier, dan Dream Interpreter, masing-masing dengan deskripsi singkat fungsi mereka).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.id.png)

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
1. Di bagian **Tools**, pilih **Agent (Prompt) Builder**. Memilih ini akan membuka **Agent (Prompt) Builder** di tab editor baru.
1. Klik tombol **+ New Agent**. Ekstensi akan memulai wizard setup melalui **Command Palette**.
1. Masukkan nama **Calculator Agent** dan tekan **Enter**.
1. Di **Agent (Prompt) Builder**, pada kolom **Model**, pilih model **OpenAI GPT-4o (via GitHub)**.

### -2- Membuat system prompt untuk agen

Setelah agen dibuat, saatnya menentukan kepribadian dan tujuannya. Pada bagian ini, Anda akan menggunakan fitur **Generate system prompt** untuk mendeskripsikan perilaku agen—dalam hal ini agen kalkulator—dan model akan menulis system prompt untuk Anda.

![Screenshot antarmuka "Calculator Agent" di AI Toolkit untuk Visual Studio Code dengan jendela modal berjudul "Generate a prompt." Modal menjelaskan bahwa template prompt dapat dibuat dengan membagikan detail dasar dan terdapat kotak teks dengan contoh system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Di bawah kotak ada tombol "Close" dan "Generate." Di latar belakang terlihat sebagian konfigurasi agen, termasuk model yang dipilih "OpenAI GPT-4o (via GitHub)" dan kolom untuk system dan user prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.id.png)

1. Pada bagian **Prompts**, klik tombol **Generate system prompt**. Tombol ini membuka prompt builder yang menggunakan AI untuk membuat system prompt agen.
1. Di jendela **Generate a prompt**, masukkan: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik tombol **Generate**. Notifikasi akan muncul di kanan bawah yang mengonfirmasi bahwa system prompt sedang dibuat. Setelah selesai, prompt akan muncul di kolom **System prompt** pada **Agent (Prompt) Builder**.
1. Tinjau **System prompt** dan ubah jika diperlukan.

### -3- Membuat server MCP

Setelah Anda menentukan system prompt agen—yang mengarahkan perilaku dan responsnya—saatnya melengkapi agen dengan kemampuan praktis. Pada bagian ini, Anda akan membuat server MCP kalkulator dengan alat untuk melakukan penjumlahan, pengurangan, perkalian, dan pembagian. Server ini memungkinkan agen Anda melakukan operasi matematika secara real-time berdasarkan perintah bahasa alami.

!["Screenshot bagian bawah antarmuka Calculator Agent di ekstensi AI Toolkit Visual Studio Code. Menampilkan menu yang bisa diperluas untuk “Tools” dan “Structure output,” serta dropdown “Choose output format” yang disetel ke “text.” Di sebelah kanan ada tombol “+ MCP Server” untuk menambahkan server Model Context Protocol. Ada ikon gambar placeholder di atas bagian Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.id.png)

AI Toolkit dilengkapi dengan template yang memudahkan pembuatan server MCP Anda sendiri. Kita akan menggunakan template Python untuk membuat server MCP kalkulator.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

1. Di bagian **Tools** pada **Agent (Prompt) Builder**, klik tombol **+ MCP Server**. Ekstensi akan membuka wizard setup melalui **Command Palette**.
1. Pilih **+ Add Server**.
1. Pilih **Create a New MCP Server**.
1. Pilih template **python-weather**.
1. Pilih **Default folder** untuk menyimpan template server MCP.
1. Masukkan nama server berikut: **Calculator**
1. Jendela Visual Studio Code baru akan terbuka. Pilih **Yes, I trust the authors**.
1. Gunakan terminal (**Terminal** > **New Terminal**) untuk membuat virtual environment: `python -m venv .venv`
1. Aktifkan virtual environment melalui terminal:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Instal dependensi melalui terminal: `pip install -e .[dev]`
1. Di tampilan **Explorer** pada **Activity Bar**, buka direktori **src** dan pilih **server.py** untuk membuka file di editor.
1. Ganti kode dalam file **server.py** dengan yang berikut dan simpan:

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

Sekarang agen Anda sudah memiliki alat, saatnya menggunakannya! Pada bagian ini, Anda akan mengirim perintah ke agen untuk menguji dan memvalidasi apakah agen menggunakan alat yang tepat dari server MCP kalkulator.

![Screenshot antarmuka Calculator Agent di AI Toolkit Visual Studio Code. Panel kiri, di bawah “Tools,” terdapat server MCP bernama local-server-calculator_server dengan empat alat tersedia: add, subtract, multiply, dan divide. Ada tanda menunjukkan empat alat aktif. Di bawahnya ada bagian “Structure output” yang diringkas dan tombol biru “Run.” Panel kanan, di bawah “Model Response,” agen memanggil alat multiply dan subtract dengan input {"a": 3, "b": 25} dan {"a": 75, "b": 20} masing-masing. “Tool Response” akhir ditampilkan sebagai 75.0. Tombol “View Code” muncul di bagian bawah.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.id.png)

Anda akan menjalankan server MCP kalkulator di mesin pengembangan lokal melalui **Agent Builder** sebagai klien MCP.

1. Tekan `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Saya membeli 3 barang dengan harga $25 masing-masing, lalu menggunakan diskon $20. Berapa yang saya bayar?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` nilai-nilai tersebut diberikan untuk alat **subtract**.
    - Respons dari masing-masing alat akan muncul di bagian **Tool Response**.
    - Output akhir dari model akan muncul di bagian **Model Response**.
1. Kirim perintah tambahan untuk menguji agen lebih lanjut. Anda bisa mengubah perintah yang ada di kolom **User prompt** dengan mengklik dan mengganti isinya.
1. Setelah selesai menguji agen, Anda bisa menghentikan server melalui **terminal** dengan menekan **CTRL/CMD+C** untuk keluar.

## Tugas

Coba tambahkan entri alat tambahan ke file **server.py** Anda (misalnya: mengembalikan akar kuadrat dari sebuah angka). Kirim perintah tambahan yang mengharuskan agen menggunakan alat baru Anda (atau alat yang sudah ada). Pastikan untuk me-restart server agar alat baru dimuat.

## Solusi

[Solution](./solution/README.md)

## Poin Penting

Hal penting yang bisa diambil dari bab ini adalah:

- Ekstensi AI Toolkit adalah klien yang hebat untuk menggunakan Server MCP dan alat-alatnya.
- Anda dapat menambahkan alat baru ke server MCP, memperluas kemampuan agen agar memenuhi kebutuhan yang berkembang.
- AI Toolkit menyertakan template (misalnya template server MCP Python) untuk mempermudah pembuatan alat kustom.

## Sumber Tambahan

- [Dokumentasi AI Toolkit](https://aka.ms/AIToolkit/doc)

## Selanjutnya
- Selanjutnya: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi yang penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.