<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:26:59+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ms"
}
-->
# Menggunakan server dari sambungan AI Toolkit untuk Visual Studio Code

Apabila anda sedang membina agen AI, ia bukan sahaja tentang menjana respons pintar; ia juga tentang memberikan keupayaan kepada agen anda untuk mengambil tindakan. Di sinilah Protokol Konteks Model (MCP) berperanan. MCP memudahkan agen untuk mengakses alat dan perkhidmatan luaran dengan cara yang konsisten. Fikirkan ia seperti menyambungkan agen anda kepada kotak alat yang boleh *benar-benar* digunakan.

Katakan anda menghubungkan agen anda kepada server MCP kalkulator anda. Tiba-tiba, agen anda boleh melakukan operasi matematik hanya dengan menerima arahan seperti "Berapakah 47 kali 89?"—tiada keperluan untuk kod keras atau membina API tersuai.

## Gambaran Keseluruhan

Pelajaran ini meliputi cara untuk menyambungkan server MCP kalkulator kepada agen dengan sambungan [AI Toolkit](https://aka.ms/AIToolkit) dalam Visual Studio Code, membolehkan agen anda melakukan operasi matematik seperti penambahan, pengurangan, pendaraban, dan pembahagian melalui bahasa semula jadi.

AI Toolkit ialah sambungan yang kuat untuk Visual Studio Code yang memudahkan pembangunan agen. Jurutera AI boleh dengan mudah membina aplikasi AI dengan membangunkan dan menguji model AI generatif—secara tempatan atau di awan. Sambungan ini menyokong kebanyakan model generatif utama yang tersedia hari ini.

*Nota*: AI Toolkit kini menyokong Python dan TypeScript.

## Objektif Pembelajaran

Pada akhir pelajaran ini, anda akan dapat:

- Menggunakan server MCP melalui AI Toolkit.
- Mengkonfigurasi konfigurasi agen untuk membolehkan ia menemui dan menggunakan alat yang disediakan oleh server MCP.
- Menggunakan alat MCP melalui bahasa semula jadi.

## Pendekatan

Berikut adalah cara kita perlu mendekati ini pada tahap tinggi:

- Cipta agen dan definisikan arahan sistemnya.
- Cipta server MCP dengan alat kalkulator.
- Sambungkan Pembina Agen kepada server MCP.
- Uji pemanggilan alat agen melalui bahasa semula jadi.

Bagus, sekarang kita memahami aliran, mari kita konfigurasi agen AI untuk memanfaatkan alat luaran melalui MCP, meningkatkan kemampuannya!

## Prasyarat

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit untuk Visual Studio Code](https://aka.ms/AIToolkit)

## Latihan: Menggunakan server

Dalam latihan ini, anda akan membina, menjalankan, dan meningkatkan agen AI dengan alat dari server MCP dalam Visual Studio Code menggunakan AI Toolkit.

### -0- Langkah awal, tambahkan model OpenAI GPT-4o kepada Model Saya

Latihan ini menggunakan model **GPT-4o**. Model ini harus ditambahkan kepada **Model Saya** sebelum mencipta agen.

1. Buka sambungan **AI Toolkit** dari **Activity Bar**.
1. Dalam bahagian **Catalog**, pilih **Models** untuk membuka **Model Catalog**. Memilih **Models** membuka **Model Catalog** dalam tab editor baru.
1. Dalam bar carian **Model Catalog**, masukkan **OpenAI GPT-4o**.
1. Klik **+ Add** untuk menambah model kepada senarai **Model Saya** anda. Pastikan anda telah memilih model yang **Hosted by GitHub**.
1. Dalam **Activity Bar**, sahkan bahawa model **OpenAI GPT-4o** muncul dalam senarai.

### -1- Cipta agen

**Agent (Prompt) Builder** membolehkan anda mencipta dan menyesuaikan agen yang dikuasakan AI anda sendiri. Dalam bahagian ini, anda akan mencipta agen baru dan menetapkan model untuk menggerakkan perbualan.

1. Buka sambungan **AI Toolkit** dari **Activity Bar**.
1. Dalam bahagian **Tools**, pilih **Agent (Prompt) Builder**. Memilih **Agent (Prompt) Builder** membuka **Agent (Prompt) Builder** dalam tab editor baru.
1. Klik butang **+ New Builder**. Sambungan akan melancarkan wizard setup melalui **Command Palette**.
1. Masukkan nama **Calculator Agent** dan tekan **Enter**.
1. Dalam **Agent (Prompt) Builder**, untuk medan **Model**, pilih model **OpenAI GPT-4o (via GitHub)**.

### -2- Cipta arahan sistem untuk agen

Dengan agen telah disediakan, tiba masanya untuk menentukan personaliti dan tujuannya. Dalam bahagian ini, anda akan menggunakan ciri **Generate system prompt** untuk menerangkan tingkah laku yang diinginkan bagi agen—dalam kes ini, agen kalkulator—dan meminta model menulis arahan sistem untuk anda.

1. Untuk bahagian **Prompts**, klik butang **Generate system prompt**. Butang ini membuka pembina arahan yang menggunakan AI untuk menjana arahan sistem untuk agen.
1. Dalam tetingkap **Generate a prompt**, masukkan yang berikut: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik butang **Generate**. Pemberitahuan akan muncul di sudut kanan bawah mengesahkan bahawa arahan sistem sedang dijana. Setelah penjanaan arahan selesai, arahan akan muncul dalam medan **System prompt** di **Agent (Prompt) Builder**.
1. Tinjau **System prompt** dan ubah jika perlu.

### -3- Cipta server MCP

Sekarang anda telah menentukan arahan sistem agen anda—membimbing tingkah laku dan responsnya—masa untuk melengkapi agen dengan keupayaan praktikal. Dalam bahagian ini, anda akan mencipta server MCP kalkulator dengan alat untuk melaksanakan pengiraan penambahan, pengurangan, pendaraban, dan pembahagian. Server ini akan membolehkan agen anda melakukan operasi matematik masa nyata sebagai respons kepada arahan bahasa semula jadi.

AI Toolkit dilengkapi dengan templat untuk memudahkan penciptaan server MCP anda sendiri. Kita akan menggunakan templat Python untuk mencipta server MCP kalkulator.

*Nota*: AI Toolkit kini menyokong Python dan TypeScript.

1. Dalam bahagian **Tools** di **Agent (Prompt) Builder**, klik butang **+ MCP Server**. Sambungan akan melancarkan wizard setup melalui **Command Palette**.
1. Pilih **+ Add Server**.
1. Pilih **Create a New MCP Server**.
1. Pilih **python-weather** sebagai templat.
1. Pilih **Default folder** untuk menyimpan templat server MCP.
1. Masukkan nama berikut untuk server: **Calculator**
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

### -4- Jalankan agen dengan server MCP kalkulator

Sekarang agen anda mempunyai alat, masa untuk menggunakannya! Dalam bahagian ini, anda akan menghantar arahan kepada agen untuk menguji dan mengesahkan sama ada agen memanfaatkan alat yang sesuai dari server MCP kalkulator.

Anda akan menjalankan server MCP kalkulator pada mesin pembangunan tempatan anda melalui **Agent Builder** sebagai klien MCP.

1. Tekan `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Saya membeli 3 barang berharga $25 setiap satu, dan kemudian menggunakan diskaun $20. Berapa banyak yang saya bayar?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` nilai diberikan untuk alat **subtract**.
    - Respons dari setiap alat disediakan dalam **Tool Response** masing-masing.
    - Output akhir dari model disediakan dalam **Model Response** akhir.
1. Hantar arahan tambahan untuk menguji agen lebih lanjut. Anda boleh mengubah arahan yang sedia ada dalam medan **User prompt** dengan mengklik ke dalam medan dan menggantikan arahan yang sedia ada.
1. Setelah anda selesai menguji agen, anda boleh menghentikan server melalui **terminal** dengan memasukkan **CTRL/CMD+C** untuk berhenti.

## Tugasan

Cuba tambahkan entri alat tambahan kepada fail **server.py** anda (contohnya: kembalikan akar kuadrat nombor). Hantar arahan tambahan yang memerlukan agen memanfaatkan alat baru anda (atau alat yang sedia ada). Pastikan untuk memulakan semula server untuk memuatkan alat yang baru ditambahkan.

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Pengambilan Utama

Pengambilan utama dari bab ini adalah berikut:

- Sambungan AI Toolkit adalah klien yang hebat yang membolehkan anda menggunakan Server MCP dan alat mereka.
- Anda boleh menambah alat baru kepada server MCP, memperluaskan keupayaan agen untuk memenuhi keperluan yang berkembang.
- AI Toolkit termasuk templat (contohnya, templat server MCP Python) untuk memudahkan penciptaan alat tersuai.

## Sumber Tambahan

- [Dokumen AI Toolkit](https://aka.ms/AIToolkit/doc)

## Apa Seterusnya

Seterusnya: [Pelajaran 4 Pelaksanaan Praktikal](/04-PracticalImplementation/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.