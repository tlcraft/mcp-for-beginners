<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:23:06+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "mo"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) iku solusi referensi lengkap sing dikembangake dening Microsoft sing nuduhake cara mbangun aplikasi perencanaan perjalanan kanthi multi-agent, didhukung AI nggunakake Model Context Protocol (MCP), Azure OpenAI, lan Azure AI Search. Proyek iki nampilake praktik paling apik kanggo ngatur sawetara agen AI, nggabungake data perusahaan, lan nyedhiyakake platform sing aman lan bisa dikembangake kanggo skenario nyata.

## Key Features
- **Orkestrasi Multi-Agen:** Nggunakake MCP kanggo ngkoordinasi agen khusus (kayata, agen penerbangan, hotel, lan itinerary) sing kolaborasi kanggo ngrampungake tugas perencanaan perjalanan sing rumit.
- **Integrasi Data Perusahaan:** Nyambungake menyang Azure AI Search lan sumber data perusahaan liyane kanggo nyedhiyakake informasi sing paling anyar lan relevan kanggo rekomendasi perjalanan.
- **Arsitektur Aman lan Bisa Dikembangake:** Nggunakake layanan Azure kanggo otentikasi, otorisasi, lan panggelaran sing bisa dikembangake, ngetutake praktik keamanan perusahaan sing paling apik.
- **Alat yang Bisa Dikembangake:** Nggimplementasi alat MCP sing bisa digunakake maneh lan template prompt, ngidini adaptasi cepet kanggo domain anyar utawa syarat bisnis.
- **Pengalaman Pengguna:** Nyedhiyakake antarmuka obrolan kanggo pangguna supaya bisa berinteraksi karo agen perjalanan, didhukung dening Azure OpenAI lan MCP.

