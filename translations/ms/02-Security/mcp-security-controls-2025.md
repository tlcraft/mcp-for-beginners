<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:46:33+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "ms"
}
-->
# Kawalan Keselamatan MCP Terkini - Kemas Kini Julai 2025

Seiring dengan evolusi Model Context Protocol (MCP), keselamatan kekal sebagai aspek penting. Dokumen ini menggariskan kawalan keselamatan terkini dan amalan terbaik untuk melaksanakan MCP dengan selamat setakat Julai 2025.

## Pengesahan dan Kebenaran

### Sokongan Delegasi OAuth 2.0

Kemas kini terkini pada spesifikasi MCP kini membenarkan pelayan MCP mendelegasikan pengesahan pengguna kepada perkhidmatan luaran seperti Microsoft Entra ID. Ini meningkatkan tahap keselamatan dengan ketara melalui:

1. **Menghapuskan Pelaksanaan Pengesahan Tersuai**: Mengurangkan risiko kelemahan keselamatan dalam kod pengesahan tersuai  
2. **Memanfaatkan Penyedia Identiti Terkenal**: Mendapat manfaat daripada ciri keselamatan bertaraf perusahaan  
3. **Memusatkan Pengurusan Identiti**: Memudahkan pengurusan kitaran hayat pengguna dan kawalan akses  

## Pencegahan Penyaluran Token

Spesifikasi Kebenaran MCP secara jelas melarang penyaluran token untuk mengelakkan pengelakan kawalan keselamatan dan isu tanggungjawab.

### Keperluan Utama

1. **Pelayan MCP TIDAK BOLEH menerima token yang tidak dikeluarkan untuk mereka**: Sahkan bahawa semua token mempunyai tuntutan audiens yang betul  
2. **Laksanakan pengesahan token yang betul**: Semak penerbit, audiens, tarikh luput, dan tandatangan  
3. **Gunakan pengeluaran token berasingan**: Keluarkan token baru untuk perkhidmatan hiliran dan bukannya menyalurkan token sedia ada  

## Pengurusan Sesi Selamat

Untuk mengelakkan serangan rampasan dan penetapan sesi, laksanakan kawalan berikut:

1. **Gunakan ID sesi yang selamat dan tidak deterministik**: Dijana dengan penjana nombor rawak yang selamat secara kriptografi  
2. **Pautkan sesi dengan identiti pengguna**: Gabungkan ID sesi dengan maklumat khusus pengguna  
3. **Laksanakan putaran sesi yang betul**: Selepas perubahan pengesahan atau peningkatan keistimewaan  
4. **Tetapkan masa tamat sesi yang sesuai**: Seimbangkan keselamatan dengan pengalaman pengguna  

## Pengasingan Pelaksanaan Alat

Untuk mengelakkan pergerakan sisi dan mengandungi kemungkinan kompromi:

1. **Asingkan persekitaran pelaksanaan alat**: Gunakan kontena atau proses berasingan  
2. **Terapkan had sumber**: Elakkan serangan kehabisan sumber  
3. **Laksanakan akses keistimewaan minimum**: Berikan hanya kebenaran yang diperlukan  
4. **Pantau corak pelaksanaan**: Kenal pasti tingkah laku luar biasa  

## Perlindungan Definisi Alat

Untuk mengelakkan pencemaran alat:

1. **Sahkan definisi alat sebelum digunakan**: Periksa arahan berniat jahat atau corak yang tidak sesuai  
2. **Gunakan pengesahan integriti**: Hash atau tandatangani definisi alat untuk mengesan perubahan tanpa kebenaran  
3. **Laksanakan pemantauan perubahan**: Beri amaran tentang pengubahsuaian metadata alat yang tidak dijangka  
4. **Kawalan versi definisi alat**: Jejak perubahan dan benarkan pemulihan jika perlu  

Kawalan ini berfungsi bersama untuk mewujudkan tahap keselamatan yang kukuh bagi pelaksanaan MCP, menangani cabaran unik sistem berasaskan AI sambil mengekalkan amalan keselamatan tradisional yang teguh.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.