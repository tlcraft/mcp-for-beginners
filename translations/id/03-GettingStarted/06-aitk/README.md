<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:45:26+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "id"
}
-->
# Menggunakan server dari ekstensi AI Toolkit untuk Visual Studio Code

Saat Anda membangun agen AI, bukan hanya tentang menghasilkan respons yang cerdas; ini juga tentang memberi agen Anda kemampuan untuk mengambil tindakan. Di sinilah Model Context Protocol (MCP) berperan. MCP memudahkan agen mengakses alat dan layanan eksternal dengan cara yang konsisten. Anggap saja seperti menghubungkan agen Anda ke kotak alat yang benar-benar bisa digunakan.

Misalnya, Anda menghubungkan agen ke server MCP kalkulator Anda. Tiba-tiba, agen Anda bisa melakukan operasi matematika hanya dengan menerima perintah seperti “Berapa 47 dikali 89?”—tanpa perlu menulis logika khusus atau membuat API kustom.

## Ikhtisar

Pelajaran ini membahas cara menghubungkan server MCP kalkulator ke agen dengan ekstensi [AI Toolkit](https://aka.ms/AIToolkit) di Visual Studio Code, memungkinkan agen Anda melakukan operasi matematika seperti penjumlahan, pengurangan, perkalian, dan pembagian melalui bahasa alami.

AI Toolkit adalah ekstensi yang kuat untuk Visual Studio Code yang mempermudah pengembangan agen. Insinyur AI dapat dengan mudah membangun aplikasi AI dengan mengembangkan dan menguji model AI generatif—secara lokal atau di cloud. Ekstensi ini mendukung sebagian besar model generatif utama yang tersedia saat ini.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

## Tujuan Pembelajaran

Di akhir pelajaran ini, Anda akan dapat:

- Menggunakan server MCP melalui AI Toolkit.
- Mengonfigurasi pengaturan agen agar dapat menemukan dan memanfaatkan alat yang disediakan oleh server MCP.
- Menggunakan alat MCP melalui bahasa alami.

## Pendekatan

Berikut cara kita harus mendekati ini secara garis besar:

- Buat agen dan definisikan prompt sistemnya.
- Buat server MCP dengan alat kalkulator.
- Hubungkan Agent Builder ke server MCP.
- Uji pemanggilan alat agen melalui bahasa alami.

Bagus, sekarang setelah kita memahami alurnya, mari kita konfigurasikan agen AI untuk memanfaatkan alat eksternal melalui MCP, meningkatkan kemampuannya!

## Prasyarat

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit untuk Visual Studio Code](https://aka.ms/AIToolkit)

## Latihan: Menggunakan server

Dalam latihan ini, Anda akan membangun, menjalankan, dan meningkatkan agen AI dengan alat dari server MCP di dalam Visual Studio Code menggunakan AI Toolkit.

### -0- Langkah awal, tambahkan model OpenAI GPT-4o ke My Models

Latihan ini menggunakan model **GPT-4o**. Model ini harus ditambahkan ke **My Models** sebelum membuat agen.

![Screenshot dari antarmuka pemilihan model di ekstensi AI Toolkit Visual Studio Code. Judulnya "Find the right model for your AI Solution" dengan subjudul yang mengajak pengguna untuk menemukan, menguji, dan menerapkan model AI. Di bawah “Popular Models,” ada enam kartu model: DeepSeek-R1 (hosted di GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kecil, Cepat), dan DeepSeek-R1 (hosted di Ollama). Setiap kartu memiliki opsi “Add” atau “Try in Playground.”](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.id.png)

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
2. Di bagian **Catalog**, pilih **Models** untuk membuka **Model Catalog**. Memilih **Models** akan membuka **Model Catalog** di tab editor baru.
3. Di bilah pencarian **Model Catalog**, ketik **OpenAI GPT-4o**.
4. Klik **+ Add** untuk menambahkan model ke daftar **My Models** Anda. Pastikan Anda memilih model yang **Hosted by GitHub**.
5. Di **Activity Bar**, pastikan model **OpenAI GPT-4o** muncul dalam daftar.

### -1- Buat agen

**Agent (Prompt) Builder** memungkinkan Anda membuat dan menyesuaikan agen AI Anda sendiri. Di bagian ini, Anda akan membuat agen baru dan menetapkan model untuk menggerakkan percakapan.

![Screenshot antarmuka "Calculator Agent" di ekstensi AI Toolkit Visual Studio Code. Panel kiri menunjukkan model yang dipilih "OpenAI GPT-4o (via GitHub)." Prompt sistem bertuliskan "You are a professor in university teaching math," dan prompt pengguna "Explain to me the Fourier equation in simple terms." Ada tombol untuk menambah alat, mengaktifkan MCP Server, dan memilih output terstruktur. Tombol biru “Run” di bagian bawah. Panel kanan berisi “Get Started with Examples” dengan tiga agen contoh: Web Developer (dengan MCP Server, Second-Grade Simplifier, dan Dream Interpreter, masing-masing dengan deskripsi singkat fungsinya).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.id.png)

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
2. Di bagian **Tools**, pilih **Agent (Prompt) Builder**. Memilih **Agent (Prompt) Builder** akan membuka tab editor baru.
3. Klik tombol **+ New Agent**. Ekstensi akan memulai wizard pengaturan melalui **Command Palette**.
4. Masukkan nama **Calculator Agent** dan tekan **Enter**.
5. Di **Agent (Prompt) Builder**, pada bidang **Model**, pilih model **OpenAI GPT-4o (via GitHub)**.

### -2- Buat prompt sistem untuk agen

Setelah agen dibuat, saatnya menentukan kepribadian dan tujuannya. Di bagian ini, Anda akan menggunakan fitur **Generate system prompt** untuk mendeskripsikan perilaku agen—dalam hal ini agen kalkulator—dan meminta model menulis prompt sistem untuk Anda.

![Screenshot antarmuka "Calculator Agent" di AI Toolkit Visual Studio Code dengan jendela modal terbuka berjudul "Generate a prompt." Modal menjelaskan bahwa template prompt dapat dibuat dengan membagikan detail dasar dan ada kotak teks dengan contoh prompt sistem: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Di bawah kotak teks ada tombol "Close" dan "Generate." Di latar belakang, bagian konfigurasi agen terlihat, termasuk model "OpenAI GPT-4o (via GitHub)" dan bidang prompt sistem serta pengguna.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.id.png)

1. Pada bagian **Prompts**, klik tombol **Generate system prompt**. Tombol ini membuka pembuat prompt yang memanfaatkan AI untuk menghasilkan prompt sistem untuk agen.
2. Di jendela **Generate a prompt**, masukkan: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klik tombol **Generate**. Sebuah notifikasi akan muncul di pojok kanan bawah mengonfirmasi bahwa prompt sistem sedang dibuat. Setelah selesai, prompt akan muncul di bidang **System prompt** di **Agent (Prompt) Builder**.
4. Tinjau **System prompt** dan ubah jika perlu.

### -3- Buat server MCP

Setelah Anda menentukan prompt sistem agen—yang mengarahkan perilaku dan responsnya—saatnya melengkapi agen dengan kemampuan praktis. Di bagian ini, Anda akan membuat server MCP kalkulator dengan alat untuk melakukan operasi penjumlahan, pengurangan, perkalian, dan pembagian. Server ini akan memungkinkan agen Anda melakukan operasi matematika secara real-time sebagai respons terhadap perintah bahasa alami.

![Screenshot bagian bawah antarmuka Calculator Agent di ekstensi AI Toolkit Visual Studio Code. Menampilkan menu yang dapat diperluas untuk “Tools” dan “Structure output,” dengan menu dropdown “Choose output format” yang disetel ke “text.” Di sebelah kanan, ada tombol “+ MCP Server” untuk menambah server Model Context Protocol. Ikon gambar placeholder di atas bagian Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.id.png)

AI Toolkit dilengkapi dengan template untuk memudahkan pembuatan server MCP Anda sendiri. Kita akan menggunakan template Python untuk membuat server MCP kalkulator.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

1. Di bagian **Tools** pada **Agent (Prompt) Builder**, klik tombol **+ MCP Server**. Ekstensi akan memulai wizard pengaturan melalui **Command Palette**.
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
12. Ganti kode dalam file **server.py** dengan yang berikut dan simpan:

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

### -4- Jalankan agen dengan server MCP kalkulator

Sekarang agen Anda sudah memiliki alat, saatnya menggunakannya! Di bagian ini, Anda akan mengirimkan prompt ke agen untuk menguji dan memvalidasi apakah agen menggunakan alat yang tepat dari server MCP kalkulator.

![Screenshot antarmuka Calculator Agent di ekstensi AI Toolkit Visual Studio Code. Panel kiri, di bawah “Tools,” terdapat server MCP bernama local-server-calculator_server dengan empat alat tersedia: add, subtract, multiply, dan divide. Ada tanda menunjukkan empat alat aktif. Di bawahnya ada bagian “Structure output” yang terlipat dan tombol biru “Run.” Panel kanan, di bawah “Model Response,” agen memanggil alat multiply dan subtract dengan input {"a": 3, "b": 25} dan {"a": 75, "b": 20} masing-masing. “Tool Response” akhir menunjukkan 75.0. Tombol “View Code” muncul di bagian bawah.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.id.png)

Anda akan menjalankan server MCP kalkulator di mesin pengembangan lokal melalui **Agent Builder** sebagai klien MCP.

1. Tekan `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Saya membeli 3 barang seharga $25 masing-masing, lalu menggunakan diskon $20. Berapa total yang saya bayar?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` nilai diberikan untuk alat **subtract**.
    - Respons dari setiap alat akan ditampilkan di bagian **Tool Response** masing-masing.
    - Output akhir dari model akan ditampilkan di bagian **Model Response**.
2. Kirimkan prompt tambahan untuk menguji agen lebih lanjut. Anda dapat mengubah prompt yang ada di bidang **User prompt** dengan mengklik dan mengganti isinya.
3. Setelah selesai menguji agen, Anda dapat menghentikan server melalui **terminal** dengan menekan **CTRL/CMD+C** untuk keluar.

## Tugas

Coba tambahkan entri alat tambahan ke file **server.py** Anda (misalnya: mengembalikan akar kuadrat dari sebuah angka). Kirimkan prompt tambahan yang memerlukan agen menggunakan alat baru Anda (atau alat yang sudah ada). Pastikan untuk memulai ulang server agar alat yang baru ditambahkan dapat dimuat.

## Solusi

[Solusi](./solution/README.md)

## Hal Penting yang Perlu Diingat

Beberapa hal penting dari bab ini adalah:

- Ekstensi AI Toolkit adalah klien yang hebat yang memungkinkan Anda menggunakan Server MCP dan alat-alatnya.
- Anda dapat menambahkan alat baru ke server MCP, memperluas kemampuan agen agar sesuai dengan kebutuhan yang berkembang.
- AI Toolkit menyertakan template (misalnya, template server MCP Python) untuk mempermudah pembuatan alat kustom.

## Sumber Daya Tambahan

- [Dokumentasi AI Toolkit](https://aka.ms/AIToolkit/doc)

## Selanjutnya

Selanjutnya: [Pelajaran 4 Implementasi Praktis](/04-PracticalImplementation/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.