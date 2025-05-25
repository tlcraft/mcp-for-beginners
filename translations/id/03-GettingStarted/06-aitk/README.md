<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:26:37+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "id"
}
-->
# Menggunakan server dari ekstensi AI Toolkit untuk Visual Studio Code

Saat Anda membangun agen AI, itu bukan hanya tentang menghasilkan respons yang cerdas; tetapi juga tentang memberikan kemampuan kepada agen Anda untuk mengambil tindakan. Di sinilah Model Context Protocol (MCP) berperan. MCP memudahkan agen untuk mengakses alat dan layanan eksternal dengan cara yang konsisten. Anggap saja seperti menyambungkan agen Anda ke kotak alat yang benar-benar bisa digunakan.

Misalnya Anda menghubungkan agen ke server MCP kalkulator Anda. Tiba-tiba, agen Anda dapat melakukan operasi matematika hanya dengan menerima prompt seperti "Berapa 47 kali 89?"—tanpa perlu menghardcode logika atau membangun API khusus.

## Gambaran Umum

Pelajaran ini mencakup cara menghubungkan server MCP kalkulator ke agen dengan ekstensi [AI Toolkit](https://aka.ms/AIToolkit) di Visual Studio Code, memungkinkan agen Anda melakukan operasi matematika seperti penjumlahan, pengurangan, perkalian, dan pembagian melalui bahasa alami.

AI Toolkit adalah ekstensi yang kuat untuk Visual Studio Code yang memudahkan pengembangan agen. Insinyur AI dapat dengan mudah membangun aplikasi AI dengan mengembangkan dan menguji model AI generatif—secara lokal atau di cloud. Ekstensi ini mendukung sebagian besar model generatif utama yang tersedia saat ini.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Menggunakan server MCP melalui AI Toolkit.
- Mengkonfigurasi pengaturan agen agar dapat menemukan dan memanfaatkan alat yang disediakan oleh server MCP.
- Memanfaatkan alat MCP melalui bahasa alami.

## Pendekatan

Berikut cara kita harus mendekati ini secara keseluruhan:

- Buat agen dan tentukan sistem prompt-nya.
- Buat server MCP dengan alat kalkulator.
- Hubungkan Agent Builder ke server MCP.
- Uji pemanggilan alat agen melalui bahasa alami.

Bagus, sekarang kita memahami alurnya, mari kita konfigurasikan agen AI untuk memanfaatkan alat eksternal melalui MCP, meningkatkan kemampuannya!

## Prasyarat

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit untuk Visual Studio Code](https://aka.ms/AIToolkit)

## Latihan: Menggunakan server

Dalam latihan ini, Anda akan membangun, menjalankan, dan meningkatkan agen AI dengan alat dari server MCP di dalam Visual Studio Code menggunakan AI Toolkit.

### -0- Langkah awal, tambahkan model OpenAI GPT-4o ke My Models

Latihan ini menggunakan model **GPT-4o**. Model tersebut harus ditambahkan ke **My Models** sebelum membuat agen.

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
1. Di bagian **Catalog**, pilih **Models** untuk membuka **Model Catalog**. Memilih **Models** membuka **Model Catalog** di tab editor baru.
1. Di bilah pencarian **Model Catalog**, masukkan **OpenAI GPT-4o**.
1. Klik **+ Add** untuk menambahkan model ke daftar **My Models** Anda. Pastikan Anda telah memilih model yang **Hosted by GitHub**.
1. Di **Activity Bar**, konfirmasikan bahwa model **OpenAI GPT-4o** muncul dalam daftar.

### -1- Buat agen

**Agent (Prompt) Builder** memungkinkan Anda membuat dan menyesuaikan agen bertenaga AI Anda sendiri. Di bagian ini, Anda akan membuat agen baru dan menetapkan model untuk menggerakkan percakapan.

1. Buka ekstensi **AI Toolkit** dari **Activity Bar**.
1. Di bagian **Tools**, pilih **Agent (Prompt) Builder**. Memilih **Agent (Prompt) Builder** membuka **Agent (Prompt) Builder** di tab editor baru.
1. Klik tombol **+ New Builder**. Ekstensi akan meluncurkan wizard pengaturan melalui **Command Palette**.
1. Masukkan nama **Calculator Agent** dan tekan **Enter**.
1. Di **Agent (Prompt) Builder**, untuk bidang **Model**, pilih model **OpenAI GPT-4o (via GitHub)**.

### -2- Buat sistem prompt untuk agen

Dengan kerangka agen sudah dibuat, saatnya mendefinisikan kepribadian dan tujuannya. Di bagian ini, Anda akan menggunakan fitur **Generate system prompt** untuk mendeskripsikan perilaku yang diinginkan dari agen—dalam hal ini, agen kalkulator—dan membiarkan model menulis sistem prompt untuk Anda.

1. Untuk bagian **Prompts**, klik tombol **Generate system prompt**. Tombol ini membuka pembuat prompt yang memanfaatkan AI untuk menghasilkan sistem prompt untuk agen.
1. Di jendela **Generate a prompt**, masukkan berikut ini: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik tombol **Generate**. Sebuah notifikasi akan muncul di sudut kanan bawah mengonfirmasi bahwa sistem prompt sedang dibuat. Setelah pembuatan prompt selesai, prompt akan muncul di bidang **System prompt** dari **Agent (Prompt) Builder**.
1. Tinjau **System prompt** dan modifikasi jika perlu.

### -3- Buat server MCP

Sekarang setelah Anda mendefinisikan sistem prompt agen Anda—memandu perilaku dan responsnya—saatnya untuk melengkapi agen dengan kemampuan praktis. Di bagian ini, Anda akan membuat server MCP kalkulator dengan alat untuk melakukan perhitungan penjumlahan, pengurangan, perkalian, dan pembagian. Server ini akan memungkinkan agen Anda melakukan operasi matematika real-time sebagai respons terhadap prompt bahasa alami.

AI Toolkit dilengkapi dengan template untuk memudahkan pembuatan server MCP Anda sendiri. Kami akan menggunakan template Python untuk membuat server MCP kalkulator.

*Catatan*: AI Toolkit saat ini mendukung Python dan TypeScript.

1. Di bagian **Tools** dari **Agent (Prompt) Builder**, klik tombol **+ MCP Server**. Ekstensi akan meluncurkan wizard pengaturan melalui **Command Palette**.
1. Pilih **+ Add Server**.
1. Pilih **Create a New MCP Server**.
1. Pilih **python-weather** sebagai template.
1. Pilih **Default folder** untuk menyimpan template server MCP.
1. Masukkan nama berikut untuk server: **Calculator**
1. Jendela Visual Studio Code baru akan terbuka. Pilih **Yes, I trust the authors**.
1. Menggunakan terminal (**Terminal** > **New Terminal**), buat lingkungan virtual: `python -m venv .venv`
1. Menggunakan terminal, aktifkan lingkungan virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Menggunakan terminal, instal dependensi: `pip install -e .[dev]`
1. Di tampilan **Explorer** dari **Activity Bar**, perluas direktori **src** dan pilih **server.py** untuk membuka file di editor.
1. Ganti kode dalam file **server.py** dengan berikut ini dan simpan:

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

Sekarang agen Anda memiliki alat, saatnya menggunakannya! Di bagian ini, Anda akan mengirimkan prompt ke agen untuk menguji dan memvalidasi apakah agen memanfaatkan alat yang tepat dari server MCP kalkulator.

Anda akan menjalankan server MCP kalkulator di mesin pengembangan lokal Anda melalui **Agent Builder** sebagai klien MCP.

1. Tekan `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Saya membeli 3 item dengan harga $25 masing-masing, lalu menggunakan diskon $20. Berapa yang saya bayar?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` nilai-nilai ditugaskan untuk alat **subtract**.
    - Respons dari setiap alat diberikan dalam **Tool Response** masing-masing.
    - Output akhir dari model diberikan dalam **Model Response** akhir.
1. Kirimkan prompt tambahan untuk menguji agen lebih lanjut. Anda dapat memodifikasi prompt yang ada di bidang **User prompt** dengan mengklik ke dalam bidang dan mengganti prompt yang ada.
1. Setelah Anda selesai menguji agen, Anda dapat menghentikan server melalui **terminal** dengan memasukkan **CTRL/CMD+C** untuk keluar.

## Tugas

Cobalah menambahkan entri alat tambahan ke file **server.py** Anda (misalnya: mengembalikan akar kuadrat dari sebuah angka). Kirimkan prompt tambahan yang memerlukan agen untuk memanfaatkan alat baru Anda (atau alat yang ada). Pastikan untuk memulai ulang server untuk memuat alat yang baru ditambahkan.

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini adalah sebagai berikut:

- Ekstensi AI Toolkit adalah klien yang hebat yang memungkinkan Anda menggunakan Server MCP dan alat-alatnya.
- Anda dapat menambahkan alat baru ke server MCP, memperluas kemampuan agen untuk memenuhi kebutuhan yang berkembang.
- AI Toolkit menyertakan template (misalnya, template server MCP Python) untuk menyederhanakan pembuatan alat khusus.

## Sumber Daya Tambahan

- [Dokumentasi AI Toolkit](https://aka.ms/AIToolkit/doc)

## Selanjutnya

Berikutnya: [Pelajaran 4 Implementasi Praktis](/04-PracticalImplementation/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi yang penting, disarankan untuk menggunakan jasa penerjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.