## Architecture
![Architecture](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Architecture Diagram Description

Solusi Azure AI Travel Agents dirancang kanggo modularitas, skalabilitas, lan integrasi aman saka sawetara agen AI lan sumber data perusahaan. Komponen utama lan aliran data yaiku:

- **Antarmuka Pengguna:** Pangguna berinteraksi karo sistem liwat UI obrolan (kayata obrolan web utawa bot Teams), sing ngirim pitakon pangguna lan nampa rekomendasi perjalanan.
- **MCP Server:** Tumindak minangka orkestrator pusat, nampa input pangguna, ngatur konteks, lan ngkoordinasi tindakan agen khusus (kayata, FlightAgent, HotelAgent, ItineraryAgent) liwat Model Context Protocol.
- **AI Agents:** Saben agen tanggung jawab kanggo domain tartamtu (penerbangan, hotel, itinerary) lan diimplementasikan minangka alat MCP. Agen nggunakake template prompt lan logika kanggo ngolah panjalukan lan ngasilake tanggapan.
- **Azure OpenAI Service:** Nyedhiyakake pemahaman lan generasi bahasa alami sing canggih, ngidini agen kanggo nginterpretasi maksud pangguna lan ngasilake tanggapan obrolan.
- **Azure AI Search & Enterprise Data:** Agen nanya Azure AI Search lan sumber data perusahaan liyane kanggo njupuk informasi paling anyar babagan penerbangan, hotel, lan opsi perjalanan.
- **Otensikasi & Keamanan:** Nggintegrasi karo Microsoft Entra ID kanggo otentikasi aman lan ngetrapake kontrol akses hak istimewa paling cilik kanggo kabeh sumber daya.
- **Panggelaran:** Dirancang kanggo panggelaran ing Azure Container Apps, njamin skalabilitas, pemantauan, lan efisiensi operasional.

Arsitektur iki ngidini orkestrasi seamless saka sawetara agen AI, integrasi aman karo data perusahaan, lan platform sing kuat lan bisa dikembangake kanggo mbangun solusi AI khusus domain.

## Step-by-Step Explanation of the Architecture Diagram
Bayangake ngrancang perjalanan gedhe lan duwe tim asisten ahli sing mbantu sampeyan ing saben detail. Sistem Azure AI Travel Agents kerjane kanthi cara sing padha, nggunakake bagean sing beda (kayata anggota tim) sing saben duwe tugas khusus. Iki carane kabeh pas bareng:

### Antarmuka Pengguna (UI):
Anggep iki minangka meja depan agen perjalanan sampeyan. Iki panggonan sampeyan (pangguna) takon utawa nggawe panjalukan, kayata "Temokake aku penerbangan menyang Paris." Iki bisa dadi jendela obrolan ing situs web utawa aplikasi olahpesan.

### MCP Server (Koordinator):
MCP Server kaya manajer sing ngrungokake panjalukan sampeyan ing meja depan lan mutusake spesialis sing kudu nangani saben bagean. Iki nglacak obrolan sampeyan lan mesthekake kabeh mlaku kanthi lancar.

### AI Agents (Asisten Spesialis):
Saben agen iku ahli ing wilayah tartamtu—siji ngerti kabeh babagan penerbangan, liyane babagan hotel, lan liyane babagan ngrancang itinerary sampeyan. Nalika sampeyan takon kanggo perjalanan, MCP Server ngirim panjalukan sampeyan menyang agen sing bener. Agen kasebut nggunakake kawruh lan alat kanggo nemokake pilihan sing paling apik kanggo sampeyan.

### Azure OpenAI Service (Ahli Bahasa):
Iki kaya duwe ahli bahasa sing ngerti persis apa sing sampeyan takon, ora ketompo carane sampeyan ngucapake. Iki mbantu agen ngerti panjalukan sampeyan lan nanggapi ing basa obrolan alami.

### Azure AI Search & Enterprise Data (Perpustakaan Informasi):
Bayangake perpustakaan gedhe, paling anyar karo kabeh info perjalanan paling anyar—jadwal penerbangan, kasedhiyan hotel, lan liya-liyane. Agen nelusuri perpustakaan iki kanggo entuk jawaban sing paling akurat kanggo sampeyan.

### Otensikasi & Keamanan (Penjaga Keamanan):
Kaya penjaga keamanan mriksa sapa sing bisa mlebu wilayah tartamtu, bagean iki mesthekake mung wong lan agen sing sah bisa ngakses informasi sensitif. Iki njaga data sampeyan aman lan pribadi.

### Panggelaran ing Azure Container Apps (Bangunan):
Kabeh asisten lan alat iki bisa digunakake bebarengan ing bangunan sing aman lan bisa dikembangake (awan). Iki tegese sistem bisa nangani akeh pangguna sekaligus lan mesthi kasedhiya nalika sampeyan butuh.

## How it all works together:

Sampeyan miwiti kanthi takon ing meja depan (UI).
Manajer (MCP Server) nemtokake spesialis (agen) sing kudu mbantu sampeyan.
Spesialis nggunakake ahli bahasa (OpenAI) kanggo ngerti panjalukan sampeyan lan perpustakaan (AI Search) kanggo nemokake jawaban paling apik.
Penjaga keamanan (Otensikasi) mesthekake kabeh aman.
Kabeh iki kedadeyan ing bangunan sing bisa dipercaya lan bisa dikembangake (Azure Container Apps), supaya pengalaman sampeyan lancar lan aman.
Kerja tim iki ngidini sistem kanthi cepet lan aman mbantu sampeyan ngrancang perjalanan, kaya tim agen perjalanan ahli sing kerja bareng ing kantor modern!

## Technical Implementation
- **MCP Server:** Ngguwatake logika orkestrasi inti, ngekspos alat agen, lan ngatur konteks kanggo alur kerja perencanaan perjalanan multi-langkah.
- **Agen:** Saben agen (kayata, FlightAgent, HotelAgent) diimplementasikan minangka alat MCP kanthi template prompt lan logika dhewe.
- **Integrasi Azure:** Nggunakake Azure OpenAI kanggo pemahaman bahasa alami lan Azure AI Search kanggo njupuk data.
- **Keamanan:** Nggintegrasi karo Microsoft Entra ID kanggo otentikasi lan ngetrapake kontrol akses hak istimewa paling cilik kanggo kabeh sumber daya.
- **Panggelaran:** Ndhukung panggelaran menyang Azure Container Apps kanggo skalabilitas lan efisiensi operasional.

## Results and Impact
- Nampilake cara MCP bisa digunakake kanggo ngatur sawetara agen AI ing skenario produksi nyata.
- Nggcepitake pangembangan solusi kanthi nyedhiyakake pola sing bisa digunakake maneh kanggo koordinasi agen, integrasi data, lan panggelaran aman.
- Tumindak minangka blueprint kanggo mbangun aplikasi AI khusus domain nggunakake MCP lan layanan Azure.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

It seems there might be a misunderstanding. "Mo" is not recognized as a language code or a specific language. If you meant a specific language, could you please clarify which one? This way, I can assist you more accurately with the translation.