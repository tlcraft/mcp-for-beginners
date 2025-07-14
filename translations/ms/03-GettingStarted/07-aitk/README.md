<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:38:23+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ms"
}
-->
# Menggunakan pelayan dari sambungan AI Toolkit untuk Visual Studio Code

Apabila anda membina agen AI, ia bukan sekadar menjana respons pintar; ia juga tentang memberi agen anda keupayaan untuk mengambil tindakan. Di sinilah Model Context Protocol (MCP) memainkan peranan. MCP memudahkan agen mengakses alat dan perkhidmatan luaran dengan cara yang konsisten. Fikirkan ia seperti menyambungkan agen anda ke dalam kotak alat yang *benar-benar* boleh digunakan.

Katakan anda menyambungkan agen kepada pelayan MCP kalkulator anda. Tiba-tiba, agen anda boleh melakukan operasi matematik hanya dengan menerima arahan seperti “Berapakah 47 darab 89?”—tanpa perlu menulis logik secara keras atau membina API tersuai.

## Gambaran Keseluruhan

Pelajaran ini menerangkan cara menyambungkan pelayan MCP kalkulator kepada agen menggunakan sambungan [AI Toolkit](https://aka.ms/AIToolkit) dalam Visual Studio Code, membolehkan agen anda melakukan operasi matematik seperti penambahan, penolakan, pendaraban, dan pembahagian melalui bahasa semula jadi.

AI Toolkit adalah sambungan yang kuat untuk Visual Studio Code yang memudahkan pembangunan agen. Jurutera AI boleh dengan mudah membina aplikasi AI dengan membangunkan dan menguji model AI generatif—secara tempatan atau di awan. Sambungan ini menyokong kebanyakan model generatif utama yang tersedia hari ini.

*Nota*: AI Toolkit kini menyokong Python dan TypeScript.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Menggunakan pelayan MCP melalui AI Toolkit.
- Mengkonfigurasi konfigurasi agen untuk membolehkannya menemui dan menggunakan alat yang disediakan oleh pelayan MCP.
- Menggunakan alat MCP melalui bahasa semula jadi.

## Pendekatan

Berikut adalah cara kita perlu mendekatinya secara umum:

- Cipta agen dan tentukan arahan sistemnya.
- Cipta pelayan MCP dengan alat kalkulator.
- Sambungkan Agent Builder ke pelayan MCP.
- Uji penggunaan alat agen melalui bahasa semula jadi.

Bagus, sekarang kita faham alirannya, mari kita konfigurasikan agen AI untuk memanfaatkan alat luaran melalui MCP, meningkatkan keupayaannya!

## Prasyarat

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit untuk Visual Studio Code](https://aka.ms/AIToolkit)

## Latihan: Menggunakan pelayan

Dalam latihan ini, anda akan membina, menjalankan, dan meningkatkan agen AI dengan alat dari pelayan MCP di dalam Visual Studio Code menggunakan AI Toolkit.

### -0- Langkah awal, tambah model OpenAI GPT-4o ke My Models

Latihan ini menggunakan model **GPT-4o**. Model ini perlu ditambah ke dalam **My Models** sebelum mencipta agen.

![Tangkapan skrin antara muka pemilihan model dalam sambungan AI Toolkit Visual Studio Code. Tajuknya berbunyi "Cari model yang sesuai untuk Penyelesaian AI anda" dengan subjudul menggalakkan pengguna untuk menemui, menguji, dan melancarkan model AI. Di bawah, di bawah “Popular Models,” enam kad model dipaparkan: DeepSeek-R1 (hos GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kecil, Pantas), dan DeepSeek-R1 (hos Ollama). Setiap kad termasuk pilihan untuk “Tambah” model atau “Cuba di Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ms.png)

1. Buka sambungan **AI Toolkit** dari **Activity Bar**.
1. Dalam bahagian **Catalog**, pilih **Models** untuk membuka **Model Catalog**. Memilih **Models** akan membuka **Model Catalog** dalam tab editor baru.
1. Dalam bar carian **Model Catalog**, masukkan **OpenAI GPT-4o**.
1. Klik **+ Add** untuk menambah model ke senarai **My Models** anda. Pastikan anda memilih model yang **Dihoskan oleh GitHub**.
1. Dalam **Activity Bar**, sahkan bahawa model **OpenAI GPT-4o** muncul dalam senarai.

### -1- Cipta agen

**Agent (Prompt) Builder** membolehkan anda mencipta dan menyesuaikan agen AI anda sendiri. Dalam bahagian ini, anda akan mencipta agen baru dan menetapkan model untuk menggerakkan perbualan.

![Tangkapan skrin antara muka pembina "Calculator Agent" dalam sambungan AI Toolkit untuk Visual Studio Code. Pada panel kiri, model yang dipilih ialah "OpenAI GPT-4o (via GitHub)." Arahan sistem berbunyi "Anda adalah seorang profesor di universiti yang mengajar matematik," dan arahan pengguna berkata, "Terangkan kepada saya persamaan Fourier dalam istilah mudah." Pilihan tambahan termasuk butang untuk menambah alat, mengaktifkan MCP Server, dan memilih output berstruktur. Butang biru “Run” berada di bawah. Pada panel kanan, di bawah "Get Started with Examples," tiga agen contoh disenaraikan: Web Developer (dengan MCP Server, Second-Grade Simplifier, dan Dream Interpreter, masing-masing dengan penerangan ringkas fungsi mereka.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ms.png)

1. Buka sambungan **AI Toolkit** dari **Activity Bar**.
1. Dalam bahagian **Tools**, pilih **Agent (Prompt) Builder**. Memilih **Agent (Prompt) Builder** akan membuka **Agent (Prompt) Builder** dalam tab editor baru.
1. Klik butang **+ New Agent**. Sambungan akan melancarkan wizard persediaan melalui **Command Palette**.
1. Masukkan nama **Calculator Agent** dan tekan **Enter**.
1. Dalam **Agent (Prompt) Builder**, untuk medan **Model**, pilih model **OpenAI GPT-4o (via GitHub)**.

### -2- Cipta arahan sistem untuk agen

Dengan agen telah disediakan, tiba masanya untuk menentukan personaliti dan tujuannya. Dalam bahagian ini, anda akan menggunakan ciri **Generate system prompt** untuk menerangkan tingkah laku yang diinginkan agen—dalam kes ini, agen kalkulator—dan membiarkan model menulis arahan sistem untuk anda.

![Tangkapan skrin antara muka "Calculator Agent" dalam AI Toolkit untuk Visual Studio Code dengan tetingkap modal terbuka bertajuk "Generate a prompt." Modal menerangkan bahawa templat arahan boleh dijana dengan berkongsi maklumat asas dan termasuk kotak teks dengan contoh arahan sistem: "Anda adalah pembantu matematik yang membantu dan cekap. Apabila diberikan masalah yang melibatkan aritmetik asas, anda memberi respons dengan keputusan yang betul." Di bawah kotak teks terdapat butang "Close" dan "Generate". Di latar belakang, sebahagian konfigurasi agen kelihatan, termasuk model yang dipilih "OpenAI GPT-4o (via GitHub)" dan medan untuk arahan sistem dan pengguna.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ms.png)

1. Untuk bahagian **Prompts**, klik butang **Generate system prompt**. Butang ini membuka pembina arahan yang menggunakan AI untuk menjana arahan sistem bagi agen.
1. Dalam tetingkap **Generate a prompt**, masukkan: `Anda adalah pembantu matematik yang membantu dan cekap. Apabila diberikan masalah yang melibatkan aritmetik asas, anda memberi respons dengan keputusan yang betul.`
1. Klik butang **Generate**. Pemberitahuan akan muncul di sudut kanan bawah mengesahkan bahawa arahan sistem sedang dijana. Setelah penjanaan selesai, arahan akan muncul dalam medan **System prompt** di **Agent (Prompt) Builder**.
1. Semak **System prompt** dan ubah jika perlu.

### -3- Cipta pelayan MCP

Sekarang anda telah menentukan arahan sistem agen anda—yang membimbing tingkah laku dan responsnya—tiba masanya untuk melengkapkan agen dengan keupayaan praktikal. Dalam bahagian ini, anda akan mencipta pelayan MCP kalkulator dengan alat untuk melaksanakan pengiraan penambahan, penolakan, pendaraban, dan pembahagian. Pelayan ini akan membolehkan agen anda melakukan operasi matematik masa nyata sebagai respons kepada arahan bahasa semula jadi.

![Tangkapan skrin bahagian bawah antara muka Calculator Agent dalam sambungan AI Toolkit untuk Visual Studio Code. Ia menunjukkan menu boleh kembang untuk “Tools” dan “Structure output,” bersama menu lungsur bertajuk “Choose output format” yang diset kepada “text.” Di sebelah kanan, terdapat butang bertanda “+ MCP Server” untuk menambah pelayan Model Context Protocol. Ikon gambar tempat letak ditunjukkan di atas bahagian Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ms.png)

AI Toolkit dilengkapi dengan templat untuk memudahkan penciptaan pelayan MCP anda sendiri. Kita akan menggunakan templat Python untuk mencipta pelayan MCP kalkulator.

*Nota*: AI Toolkit kini menyokong Python dan TypeScript.

1. Dalam bahagian **Tools** di **Agent (Prompt) Builder**, klik butang **+ MCP Server**. Sambungan akan melancarkan wizard persediaan melalui **Command Palette**.
1. Pilih **+ Add Server**.
1. Pilih **Create a New MCP Server**.
1. Pilih **python-weather** sebagai templat.
1. Pilih **Default folder** untuk menyimpan templat pelayan MCP.
1. Masukkan nama berikut untuk pelayan: **Calculator**
1. Tetingkap Visual Studio Code baru akan dibuka. Pilih **Yes, I trust the authors**.
1. Menggunakan terminal (**Terminal** > **New Terminal**), cipta persekitaran maya: `python -m venv .venv`
1. Menggunakan terminal, aktifkan persekitaran maya:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Menggunakan terminal, pasang kebergantungan: `pip install -e .[dev]`
1. Dalam paparan **Explorer** di **Activity Bar**, kembangkan direktori **src** dan pilih **server.py** untuk membuka fail dalam editor.
1. Gantikan kod dalam fail **server.py** dengan yang berikut dan simpan:

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

### -4- Jalankan agen dengan pelayan MCP kalkulator

Sekarang agen anda mempunyai alat, tiba masanya untuk menggunakannya! Dalam bahagian ini, anda akan menghantar arahan kepada agen untuk menguji dan mengesahkan sama ada agen menggunakan alat yang sesuai dari pelayan MCP kalkulator.

![Tangkapan skrin antara muka Calculator Agent dalam sambungan AI Toolkit untuk Visual Studio Code. Pada panel kiri, di bawah “Tools,” pelayan MCP bernama local-server-calculator_server ditambah, menunjukkan empat alat tersedia: add, subtract, multiply, dan divide. Lencana menunjukkan empat alat aktif. Di bawahnya adalah bahagian “Structure output” yang dilipat dan butang biru “Run.” Pada panel kanan, di bawah “Model Response,” agen menggunakan alat multiply dan subtract dengan input {"a": 3, "b": 25} dan {"a": 75, "b": 20} masing-masing. “Tool Response” akhir dipaparkan sebagai 75.0. Butang “View Code” muncul di bawah.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ms.png)

Anda akan menjalankan pelayan MCP kalkulator pada mesin pembangunan tempatan anda melalui **Agent Builder** sebagai klien MCP.

1. Tekan `F5` untuk mula debug pelayan MCP. **Agent (Prompt) Builder** akan dibuka dalam tab editor baru. Status pelayan boleh dilihat di terminal.
1. Dalam medan **User prompt** di **Agent (Prompt) Builder**, masukkan arahan berikut: `Saya membeli 3 barang berharga $25 setiap satu, dan kemudian menggunakan diskaun $20. Berapa jumlah yang saya bayar?`
1. Klik butang **Run** untuk menjana respons agen.
1. Semak output agen. Model sepatutnya membuat kesimpulan bahawa anda membayar **$55**.
1. Berikut adalah pecahan apa yang sepatutnya berlaku:
    - Agen memilih alat **multiply** dan **subtract** untuk membantu pengiraan.
    - Nilai `a` dan `b` yang sesuai diberikan untuk alat **multiply**.
    - Nilai `a` dan `b` yang sesuai diberikan untuk alat **subtract**.
    - Respons dari setiap alat diberikan dalam **Tool Response** masing-masing.
    - Output akhir dari model diberikan dalam **Model Response** akhir.
1. Hantar arahan tambahan untuk menguji agen dengan lebih lanjut. Anda boleh mengubah arahan sedia ada dalam medan **User prompt** dengan mengklik ke dalam medan dan menggantikan arahan yang ada.
1. Setelah selesai menguji agen, anda boleh menghentikan pelayan melalui **terminal** dengan menekan **CTRL/CMD+C** untuk keluar.

## Tugasan

Cuba tambah entri alat tambahan ke dalam fail **server.py** anda (contoh: pulangkan punca kuasa dua bagi nombor). Hantar arahan tambahan yang memerlukan agen menggunakan alat baru anda (atau alat sedia ada). Pastikan anda mulakan semula pelayan untuk memuatkan alat yang baru ditambah.

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Perkara Penting

Perkara penting dari bab ini adalah seperti berikut:

- Sambungan AI Toolkit adalah klien yang hebat yang membolehkan anda menggunakan Pelayan MCP dan alat-alatnya.
- Anda boleh menambah alat baru ke pelayan MCP, memperluaskan keupayaan agen untuk memenuhi keperluan yang berkembang.
- AI Toolkit termasuk templat (contohnya, templat pelayan MCP Python) untuk memudahkan penciptaan alat tersuai.

## Sumber Tambahan

- [Dokumentasi AI Toolkit](https://aka.ms/AIToolkit/doc)

## Apa Seterusnya
- Seterusnya: [Ujian & Debugging](../08-testing/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.