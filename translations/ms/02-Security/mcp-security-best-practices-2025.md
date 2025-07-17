<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:54:35+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "ms"
}
-->
# MCP Amalan Terbaik Keselamatan - Kemas Kini Julai 2025

## Amalan Terbaik Keselamatan Menyeluruh untuk Pelaksanaan MCP

Apabila bekerja dengan pelayan MCP, ikuti amalan terbaik keselamatan ini untuk melindungi data, infrastruktur, dan pengguna anda:

1. **Pengesahan Input**: Sentiasa sahkan dan bersihkan input untuk mengelakkan serangan suntikan dan masalah confused deputy.
   - Laksanakan pengesahan ketat untuk semua parameter alat
   - Gunakan pengesahan skema untuk memastikan permintaan mematuhi format yang dijangka
   - Tapis kandungan yang berpotensi berbahaya sebelum pemprosesan

2. **Kawalan Akses**: Laksanakan pengesahan dan kebenaran yang betul untuk pelayan MCP anda dengan kebenaran terperinci.
   - Gunakan OAuth 2.0 dengan penyedia identiti yang diiktiraf seperti Microsoft Entra ID
   - Laksanakan kawalan akses berasaskan peranan (RBAC) untuk alat MCP
   - Jangan sekali-kali melaksanakan pengesahan tersuai apabila penyelesaian sedia ada tersedia

3. **Komunikasi Selamat**: Gunakan HTTPS/TLS untuk semua komunikasi dengan pelayan MCP anda dan pertimbangkan menambah penyulitan tambahan untuk data sensitif.
   - Konfigurasikan TLS 1.3 jika boleh
   - Laksanakan pin sijil untuk sambungan kritikal
   - Putar sijil secara berkala dan sahkan kesahihannya

4. **Had Kadar**: Laksanakan had kadar untuk mengelakkan penyalahgunaan, serangan DoS, dan mengurus penggunaan sumber.
   - Tetapkan had permintaan yang sesuai berdasarkan corak penggunaan yang dijangka
   - Laksanakan tindak balas berperingkat untuk permintaan berlebihan
   - Pertimbangkan had kadar khusus pengguna berdasarkan status pengesahan

5. **Pencatatan dan Pemantauan**: Pantau pelayan MCP anda untuk aktiviti mencurigakan dan laksanakan jejak audit menyeluruh.
   - Catat semua percubaan pengesahan dan panggilan alat
   - Laksanakan amaran masa nyata untuk corak mencurigakan
   - Pastikan log disimpan dengan selamat dan tidak boleh diubah suai

6. **Penyimpanan Selamat**: Lindungi data sensitif dan kelayakan dengan penyulitan yang betul semasa penyimpanan.
   - Gunakan peti kunci atau storan kelayakan selamat untuk semua rahsia
   - Laksanakan penyulitan peringkat medan untuk data sensitif
   - Putar kunci penyulitan dan kelayakan secara berkala

7. **Pengurusan Token**: Elakkan kelemahan token passthrough dengan mengesahkan dan membersihkan semua input dan output model.
   - Laksanakan pengesahan token berdasarkan tuntutan audiens
   - Jangan terima token yang tidak dikeluarkan secara eksplisit untuk pelayan MCP anda
   - Laksanakan pengurusan hayat token dan putaran yang betul

8. **Pengurusan Sesi**: Laksanakan pengendalian sesi yang selamat untuk mengelakkan pembajakan dan serangan penetapan sesi.
   - Gunakan ID sesi yang selamat dan tidak deterministik
   - Ikat sesi kepada maklumat khusus pengguna
   - Laksanakan tamat tempoh dan putaran sesi yang betul

9. **Sandboxing Pelaksanaan Alat**: Jalankan pelaksanaan alat dalam persekitaran terasing untuk mengelakkan pergerakan sisi jika dikompromi.
   - Laksanakan pengasingan kontena untuk pelaksanaan alat
   - Gunakan had sumber untuk mengelakkan serangan keletihan sumber
   - Gunakan konteks pelaksanaan berasingan untuk domain keselamatan yang berbeza

10. **Audit Keselamatan Berkala**: Jalankan semakan keselamatan berkala untuk pelaksanaan MCP dan kebergantungan anda.
    - Jadualkan ujian penembusan secara berkala
    - Gunakan alat imbasan automatik untuk mengesan kelemahan
    - Kemas kini kebergantungan untuk menangani isu keselamatan yang diketahui

11. **Penapisan Keselamatan Kandungan**: Laksanakan penapis keselamatan kandungan untuk input dan output.
    - Gunakan Azure Content Safety atau perkhidmatan serupa untuk mengesan kandungan berbahaya
    - Laksanakan teknik pelindung prompt untuk mengelakkan suntikan prompt
    - Imbas kandungan yang dijana untuk kebocoran data sensitif yang berpotensi

12. **Keselamatan Rantaian Bekalan**: Sahkan integriti dan keaslian semua komponen dalam rantaian bekalan AI anda.
    - Gunakan pakej bertandatangan dan sahkan tandatangan
    - Laksanakan analisis bil bahan perisian (SBOM)
    - Pantau kemas kini berniat jahat pada kebergantungan

13. **Perlindungan Definisi Alat**: Elakkan pencemaran alat dengan mengamankan definisi dan metadata alat.
    - Sahkan definisi alat sebelum digunakan
    - Pantau perubahan tidak dijangka pada metadata alat
    - Laksanakan pemeriksaan integriti untuk definisi alat

14. **Pemantauan Pelaksanaan Dinamik**: Pantau tingkah laku masa nyata pelayan MCP dan alat.
    - Laksanakan analisis tingkah laku untuk mengesan anomali
    - Tetapkan amaran untuk corak pelaksanaan yang tidak dijangka
    - Gunakan teknik perlindungan kendiri aplikasi masa nyata (RASP)

15. **Prinsip Hak Istimewa Paling Minimum**: Pastikan pelayan MCP dan alat beroperasi dengan kebenaran minimum yang diperlukan.
    - Berikan hanya kebenaran khusus yang diperlukan untuk setiap operasi
    - Semak dan audit penggunaan kebenaran secara berkala
    - Laksanakan akses tepat pada masanya untuk fungsi pentadbiran

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.